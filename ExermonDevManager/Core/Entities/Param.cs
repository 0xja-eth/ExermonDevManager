using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

using System.ComponentModel.DataAnnotations.Schema;

namespace ExermonDevManager.Core.Entities {

	using Core.Data;
	using Core.Utils;
	using Core.CodeGen;
	using Core.Managers;

	/// <summary>
	/// 参数类
	/// </summary>
	public abstract partial class Param : BaseEntity {

		[AutoConvert]
		[ControlField("描述", 100)]
		public string description { get; set; } = "";

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
