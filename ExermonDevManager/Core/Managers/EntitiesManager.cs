using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

using System.Windows.Forms;

using Microsoft.EntityFrameworkCore;

using LitJson;

namespace ExermonDevManager.Core.Managers {

	using Entities;

	using Config;
	using Utils;

	/// <summary>
	/// 表信息
	/// </summary>
	public class TableInfo {

		public ExerDbContext db { get; protected set; }
		
		public Type type { get; protected set; }

		public string tableName { get; protected set; }
		public string displayName { get; protected set; }

		public IList items { get; protected set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		public TableInfo(ExerDbContext db, /*PropertyInfo prop,*/ TableSetting attr, Type type) {
			this.db = db; this.type = type; /*this.prop = prop;*/

			tableName = attr.tableName;
			displayName = string.Format(EntitiesManager.
				DisplayNameFormat, attr.displayName, tableName);
		}

		/// <summary>
		/// 读取数据
		/// </summary>
		/// <param name="db"></param>
		public void load() {
			var method = db.GetType().GetMethod("Set");
			method = method.MakeGenericMethod(type);

			var dbSet = method.Invoke(db, null);

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
	/// 数据库管理类
	/// </summary>
	public static class EntitiesManager {

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
		/// 实体类型信息
		/// </summary>
		public class EntityTypeInfo {

			/// <summary>
			/// 实体类型
			/// </summary>
			public Type entityType;

			/// <summary>
			/// 所属框架
			/// </summary>
			public IFramework framework;

			/// <summary>
			/// 构造函数
			/// </summary>
			public EntityTypeInfo(IFramework framework, Type entityType) {
				this.entityType = entityType;
				this.framework = framework;
			}

		}

		/// <summary>
		/// 数据库连接
		/// </summary>
		public static ExerDbContext db { get; private set; }

		/// <summary>
		/// 表类型列表
		/// </summary>
		public static List<TableInfo> rootTables { get; private set; } = new List<TableInfo>();
		public static List<TableInfo> tables { get; private set; } = new List<TableInfo>();

		/// <summary>
		/// 实体类型
		/// </summary>
		public static List<EntityTypeInfo> entityTypes { get; private set; } = new List<EntityTypeInfo>();

		#region 初始化/结束

		/// <summary>
		/// 初始化
		/// </summary>
		public static void initialize() {
			if (db != null) return;
			db = new ExerDbContext();

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
			foreach(var info in entityTypes) {
				var type = info.entityType;
				var attr = BaseEntity.getTableSetting(type);
				var table = new TableInfo(db, attr, type);

				tables.Add(table);
				if (attr.root) rootTables.Add(table);
			}
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
		/// 获取实体的框架
		/// </summary>
		/// <param name="entityType"></param>
		/// <returns></returns>
		public static IFramework getFramework(Type entityType) {
			return entityTypes.Find(e => e.entityType == entityType)?.framework;
		}

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

		#region 注册实体
		
		/// <summary>
		/// 注册实体
		/// </summary>
		/// <param name="type"></param>
		public static void registerEntity(IFramework framework, Type type) {
			Console.WriteLine("Register entity: " + type);

			entityTypes.Add(new EntityTypeInfo(framework, type));
		}

		/// <summary>
		/// 注册实体
		/// </summary>
		/// <param name="type"></param>
		public static void registerEntities(IFramework framework, Type[] types) {
			foreach (var type in types)
				registerEntity(framework, type);
		}

		#endregion
	}
}
