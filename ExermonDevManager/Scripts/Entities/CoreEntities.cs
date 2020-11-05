using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

using System.ComponentModel.DataAnnotations.Schema;

namespace ExermonDevManager.Scripts.Entities {

	using Data;

	using Utils;
	using CodeGen;

	/// <summary>
	/// 核心实体
	/// </summary>
	public class CoreEntity : CoreData {

		/// <summary>
		/// 是否支持ID
		/// </summary>
		/// <returns></returns>
		protected sealed override bool idEnable() {
			return true;
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		public CoreEntity() { }
		public CoreEntity(string name, string description = "", bool buildIn = true) :
			base(name, description, buildIn) { }

	}

	/// <summary>
	/// 模块
	/// </summary>
	public class Module : CoreEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("代码", 10)]
		public string code { get; set; }

		/// <summary>
		/// 关联查询
		/// </summary>
		[ControlField("模型", 101)]
		public List<Model> models { get; } = new List<Model>();
		[ControlField("请求-响应接口", 102)]
		public List<ReqResInterface> reqResInterfaces { get; } 
			= new List<ReqResInterface>();
		[ControlField("发射接口", 103)]
		public List<EmitInterface> emitInterfaces { get; } 
			= new List<EmitInterface>();
		[ControlField("异常", 104)]
		public List<Exception_> exceptions { get; }
			= new List<Exception_>();

		/// <summary>
		/// 构造函数
		/// </summary>
		public Module() { }
		public Module(string name, string code, 
			string description = "", bool buildIn = true) : 
			base(name, description, buildIn) {
			this.code = code;
		}

		/// <summary>
		/// 生成Python代码
		/// </summary>
		/// <returns></returns>
		public string pyCode() {
			return code.ToLower() + "_module";
		}

		/// <summary>
		/// 生成C#代码
		/// </summary>
		/// <returns></returns>
		public string csCode() {
			return code + "Module";
		}

		#region 关联查询
		
		/// <summary>
		/// 前端模型
		/// </summary>
		/// <returns></returns>
		public List<Model> frontendModels() {
			return models?.FindAll(m => m.isFrontend && !m.buildIn);
		}

		/// <summary>
		/// 后台模型
		/// </summary>
		/// <returns></returns>
		public List<Model> backendModels() {
			return models?.FindAll(m => m.isBackend && !m.buildIn);
		}
		
