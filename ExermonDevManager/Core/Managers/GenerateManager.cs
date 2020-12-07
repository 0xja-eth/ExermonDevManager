using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExermonDevManager.Core.Managers {

	using CodeGen;
	using Data;

	using Utils;

	/// <summary>
	/// 数据生成管理基类
	/// </summary>
	public interface IGenerateManager {

		/// <summary>
		/// 获取数据类型
		/// </summary>
		/// <returns></returns>
		Type dataType { get; }

		/// <summary>
		/// 获取所有模板
		/// </summary>
		/// <returns></returns>
		List<TemplateItem> getTemplateItems();

		#region 模板相关
		
		/// <summary>
		/// 添加模板（根据模板设置）
		/// </summary>
		/// <param name="template"></param>
		void addTemplate(TemplateSetting template);

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
		public Type dataType => typeof(T);

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
		void setGlobalTemplate(TemplateSetting setting) {
			templates.Insert(0, new TemplateItem(setting, dataType));
		}

		/// <summary>
		/// 添加模板
		/// </summary>
		/// <param name="template"></param>
		public void addTemplate(Enum name, CodeTemplate template, string desc = "") {
			templates.Add(new TemplateItem(name, template, desc));
		}
		public void addTemplate(TemplateSetting setting) {
			var template = setting.getTemplate(dataType);
			if (template == null)
				Console.WriteLine("Missing template: " + setting.name + "[" + dataType + "]");
			else if (setting.isGlobal) setGlobalTemplate(template);
			else templates.Add(new TemplateItem(setting, dataType));
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
			return getGenerator(DataManager.poolGet<T>(id), name);
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
			return getGenerators(DataManager.poolGet<T>(id), names);
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
			foreach (var table in EntitiesManager.tables) {
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

}
