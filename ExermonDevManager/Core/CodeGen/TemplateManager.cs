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
	/// 模板项
	/// </summary>
	public class TemplateItem : CoreData {

		/// <summary>
		/// 常量定义
		/// </summary>
		const string GlobalName = "Global";
		const string GlobalDescription = "用于实际生成代码的模板";

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public string description { get; protected set; } = "";
		[AutoConvert]
		public bool isGlobal { get; protected set; }
		[AutoConvert]
		public int type { get; protected set; }
		[AutoConvert]
		public int templateId { get; protected set; }

		/// <summary>
		/// 枚举类型
		/// </summary>
		public Type enumType;

		/// <summary>
		/// 构造函数
		/// </summary>
		public TemplateItem() { }
		public TemplateItem(CodeTemplate template, string desc = GlobalDescription) {
			isGlobal = true;
			templateId = template.id;
			description = desc;
		}
		public TemplateItem(Enum type, CodeTemplate template, string desc = "") {
			enumType = type.GetType();
			this.type = type.GetHashCode();
			templateId = template.id;
			description = desc;
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

		#region 显示项

		/// <summary>
		/// 不显示的字段
		/// </summary>
		/// <returns></returns>
		protected static new string[] listExclude() {
			return new string[] { "name", "buildIn" };
		}

		/// <summary>
		/// 类型名
		/// </summary>
		/// <returns></returns>
		[ControlField("类型", 0)]
		public string typeName() {
			if (isGlobal) return GlobalName;
			if (enumType == null) return "";
			return Enum.GetName(enumType, type);
		}

		/// <summary>
		/// 模板路径
		/// </summary>
		/// <returns></returns>
		[ControlField("路径", 1)]
		public string templatePath() {
			return template()?.path;
		}

		#endregion

	}

	/// <summary>
	/// 数据生成管理基类
	/// </summary>
	public interface IGenerateManager {

		/// <summary>
		/// 获取数据类型
		/// </summary>
		/// <returns></returns>
		Type getDataType();

		/// <summary>
		/// 获取所有模板
		/// </summary>
		/// <returns></returns>
		List<TemplateItem> getTemplateItems();

		#region 模板相关

		/// <summary>
		/// 设置全局模板
		/// </summary>
		/// <param name="template"></param>
		void setGlobalTemplate(CodeTemplate template);

		/// <summary>
		/// 添加模板
		/// </summary>
		/// <param name="template"></param>
		void addTemplate(Enum name, CodeTemplate template, string desc = "");

		/// <summary>
		/// 获取模板实例
		/// </summary>
		/// <returns></returns>
		CodeTemplate getGlobalTemplate();

		/// <summary>
		/// 获取模板实例
		/// </summary>
		/// <returns></returns>
		CodeTemplate getTemplate(Enum name);
		CodeTemplate getTemplate(int type);

		#endregion

		#region 生成器相关

		/// <summary>
		/// 总代码生成器
		/// </summary>
		/// <returns></returns>
		CodeGenerator getGlobalGenerator();

		/// <summary>
		/// 单数据代码生成器
		/// </summary>
		/// <returns></returns>
		CodeGenerator getGenerator(int id, Enum name);
		CodeGenerator getGenerator(CoreData data, Enum name);

		/// <summary>
		/// 获取所有生成器
		/// </summary>
		/// <returns></returns>
		List<CodeGenerator> getGenerators(int id, params Enum[] names);
		List<CodeGenerator> getGenerators(CoreData data, params Enum[] names);

		#endregion
	}

	/// <summary>
	/// 数据生成管理（每个类一个对应的生成器管理类）
	/// </summary>
	public class GenerateManager<T> : Singleton<GenerateManager<T>>, 
		IGenerateManager where T : CoreData {

		/// <summary>
		/// 其他模板（预览用）ID字典
		/// </summary>
		List<TemplateItem> templates = new List<TemplateItem>();

		/// <summary>
		/// 获取数据类型
		/// </summary>
		/// <returns></returns>
		public Type getDataType() { return typeof(T); }

		///// <summary>
		///// 获取数据
		///// </summary>
		///// <returns></returns>
		//public List<T> getData() { return BaseData.poolGet<T>(); }

		/// <summary>
		/// 获取所有模板项
		/// </summary>
		/// <returns></returns>
		public List<TemplateItem> getTemplateItems() {
			return templates;
		}

		#region 模板相关

		/// <summary>
		/// 设置全局模板
		/// </summary>
		/// <param name="template"></param>
		public void setGlobalTemplate(CodeTemplate template) {
			templates.Insert(0, new TemplateItem(template));
		}

		/// <summary>
		/// 添加模板
		/// </summary>
		/// <param name="template"></param>
		public void addTemplate(Enum name, CodeTemplate template, string desc = "") {
			templates.Add(new TemplateItem(name, template, desc));
		}

		/// <summary>
		/// 获取模板实例
		/// </summary>
		/// <returns></returns>
		public CodeTemplate getGlobalTemplate() {
			if (templates.Count > 0 && templates[0].isGlobal)
				return templates[0].template();
			return null;
		}

		/// <summary>
		/// 获取模板实例
		/// </summary>
		/// <returns></returns>
		public CodeTemplate getTemplate(Enum name) {
			return getTemplate(name.GetHashCode());
		}
		public CodeTemplate getTemplate(int type) {
			var item = templates.Find(t => t.type == type);
			return item?.template();
		}

		#endregion

		#region 生成器相关

		/// <summary>
		/// 总代码生成器
		/// </summary>
		/// <returns></returns>
		public CodeGenerator getGlobalGenerator() {
			var template = getGlobalTemplate();
			if (template == null) return null;
			var generator = new CodeGenerator(template);
			setupGlobalData(generator);

			return generator;
		}

		/// <summary>
		/// 单数据代码生成器
		/// </summary>
		/// <returns></returns>
		public CodeGenerator getGenerator(int id, Enum name) {
			return getGenerator(BaseData.poolGet<T>(id), name);
		}
		public CodeGenerator getGenerator(CoreData data, Enum name) {
			return getGenerator(data as T, name);
		}
		public CodeGenerator getGenerator(T data, Enum name) {
			return getGenerator(data, name.GetHashCode());
		}
		public CodeGenerator getGenerator(T data, int type) {
			return getGenerator(data, getTemplate(type));
		}
		public CodeGenerator getGenerator(T data, CodeTemplate template) {
			if (template == null) return null;

			var generator = new CodeGenerator(template, data);
			setupGlobalData(generator);

			return generator;
		}

		/// <summary>
		/// 获取所有生成器
		/// </summary>
		/// <returns></returns>
		public List<CodeGenerator> getGenerators(int id, params Enum[] names) {
			return getGenerators(BaseData.poolGet<T>(id), names);
		}
		public List<CodeGenerator> getGenerators(CoreData data, Enum[] names) {
			return getGenerators(data as T, names);
		}
		public List<CodeGenerator> getGenerators(T data, params Enum[] names) {
			var res = new List<CodeGenerator>();
			if (names.Length <= 0)
				foreach (var item in templates)
					res.Add(getGenerator(data, item.template()));
			else foreach (var name in names)
					res.Add(getGenerator(data, name));

			return res;
		}

		/// <summary>
		/// 配置全局生成数据
		/// </summary>
		/// <param name="generator"></param>
		void setupGlobalData(CodeGenerator generator) {
			// V1.0 Code
			//foreach (var type in DataManager.dataTypes) {
			//	var attrName = getTypeAttrName(type);
			//	var data = BaseData.poolGet(type);
			//	generator.addData(attrName, data);
			//}
			// V2.0 Code
			foreach (var table in DatabaseManager.tables) {
				var attrName = getTypeAttrName(table.type);
				generator.addData(attrName, table.items);
			}
		}

		/// <summary>
		/// 获取类型的属性名
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		string getTypeAttrName(Type type) {
			var res = ""; bool flag = false;
			foreach (var c in type.Name) 
				if (char.IsLetter(c)) {
					res += flag ? c : char.ToLower(c);
					flag = true;
				}

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
		public const string RootPath = "./templates/";

		/// <summary>
		/// 模板拓展名
		/// </summary>
		public const string ExtendName = "exer";

		/// <summary>
		/// 文件名格式
		/// </summary>
		const string FileNameFormat = "{0}s";

		/// <summary>
		/// 模板库
		/// </summary>
		static Dictionary<string, int> templates = new Dictionary<string, int>();

		#region 文件系统

		/// <summary>
		/// 模板名称、文件名、路径互换
		/// 模板名称：name，不包含路径和拓展名
		/// 文件名：file，可包含路径的文件名（相对路径）
		/// 路径：path，包含路径（templates之下的绝对路径）
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static string name2File(string name) {
			return Path.ChangeExtension(name, ExtendName);
		}
		public static string file2Path(string root, string file) {
			return Path.Combine(root, file);
		}
		public static string path2Name(string name) {
			return Path.GetFileNameWithoutExtension(name);
		}

		#endregion

		/// <summary>
		/// 初始化
		/// </summary>
		public static void initialize() {
			loadAllTemplates();
			addDefaultTemplates();
		}

		#region 预读取模板

		/// <summary>
		/// 读取全部模板
		/// </summary>
		public static void loadAllTemplates() {
			loadDirectory(new DirectoryInfo(RootPath));
		}

		/// <summary>
		/// 读取文件夹
		/// </summary>
		static void loadDirectory(DirectoryInfo dir) {
			var dirs = dir.GetDirectories();
			var files = dir.GetFiles("*." + ExtendName);

			foreach (var file in files) loadTemplate(file.FullName);
			foreach (var subDir in dirs) loadDirectory(subDir);
		}

		/// <summary>
		/// 读取模板
		/// </summary>
		/// <param name="path">文件名</param>
		/// <returns></returns>
		static CodeTemplate loadTemplate(string path) {
			Console.WriteLine("Loading template: " + path);
			var template = new CodeTemplate(path);
			templates[path] = template.id;
			//template.parse();
			return template;
		}

		#endregion

		#region 模板操作

		/// <summary>
		/// 添加预设的模板
		/// </summary>
		static void addDefaultTemplates() {
			Config.Template.addTemplates();
		}

		/// <summary>
		/// 添加模板
		/// </summary>
		/// <typeparam name="T">对应类型</typeparam>
		/// <param name="path">模板路径</param>
		public static void addTemplate<T>(string path = null) where T : CoreData {
			var type = typeof(T);

			// 如果路径为空，自动生成路径
			if (string.IsNullOrEmpty(path)) 
				path = name2File(string.Format(FileNameFormat, type.Name));
			path = file2Path(RootPath, path);

			var template = getTemplate(path);
			if (template == null) return;

			GenerateManager<T>.Get().setGlobalTemplate(template);
		}
		public static void addTemplate<T>(Enum name, string path) where T : CoreData {
			var type = typeof(T);

			path = file2Path(RootPath, path);

			var template = getTemplate(path);
			if (template == null) return;

			GenerateManager<T>.Get().addTemplate(name, template);
		}

		/// <summary>
		/// 读取模板
		/// </summary>
		/// <param name="path">路径</param>
		/// <returns></returns>
		public static CodeTemplate getTemplate(string path) {
			if (templates.ContainsKey(path)) {
				var id = templates[path];
				return BaseData.poolGet<CodeTemplate>(id);
			} 
			return loadTemplate(path);
		}
		public static CodeTemplate getTemplate(string root, string name) {
			return getTemplate(file2Path(root, name));
		}
		public static CodeTemplate getTemplate<T>() where T : CoreData {
			return GenerateManager<T>.Get().getGlobalTemplate();
		}

		#endregion

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