		#endregion

	}

	/// <summary>
	/// 函数类
	/// </summary>
	public class Function : CoreEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("代码", 10)]
		public string code { get; set; } // 函数内容

	}

	#region 类型相关

	/// <summary>
	/// 类型类
	/// </summary>
	public class Type_ : CoreEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("代码", 10)]
		public string code { get; set; } = "";
		[AutoConvert]
		[ControlField("可继承", 20)]
		public bool derivable { get; set; } = true;

		/// <summary>
		/// 构造函数
		/// </summary>
		public Type_() { }
		public Type_(string name, string code = null,
			string description = "", bool buildIn = true) :
			base(name, description, buildIn) {
			this.code = code ?? name; derivable = !buildIn;
		}
		
		///// <summary>
		///// 继承的类型
		///// </summary>
		///// <returns></returns>
		//public virtual List<T> inheritTypes<T>() where T : Type_ {
		//	var res = new List<T>(inherits.Count);
		//	foreach (var id in inherits)
		//		res.Add(poolGet<T>(id));
		//	return res;
		//}

		///// <summary>
		///// 派生的类型
		///// </summary>
		///// <returns></returns>
		//public virtual List<T> deriveTypes<T>() where T : Type_ {
		//	var res = new List<T>();
		//	var types = poolGet<T>();

		//	foreach (var type in types) {
		//		var inherits = type.inheritTypes<T>();
		//		if (inherits != null && inherits.Contains(this as T))
		//			res.Add(type);
		//	}

		//	return res;
		//}
	}

	/// <summary>
	/// 类型类
	/// </summary>
	public abstract class Type_<P> : Type_ where P : Param {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("字段")]
		[InverseProperty("ownerType")]
		public List<P> params_ { get; protected set; } = new List<P>();

		/// <summary>
		/// 构造函数
		/// </summary>
		public Type_() { }
		public Type_(string name, string code = null,
			string description = "", bool buildIn = true) :
			base(name, code, description, buildIn) { }
	}

	/// <summary>
	/// 类型类
	/// </summary>
	public abstract class Type_<T, P> : Type_<P> 
		where T: Type_<T, P> where P : Param {

		/// <summary>
		/// 继承关系
		/// </summary>
		public class InheritDerive {

			public int id { get; set; }

			public int deriveTypeId { get; set; }
			public T deriveType { get; set; }

			public int inhertTypeId { get; set; }
			public T inhertType { get; set; }

		}

		/// <summary>
		/// 继承/派生类型（关联属性）
		/// </summary>
		[AutoConvert]
		[ControlField("继承")]
		[InverseProperty("inhertType")]
		public List<InheritDerive> inherits { get; } = new List<InheritDerive>();
		[AutoConvert]
		[ControlField("派生")]
		[InverseProperty("deriveType")]
		public List<InheritDerive> derives { get; } = new List<InheritDerive>();

		/// <summary>
		/// 构造函数
		/// </summary>
		public Type_() { }
		public Type_(string name, string code = null,
			string description = "", bool buildIn = true) :
			base(name, code, description, buildIn) { }

		/// <summary>
		/// 总属性
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<List<P>> totalParams_ = null;
		protected List<P> _totalParams_() {
			var res = new List<P>(params_);

			foreach (var inherit in inherits)
				res.AddRange(inherit.inhertType.totalParams());

			return res;
		}
		public List<P> totalParams() {
			return totalParams_?.value();
		}

		///// <summary>
		///// 继承的类型
		///// </summary>
		///// <returns></returns>
		//protected CacheAttr<List<T>> inheritTypes_ = null;
		//protected List<T> _inheritTypes_() {
		//	var res = new List<T>(inherits.Count);
		//	foreach (var id in inherits)
		//		res.Add(poolGet<T>(id));
		//	return res;
		//}
		//public List<T> inheritTypes() {
		//	return inheritTypes_?.value();
		//}
		//public override List<T2> inheritTypes<T2>() {
		//	if (typeof(T2) == typeof(T))
		//		return inheritTypes() as List<T2>;
		//	return base.inheritTypes<T2>();
		//}
		public List<T> inheritTypes() {
			var res = new List<T>();

			foreach (var inherit in inherits)
				res.Add(inherit.inhertType);

			return res;
		}

		/// <summary>
		/// 派生的类型
		/// </summary>
		/// <returns></returns>
		public List<T> deriveTypes() {
			var res = new List<T>();

			foreach (var derive in derives)
				res.Add(derive.deriveType);

			return res;
		}
		//public override List<T2> deriveTypes<T2>() {
		//	if (typeof(T2) == typeof(T))
		//		return deriveTypes() as List<T2>;
		//	return base.deriveTypes<T2>();
		//}
	}

	/// <summary>
	/// 参数类
	/// </summary>
	public abstract class Param : CoreEntity {

		/// <summary>
		/// 属性
		/// </summary>
		
		/// <summary>
		/// 获取分组键值
		/// </summary>
		/// <returns></returns>
		public override string groupKey() {
			return ownerType?.id.ToString();
		}

		/// <summary>
		/// Python格式名称
		/// </summary>
		/// <returns></returns>
		public string pyName() {
			return DataLoader.hump2Underline(name);
		}

		/// <summary>
		/// C#格式名称
		/// </summary>
		/// <returns></returns>
		public string csName() {
			return DataLoader.underline2LowerHump(name);
		}

		/// <summary>
		/// 所属类型
		/// </summary>
		/// <returns></returns>
		public int? ownerTypeId { get; set; }
		public Type_ ownerType { get; set; }
		//public abstract int? ownerTypeId { get; set; }
		//public abstract Type_ ownerType { get; set; }
	}

	#endregion

	#region 模型相关

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
		public class TypeSettingModel {

			public int id { get; set; }

			public int typeSettingId { get; set; }
			public TypeSetting typeSetting { get; set; }

			public int modelId { get; set; }
			public Model model { get; set; }

		}

		/// <summary>
		/// TypeSetting与ModelField关系
		/// </summary>
		public class TypeSettingModelField {

			public int id { get; set; }

			public int typeSettingId { get; set; }
			public TypeSetting typeSetting { get; set; }

			public int modelFieldId { get; set; }
			public ModelField modelField { get; set; }

		}

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public int moduleId { get; set; }
		[ControlField("所属模块")]
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

	/// <summary>
	/// 模型属性类
	/// </summary>
	public class ModelField : Param {

		/// <summary>
		/// 后端属性标记
		/// </summary>
		[AttributeUsage(AttributeTargets.Property)]
		public class FrontendFieldAttribute : Attribute { }

		/// <summary>
		/// 后端属性标记
		/// </summary>
		[AttributeUsage(AttributeTargets.Property)]
		public class BackendFieldAttribute : Attribute {

			/// <summary>
			/// 属性名
			/// </summary>
			public string paramName;

			/// <summary>
			/// 构造函数
			/// </summary>
			public BackendFieldAttribute(string paramName = null) {
				this.paramName = paramName;
			}
		}

		/// <summary>
		/// 通用属性标记
		/// </summary>
		[AttributeUsage(AttributeTargets.Property)]
		public class GeneralFieldAttribute : Attribute { }

		/// <summary>
		/// 属性设置
		/// </summary>
		[AttributeUsage(AttributeTargets.Property)]
		public class BFieldSettingAttribute : BackendFieldAttribute {

			/// <summary>
			/// 接受类型
			/// </summary>
			public List<FieldEnum> acceptTypes;

			/// <summary>
			/// 构造函数
			/// </summary>
			public BFieldSettingAttribute(string paramName, 
				params FieldEnum[] types) : base(paramName) {
				acceptTypes = new List<FieldEnum>(types);
			}
		}

		/// <summary>
		/// 基本配置
		/// </summary>
		[AutoConvert]
		[GeneralField]
		[ControlField("后台可用")]
		public bool isBackend_ { get; set; } = true; // 是否后端属性
		[AutoConvert]
		[GeneralField]
		[ControlField("前端可用")]
		public bool isFrontend_ { get; set; } = true; // 是否前端属性
		[AutoConvert]
		[GeneralField]
		[ControlField("键名")]
		public string keyName { get; set; } // 键值
		
		/// <summary>
		/// 类型设置
		/// </summary>
		public List<Model.TypeSettingModelField> typeSettingModelFields { get; set; }

		/// <summary>
		/// 所属模型
		/// </summary>
		//[AutoConvert]
		//public int? ownerModelId { get; set; }
		//public Model ownerModel { get; set; }
		public Model ownerModel => ownerType as Model;

		#region 前端属性

		/// <summary>
		/// 前端属性
		/// </summary>
		[AutoConvert]
		[FrontendField]
		public int fTypeId { get; set; } // 前端类型ID
		[ControlField("前端类型")]
		public Model fType { get; set; }

		[AutoConvert]
		[FrontendField]
		[ControlField("维度")]
		public int dimension { get; set; }
		[AutoConvert]
		[FrontendField]
		[ControlField("使用List")]
		public bool useList { get; set; } = false; // 是否使用 List<T>
		[AutoConvert]
		[FrontendField]
		[ControlField("protected set")]
		public bool protectedSet { get; set; } = true; // 是否为 protected set
		[AutoConvert]
		[FrontendField]
		[ControlField("格式")]
		public string format { get; set; } = "";
		[AutoConvert]
		[FrontendField]
		[ControlField("自动读取")]
		public bool autoLoad { get; set; } = true;
		[AutoConvert]
		[FrontendField]
		[ControlField("自动转化")]
		public bool autoConvert { get; set; } = true;
		[AutoConvert]
		[FrontendField]
		[ControlField("前端默认值")]
		public string fDefault { get; set; } = "";
		[AutoConvert]
		[FrontendField]
		[ControlField("默认实例化")]
		public bool defaultNew { get; set; } = false;

		#endregion

		#region 后端属性

		/// <summary>
		/// 后端属性
		/// </summary>
		[AutoConvert]
		[BackendField]
		public int bTypeId { get; set; }
		[ControlField("后台类型")]
		public DjangoFieldType bType { get; set; }

		[AutoConvert]
		[BackendField("default")]
		[ControlField("后台默认值")]
		public string bDefault { get; set; } = ""; // 代码
		[AutoConvert]
		[BFieldSetting(null, FieldEnum.Str, FieldEnum.File, FieldEnum.Bin)]
		[ControlField("max_length")]
		public int maxLength { get; set; }
		[AutoConvert]
		[BackendField("null")]
		[ControlField("null")]
		public bool null_ { get; set; } = false;
		[AutoConvert]
		[BackendField]
		[ControlField("blank")]
		public bool blank { get; set; } = false;
		[AutoConvert]
		[BackendField]
		[ControlField("unique")]
		public bool unique { get; set; } = false;
		[AutoConvert]
		[BackendField]
		[ControlField("别名")]
		public string verboseName { get; set; }

		/// <summary>
		/// Int
		/// </summary>
		[AutoConvert]
		[BFieldSetting("choices", FieldEnum.Int)]
		public int choicesId { get; set; } = -1;
		[ControlField("选项")]
		public CustomEnumGroup choices { get; set; }

		/// <summary>
		/// Time
		/// </summary>
		[AutoConvert]
		[BFieldSetting(null, FieldEnum.Time)]
		[ControlField("auto_now")]
		public bool autoNow { get; set; } = false;
		[AutoConvert]
		[BFieldSetting(null, FieldEnum.Time)]
		[ControlField("auto_now_add")]
		public bool autoNowAdd { get; set; } = false;

		/// <summary>
		/// File
		/// </summary>
		[AutoConvert]
		[BFieldSetting(null, FieldEnum.File)]
		[ControlField("upload_to")]
		public string uploadTo { get; set; } = "";

		/// <summary>
		/// Relate
		/// </summary>
		[AutoConvert]
		[BFieldSetting("to", FieldEnum.Rel)]
		public int toModelId { get; set; } = -1;
		[ControlField("to")]
		public Model toModel { get; set; }
		[AutoConvert]
		[BFieldSetting("on_delete", FieldEnum.Rel)]
		public int onDeleteId { get; set; } = -1;
		[ControlField("on_delete")]
		public DjangoOnDeleteChoice onDelete { get; set; }

		/// <summary>
		/// Admin 配置
		/// </summary>
		[AutoConvert]
		[BackendField]
		[ControlField("list_display")]
		public bool listDisplay { get; set; } = true;
		[AutoConvert]
		[BackendField]
		[ControlField("list_editable")]
		public bool listEditable { get; set; } = true;

		/// <summary>
		/// 读取转化配置
		/// </summary>
		[AutoConvert]
		[BackendField]
		[ControlField("type_filter")]
		public string typeFilter { get; set; } = "any";
		[AutoConvert]
		[BackendField]
		[ControlField("type_exclude")]
		public string typeExclude { get; set; } = "";

		[AutoConvert]
		[BackendField]
		[ControlField("convert_func")]
		public string convertFunc { get; set; } = "None"; // 转化函数代码

		#endregion

		#region 显示文本计算

		/// <summary>
		/// 后端声明代码
		/// </summary>
		/// <returns></returns>
		[ControlField("后端声明", 10)]
		public string bTypeText() {
			return genCode(Model.GenType.DjangoModelFieldDeclare);
		}

		/// <summary>
		/// 前端声明代码
		/// </summary>
		/// <returns></returns>
		[ControlField("前端声明", 10)]
		public string fTypeText() {
			return genCode(Model.GenType.ExermonModelPropDeclare);
		}

		#endregion

		#region 代码生成

		#region 部分生成

		/// <summary>
		/// 生成后台代码
		/// </summary>
		/// <returns></returns>
		public string bCode() {
			return genCode(Model.GenType.DjangoModelField);
		}

		/// <summary>
		/// 生成前端代码
		/// </summary>
		/// <returns></returns>
		public string fCode() {
			return genCode(Model.GenType.ExermonModelProp);
		}

		#endregion

		#region DjangoModelField

		/// <summary>
		/// 后端名代码
		/// </summary>
		/// <returns></returns>
		string bNameCode() {
			return DataLoader.underline2LowerHump(name);
		}

		/// <summary>
		/// 后端类型代码
		/// </summary>
		/// <returns></returns>
		string bTypeCode() {
			return bType?.name;
		}

		/// <summary>
		/// 获取字段参数列表
		/// </summary>
		/// <returns></returns>
		List<ParamItem> fieldParams() {
			var group = new ParamGroup();
			processPyFieldParams(group);

			return group.params_;
		}

		/// <summary>
		/// 获取拓展参数列表
		/// </summary>
		/// <returns></returns>
		List<ParamItem> extendParams() {
			var group = new ParamGroup();
			processPyFieldExtParams(group);

			return group.params_;
		}

		#endregion

		#region ExermonModelProp

		/// <summary>
		/// 获取自动参数列表
		/// </summary>
		/// <returns></returns>
		List<ParamItem> autoParams() {
			var group = new ParamGroup();
			processCSPropAutoParams(group);

			return group.params_;
		}

		/// <summary>
		/// 前端名代码
		/// </summary>
		/// <returns></returns>
		string fNameCode() {
			return DataLoader.underline2LowerHump(name);
		}

		/// <summary>
		/// 前端类型代码
		/// </summary>
		/// <returns></returns>
		string fTypeCode() {
			var type = fType.code;
			if (!useList)
				for (int i = 0; i < dimension; ++i) type += "[]";
			else
				for (int i = 0; i < dimension; ++i) type = "List<" + type + ">";
			return type;
		}

		/// <summary>
		/// 前端默认值代码
		/// </summary>
		/// <returns></returns>
		string fDefaultCode() {
			var type = fTypeCode();
			return defaultNew ? string.Format("new {0}()", type) : fDefault;
		}

		#endregion

		#region 属性/参数代码

		/// <summary>
		/// to参数代码
		/// </summary>
		/// <returns></returns>
		string toModelCode() {
			var module = toModel?.module;
			if (module == null) return null;
			return module.pyCode() + "." + toModel.code;
		}

		/// <summary>
		/// 处理字段参数
		/// </summary>
		/// <param name="params_"></param>
		void processPyFieldParams(ParamGroup params_) {

			var onDelete = this.onDelete?.name;
			var choices = this.choices?.name;

			params_.addParam("to", toModelCode());
			params_.addParam("on_delete", onDelete, "", true);
			params_.addParam("default", bDefault, "", true);
			params_.addParam("null", null_, false);
			params_.addParam("blank", blank, false);
			params_.addParam("unique", unique, false);
			params_.addParam("max_length", maxLength, 0);
			params_.addParam("choices", choices, "", true);
			params_.addParam("auto_new", autoNow, false);
			params_.addParam("auto_new_add", autoNowAdd, false);
			params_.addParam("upload_to", uploadTo, "", true);
			params_.addParam("verbose_name", verboseName);
		}

		/// <summary>
		/// 类型过滤代码
		/// </summary>
		/// <returns></returns>
		string typeFilterCode() {
			var res = Python.get().str2StrList(typeFilter);
			return "[" + res + "]";
		}

		/// <summary>
		/// 类型过滤代码
		/// </summary>
		/// <returns></returns>
		string typeExcludeCode() {
			var res = Python.get().str2StrList(typeExclude);
			return "[" + res + "]";
		}

		/// <summary>
		/// 处理字段拓展参数
		/// </summary>
		/// <param name="params_"></param>
		void processPyFieldExtParams(ParamGroup params_) {

			params_.addParam("key_name", keyName, null);
			params_.addParam("type_filter", typeFilterCode(), "['any']", true);
			params_.addParam("type_exclude", typeExcludeCode(), "[]", true);
			params_.addParam("convert", convertFunc, "None", true);
		}

		/// <summary>
		/// 处理属性自动生成参数
		/// </summary>
		/// <param name="params_"></param>
		void processCSPropAutoParams(ParamGroup params_) {

			params_.addParam("keyName", keyName);
			params_.addParam("autoLoad", autoLoad, true);
			params_.addParam("autoConvert", autoConvert, true);
			params_.addParam("format", format, "");
		}

		#endregion

		#endregion

		#region 反射相关计算

		/// <summary>
		/// 获取可用字段名称
		/// </summary>
		/// <returns></returns>
		public List<string> getEnableFieldNames() {

			var res = getGeneralFieldNames();

			if (isBackend()) getBackendFieldNames(res);
			if (isFrontend()) getFrontendFieldNames(res);

			return res;
		}

		/// <summary>
		/// 获取一般字段名称
		/// </summary>
		/// <param name="list"></param>
		List<string> getGeneralFieldNames(List<string> list = null) {
			list = list ?? new List<string>();

			ReflectionUtils.processAttribute<PropertyInfo, AutoConvertAttribute>
				(GetType().BaseType, (p, attr) => list.Add(p.Name));
			ReflectionUtils.processAttribute<PropertyInfo, GeneralFieldAttribute>
				(GetType(), (p, attr) => list.Add(p.Name));

			return list;
		}

		/// <summary>
		/// 获取后台字段名称
		/// </summary>
		/// <param name="list"></param>
		List<string> getBackendFieldNames(List<string> list = null) {
			var fieldEnum = bType.type;

			list = list ?? new List<string>();

			ReflectionUtils.processAttribute<PropertyInfo, BackendFieldAttribute>
				(GetType(), (p, a) => {
					var attr = a as BFieldSettingAttribute;
					if (attr == null || attr.acceptTypes.Contains(fieldEnum))
						list.Add(p.Name);
				});
			return list;
		}

		/// <summary>
		/// 获取后台字段名称
		/// </summary>
		/// <param name="list"></param>
		List<string> getFrontendFieldNames(List<string> list = null) {
			list = list ?? new List<string>();

			ReflectionUtils.processAttribute<PropertyInfo, FrontendFieldAttribute>
				(GetType(), (p, attr) => list.Add(p.Name));

			return list;
		}

		/// <summary>
		/// 获取后台字段名称
		/// </summary>
		/// <param name="list"></param>
		List<string> getBackendParamNames() {
			var fieldEnum = bType.type;

			var list = new List<string>();

			ReflectionUtils.processAttribute<PropertyInfo, BackendFieldAttribute>
				(GetType(), (p, a) => {
					var attr = a as BFieldSettingAttribute;
					if (attr == null || attr.acceptTypes.Contains(fieldEnum)) 
						list.Add(a.paramName ?? DataLoader.
							hump2Underline(p.Name));
				});
			return list;
		}

		#endregion

		#region 相关数据获取

		/// <summary>
		/// 前后台判断
		/// </summary>
		/// <returns></returns>
		public bool isBackend() {
			if (ownerModel == null) return isBackend_;
			return ownerModel.isBackend && isBackend_;
		}
		public bool isFrontend() {
			if (ownerModel == null) return isFrontend_;
			return ownerModel.isFrontend && isFrontend_;
		}

		///// <summary>
		///// 获取所属模型
		///// </summary>
		///// <returns></returns>
		//public sealed override int? ownerTypeId {
		//	get => ownerModelId;
		//	set { ownerModelId = value; }
		//}
		//public sealed override Type_ ownerType {
		//	get => ownerModel;
		//	set { ownerModel = value as Model; }
		//}

		///// <summary>
		///// 获取类型实例
		///// </summary>
		///// <returns></returns>
		//protected CacheAttr<DjangoFieldType> bType_ = null;
		//protected DjangoFieldType _bType_() {
		//	return poolGet<DjangoFieldType>(bTypeId);
		//}
		//public DjangoFieldType bType() {
		//	return bType_?.value();
		//}

		/// <summary>
		/// 是否关系字段
		/// </summary>
		/// <returns></returns>
		public bool isRelated() {
			if (bType == null) return false;
			return bType.type == FieldEnum.Rel;
		}

		///// <summary>
		///// 获取指向模型
		///// </summary>
		///// <returns></returns>
		//protected CacheAttr<Model> toModel_ = null;
		//protected Model _toModel_() {
		//	return poolGet<Model>(toModelId);
		//}
		//public Model toModel() {
		//	return toModel_?.value();
		//}

		///// <summary>
		///// 获取选择项枚举
		///// </summary>
		///// <returns></returns>
		//protected CacheAttr<CustomEnumGroup> choices_ = null;
		//protected CustomEnumGroup _choices_() {
		//	return poolGet<CustomEnumGroup>(choicesId);
		//}
		//public CustomEnumGroup choices() {
		//	return choices_?.value();
		//}

		///// <summary>
		///// 获取选择项枚举
		///// </summary>
		///// <returns></returns>
		//protected CacheAttr<DjangoOnDeleteChoice> onDelete_ = null;
		//protected DjangoOnDeleteChoice _onDelete_() {
		//	return poolGet<DjangoOnDeleteChoice>(onDeleteId);
		//}
		//public DjangoOnDeleteChoice onDelete() {
		//	return onDelete_?.value();
		//}

		///// <summary>
		///// 获取模块实例
		///// </summary>
		///// <returns></returns>
		//protected CacheAttr<Model> fType_ = null;
		//protected Model _fType_() {
		//	return poolGet<Model>(fTypeId);
		//}
		//public Model fType() {
		//	return fType_?.value();
		//}

		#endregion

	}

	/// <summary>
	/// 类型
	/// </summary>
	public enum FieldEnum {
		None, Int, Float, Bool, Str, Time, Bin, File, Rel,
	}

	/// <summary>
	/// Django字段类型
	/// </summary>
	public class DjangoFieldType : CoreEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("类型")]
		public FieldEnum type { get; set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		public DjangoFieldType() { }
		public DjangoFieldType(string name,
			FieldEnum type = FieldEnum.Int, string description = "") {
			this.name = name; this.type = type;
			this.description = description;
		}

		/// <summary>
		/// 下拉框文本
		/// </summary>
		/// <returns></returns>
		public override string comboText() {
			return name;
		}
	}
	
	/// <summary>
	/// OnDelete选项
	/// </summary>
	public class DjangoOnDeleteChoice : CoreEntity {

		/// <summary>
		/// 构造函数
		/// </summary>
		public DjangoOnDeleteChoice() { }
		public DjangoOnDeleteChoice(string name, string description = "") {
			this.name = name; 
			this.description = description;
		}
	}

	#endregion

	#region 接口相关

	/// <summary>
	/// 请求-响应接口类
	/// </summary>
	public class ReqResInterface : CoreEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("路由", 10)]
		public string route { get; set; } = "";

		[AutoConvert]
		[ControlField("请求参数")]
		[InverseProperty("reqInterface")]
		public List<InterfaceParam> reqParams { get; protected set; } = new List<InterfaceParam>();
		[AutoConvert]
		[ControlField("响应参数")]
		[InverseProperty("resInterface")]
		public List<InterfaceParam> resParams { get; protected set; } = new List<InterfaceParam>();

		//[AutoConvert]
		//public int bModuleId {
		//	get { return bModuleId_; }
		//	set { bModuleId_ = value; bModule_.clear(); }
		//}
		//int bModuleId_ = 0;
		[AutoConvert]
		public int bModuleId { get; set; }
		[ControlField("所属模块")]
		public Module bModule { get; set; }
		[AutoConvert]
		[ControlField("处理函数")]
		public string bFunc { get; set; } = "";
		[AutoConvert]
		public int bTagId { get; set; }
		[ControlField("Channels标志")]
		public ChannelsTag bTag { get; set; }

		[AutoConvert]
		[ControlField("前端名称")]
		public string fName { get; set; } = "";

		/// <summary>
		/// 构造函数
		/// </summary>
		public ReqResInterface() { }

		/// <summary>
		/// 获取分组键值
		/// </summary>
		/// <returns></returns>
		public override string groupKey() {
			return bModuleId.ToString();
		}

		///// <summary>
		///// 获取模块实例
		///// </summary>
		///// <returns></returns>
		//protected CacheAttr<Module> bModule_ = null;
		//protected Module _bModule_() {
		//	return poolGet<Module>(bModuleId);
		//}
		//public Module bModule() {
		//	return bModule_?.value();
		//}

		///// <summary>
		///// 获取标签实例
		///// </summary>
		///// <returns></returns>
		//protected CacheAttr<ChannelsTag> bTag_ = null;
		//protected ChannelsTag _bTag_() {
		//	return poolGet<ChannelsTag>(bTagId);
		//}
		//public ChannelsTag bTag() {
		//	return bTag_?.value();
		//}

		/// <summary>
		/// 处理函数文本
		/// </summary>
		/// <returns></returns>
		[ControlField("处理函数", 20)]
		public string bFuncText() {
			return string.Format("{0}.{1}", bModule.code, bFunc);
		}

		/// <summary>
		/// 处理函数文本
		/// </summary>
		/// <returns></returns>
		public string bTagName() {
			return bTag.name;
		}
		
	}

	/// <summary>
	/// 发射接口类
	/// </summary>
	public class EmitInterface : CoreEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("类型", 10)]
		public string type { get; set; } = "";
		[AutoConvert]
		[ControlField("参数")]
		[InverseProperty("emitInterface")]
		public List<InterfaceParam> params_ { get; protected set; } = new List<InterfaceParam>();

		[AutoConvert]
		public int bModuleId { get; set; }
		[ControlField("所属模块")]
		public Module bModule { get; set; }

		/// <summary>
		/// 获取分组键值
		/// </summary>
		/// <returns></returns>
		public override string groupKey() {
			return bModuleId.ToString();
		}

		///// <summary>
		///// 获取模块实例
		///// </summary>
		///// <returns></returns>
		//protected CacheAttr<Module> bModule_ = null;
		//protected Module _bModule_() {
		//	return poolGet<Module>(bModuleId);
		//}
		//public Module bModule() {
		//	return bModule_?.value();
		//}
	}

	/// <summary>
	/// 组合数据
	/// </summary>
	public class GroupData : Type_<GroupData, InterfaceParam> {

		/// <summary>
		/// 属性
		/// </summary>
		//[AutoConvert]
		//[ControlField("可继承", 20)]
		//public bool baseData { get; set; } = false;

		/// <summary>
		/// 构造函数
		/// </summary>
		public GroupData() { }
		public GroupData(string name, string code = null,
			string description = "", bool buildIn = true) :
			base (name, code, description, buildIn) { }
	}

	/// <summary>
	/// 接口参数类
	/// </summary>
	public class InterfaceParam : Param {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public int typeId { get; set; }
		[ControlField("类型")]
		public GroupData type { get; set; }
		[AutoConvert]
		[ControlField("维度")]
		public int dimension { get; set; }

		/// <summary>
		/// 所属模型
		/// </summary>
		//[AutoConvert]
		//public int? groupDataId { get; set; }
		public GroupData groupData => ownerType as GroupData;

		public int? reqInterfaceId { get; set; }
		public ReqResInterface reqInterface { get; set; }

		public int? resInterfaceId { get; set; }
		public ReqResInterface resInterface { get; set; }

		public int? emitInterfaceId { get; set; }
		public EmitInterface emitInterface { get; set; }

		/// <summary>
		/// 获取所属类型
		/// </summary>
		/// <returns></returns>
		//protected CacheAttr<GroupData> ownerType_ = null;
		//protected GroupData _ownerType_() {
		//	var types = poolGet<GroupData>();
		//	foreach (var type in types)
		//		if (type.params_.Contains(this))
		//			return type;
		//	return null;
		//}
		//public sealed override int? ownerTypeId {
		//	get => groupDataId;
		//	set { groupDataId = value; }
		//}
		//public sealed override Type_ ownerType {
		//	get => groupData;
		//	set { groupData = value as GroupData; }
		//}

		///// <summary>
		///// 获取类型实例
		///// </summary>
		///// <returns></returns>
		//protected CacheAttr<GroupData> type_ = null;
		//protected GroupData _type_() {
		//	return poolGet<GroupData>(typeId);
		//}
		//public GroupData type() {
		//	return type_?.value();
		//}

		/// <summary>
		/// 实际显示的类型名称
		/// </summary>
		/// <returns></returns>
		public string typeName() {
			var res = type.name;
			if (dimension == 0) return res;
			if (dimension == 1) return res + "（数组）";

			var format = res + "（{0}维数组）";
			return string.Format(format, dimension);
		}

		/// <summary>
		/// 实际显示的类型代码
		/// </summary>
		/// <returns></returns>
		[ControlField("类型", 10)]
		public string typeCode() {
			var res = type.code;
			for (int i = 0; i < dimension; ++i)
				res += "[]";
			return res;
		}

		/// <summary>
		/// 是否为用ID名参数
		/// </summary>
		/// <returns></returns>
		public bool isUid() { return name == "uid"; }
	}

	#endregion

	#region 枚举相关

	/// <summary>
	/// 枚举数据类型基类
	/// </summary>
	public abstract class Enum_ : CoreEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("枚举值", 10)]
		public int code { get; set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		public Enum_() { }
		public Enum_(int code, string name, string description = "") {
			this.code = code; this.name = name;
			this.description = description;
		}

		/// <summary>
		/// 下拉框文本
		/// </summary>
		/// <returns></returns>
		public override string comboText() {
			return code + ". " + name;
		}

		///// <summary>
		///// 生成Python代码块
		///// </summary>
		///// <returns></returns>
		//public override LangElement<Python> genPyBlock() {
		//	return new LangEnumItem<Python>(name, code, description);
		//}

		///// <summary>
		///// 生成C#代码块
		///// </summary>
		///// <returns></returns>
		//public override LangElement<CSharp> genCSBlock() {
		//	return new LangEnumItem<CSharp>(name, code, description);
		//}
	}

	/// <summary>
	/// Channels标签
	/// </summary>
	public class ChannelsTag : Enum_ {

		/// <summary>
		/// 构造函数
		/// </summary>
		public ChannelsTag() { }
		public ChannelsTag(int code, string name, string description = "") :
			base(code, name, description) { }
	}

	/// <summary>
	/// 异常
	/// </summary>
	public class Exception_ : Enum_ {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("警告文本", 110)]
		public string alertText { get; set; } = "";
		[AutoConvert]
		public int moduleId { get; set; }
		[ControlField("所属模块")]
		public Module module { get; set; }

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
		/// 生成键代码
		/// </summary>
		/// <returns></returns>
		public string genKeyCode() {
			return "ErrorType." + name;
		}

		/// <summary>
		/// 生成前端提示文本设定代码
		/// </summary>
		/// <returns></returns>
		public string genAlertTextCode() {
			return "\"" + alertText + "\"";
		}

		///// <summary>
		///// 生成异常管理代码
		///// </summary>
		///// <returns></returns>
		//public static string genPyExceptionCode() {
		//	var file = new LangFile<Python>();
		//	file.addSubBlock(new LangErrorTypeEnum());
		//	file.addSubBlock(new LangGameExceptionClass());
		//	return file.genCode();
		//}
		
	}

	/// <summary>
	/// 自定义枚举
	/// </summary>
	public class CustomEnumGroup : CoreEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("前端可用")]
		public bool isFrontend { get; set; } = true;
		[AutoConvert]
		[ControlField("后台可用")]
		public bool isBackend { get; set; } = true;

		[AutoConvert]
		[ControlField("枚举值")]
		public List<CustomEnum> values { get; set; }

		///// <summary>
		///// 生成Python代码块
		///// </summary>
		///// <returns></returns>
		//public override LangElement<Python> genPyBlock() {
		//	if (!isBackend) return null;
		//	var block = new LangEnum<Python>(name, description);

		//	foreach (var value in values) {
		//		var subBlock = value.genPyBlock<LangBlock<Python>>();
		//		if (subBlock != null) block.addSubBlock(subBlock);
		//	}

		//	return block;
		//}

		///// <summary>
		///// 生成C#代码块
		///// </summary>
		///// <returns></returns>
		//public override LangElement<CSharp> genCSBlock() {
		//	if (!isFrontend) return null;
		//	var block = new LangEnum<CSharp>(name, description);

		//	foreach (var value in values) {
		//		var subBlock = value.genCSBlock<LangBlock<CSharp>>();
		//		if (subBlock != null) block.addSubBlock(subBlock);
		//	}

		//	return block;
		//}
	}

	/// <summary>
	/// 自定义枚举
	/// </summary>
	public class CustomEnum : Enum_ {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public int enumGroupId { get; set; }
		public CustomEnumGroup enumGroup { get; set; }
	}

	#endregion

	/// <summary>
	/// 默认/内置数据
	/// </summary>
	public static class Default {
		
		/// <summary>
		/// 默认数据类型
		/// </summary>
		public static class Types {
			public static readonly GroupData Int = new GroupData("int");
			public static readonly GroupData Double = new GroupData("double");
			public static readonly GroupData Str = new GroupData("str");
			public static readonly GroupData Bool = new GroupData("bool");
			public static readonly GroupData Date_ = new GroupData("date");
			public static readonly GroupData DateTime_ = new GroupData("datetime");
			public static readonly GroupData DataTuple_ = new GroupData("[int, str]"); // 数据元组
			public static readonly GroupData Dict = new GroupData("dict");
			public static readonly GroupData Var = new GroupData("var");

			/// <summary>
			/// 初始化
			/// </summary>
			public static void initialize() { }
		}

		/// <summary>
		/// 默认Channels标签
		/// </summary>
		public static class ChannelsTags {
			public static readonly ChannelsTag Self = new ChannelsTag(0, "Self");
			public static readonly ChannelsTag NoLayer = new ChannelsTag(-1, "NoLayer");

			/// <summary>
			/// 初始化
			/// </summary>
			public static void initialize() {}
		}

		/// <summary>
		/// Django默认配置
		/// </summary>
		public static class Django {

			/// <summary>
			/// 默认字段类型
			/// </summary>
			public static class FieldTypes {
				public static readonly DjangoFieldType Auto = new DjangoFieldType("models.AutoField");

				public static readonly DjangoFieldType Char = new DjangoFieldType(
					"models.CharField", FieldEnum.Str);
				public static readonly DjangoFieldType Text = new DjangoFieldType(
					"models.TextField", FieldEnum.Str);

				public static readonly DjangoFieldType Boolean = new DjangoFieldType(
					"models.BooleanField", FieldEnum.Bool);

				public static readonly DjangoFieldType Integer = new DjangoFieldType("models.IntegerField");
				public static readonly DjangoFieldType Float = new DjangoFieldType("models.FloatField");
				public static readonly DjangoFieldType BInteger = new DjangoFieldType("models.BigIntegerField");
				public static readonly DjangoFieldType SInteger = new DjangoFieldType("models.SmallIntegerField");
				public static readonly DjangoFieldType PInteger = new DjangoFieldType("models.PositiveIntegerField");
				//public static readonly DjangoFieldType PBInteger = new DjangoFieldType("models.PositiveBigIntegerField");
				public static readonly DjangoFieldType PSInteger = new DjangoFieldType("models.PositiveSmallIntegerField");

				public static readonly DjangoFieldType Date_ = new DjangoFieldType(
					"models.DateField", FieldEnum.Time);
				public static readonly DjangoFieldType Time = new DjangoFieldType(
					"models.TimeField", FieldEnum.Time);
				public static readonly DjangoFieldType DateTime_ = new DjangoFieldType(
					"models.DateTimeField", FieldEnum.Time);

				public static readonly DjangoFieldType Email = new DjangoFieldType(
					"models.EmailField", FieldEnum.Str);

				public static readonly DjangoFieldType File = new DjangoFieldType(
					"models.FileField", FieldEnum.File);
				public static readonly DjangoFieldType Image = new DjangoFieldType(
					"models.ImageField", FieldEnum.File);

				public static readonly DjangoFieldType Binary = new DjangoFieldType(
					"models.BinaryField", FieldEnum.Bin);

				public static readonly DjangoFieldType IPAddr = new DjangoFieldType(
					"models.IPAddressField", FieldEnum.Str);
				public static readonly DjangoFieldType GenericIPAddr = new DjangoFieldType(
					"models.GenericIPAddressField", FieldEnum.Str);

				public static readonly DjangoFieldType JSON = new DjangoFieldType(
					"jsonfield.JSONField", FieldEnum.Str);

				public static readonly DjangoFieldType Foreign = new DjangoFieldType(
					"models.ForeignKey", FieldEnum.Rel);
				public static readonly DjangoFieldType OneToOne = new DjangoFieldType(
					"models.OneToOneField", FieldEnum.Rel);
				public static readonly DjangoFieldType ManyToMany = new DjangoFieldType(
					"models.ManyToManyField", FieldEnum.Rel);

				/// <summary>
				/// 初始化
				/// </summary>
				public static void initialize() { }
			}

			/// <summary>
			/// 删除选项
			/// </summary>
			public static class OnDeleteChoices {

				public static readonly DjangoOnDeleteChoice CASCADE =
					new DjangoOnDeleteChoice("models.CASCADE");
				public static readonly DjangoOnDeleteChoice PROTECT =
					new DjangoOnDeleteChoice("models.PROTECT");
				public static readonly DjangoOnDeleteChoice SET_NULL =
					new DjangoOnDeleteChoice("models.SET_NULL");
				public static readonly DjangoOnDeleteChoice SET_DEFAULT =
					new DjangoOnDeleteChoice("models.SET_DEFAULT");
				public static readonly DjangoOnDeleteChoice DO_NOTHING =
					new DjangoOnDeleteChoice("models.DO_NOTHING");

				/// <summary>
				/// 初始化
				/// </summary>
				public static void initialize() { }
			}

			/// <summary>
			/// 初始化
			/// </summary>
			public static void initialize() {
				FieldTypes.initialize();
				OnDeleteChoices.initialize();
			}
		}

		/// <summary>
		/// Unity默认配置
		/// </summary>
		public static class Unity {

			/// <summary>
			/// 默认字段类型
			/// </summary>
			public static class Models {
				public static readonly Model Int = new Model("int");
				public static readonly Model Double = new Model("double");
				public static readonly Model String = new Model("string");
				public static readonly Model Bool = new Model("bool");
				public static readonly Model Date_ = new Model("Date");
				public static readonly Model DateTime_ = new Model("DateTime");
				public static readonly Model Tuple_ = new Model("Tuple<int, string>");

				/// <summary>
				/// 初始化
				/// </summary>
				public static void initialize() { }
			}

			/// <summary>
			/// 初始化
			/// </summary>
			public static void initialize() {
				Models.initialize();
			}
		}

		/// <summary>
		/// 初始化
		/// </summary>
		public static void initialize() {
			Types.initialize();
			ChannelsTags.initialize();
			Django.initialize();
			Unity.initialize();
		}
	}

}
