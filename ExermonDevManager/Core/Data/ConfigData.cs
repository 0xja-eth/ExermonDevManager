using System;
using System.Collections.Generic;

namespace ExermonDevManager.Core.Data {

	/// <summary>
	/// 配置数据
	/// </summary>
	public class ConfigData : BaseData {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public string editorPath { get; set; }
		[AutoConvert]
		public string exportPath { get; set; }

		/// <summary>
		/// 能否应用ID
		/// </summary>
		/// <returns></returns>
		public override bool idEnable() {
			return false;
		}
	}

}
