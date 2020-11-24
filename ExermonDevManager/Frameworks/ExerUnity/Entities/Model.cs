using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

using System.ComponentModel.DataAnnotations.Schema;

namespace ExermonDevManager.Frameworks.ExerUnity.Entities {

	using Core.Data;
	using Core.Utils;
	using Core.CodeGen;
	using Core.Managers;
	
	/// <summary>
	/// 模型类
	/// </summary>
	public class Model : Type_<Model, ModelField> {

		/// <summary>
		/// 生成代码类型
		/// </summary>
		public enum GenType {

			DjangoModel, // 生成Django模型代码
			DjangoModelAdminSettings, // 生成Admin配置代码
			DjangoModelTypeSettings, // 生成转化配置代码

			DjangoModelField, // 生成Django模型字段代码
			DjangoModelFieldDeclare, // 生成Django模型字段声明代码

			ExermonModel, // 生成Exermon模型代码

			ExermonModelProp, // 生成Exermon模型属性代码
			ExermonModelPropDeclare, // 生成Exermon模型属性声明代码
		}

		/// <summary>
		/// 类型设定
		/// </summary>
		public class TypeSetting : CoreEntity {

			/// <summary>
			/// 属性
			/// </summary>
			[AutoConvert]
			[InverseProperty("typeSetting")]
			[ControlField("字段", 10)]
			public List<TypeSettingModelField> fields { get; set; } 
				= new List<TypeSettingModelField>();
			[AutoConvert]
			[InverseProperty("typeSetting")]
			[ControlField("关系", 10)]
			public List<TypeSettingModel> relModels { get; set; } 
				= new List<TypeSettingModel>();

			/// <summary>
			/// 所属模型
			/// </summary>
			[AutoConvert]
			public int modelId { get; set; }
			public Model model { get; set; }

			///// <summary>
			///// 字段
			///// </summary>
			///// <returns></returns>
			//public List<ModelField> fields() {
			//	var res = new List<ModelField>();
			//	if (model == null) return res;
			//	foreach (var id in fieldIds) 
			//		if (id < model.params_.Count)
			//			res.Add(model.params_[id]);
			//	return res;
			//}

			///// <summary>
			///// 关系模型
			///// </summary>
			///// <returns></returns>
			//public List<Model> relModels() {
			//	var res = new List<Model>();
			//	foreach (var id in relModelIds)
			//		res.Add(poolGet<Model>(id));
			//	return res;
			//}

			/// <summary>
			/// 生成字段代码
			/// </summary>
			/// <returns></returns>
			public List<string> genFieldCodes() {
				var names = new List<string>(fields.Count);

				foreach (var field in fields)
					names.Add("'" + field?.modelField?.pyName() + "'");

				return names;
			}
			public string genFieldsCode() {
				return string.Join(", ", genFieldCodes());
			}

			/// <summary>
			/// 生成关系代码
			/// </summary>
			/// <returns></returns>
			public List<string> genRelCodes() {
				var names = new List<string>(relModels.Count);

				foreach (var rel in relModels)
					names.Add("'" + rel?.model?.code + "'");

				return names;
			}
			public string genRelsCode() {
				return string.Join(", ", genRelCodes());
			}

		}

		/// <summary>
		/// TypeSetting与Model关系
		/// </summary>
		public class TypeSettingModel : CoreEntity {

			/// <summary>
			/// 属性
			/// </summary>
			[AutoConvert]
			public int typeSettingId { get; set; }
			public TypeSetting typeSetting { get; set; }

			[AutoConvert]
			public int modelId { get; set; }
			[ControlField("模型")]
			public Model model { get; set; }

			/// <summary>
			/// 不显示的字段
			/// </summary>
			/// <returns></returns>
			protected static new string[] listExclude() {
				return new string[] { "name", "description", "buildIn" };
			}
		}

		/// <summary>
		/// TypeSetting与ModelField关系
		/// </summary>
		public class TypeSettingModelField : CoreEntity {

			/// <summary>
			/// 属性
			/// </summary>
			[AutoConvert]
			public int typeSettingId { get; set; }
			public TypeSetting typeSetting { get; set; }

			[AutoConvert]
			public int modelFieldId { get; set; }
			[ControlField("字段")]
			public ModelField modelField { get; set; }

			/// <summary>
			/// 不显示的字段
			/// </summary>
			/// <returns></returns>
			protected static new string[] listExclude() {
				return new string[] { "name", "description", "buildIn" };
			}
		}

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public int moduleId { get; set; }
		[ControlField("所属模块", 2)]
		public Module module { get; set; }

