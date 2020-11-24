using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExermonDevManager.Core.CodeGen {

	using Data;
	
	/// <summary>
	/// Python
	/// </summary>
	public class Python : Language<Python> {
		
		// 表示为空
		public override string nullCode => "null";

		#region 代码生成
		
		/// <summary>
		/// 生成类型代码
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		string genTypeCode(string type) {
			if (string.IsNullOrEmpty(type)) return "";
			return ": '" + type + "'";
		}

		/// <summary>
		/// 转化为代码（字符串代码）
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		protected override string bool2Code(bool val) {
			return val ? "True" : "False";
		}

		#endregion

	}
}
