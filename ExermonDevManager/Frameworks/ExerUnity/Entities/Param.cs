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
	/// 参数类
	/// </summary>
	public abstract partial class Param : CoreEntity {

		/// <summary>
		/// Python格式名称
		/// </summary>
		/// <returns></returns>
		public string pyName() {
			return DataLoader.hump2Underline(name);
		}

		/// <summary>
		/// C#格式名称
		/// </summary>
		/// <returns></returns>
		public string csName() {
			return DataLoader.underline2LowerHump(name);
		}

		/// <summary>
		/// 所属类型
		/// </summary>
		/// <returns></returns>
		public int? ownerTypeId { get; set; }
	}

	/// <summary>
	/// 参数类
	/// </summary>
	public abstract partial class Param<T> : Param where T : Type_ {

		/// <summary>
		/// 属性
		/// </summary>
		
		/// <summary>
		/// 获取分组键值
		/// </summary>
		/// <returns></returns>
		public override string groupKey() {
			return ownerType?.id.ToString();
		}

		public T ownerType { get; set; }
		//public abstract int? ownerTypeId { get; set; }
		//public abstract Type_ ownerType { get; set; }
	}
}
