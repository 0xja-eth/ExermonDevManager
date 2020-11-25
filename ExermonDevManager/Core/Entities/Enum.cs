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
	/// 枚举数据类型基类
	/// </summary>
	public abstract class Enum_ : BaseEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("值", 10)]
		public int value { get; set; }

		/// <summary>
		/// 下拉框文本
		/// </summary>
		/// <returns></returns>
		public override string comboText() {
			return value + ". " + code;
		}

		///// <summary>
		///// 生成Python代码块
		///// </summary>
		///// <returns></returns>
		//public override LangElement<Python> genPyBlock() {
		//	return new LangEnumItem<Python>(name, code, description);
		//}

		///// <summary>
		///// 生成C#代码块
		///// </summary>
		///// <returns></returns>
		//public override LangElement<CSharp> genCSBlock() {
		//	return new LangEnumItem<CSharp>(name, code, description);
		//}
	}

	/// <summary>
	/// 自定义枚举
	/// </summary>
	[TableSetting("自定义枚举")]
	public class CustomEnumGroup : BaseEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("枚举值", 50)]
		public List<CustomEnum> values { get; set; } = new List<CustomEnum>();

	}

	/// <summary>
	/// 自定义枚举
	/// </summary>
	[TableSetting("自定义枚举项", false)]
	public class CustomEnum : Enum_ {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public int enumGroupId { get; set; }
		public CustomEnumGroup enumGroup { get; set; }
	}

}
