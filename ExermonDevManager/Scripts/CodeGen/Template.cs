using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
		[ControlField("路径", 10)]
		public string path { get; set; }

		/// <summary>
		/// 其他变量
		/// </summary>
		string content; // 内容
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
		/// 不显示的字段
		/// </summary>
		/// <returns></returns>
		protected new static string[] listExclude() {
			return new string[] { "name", "description" };
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
		public Language language() {
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
		public static Dictionary<Enum, int> templateIds = 
			new Dictionary<Enum, int>();

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
		public static void addTemplate(Enum name, CodeTemplate template) {
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
		public static CodeTemplate template(Enum name) {
			if (templateIds.ContainsKey(name)) {
				var id = templateIds[name];
				return BaseData.poolGet<CodeTemplate>(id);
			}
			return null;
		}

		#endregion

		#region 生成器相关

		/// <summary>
		/// 单数据代码生成器
		/// </summary>
		/// <returns></returns>
		public static CodeGenerator generator(int id, Enum name) {
			return generator(BaseData.poolGet<T>(id), name);
		}
		public static CodeGenerator generator(T data, Enum name) {
			var template = GenerateManager<T>.template(name);
			if (template == null) return null;

			var generator = new CodeGenerator(template, data);
			setupGlobalData(generator);

			return generator;
		}

		/// <summary>
		/// 获取所有生成器
		/// </summary>
		/// <returns></returns>
		public static List<CodeGenerator> generators(int id, params Enum[] names) {
			return generators(BaseData.poolGet<T>(id), names);
		}
		public static List<CodeGenerator> generators(T data, params Enum[] names) {
			var res = new List<CodeGenerator>();
			if (names.Length <= 0)
				foreach (var name in templateIds.Keys)
					res.Add(generator(data, name));
			else foreach (var name in names)
					res.Add(generator(data, name));

			return res;
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
			addTemplate<ReqResInterface>();
			addTemplate<Model>();

			addModelTemplates();
		}

		/// <summary>
		/// 配置模型模板库
		/// </summary>
		static void addModelTemplates() {
			addTemplate<Model>(Model.GenType.DjangoModel, 
				"backend/model/DjangoModel");
			addTemplate<Model>(Model.GenType.DjangoModelAdminSettings, 
				"backend/model/DjangoModelAdminSettings");
			addTemplate<Model>(Model.GenType.DjangoModelTypeSettings, 
				"backend/model/DjangoModelTypeSettings");

			addTemplate<Model>(Model.GenType.ExermonModel,
				"frontend/model/ExermonModel");

			addTemplate<ModelField>(Model.GenType.DjangoModelField,
				"backend/model/DjangoModelField");
			addTemplate<ModelField>(Model.GenType.DjangoModelFieldDeclare,
				"backend/model/DjangoModelFieldDeclare");

			addTemplate<ModelField>(Model.GenType.ExermonModelProp,
				"frontend/model/ExermonModelProp");
			addTemplate<ModelField>(Model.GenType.ExermonModelPropDeclare,
				"frontend/model/ExermonModelPropDeclare");
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

			GenerateManager<T>.setGlobalTemplate(template);
		}
		public static void addTemplate<T>(Enum name, string path) where T : CoreData {
			var type = typeof(T);

			path = file2Path(RootPath, path);

			var template = getTemplate(path);
			if (template == null) return;

			GenerateManager<T>.addTemplate(name, template);
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
			return GenerateManager<T>.globalTemplate();
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
