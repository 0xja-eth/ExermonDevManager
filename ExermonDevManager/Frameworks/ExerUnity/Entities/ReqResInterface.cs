using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

using System.ComponentModel.DataAnnotations.Schema;

namespace ExermonDevManager.Frameworks.ExerUnity.Entities {

	using Core.Data;
	using Core.Entities;

	/// <summary>
	/// 请求-响应接口类
	/// </summary>
	[TableSetting("请求-响应接口")]
	public class ReqResInterface : BaseEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public int serviceId { get; set; }
		[ControlField("服务", 10)]
		public Service service { get; set; }

		[AutoConvert]
		[ControlField("路由", 10)]
		public string route { get; set; } = "";

		[AutoConvert]
		[ControlField("操作代码", 30)]
		public string operCode { get; set; } = "";
		[AutoConvert]
		[ControlField("操作文本", 30)]
		public string operText { get; set; } = "";
		[AutoConvert]
		[ControlField("函数名", 30)]
		public string funcName { get; set; } = "";

		[AutoConvert]
		[ControlField("是否单向接口", 15)]
		public bool isEmit { get; set; } = false;

		[AutoConvert]
		[ControlField("请求参数", 20)]
		[InverseProperty("reqInterface")]
		public List<InterfaceParam> reqParams { get; protected set; } = new List<InterfaceParam>();
		[AutoConvert]
		[ControlField("响应参数", 20)]
		[InverseProperty("resInterface")]
		public List<InterfaceParam> resParams { get; protected set; } = new List<InterfaceParam>();

		/// <summary>
		/// 构造函数
		/// </summary>
		public ReqResInterface() { }

		#region 配置

		/// <summary>
		/// 不显示的字段
		/// </summary>
		/// <returns></returns>
		protected static new string[] listExclude() {
			return new string[] { "code", "buildIn" };
		}

		/// <summary>
		/// 获取分组键值
		/// </summary>
		/// <returns></returns>
		public override string groupKey() {
			return serviceId.ToString();
		}

		#endregion
	}
}
