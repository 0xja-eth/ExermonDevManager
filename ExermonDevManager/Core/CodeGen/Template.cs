using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExermonDevManager.Core.CodeGen {

	using Config;

	using Data;
	using Managers;

	using Utils;

	/// <summary>
	/// 代码模板类
	/// </summary>
	public class CodeTemplate : CoreData {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("路径", 10)]
		public string path { get; set; }

		/// <summary>
		/// 其他变量
		/// </summary>
		public string content; // 内容
		int pointer = 0; // 指针

		/// <summary>
		/// 是否已分析
		/// </summary>
		public bool isParsed { get; protected set; } = false;

		/// <summary>
		/// 分析器
		/// </summary>
		RootParser parser = new RootParser();

		/// <summary>
		/// 构造函数
		/// </summary>
		public CodeTemplate(string path) : 
			base(TemplateManager.path2Name(path)) {
			this.path = TemplateManager.name2File(path);
			load();
		}

		/// <summary>
		/// 组名
		/// </summary>
		/// <returns></returns>
		public override string groupText() {
			return name.Split('.')[0];
		}

		/// <summary>
		/// 读取文本
		/// </summary>
		void load() {
			content = StorageManager.loadDataFromFile(path);
		}

		/// <summary>
		/// 获取目录路径
		/// </summary>
		/// <returns></returns>
		public string getDir() { return Path.GetDirectoryName(path); }

		/// <summary>
		/// 获得当前字符
		/// </summary>
		/// <returns></returns>
		public char getChar() {
			if (content == null || pointer < 0 || 
				pointer >= content.Length) return '\0';
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
		/// 切换并获取上一个字符
		/// </summary>
		/// <returns></returns>
		public char prevChar() {
			pointer--; return getChar();
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
		public Parser parse() {
			if (!isParsed) {
				parser.parse(this);
				isParsed = true;
			}
			return parser;
		}

		/// <summary>
		/// 结果
		/// </summary>
		public Block output() {
			return parse()?.output();
		}

	}
	
	/// <summary>
	/// 生成的代码
	/// </summary>
	public class GeneratedCode : CoreData {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("路径", 10, 192)]
		public string path { get; set; }
		[AutoConvert]
		[ControlField("语言", 20, 64)]
		public string language { get; set; }
		[AutoConvert]
		public string code { get; set; } = "";

		/// <summary>
		/// 模板ID
		/// </summary>
		[AutoConvert]
		public int templateId { get; set; }

		/// <summary>
		/// 是否需要ID
		/// </summary>
		protected override bool idEnable() { return false; }

		/// <summary>
		/// 不显示的字段
		/// </summary>
		/// <returns></returns>
		protected new static string[] listExclude() {
			return new string[] { "name", "description", "buildIn" };
		}

		/// <summary>
		/// 组键
		/// </summary>
		/// <returns></returns>
		public override string groupKey() {
			return template().id.ToString();
		}

		/// <summary>
		/// 获取模板实例
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<CodeTemplate> template_ = null;
		protected CodeTemplate _template_() {
			return poolGet<CodeTemplate>(templateId);
		}
		public CodeTemplate template() {
			return template_?.value();
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		public GeneratedCode() { }
		public GeneratedCode(string language, string path,
			CodeTemplate template) {
			this.language = language; this.path = path;
			templateId = template.id;
		}
	}

	/// <summary>
	/// 代码生成器
	/// </summary>
	public class CodeGenerator {

		/// <summary>
		/// 当前生成器
		/// </summary>
		public static CodeGenerator current = null;

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
			config[key] = value;
		}

		/// <summary>
		/// 清空配置内容
		/// </summary>
		/// <returns></returns>
		public void clearConfig() {
			config.Clear();
		}

		/// <summary>
		/// 语言
		/// </summary>
		/// <returns></returns>
		public string langName() { return getConfig("language"); }

		/// <summary>
		/// 语言实例
		/// </summary>
		/// <returns></returns>
		public ILanguage language() {
			return LanguageManager.getLanguage(langName());
		}

		/// <summary>
		/// 生成路径
		/// </summary>
		/// <returns></returns>
		public string genPath() { return getConfig("gen_path"); }

		#endregion

		#region 生成相关

		/// <summary>
		/// 代码字典（文件路径-代码映射）
		/// </summary>
		public List<GeneratedCode> codes = new List<GeneratedCode>();

		/// <summary>
		/// 总代码
		/// </summary>
		public string sumCode = "";

		/// <summary>
		/// 代码生成控制
		/// </summary>
		public bool genTagCode = false;
		public bool loopBreak = false;

		/// <summary>
		/// 能否生成代码
		/// </summary>
		/// <returns></returns>
		bool genEnable() { return !genTagCode && !loopBreak; }

		/// <summary>
		/// 添加生成的代码
		/// </summary>
		/// <param name="code"></param>
		public string addCode(string code, int indent = 0) {
			if (!genEnable()) return "";

			string path = genPath(), lang = langName();
			if (!string.IsNullOrEmpty(path)) {
				//Console.WriteLine(code + ": (" + indent + ")" + 
				//	(new System.Diagnostics.StackTrace()).ToString());

				var exportedCode = getOrCreateCode(lang, path);
				exportedCode.code = addCodeWithIndent(
					exportedCode.code, code, indent);
			}
			sumCode += code; return code;
		}

		/// <summary>
		/// 移除代码
		/// </summary>
		/// <param name="cnt">最后几位的代码</param>
		/// <returns></returns>
		public void removeCode(int cnt) {
			string path = genPath(), lang = langName();
			if (!string.IsNullOrEmpty(path)) {
				var exportedCode = getOrCreateCode(lang, path);
				exportedCode.code = removeStr(
					exportedCode.code, cnt);
			}
			sumCode = removeStr(sumCode, cnt);
		}

		/// <summary>
		/// 移除字符串
		/// </summary>
		/// <returns></returns>
		string removeStr(string str, int cnt) {
			var len = str.Length;
			if (len <= cnt) return "";
			return str.Substring(0, len - cnt);
		}

		/// <summary>
		/// 添加缩进
		/// </summary>
		/// <param name="oriCode">原始代码</param>
		/// <param name="newCode">新代码</param>
		/// <param name="indent">缩进</param>
		/// <returns></returns>
		string addCodeWithIndent(string oriCode, 
			string newCode, int indent = 1) {
			if (indent <= 0) return oriCode + newCode;

			var lines = Regex.Split(newCode, "\r\n");
			var indentStr = "";
			for (int i = 0; i < indent; ++i)
				indentStr += "\t";

			for (int i = 1; i < lines.Length; ++i)
				lines[i] = indentStr + lines[i];

			newCode = string.Join("\r\n", lines);
			return oriCode + newCode;
		}

		/// <summary>
		/// 创建代码
		/// </summary>
		/// <param name="language"></param>
		/// <param name="path"></param>
		GeneratedCode getOrCreateCode(string language, string path) {
			var code = codes.Find(c => c.path == path);
			if (code == null) {
				code = new GeneratedCode(language, path, template);
				codes.Add(code);
			}
			
			return code;
		}

		/// <summary>
		/// 生成
		/// </summary>
		public string generate() {
			beforeGenerate();
			doGenerate();
			afterGenerate();

			return sumCode;
		}

		/// <summary>
		/// 生成前
		/// </summary>
		void beforeGenerate() {
			clearConfig(); codes.Clear();
			current = this; // 设置当前生成器
			sumCode = "";
		}

		/// <summary>
		/// 执行生成
		/// </summary>
		void doGenerate() {
			var block = template.output();
			block.setupGenerator(this);
			block.setData(data); block.genCode();
		}

		/// <summary>
		/// 生成后
		/// </summary>
		void afterGenerate() {
			current = null; // 重置当前生成器
		}

		/// <summary>
		/// 保存到文件
		/// </summary>
		public void save() {
			foreach(var item in codes) {
				string path = item.path, code = item.code;
				StorageManager.saveDataIntoFile(code, path);
			}
		}

		#endregion
	}
	
}
