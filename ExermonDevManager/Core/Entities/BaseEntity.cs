using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

namespace ExermonDevManager.Core.Entities {

	using Data;
	using CodeGen;
	using Managers;

	using Utils;

	/// <summary>
	/// 表配置特性
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class TableSetting : Attribute {

		/// <summary>
		/// 表名
		/// </summary>
		public string tableName;

		/// <summary>
		/// 显示名
		/// </summary>
		public string displayName;

		/// <summary>
		/// 是否为根实体
		/// </summary>
		public bool root = false;

		/// <summary>
		/// 构造函数
		/// </summary>
		public TableSetting() { }
		public TableSetting(string displayName, bool root = true) {
			this.displayName = displayName;
			this.root = root;
		}
		public TableSetting(string displayName, string tableName, bool root = true) {
			this.displayName = displayName;
			this.tableName = tableName;
			this.root = root;
		}
	}

	/// <summary>
	/// 基本实体
	/// </summary>
	public abstract class BaseEntity : CoreData {

		/// <summary>
		/// 是否支持ID
		/// </summary>
		/// <returns></returns>
		public sealed override bool idEnable() {
			return true;
		}

		/// <summary>
		/// ID偏移量
		/// </summary>
		/// <returns></returns>
		protected override int idOffset() {
			return 1;
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		public BaseEntity() { }
		public BaseEntity(string name, string code, bool buildIn = true) :
			base(name, code, buildIn) { }
		public BaseEntity(string name, bool buildIn = true) :
			base(name, buildIn) { }

		#region 代码生成

		/// <summary>
		/// 获取代码生成器
		/// </summary>
		/// <returns></returns>
		public CodeGenerator getGenerator(Enum name) {
			return getGenerateManager().getGenerator(this, name);
		}

		/// <summary>
		/// 获取指定/所有生成器
		/// </summary>
		/// <returns></returns>
		public List<CodeGenerator> getGenerators(params Enum[] names) {
			return getGenerateManager().getGenerators(this, names);
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		/// <returns></returns>
		public string genCode(Enum name) {
			var generator = getGenerator(name);
			return generator?.generate();
		}

		/// <summary>
		/// 生成代码列表
		/// </summary>
		/// <returns></returns>
		public List<GeneratedCode> genCodes(Enum name) {
			var generator = getGenerator(name);
			generator?.generate();
			return generator?.codes;
		}

		/// <summary>
		/// 获取自身对应的生成管理类
		/// </summary>
		/// <returns></returns>
		IGenerateManager getGenerateManager() {
			return getGenerateManager(GetType());
		}

		/// <summary>
		/// 获取自身对应的生成管理类
		/// </summary>
		/// <returns></returns>
		public static IGenerateManager getGenerateManager(Type type) {
			var mType = typeof(GenerateManager<>).MakeGenericType(type);
			var getFunc = mType.GetMethod("Get", ReflectionUtils.DefaultStaticFlag);

			return getFunc.Invoke(null, null) as IGenerateManager;
		}

		#endregion

		#region 标记处理

		#region 表数据

		/// <summary>
		/// 表名
		/// </summary>
		/// <returns></returns>
		public static string getTableName(Type type) {
			return getTableSetting(type).tableName;
		}

		/// <summary>
		/// 显示名
		/// </summary>
		/// <returns></returns>
		public static string getDisplayName(Type type) {
			return getTableSetting(type).displayName;
		}

		/// <summary>
		/// 获取表设置
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static TableSetting getTableSetting(Type type) {
			var attr = type.GetCustomAttribute<TableSetting>(true);
			if (attr == null) attr = new TableSetting();

			attr.displayName = attr.displayName ?? type.Name;
			attr.tableName = attr.tableName ?? type.Name.ToLower() + "s";

			return attr;
		}

		#endregion

		#region 模板数据

		/// <summary>
		/// 获取模板设定
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static IEnumerable<TemplateSetting> getTemplateSetting(Type type) {
			return type.GetCustomAttributes<TemplateSetting>();
		}

		#endregion

		#endregion
	}

	/// <summary>
	/// 具备描述的实体
	/// </summary>
	public interface IDescriptionEntity {

		/// <summary>
		/// 属性
		/// </summary>
		string description { get; set; }

		/// <summary>
		/// 注释描述
		/// </summary>
		/// <returns></returns>
		string commentDescription();
	}

}
