using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LitJson;

namespace ExermonDevManager.Scripts.Data {

	using Config;
	using CodeGen;

	/// <summary>
	/// 数据管理类
	/// </summary>
	public static class DataManager {

		/// <summary>
		/// 常量定义
		/// </summary>
		const string ConnectionStringFormat = "server={0};user id={1};" +
			"password={2};persistsecurityinfo=True;database={3};Character Set=utf8";

		/// <summary>
		/// 链接字符串
		/// </summary>
		public static string ConnectionString => string.Format(ConnectionStringFormat,
			Config.MySQL.Host, Config.MySQL.User, Config.MySQL.Password, Config.MySQL.Database);

		/// <summary>
		/// 路径常量定义
		/// </summary>
		public static readonly string RootPath = "./data/";

		/// <summary>
		/// 数据类型列表
		/// </summary>
		public static List<Type> dataTypes = new List<Type>();

		/// <summary>
		/// 注册类型
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public static void registerType<T>() where T : BaseData {
			dataTypes.Add(typeof(T));
		}

		#region 存取管理

		/// <summary>
		/// 保存所有数据
		/// </summary>
		public static void saveAllData() {
			foreach (var type in dataTypes) saveData(type);
		}

		/// <summary>
		/// 保存单个数据
		/// </summary>
		/// <param name="type"></param>
		public static void saveData(Type type) {
			var fileName = type.Name + ".json";
			var data = BaseData.convertPool(type);
			StorageManager.saveJsonIntoFile(
				data, RootPath, fileName);
		}

		/// <summary>
		/// 读取所有数据
		/// </summary>
		static void loadAllData() {
			foreach (var type in dataTypes) loadData(type);
		}

		/// <summary>
		/// 读取单个数据
		/// </summary>
		/// <param name="type"></param>
		public static void loadData(Type type) {
			var fileName = type.Name + ".json";
			var data = StorageManager.loadJsonFromFile(
				RootPath, fileName);
			BaseData.loadPool(type, data);
		}

		#endregion

		/// <summary>
		/// 初始化
		/// </summary>
		public static void initialize() {
			registerType<Module>();
			registerType<GroupData>();
			registerType<Model>();
			registerType<ChannelsTag>();
			registerType<CustomEnumGroup>();
			registerType<Exception_>();
			registerType<ReqResInterface>();
			registerType<EmitInterface>();

			loadAllData();
		}
	}
}
