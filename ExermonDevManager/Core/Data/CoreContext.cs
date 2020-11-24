using System;

using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExermonDevManager.Core.Data {

	using Managers;

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
		public TableSetting(string displayName, bool root = true) {
			this.displayName = displayName; this.root = root;
		}
		public TableSetting(string displayName, string name, bool root = true) {
			this.displayName = displayName;
			this.tableName = name; this.root = root;
		}
		public TableSetting(Type type) {
			displayName = type.Name;
			tableName = type.Name.ToLower() + "s";
		}
	}

	public class CoreContext : DbContext {

		/// <summary>
		/// 实体类型
		/// </summary>
		static List<Type> entityTypes = new List<Type>();

		/// <summary>
		/// 数据库配置
		/// </summary>
		//[TableSetting("模块")]
		//public DbSet<Module> modules { get; set; }

		//[TableSetting("模型")]
		//public DbSet<Model> models { get; set; }
		//[TableSetting("类型设定", false)]
		//public DbSet<Model.TypeSetting> typeSettings { get; set; }
		//[TableSetting("类型设定-关系", false)]
		//public DbSet<Model.TypeSettingModel> typeSettingModels { get; set; }
		//[TableSetting("类型设定-字段", false)]
		//public DbSet<Model.TypeSettingModelField> typeSettingModelFields { get; set; }
		//[TableSetting("模型继承关系", false)]
		//public DbSet<Model.InheritDerive> modelInheritDerives { get; set; }

		//[TableSetting("模型字段", false)]
		//public DbSet<ModelField> modelFields { get; set; }
		//[TableSetting("Django字段类型")]
		//public DbSet<DjangoFieldType> djangoFieldTypes { get; set; }
		//[TableSetting("DjangoOnDelete策略")]
		//public DbSet<DjangoOnDeleteChoice> djangoOnDeleteChoices { get; set; }

		//[TableSetting("请求-响应接口")]
		//public DbSet<ReqResInterface> reqResInterfaces { get; set; }
		//[TableSetting("发射接口")]
		//public DbSet<EmitInterface> emitInterfaces { get; set; }
		//[TableSetting("组合数据")]
		//public DbSet<GroupData> groupDatas { get; set; }
		//[TableSetting("组合数据继承关系", false)]
		//public DbSet<GroupData.InheritDerive> groupDataInheritDerives { get; set; }
		//[TableSetting("接口参数", false)]
		//public DbSet<InterfaceParam> interfaceParams { get; set; }

		//[TableSetting("Channels标志")]
		//public DbSet<ChannelsTag> channelTags { get; set; }
		//[TableSetting("异常")]
		//public DbSet<Exception_> exceptions { get; set; }

		//[TableSetting("自定义枚举")]
		//public DbSet<CustomEnumGroup> customEnumGroups { get; set; }
		//[TableSetting("自定义枚举项", false)]
		//public DbSet<CustomEnum> customEnums { get; set; }

		/// <summary>
		/// 配置
		/// </summary>
		/// <param name="options"></param>
		protected override void OnConfiguring(DbContextOptionsBuilder options) 
			=> options.UseMySQL(DatabaseManager.ConnectionString);

		/// <summary>
		/// 动态添加Model
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			Program.initialize();

			var mType = modelBuilder.GetType();
			foreach (var type in entityTypes) {
				Console.WriteLine("Creating table: " + type);

				var method = mType.GetMethod("Entity", new Type[] { });
				method = method.MakeGenericMethod(type);
				var builder = method.Invoke(modelBuilder, null) as EntityTypeBuilder;

				var tableName = CoreEntity.getTableName(type);
				builder.ToTable(tableName);
			}

			base.OnModelCreating(modelBuilder);
		}

		#region 注册表

		/// <summary>
		/// 获取实体类型数组
		/// </summary>
		/// <returns></returns>
		public static Type[] getEntityTypes() {
			return entityTypes.ToArray();
		}

		/// <summary>
		/// 注册实体
		/// </summary>
		/// <param name="type"></param>
		public static void registerEntity(Type type) {
			entityTypes.Add(type);
		}

		/// <summary>
		/// 注册实体
		/// </summary>
		/// <param name="type"></param>
		public static void registerEntities(Type[] types) {
			entityTypes.AddRange(types);
		}

		#endregion
	}
}
