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
		[ControlField("参数", 20)]
		[InverseProperty("emitInterface")]
		public List<InterfaceParam> params_ { get; protected set; } = new List<InterfaceParam>();

		[AutoConvert]
		public int bModuleId { get; set; }
		[ControlField("所属模块", 2)]
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
	
}
