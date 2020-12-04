using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

using System.ComponentModel.DataAnnotations.Schema;

namespace ExermonDevManager.Frameworks.ExerUnity.Entities {

	using Core.Data;
	using Core.Entities;
	using Core.CodeGen;

	/// <summary>
	/// 服务类
	/// </summary>
	[TableSetting("服务")]
	[TemplateSetting("Services")]
	[TemplateSetting((int)GenType.Service, "Service", "服务代码")]
	[TemplateSetting((int)GenType.InterfaceOper, "InterfaceOper", "服务接口操作代码")]
	[TemplateSetting((int)GenType.InterfaceFunc, "InterfaceFunc", "服务接口函数代码")]
	public class Service : BaseEntity, IDescriptionEntity, IModuleEntity {

		/// <summary>
		/// 生成代码类型
		/// </summary>
		public enum GenType {
			Service, InterfaceOper, InterfaceFunc,
		}

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("描述", 100)]
		public string description { get; set; } = "";

		[AutoConvert]
		public int moduleId { get; set; }
		[ControlField("所属模块", 2)]
		public Module module { get; set; }

		[AutoConvert]
		[ControlField("接口", 20)]
		public List<ReqResInterface> interfaces { get; set; } = new List<ReqResInterface>();

		#region 代码生成

		/// <summary>
		/// 模型代码
		/// </summary>
		public string moduleCode => module?.code;

		/// <summary>
		/// 注释描述
		/// </summary>
		/// <returns></returns>
		public string commentDescription() {
			var format = string.IsNullOrEmpty(description) ? "{0}" : "{0}：{1}";
			return string.Format(format, name, description);
		}

		#endregion

	}
}
