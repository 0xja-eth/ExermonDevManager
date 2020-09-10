﻿using System;
using System.IO;
using System.Collections.Generic;

namespace ExermonDevManager.Scripts.CodeGen {

	using Data;

	/// <summary>
	/// 代码模板类
	/// </summary>
	public class CodeTemplate : CoreData {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("路径")]
		public string path { get; set; }

		/// <summary>
		/// 内部参数
		/// </summary>
		string content; // 内容
		int pointer = 0; // 指针

		public bool isParsed = false;

		/// <summary>
		/// 分析器
		/// </summary>
		RootParser parser = new RootParser();

		/// <summary>
		/// 构造函数
		/// </summary>
		public CodeTemplate(string name) : base(name) {
			path = TemplateManager.RootPath + name; load();
		}

		/// <summary>
		/// 读取文本
		/// </summary>
		void load() {
			content = StorageManager.loadDataFromFile(path);
		}

		/// <summary>
		/// 获得当前字符
		/// </summary>
		/// <returns></returns>
		public char getChar() {
			if (content == null) return '\0';
			if (pointer >= content.Length) return '\0';
			return content[pointer];
		}

		/// <summary>
		/// 切换并获取下一个字符
		/// </summary>
		/// <returns></returns>
		public char nextChar() {
			pointer++; return getChar();
		}

		/// <summary>
		/// 指针到达内容末尾
		/// </summary>
		/// <returns></returns>
		public bool isEnd() {
			return pointer >= content.Length;
		}

		/// <summary>
		/// 分析
		/// </summary>
		public void parse() {
			if (isParsed) return;
			parser.parse(this);
			isParsed = true;
		}

