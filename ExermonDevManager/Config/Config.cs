using System;
using System.Collections.Generic;

namespace ExermonDevManager.Config {

	// V1.0
	//using Scripts.Data;
	// V2.0
	using Core.Data;
	using Core.CodeGen;

	/// <summary>
	/// 配置内容
	/// </summary>
	public static class Config {
		
		/// <summary>
		/// MySQL连接配置
		/// </summary>
		public static class MySQL {

			public const string Host = "127.0.0.1";
			public const string User = "root";
			public const string Password = "123456";
			public const string Database = "exermon_manager";

		}
		
	}
}
