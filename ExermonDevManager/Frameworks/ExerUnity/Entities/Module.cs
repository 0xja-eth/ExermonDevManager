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
		[ControlField("请求-响应接口", 102)]
		public List<ReqResInterface> reqResInterfaces { get; } 
			= new List<ReqResInterface>();
		[ControlField("发射接口", 103)]
		public List<EmitInterface> emitInterfaces { get; } 
			= new List<EmitInterface>();
		[ControlField("异常", 104)]
		public List<Exception_> exceptions { get; }
			= new List<Exception_>();

	}
	
}