		[AutoConvert]
		[ControlField("后台可用", 10)]
		public bool isBackend { get; set; } = true; // 是否后端属性
		[AutoConvert]
		[ControlField("前端可用", 10)]
		public bool isFrontend { get; set; } = true; // 是否前端属性

		[AutoConvert]
		[ControlField("是否抽象", 10)]
		public bool abstract_ { get; set; } = false; // 抽象类

		[AutoConvert]
		[ControlField("键名", 10)]
		public string keyName { get; set; } = ""; // 关系的键名（用于后台）

		/// <summary>
		/// 转化设定
		/// </summary>
		[AutoConvert]
		[ControlField("转化设定", 10)]
		[InverseProperty("model")]
		public List<TypeSetting> typeSettings { get; set; } = new List<TypeSetting>();

		/// <summary>
		/// 类型设置
		/// </summary>
		public List<TypeSettingModel> typeSettingModels { get; set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		public Model() { }
		public Model(string name, string code = null,
			string description = "", bool buildIn = true) :
			base(name, code, description, buildIn) { 
			isBackend = !buildIn;
		}

		/// <summary>
		/// 获取分组键值
		/// </summary>
		/// <returns></returns>
		public override string groupKey() {
			return moduleId.ToString();
		}

		///// <summary>
		///// 获取模块实例
		///// </summary>
		///// <returns></returns>
		//protected CacheAttr<Module> module_ = null;
		//protected Module _module_() {
		//	return poolGet<Module>(moduleId);
		//}
		//public Module module() {
		//	return module_?.value();
		//}

		/// <summary>
		/// 使用方式文本
		/// </summary>
		/// <returns></returns>
		[ControlField("可用性", 15)]
		public string usageText() {
			if (isFrontend && isBackend) return "皆可";
			if (isFrontend) return "前端";
			if (isBackend) return "后端";
			return "无";
		}

		/// <summary>
		/// 获取相关的模型
		/// </summary>
		/// <returns></returns>
		public List<Model> getRelatedModels() {
			var res = new List<Model>();
			if (!isBackend) return res;

			var models = poolGet<Model>();

			foreach(var model in models) 
				foreach (var param in model.params_)
					if (param.isBackend_ && param.isRelated() 
						&& param.toModel == this && 
						!res.Contains(model)) res.Add(model);

			return res;
		}

		/// <summary>
		/// 获取类型设置实例
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public TypeSetting getTypeSetting(string type) {
			return typeSettings.Find(t => t.name == type);
		}

		#region 代码生成
		
		#region 部分生成

		/// <summary>
		/// 生成后台代码
		/// </summary>
		/// <returns></returns>
		public string bCode() {
			return genCode(GenType.DjangoModelField);
		}

		/// <summary>
		/// 生成前端代码
		/// </summary>
		/// <returns></returns>
		public string fCode() {
			return genCode(GenType.ExermonModelProp);
		}

		/// <summary>
		/// 生成类型设置代码
		/// </summary>
		/// <returns></returns>
		public string typeSettingsCode() {
			return genCode(GenType.DjangoModelTypeSettings);
		}

		#endregion

		/// <summary>
		/// 继承代码
		/// </summary>
		/// <returns></returns>
		List<string> inheritCodes() {
			var inherits = inheritTypes();
			var res = new List<string>(inherits.Count);
			foreach (var inherit in inherits)
				res.Add(inherit.code);
			return res;
		}

		/// <summary>
		/// 继承代码
		/// </summary>
		/// <returns></returns>
		string inheritsCode() {
			var codes = inheritCodes();
			return string.Join(", ", codes);
		}

		/// <summary>
		/// 注释描述
		/// </summary>
		/// <returns></returns>
		string commentDescription() {
			var format = string.IsNullOrEmpty(description) ? "{0}" : "{0}：{1}";
			return string.Format(format, name, description);
		}

		#region DjangoModel

		/// <summary>
		/// 是否需要 Meta 类
		/// </summary>
		/// <returns></returns>
		bool hasMeta() {
			return !string.IsNullOrEmpty(name) || abstract_;
		}

		/// <summary>
		/// 后台字段列表
		/// </summary>
		/// <returns></returns>
		List<ModelField> backendFields() {
			return params_.FindAll(f => f.isBackend());
		}

		#endregion

		#region DjangoModelTypeSettings

		/// <summary>
		/// 是否有配置
		/// </summary>
		/// <returns></returns>
		bool hasTypeSettings() { return typeSettings.Count > 0; }

		#endregion

		#region ExermonModel

		/// <summary>
		/// 前端字段列表
		/// </summary>
		/// <returns></returns>
		List<ModelField> frontendFields() {
			return params_.FindAll(f => f.isFrontend());
		}

		#endregion

		#endregion
	}
	
}
