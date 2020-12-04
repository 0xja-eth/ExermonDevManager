using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

using System.ComponentModel.DataAnnotations.Schema;

namespace ExermonDevManager.Frameworks.ExerUnity.Entities {

	using Core.Data;
	using Core.Entities;

	/// <summary>
	/// 模块
	/// </summary>
	[TableSetting("模块")]
	public class Module : BaseEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("描述", 100)]
		public string description { get; set; }

		/// <summary>
		/// 关联查询
		/// </summary>
		[ControlField("模型", 101)]
		public List<Model> models { get; } = new List<Model>();
		[ControlField("服务", 101)]
		public List<Service> services { get; } = new List<Service>();
		
	}

	/// <summary>
	/// 模块元素接口
	/// </summary>
	public interface IModuleEntity {

		/// <summary>
		/// 属性
		/// </summary>
		int moduleId { get; set; }
		Module module { get; set; }

		/// <summary>
		/// 模型代码
		/// </summary>
		string moduleCode { get; }
	}

}
