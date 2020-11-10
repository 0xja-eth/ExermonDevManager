using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

using System.Windows.Forms;

using Microsoft.EntityFrameworkCore;

using LitJson;

namespace ExermonDevManager.Scripts.Entities {

	using Config;
	using Utils;

	/// <summary>
	/// 表信息
	/// </summary>
	public class TableInfo {

		public CoreContext db { get; protected set; }
		
		public Type type { get; protected set; }
		public PropertyInfo prop { get; protected set; }

		public string tableName { get; protected set; }
		public string displayName { get; protected set; }

		public IList items { get; protected set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		public TableInfo(CoreContext db, PropertyInfo prop, string name, Type type) {
			this.db = db; this.type = type; this.prop = prop;

			tableName = prop.Name.ToLower();
			displayName = string.Format(DBManager.
				DisplayNameFormat, name, tableName);
		}

		/// <summary>
		/// 读取数据
		/// </summary>
		/// <param name="db"></param>
		public void load() {
			var dbSet = prop.GetValue(db);

			var eType = typeof(Enumerable);
			var flags = ReflectionUtils.DefaultFlag | BindingFlags.Static;

			var mInfo = eType.GetMethod("ToList", flags);
			mInfo = mInfo.MakeGenericMethod(new Type[] { type });

			items = mInfo.Invoke(null, new object[] { dbSet }) as IList;
		}

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="db"></param>
		public void delete(object item) {
			if (item == null) return;
			if (db.Entry(item).State == EntityState.Detached) db.Add(item);
			db.Remove(item);
		}

		/// <summary>
		/// 保存数据
		/// </summary>
		/// <param name="db"></param>
		public void save(bool saveChanges = true) {
			foreach (var item in items)
				if (db.Entry(item).State == EntityState.Detached) db.Add(item);

			if (saveChanges) db.SaveChanges();
		}
	}

	/// <summary>
	/// 数据管理类
	/// </summary>
	public static class DBManager {

		/// <summary>
		/// 常量定义
		/// </summary>
		public const string DisplayNameFormat = "{0}({1})";
		const string ConnectionStringFormat = "server={0};user id={1};" +
			"password={2};persistsecurityinfo=True;database={3};Character Set=utf8";

		/// <summary>
		/// 链接字符串
		/// </summary>
		public static string ConnectionString => string.Format(ConnectionStringFormat,
			Config.MySQL.Host, Config.MySQL.User, Config.MySQL.Password, Config.MySQL.Database);


		/// <summary>
		/// 数据库连接
		/// </summary>
		public static CoreContext db;

		/// <summary>
		/// 表类型列表
		/// </summary>
		public static List<TableInfo> rootTables = new List<TableInfo>();
		public static List<TableInfo> tables = new List<TableInfo>();

		#region 初始化/结束

		/// <summary>
		/// 初始化
		/// </summary>
		public static void initialize() {
			if (db != null) return;
			db = new CoreContext();

			generateTables();
			loadTables();
		}

		/// <summary>
		/// 结束
		/// </summary>
		public static void terminate() {
			db?.Dispose(); db = null;
			rootTables.Clear();
		}

		#endregion

		#region 数据操作

		/// <summary>
		/// 生成表数据
		/// </summary>
		static void generateTables() {
			ReflectionUtils.processAttribute<PropertyInfo,
				CoreContext.TableSettingAttribute>(
				typeof(CoreContext), (p, a) => {
					var type = p.PropertyType;
					if (!type.IsGenericType) return;

					var tType = type.GenericTypeArguments[0];
					var table = new TableInfo(db, p, a.name, tType);

					tables.Add(table);

					if (a.root) rootTables.Add(table);
				}
			);
		}

		/// <summary>
		/// 读取所有数据
		/// </summary>
		public static void loadTables() {
			foreach (var table in tables) table.load();
		}

		/// <summary>
		/// 保存所有数据
		/// </summary>
		public static void saveTables() {
			foreach (var table in tables) table.save(false);
			db.SaveChanges();
		}

		#endregion

		#region 数据获取

		/// <summary>
		/// 获取表名
		/// </summary>
		/// <param name="tType">表类型</param>
		/// <returns>表名</returns>
		public static TableInfo getTableInfo(Type tType) {
			foreach (var table in tables)
				if (table.type == tType) return table;
			return null;
		}

		/// <summary>
		/// 获取表名
		/// </summary>
		/// <param name="tType">表类型</param>
		/// <returns>表名</returns>
		public static string getTableName(Type tType) {
			return getTableInfo(tType)?.tableName;
		}

		/// <summary>
		/// 获取数据
		/// </summary>
		/// <param name="tType"></param>
		/// <returns></returns>
		public static IList getItems(Type tType, bool copy = false) {
			var res = getTableInfo(tType)?.items;
			if (copy && res != null) {
				var rType = res.GetType();
				var params_ = new object[] { res };
				res = Activator.CreateInstance(rType, params_) as IList;
			}
			return res;
		}
		
		#endregion

	}
}
