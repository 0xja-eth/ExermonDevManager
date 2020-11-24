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
	/// 自定义枚举
	/// </summary>
	public class CustomEnumGroup : CoreEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("前端可用", 10)]
		public bool isFrontend { get; set; } = true;
		[AutoConvert]
		[ControlField("后台可用", 10)]
		public bool isBackend { get; set; } = true;

		[AutoConvert]
		[ControlField("枚举值", 50)]
		public List<CustomEnum> values { get; set; } = new List<CustomEnum>();

		///// <summary>
		///// 生成Python代码块
		///// </summary>
		///// <returns></returns>
		//public override LangElement<Python> genPyBlock() {
		//	if (!isBackend) return null;
		//	var block = new LangEnum<Python>(name, description);

		//	foreach (var value in values) {
		//		var subBlock = value.genPyBlock<LangBlock<Python>>();
		//		if (subBlock != null) block.addSubBlock(subBlock);
		//	}

		//	return block;
		//}

		///// <summary>
		///// 生成C#代码块
		///// </summary>
		///// <returns></returns>
		//public override LangElement<CSharp> genCSBlock() {
		//	if (!isFrontend) return null;
		//	var block = new LangEnum<CSharp>(name, description);

		//	foreach (var value in values) {
		//		var subBlock = value.genCSBlock<LangBlock<CSharp>>();
		//		if (subBlock != null) block.addSubBlock(subBlock);
		//	}

		//	return block;
		//}
	}

	/// <summary>
	/// 自定义枚举
	/// </summary>
	public class CustomEnum : Enum_ {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public int enumGroupId { get; set; }
		public CustomEnumGroup enumGroup { get; set; }
	}
	
}
