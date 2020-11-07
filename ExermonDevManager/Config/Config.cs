using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExermonDevManager.Config {

	/// <summary>
	/// 配置内容
	/// </summary>
	public static class Config {
		
		/// <summary>
		/// MySQL连接数据
		/// </summary>
		public static class MySQL {

			public const string Host = "127.0.0.1";
			public const string User = "root";
			public const string Password = "123456";
			public const string Database = "exermon_manager";

		}
		
	}
}
