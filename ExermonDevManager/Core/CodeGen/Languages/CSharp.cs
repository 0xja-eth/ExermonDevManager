using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExermonDevManager.Core.CodeGen {
	
	/// <summary>
	/// C#
	/// </summary>
	public class CSharp : Language<CSharp> {

		/// <summary>
		/// 语言名称
		/// </summary>
		public override string langName => "C#";

		// 表示为空
		public override string nullCode => "null";

		#region 代码生成
		
		/// <summary>
		/// 转化为代码（字符串代码）
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		protected override string bool2Code(bool val) {
			return val ? "true" : "false";
		}

		#endregion

	}
}
