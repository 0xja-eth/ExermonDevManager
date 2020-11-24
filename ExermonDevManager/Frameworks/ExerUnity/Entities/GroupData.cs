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
	
}
