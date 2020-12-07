using System;
using System.IO;
using System.Collections.Generic;

namespace ExermonDevManager.Core.Managers {

	using CodeGen;
	using Data;
	using Entities;

	using Utils;

	/// <summary>
	/// 模板系统
	/// </summary>
	public static class TemplateManager {

		/// <summary>
		/// 模板拓展名
		/// </summary>
		public const string ExtendName = "exer";

		/// <summary>
		/// 文件名格式
		/// </summary>
		const string FileNameFormat = "{0}s";

		/// <summary>
		/// 路径常量定义
		/// </summary>
		public static string rootPath => ConfigManager.config.templatePath;

		/// <summary>
		/// 模板库
		/// </summary>
		static Dictionary<string, int> templates = new Dictionary<string, int>();

		/// <summary>
		/// 框架-模板表
		/// </summary>
		static DictList<IFramework, string> frameworkPaths = new DictList<IFramework, string>();

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
			var ext = "." + ExtendName;
			if (!file.EndsWith(ext)) file += ext;
			return Path.Combine(root, file);
		}
		public static string path2Name(string name) {
			return Path.GetFileNameWithoutExtension(name);
		}

		#endregion

		/// <summary>
		/// 初始化
		/// </summary>
		//public static void initialize() {
		//	loadAllTemplates();
		//	addDefaultTemplates();
		//}

		#region 读取模板

		/// <summary>
		/// 注册框架
		/// </summary>
		/// <param name="framework"></param>
		public static void registerFramework(IFramework framework) {
			registerFrameworkTemplates(framework);
			registerFrameworkEntities(framework);
		}

		/// <summary>
		/// 注册框架实体
		/// </summary>
		/// <param name="framework"></param>
		static void registerFrameworkTemplates(IFramework framework) {
			var path = Path.Combine(rootPath, framework.name);
			loadDirectory(framework, new DirectoryInfo(rootPath));
		}

		/// <summary>
		/// 注册框架实体
		/// </summary>
		/// <param name="framework"></param>
		static void registerFrameworkEntities(IFramework framework) {
			var entityTypes = framework.entityTypes;
			foreach(var type in entityTypes) {
				var settings = BaseEntity.getTemplateSetting(type);
				var generator = BaseEntity.getGenerateManager(type);
				foreach (var setting in settings)
					generator.addTemplate(setting);
			}
		}

		/// <summary>
		/// 读取文件夹
		/// </summary>
		static void loadDirectory(IFramework framework, DirectoryInfo dir) {
			var dirs = dir.GetDirectories();
			var files = dir.GetFiles("*." + ExtendName);

			foreach (var file in files) loadTemplate(framework, file.FullName);
			foreach (var subDir in dirs) loadDirectory(framework, subDir);
		}

		/// <summary>
		/// 读取模板
		/// </summary>
		/// <param name="path">文件名</param>
		/// <returns></returns>
		static CodeTemplate loadTemplate(IFramework framework, string path) {
			Console.WriteLine("Loading template: " + path);
			var template = new CodeTemplate(path);
			frameworkPaths.add(framework, path);
			templates[path] = template.id;
			//template.parse();
			return template;
		}

		#endregion

		#region 获取模板

		/// <summary>
		/// 读取模板
		/// </summary>
		/// <param name="path">路径</param>
		/// <returns></returns>
		public static CodeTemplate getTemplate(string path) {
			if (templates.ContainsKey(path)) {
				var id = templates[path];
				return DataManager.poolGet<CodeTemplate>(id);
			}
			return null;
		}
		public static CodeTemplate getTemplate(string root, string name) {
			return getTemplate(file2Path(root, name));
		}
		public static CodeTemplate getTemplate<T>() where T : CoreData {
			return GenerateManager<T>.Get().getGlobalTemplate();
		}
		/// <param name="framework"></param>
		/// <param name="name"></param>
		public static CodeTemplate getTemplate(IFramework framework, string name) {
			var paths = frameworkPaths.get(framework);
			foreach (var path in paths) {
				var template = getTemplate(path);
				if (template.name == name) return template;
			}
			return null;
		}

		/// <summary>
		/// 获取所有模板
		/// </summary>
		/// <param name="framework"></param>
		/// <returns></returns>
		public static CodeTemplate[] getTemplates(IFramework framework) {
			var paths = frameworkPaths.get(framework);
			var res = new List<CodeTemplate>();
			foreach (var path in paths) 
				res.Add(getTemplate(path));
			return res.ToArray();
		}

		#endregion

		//#region 模板操作
		 
		///// <summary>
		///// 添加模板
		///// </summary>
		///// <typeparam name="T">对应类型</typeparam>
		///// <param name="path">模板路径</param>
		//public static void addTemplate<T>(string path = null) where T : CoreData {
		//	var type = typeof(T);

		//	// 如果路径为空，自动生成路径
		//	if (string.IsNullOrEmpty(path))
		//		path = name2File(string.Format(FileNameFormat, type.Name));
		//	path = file2Path(rootPath, path);

		//	var template = getTemplate(path);
		//	if (template == null) return;

		//	GenerateManager<T>.Get().setGlobalTemplate(template);
		//}
		//public static void addTemplate<T>(Enum name, string path) where T : CoreData {
		//	var type = typeof(T);

		//	path = file2Path(rootPath, path);

		//	var template = getTemplate(path);
		//	if (template == null) return;

		//	GenerateManager<T>.Get().addTemplate(name, template);
		//}

		//#endregion

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
