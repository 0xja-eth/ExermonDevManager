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
	/// 模型属性类
	/// </summary>
	public class ModelField : Param<Model> {

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
		[ControlField("后台可用", 2)]
		public bool isBackend_ { get; set; } = true; // 是否后端属性
		[AutoConvert]
		[GeneralField]
		[ControlField("前端可用", 2)]
		public bool isFrontend_ { get; set; } = true; // 是否前端属性
		[AutoConvert]
		[GeneralField]
		[ControlField("键名", 5)]
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

		public ModelField() {
			Console.WriteLine("New Field: " + id);
		}

		#region 前端属性

		/// <summary>
		/// 前端属性
		/// </summary>
		[AutoConvert]
		[FrontendField]
		public int fTypeId { get; set; } // 前端类型ID
		[ControlField("前端类型", 10)]
		public Model fType { get; set; }

		[AutoConvert]
		[FrontendField]
		[ControlField("维度", 10)]
		public int dimension { get; set; }
		[AutoConvert]
		[FrontendField]
		[ControlField("使用List", 10)]
		public bool useList { get; set; } = false; // 是否使用 List<T>
		[AutoConvert]
		[FrontendField]
		[ControlField("protected set", 10)]
		public bool protectedSet { get; set; } = true; // 是否为 protected set
		[AutoConvert]
		[FrontendField]
		[ControlField("格式", 10)]
		public string format { get; set; } = "";
		[AutoConvert]
		[FrontendField]
		[ControlField("自动读取", 10)]
		public bool autoLoad { get; set; } = true;
		[AutoConvert]
		[FrontendField]
		[ControlField("自动转化", 10)]
		public bool autoConvert { get; set; } = true;
		[AutoConvert]
		[FrontendField]
		[ControlField("前端默认值", 10)]
		public string fDefault { get; set; } = "";
		[AutoConvert]
		[FrontendField]
		[ControlField("默认实例化", 10)]
		public bool defaultNew { get; set; } = false;

		#endregion

		#region 后端属性

		/// <summary>
		/// 后端属性
		/// </summary>
		[AutoConvert]
		[BackendField]
		public int bTypeId { get; set; }
		[ControlField("后台类型", 20)]
		public DjangoFieldType bType { get; set; }

		[AutoConvert]
		[BackendField("default")]
		[ControlField("后台默认值", 20)]
		public string bDefault { get; set; } = ""; // 代码
		[AutoConvert]
		[BFieldSetting(null, FieldEnum.Str, FieldEnum.File, FieldEnum.Bin)]
		[ControlField("max_length", 20)]
		public int maxLength { get; set; }
		[AutoConvert]
		[BackendField("null")]
		[ControlField("null", 20)]
		public bool null_ { get; set; } = false;
		[AutoConvert]
		[BackendField]
		[ControlField("blank", 20)]
		public bool blank { get; set; } = false;
		[AutoConvert]
		[BackendField]
		[ControlField("unique", 20)]
		public bool unique { get; set; } = false;
		[AutoConvert]
		[BackendField]
		[ControlField("别名", 20)]
		public string verboseName { get; set; }

		/// <summary>
		/// Int
		/// </summary>
		[AutoConvert]
		[BFieldSetting("choices", FieldEnum.Int)]
		public int? choicesId { get; set; }
		[ControlField("选项", 20)]
		public CustomEnumGroup choices { get; set; }

		/// <summary>
		/// Time
		/// </summary>
		[AutoConvert]
		[BFieldSetting(null, FieldEnum.Time)]
		//[ControlField("auto_now", 20)]
		public bool autoNow { get; set; } = false;
		[AutoConvert]
		[BFieldSetting(null, FieldEnum.Time)]
		//[ControlField("auto_now_add", 20)]
		public bool autoNowAdd { get; set; } = false;

		/// <summary>
		/// File
		/// </summary>
		[AutoConvert]
		[BFieldSetting(null, FieldEnum.File)]
		[ControlField("upload_to", 20)]
		public string uploadTo { get; set; } = "";

		/// <summary>
		/// Relate
		/// </summary>
		[AutoConvert]
		[BFieldSetting("to", FieldEnum.Rel)]
		public int? toModelId { get; set; }
		[ControlField("to", 20)]
		public Model toModel { get; set; }
		[AutoConvert]
		[BFieldSetting("on_delete", FieldEnum.Rel)]
		public int? onDeleteId { get; set; }
		[ControlField("on_delete", 20)]
		public DjangoOnDeleteChoice onDelete { get; set; }

		/// <summary>
		/// Admin 配置
		/// </summary>
		[AutoConvert]
		[BackendField]
		[ControlField("list_display", 30)]
		public bool listDisplay { get; set; } = true;
		[AutoConvert]
		[BackendField]
		[ControlField("list_editable", 30)]
		public bool listEditable { get; set; } = true;

		/// <summary>
		/// 读取转化配置
		/// </summary>
		[AutoConvert]
		[BackendField]
		[ControlField("type_filter", 500)]
		public string typeFilter { get; set; } = "any";
		[AutoConvert]
		[BackendField]
		[ControlField("type_exclude", 500)]
		public string typeExclude { get; set; } = "";

		[AutoConvert]
		[BackendField]
		[ControlField("convert_func", 500)]
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
			var type = fType?.code;
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
			var res = Python.Get().str2StrList(typeFilter);
			return "[" + res + "]";
		}

		/// <summary>
		/// 类型过滤代码
		/// </summary>
		/// <returns></returns>
		string typeExcludeCode() {
			var res = Python.Get().str2StrList(typeExclude);
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

			list = list ?? new List<string>();
			if (bType == null) return list;

			var fieldEnum = bType.type;

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
	
}
