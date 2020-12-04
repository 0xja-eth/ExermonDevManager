using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

using System.ComponentModel.DataAnnotations.Schema;

namespace ExermonDevManager.Frameworks.ExerUnity.Entities {

	using Core.Data;
	using Core.Entities;

	/// <summary>
	/// 发射接口类
	/// </summary>
	[TableSetting("发射接口")]
	public class EmitInterface : BaseEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("类型", 10)]
		public string type { get; set; } = "";
		[AutoConvert]
		[ControlField("参数", 20)]
		[InverseProperty("emitInterface")]
		public List<InterfaceParam> params_ { get; protected set; } = new List<InterfaceParam>();
		
	}
	
}
