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
	/// 枚举数据类型基类
	/// </summary>
	public abstract class Enum_ : CoreEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("枚举值", 10)]
		public int code { get; set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		public Enum_() { }
		public Enum_(int code, string name, string description = "") {
			this.code = code; this.name = name;
			this.description = description;
		}

		/// <summary>
		/// 下拉框文本
		/// </summary>
		/// <returns></returns>
		public override string comboText() {
			return code + ". " + name;
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

}
