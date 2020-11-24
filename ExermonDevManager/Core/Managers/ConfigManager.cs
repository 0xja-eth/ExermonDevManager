using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LitJson;

namespace ExermonDevManager.Core.Managers {

	using Data;

	/// <summary>
	/// 配置管理类
	/// </summary>
	public static class ConfigManager {

		/// <summary>
		/// 路径常量定义
		/// </summary>
		public static readonly string FilePath = "./config.json";

		/// <summary>
		/// 配置数据
		/// </summary>
		public static ConfigData config = new ConfigData();

		#region 存取管理

		/// <summary>
		/// 保存配置
		/// </summary>
		public static void save() {
			StorageManager.saveObjectIntoFile(config, FilePath);
		}

		/// <summary>
		/// 读取所有数据
		/// </summary>
		public static void load() {
			StorageManager.loadObjectFromFile(ref config, FilePath);
		}

		#endregion

		/// <summary>
		/// 初始化
		/// </summary>
		public static void initialize() {
			load();
		}
	}
}
