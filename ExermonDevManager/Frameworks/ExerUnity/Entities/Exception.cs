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
	/// 异常
	/// </summary>
	public class Exception_ : Enum_ {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("警告文本", 110)]
		public string alertText { get; set; } = "";
		[AutoConvert]
		public int moduleId { get; set; }
		[ControlField("所属模块", 2)]
		public Module module { get; set; }

		/// <summary>
		/// 获取分组键值
		/// </summary>
		/// <returns></returns>
		public override string groupKey() {
			return moduleId.ToString();
		}

		///// <summary>
		///// 获取模块实例
		///// </summary>
		///// <returns></returns>
		//protected CacheAttr<Module> module_ = null;
		//protected Module _module_() {
		//	return poolGet<Module>(moduleId);
		//}
		//public Module module() {
		//	return module_?.value();
		//}

		/// <summary>
		/// 生成键代码
		/// </summary>
		/// <returns></returns>
		public string genKeyCode() {
			return "ErrorType." + name;
		}

		/// <summary>
		/// 生成前端提示文本设定代码
		/// </summary>
		/// <returns></returns>
		public string genAlertTextCode() {
			return "\"" + alertText + "\"";
		}

		///// <summary>
		///// 生成异常管理代码
		///// </summary>
		///// <returns></returns>
		//public static string genPyExceptionCode() {
		//	var file = new LangFile<Python>();
		//	file.addSubBlock(new LangErrorTypeEnum());
		//	file.addSubBlock(new LangGameExceptionClass());
		//	return file.genCode();
		//}
		
	}

}