		/// <summary>
		/// 结果
		/// </summary>
		public Block output() {
			if (!isParsed) parse();
			return parser.output();
		}

	}

	/// <summary>
	/// 代码生成器
	/// </summary>
	public class CodeGenerator {

		/// <summary>
		/// 模板
		/// </summary>
		CodeTemplate template;

		/// <summary>
		/// 原始数据
		/// </summary>
		public object data = null;

		/// <summary>
		/// 全局数据字典（对原始数据的补充）
		/// </summary>
		Dictionary<string, object> globalData = new Dictionary<string, object>();

		/// <summary>
		/// 生成配置
		/// </summary>
		Dictionary<string, string> config = new Dictionary<string, string>();

		/// <summary>
		/// 当前生成代码
		/// </summary>
		string code = "";

		/// <summary>
		/// 构造函数
		/// </summary>
		public CodeGenerator(CodeTemplate template, object data = null) {
			this.template = template; this.data = data;
		}

		#region 数据相关

		/// <summary>
		/// 添加数据
		/// </summary>
		/// <param name="key"></param>
		/// <param name="data"></param>
		public void addData(string key, object data) {
			globalData[key] = data;
		}

		/// <summary>
		/// 获取数据
		/// </summary>
		/// <param name="key"></param>
		/// <param name="data"></param>
		public object getData(string key) {
			return globalData.ContainsKey(key) ? 
				globalData[key] : null;
		}

		#endregion

		#region 配置相关

		/// <summary>
		/// 获取配置内容
		/// </summary>
		/// <param name="key">键</param>
		/// <param name="default_">默认值</param>
		/// <returns></returns>
		public string getConfig(string key, string default_ = "") {
			if (config.ContainsKey(key)) return config[key];
			return default_;
		}

		/// <summary>
		/// 获取配置内容
		/// </summary>
		/// <param name="key">键</param>
		/// <param name="value">设定值</param>
		/// <returns></returns>
		public void setConfig(string key, string value) {
			//var oldVal = getConfig(key);
			config[key] = value;
			//if (callbacks.ContainsKey(key))
			//	callbacks[key]?.Invoke(oldVal, value);
		}

		/// <summary>
		/// 语言
		/// </summary>
		/// <returns></returns>
		public string language() { return getConfig("language"); }

		/// <summary>
		/// 生成路径
		/// </summary>
		/// <returns></returns>
		public string genPath() { return getConfig("gen_path"); }

		//#region 配置监听

		///// <summary>
		///// 配置改变回调字典
		///// </summary>
		//Dictionary<string, Action<string, string>> callbacks =
		//	new Dictionary<string, Action<string, string>>();

		///// <summary>
		///// 生成路径改变回调
		///// </summary>
		//void onGenPathChanged(string old, string new_) {
		//	if (!string.IsNullOrEmpty(old) && !string.IsNullOrEmpty(new_)) {
		//		StorageManager.saveDataIntoFile(code, old);
		//		code = "";
		//	}
		//}

		//#endregion

		#endregion

		#region 生成相关

		/// <summary>
		/// 代码字典（文件路径-代码映射）
		/// </summary>
		public Dictionary<string, string> codes = new Dictionary<string, string>();

		/// <summary>
		/// 添加生成的代码
		/// </summary>
		/// <param name="code"></param>
		public void addCode(string code) {
			var path = genPath();
			if (string.IsNullOrEmpty(path)) return;
			if (codes.ContainsKey(path))
				codes[path] += code;
			else
				codes[path] = code;
		}

		/// <summary>
		/// 生成
		/// </summary>
		public void generate() {
			var block = template.output();
			block.setupGenerator(this);
			block.genCode();
		}

		/// <summary>
		/// 保存到文件
		/// </summary>
		public void save() {
			foreach(var item in codes) {
				string path = item.Key, code = item.Value;
				StorageManager.saveDataIntoFile(code, path);
			}
		}

		#endregion

	}

	/// <summary>
	/// 数据生成管理
	/// </summary>
	public static class GenerateManager<T> where T : CoreData {

		/// <summary>
		/// 全局数据模板ID
		/// </summary>
		public static int globalTemplateId = -1;

		/// <summary>
		/// 其他模板（预览用）ID字典
		/// </summary>
		public static Dictionary<string, int> templateIds = new Dictionary<string, int>();

		/// <summary>
		/// 获取数据类型
		/// </summary>
		/// <returns></returns>
		public static Type getDataType() { return typeof(T); }

		/// <summary>
		/// 获取数据
		/// </summary>
		/// <returns></returns>
		public static List<T> getData() { return BaseData.poolGet<T>(); }

		#region 模板相关

		/// <summary>
		/// 设置全局模板
		/// </summary>
		/// <param name="template"></param>
		public static void setGlobalTemplate(CodeTemplate template) {
			globalTemplateId = template.id;
		}

		/// <summary>
		/// 添加模板
		/// </summary>
		/// <param name="template"></param>
		public static void addTemplate(string name, CodeTemplate template) {
			templateIds[name] = template.id;
		}

		/// <summary>
		/// 获取模板实例
		/// </summary>
		/// <returns></returns>
		public static CodeTemplate globalTemplate() {
			return BaseData.poolGet<CodeTemplate>(globalTemplateId);
		}

		/// <summary>
		/// 获取模板实例
		/// </summary>
		/// <returns></returns>
		public static CodeTemplate template(string name) {
			if (templateIds.ContainsKey(name)) {
				var id = templateIds[name];
				return BaseData.poolGet<CodeTemplate>(id);
			}
			return null;
		}

		#endregion

		#region 生成器相关

		/// <summary>
		/// 获取所有生成器
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static List<CodeGenerator> generators(int id) {
			return generators(BaseData.poolGet<T>(id));
		}
		public static List<CodeGenerator> generators(T data) {
			var res = new List<CodeGenerator>();
			foreach (var item in templateIds)
				res.Add(generator(item.Key, data));
			return res;
		}

		/// <summary>
		/// 单数据代码生成器
		/// </summary>
		/// <returns></returns>
		public static CodeGenerator generator(string name, int id) {
			return generator(name, BaseData.poolGet<T>(id));
		}
		public static CodeGenerator generator(string name, T data) {
			var template = GenerateManager<T>.template(name);
			if (template == null) return null;

			var generator = new CodeGenerator(template, data);
			setupGlobalData(generator);

			return generator;
		}

		/// <summary>
		/// 总代码生成器
		/// </summary>
		/// <returns></returns>
		public static CodeGenerator globalGenerator() {
			var template = globalTemplate();
			if (template == null) return null;
			var generator = new CodeGenerator(template);
			setupGlobalData(generator);

			return generator;
		}

		/// <summary>
		/// 配置全局生成数据
		/// </summary>
		/// <param name="generator"></param>
		static void setupGlobalData(CodeGenerator generator) {
			foreach (var type in DataManager.dataTypes) {
				var attrName = getTypeAttrName(type);
				var data = BaseData.poolGet(type);
				generator.addData(attrName, data);
			}
		}

		/// <summary>
		/// 获取类型的属性名
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		static string getTypeAttrName(Type type) {
			var res = "";
			foreach (var c in type.Name)
				if (char.IsLetter(c)) res += char.ToLower(c);
			return res + "s";
		}

		#endregion
	}

	/// <summary>
	/// 模板系统
	/// </summary>
	public static class TemplateManager {

		/// <summary>
		/// 路径常量定义
		/// </summary>
		public static readonly string RootPath = "./templates/";

		/// <summary>
		/// 文件名格式
		/// </summary>
		static readonly string FileNameFormat = "{0}s.t";
		
		/// <summary>
		/// 模板库
		/// </summary>
		static Dictionary<string, int> templates = new Dictionary<string, int>();

		/// <summary>
		/// 初始化
		/// </summary>
		public static void initialize() {
			loadAllTemplates();
			addDefaultTemplates();
		}

		/// <summary>
		/// 添加预设的模板
		/// </summary>
		static void addDefaultTemplates() {
			addTemplate<ReqResInterface>();
		}

		/// <summary>
		/// 读取全部模板
		/// </summary>
		public static void loadAllTemplates() {
			var root = new DirectoryInfo(RootPath);
			var files = root.GetFiles("*.t");
			foreach (var file in files)
				loadTemplate(file.Name);
		}

		/// <summary>
		/// 读取模板
		/// </summary>
		/// <param name="name">文件名</param>
		/// <returns></returns>
		public static CodeTemplate loadTemplate(string name) {
			var template = new CodeTemplate(name);
			templates[name] = template.id;
			//template.parse();
			return template;
		}

		/// <summary>
		/// 添加模板
		/// </summary>
		/// <typeparam name="T">对应类型</typeparam>
		/// <param name="name">模板名称</param>
		public static void addTemplate<T>(string name = null) where T : CoreData {
			var type = typeof(T);
			if (string.IsNullOrEmpty(name))
				name = string.Format(FileNameFormat, type.Name);

			var template = getTemplate(name);
			GenerateManager<T>.setGlobalTemplate(template);
		}

		/// <summary>
		/// 读取模板
		/// </summary>
		/// <param name="name">文件名</param>
		/// <returns></returns>
		public static CodeTemplate getTemplate(string name) {
			if (templates.ContainsKey(name)) {
				var id = templates[name];
				return BaseData.poolGet<CodeTemplate>(id);
			}
			return null;
		}
		public static CodeTemplate getTemplate<T>() where T : CoreData {
			return GenerateManager<T>.globalTemplate();
		}

		///// <summary>
		///// 创建生成器
		///// </summary>
		///// <returns></returns>
		//public static CodeGenerator createGenerator<T>() where T : ControlData {
		//	return new CodeGenerator(getTemplate<T>());
		//}
		//public static CodeGenerator createGenerator(Type type) {
		//	return new CodeGenerator(getTemplate(type));
		//}
	}
}
