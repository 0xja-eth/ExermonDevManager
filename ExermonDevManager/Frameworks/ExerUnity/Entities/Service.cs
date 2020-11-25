using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

using System.ComponentModel.DataAnnotations.Schema;

namespace ExermonDevManager.Frameworks.ExerUnity.Entities {

	using Core.Data;
	using Core.Entities;

	/// <summary>
	/// 服务类
	/// </summary>
	[TableSetting("服务")]
	public class Service : BaseEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public int moduleId { get; set; }
		[ControlField("模块", 10)]
		public Module module { get; set; }

		[AutoConvert]
		[ControlField("接口", 20)]
		public List<ReqResInterface> interfaces { get; set; } = new List<ReqResInterface>();
		
	}
}
