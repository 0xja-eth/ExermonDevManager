using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

using System.ComponentModel.DataAnnotations.Schema;

namespace ExermonDevManager.Frameworks.ExerUnity.Entities {

	using Core.Data;
	using Core.Utils;
	using Core.CodeGen;
	using Core.Entities;

	/// <summary>
	/// 模型属性类
	/// </summary>
	[TableSetting("模型属性")]
	public class ModelField : Param<Model> {
		
		/// <summary>
		/// 所属模型
		/// </summary>
		//[AutoConvert]
		//public int? ownerModelId { get; set; }
		//public Model ownerModel { get; set; }
		public Model ownerModel => ownerType as Model;

		/// <summary>
		/// 属性设置
		/// </summary>
		[AutoConvert]
		public int typeId { get; set; } // 前端类型ID
		[ControlField("前端类型", 10)]
		public Model type { get; set; }

		[AutoConvert]
		[ControlField("维度", 10)]
		public int dimension { get; set; }
		[AutoConvert]
		[ControlField("使用List", 10)]
		public bool useList { get; set; } = false; // 是否使用 List<T>

		[AutoConvert]
		[ControlField("protected set", 10)]
		public bool protectedSet { get; set; } = true; // 是否为 protected set

		[AutoConvert]
		[ControlField("默认值", 10)]
		public string fDefault { get; set; } = "";
		[AutoConvert]
		[ControlField("默认实例化", 10)]
		public bool defaultNew { get; set; } = false;

		/// <summary>
		/// AutoConvert参数
		/// </summary>
		[AutoConvert]
		[ControlField("键名", 5)]
		public string keyName { get; set; } // 键值
		[AutoConvert]
		[ControlField("格式", 10)]
		public string format { get; set; } = ""; // Date 时候用
		[AutoConvert]
		[ControlField("自动读取", 10)]
		public bool autoLoad { get; set; } = true;
		[AutoConvert]
		[ControlField("自动转化", 10)]
		public bool autoConvert { get; set; } = true;

		#region 代码生成

		#region 部分生成

		///// <summary>
		///// 生成前端代码
		///// </summary>
		///// <returns></returns>
		//public string fCode() {
		//	return genCode(Model.GenType.ExermonModelProp);
		//}

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
			var type = this.type?.code;
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
		
	}
	
}
