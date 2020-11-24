using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

using System.ComponentModel.DataAnnotations.Schema;

namespace ExermonDevManager.Frameworks.ExerUnity.Entities {

	using Core.Data;
	using Core.Utils;
	using Core.CodeGen;
	using Core.Managers;
	
	#region 模型相关
	
	/// <summary>
	/// 类型
	/// </summary>
	public enum FieldEnum {
		None, Int, Float, Bool, Str, Time, Bin, File, Rel,
	}

	/// <summary>
	/// Django字段类型
	/// </summary>
	public class DjangoFieldType : CoreEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("类型")]
		public FieldEnum type { get; set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		public DjangoFieldType() { }
		public DjangoFieldType(string name,
			FieldEnum type = FieldEnum.Int, string description = "") {
			this.name = name; this.type = type;
			this.description = description;
		}

		/// <summary>
		/// 下拉框文本
		/// </summary>
		/// <returns></returns>
		public override string comboText() {
			return name;
		}
	}
	
	/// <summary>
	/// OnDelete选项
	/// </summary>
	public class DjangoOnDeleteChoice : CoreEntity {

		/// <summary>
		/// 构造函数
		/// </summary>
		public DjangoOnDeleteChoice() { }
		public DjangoOnDeleteChoice(string name, string description = "") {
			this.name = name; 
			this.description = description;
		}
	}

	#endregion

	#region 枚举相关
	
	/// <summary>
	/// Channels标签
	/// </summary>
	public class ChannelsTag : Enum_ {

		/// <summary>
		/// 构造函数
		/// </summary>
		public ChannelsTag() { }
		public ChannelsTag(int code, string name, string description = "") :
			base(code, name, description) { }
	}

	#endregion

	///// <summary>
	///// 默认/内置数据
	///// </summary>
	//public static class Default {
		
	//	/// <summary>
	//	/// 默认数据类型
	//	/// </summary>
	//	public static class Types {

	//		/// <summary>
	//		/// 获取指定名称的模型
	//		/// </summary>
	//		/// <param name="name"></param>
	//		/// <returns></returns>
	//		public static GroupData get(string name) {
	//			return DBManager.db.groupDatas.Where(
	//				m => m.name == name && m.buildIn).First();
	//		}

	//		/// <summary>
	//		/// 初始化
	//		/// </summary>
	//		public static void initialize() { }
	//	}

	//	/// <summary>
	//	/// 默认Channels标签
	//	/// </summary>
	//	public static class ChannelsTags {

	//		/// <summary>
	//		/// 获取指定名称的模型
	//		/// </summary>
	//		/// <param name="name"></param>
	//		/// <returns></returns>
	//		public static ChannelsTag get(string name) {
	//			return DBManager.db.channelTags.Where(
	//				m => m.name == name && m.buildIn).First();
	//		}

	//		/// <summary>
	//		/// 初始化
	//		/// </summary>
	//		public static void initialize() {}
	//	}

	//	/// <summary>
	//	/// Django默认配置
	//	/// </summary>
	//	public static class Django {

	//		/// <summary>
	//		/// 默认字段类型
	//		/// </summary>
	//		public static class FieldTypes {

	//			/// <summary>
	//			/// 获取指定名称的模型
	//			/// </summary>
	//			/// <param name="name"></param>
	//			/// <returns></returns>
	//			public static DjangoFieldType get(string name) {
	//				return DBManager.db.djangoFieldTypes.Where(
	//					m => m.name == name && m.buildIn).First();
	//			}

	//			/// <summary>
	//			/// 初始化
	//			/// </summary>
	//			public static void initialize() { }
	//		}

	//		/// <summary>
	//		/// 删除选项
	//		/// </summary>
	//		public static class OnDeleteChoices {
				
	//			/// <summary>
	//			/// 获取指定名称的模型
	//			/// </summary>
	//			/// <param name="name"></param>
	//			/// <returns></returns>
	//			public static DjangoOnDeleteChoice get(string name) {
	//				return DBManager.db.djangoOnDeleteChoices.Where(
	//					m => m.name == name && m.buildIn).First();
	//			}

	//			/// <summary>
	//			/// 初始化
	//			/// </summary>
	//			public static void initialize() { }
	//		}

	//		/// <summary>
	//		/// 初始化
	//		/// </summary>
	//		public static void initialize() {
	//			FieldTypes.initialize();
	//			OnDeleteChoices.initialize();
	//		}
	//	}

	//	/// <summary>
	//	/// Unity默认配置
	//	/// </summary>
	//	public static class Unity {

	//		/// <summary>
	//		/// 默认字段类型
	//		/// </summary>
	//		public static class Models {
				
	//			/// <summary>
	//			/// 获取指定名称的模型
	//			/// </summary>
	//			/// <param name="name"></param>
	//			/// <returns></returns>
	//			public static Model get(string name) {
	//				return DBManager.db.models.Where(
	//					m => m.name == name && m.buildIn).First();
	//			}

	//			/// <summary>
	//			/// 初始化
	//			/// </summary>
	//			public static void initialize() { }
	//		}

	//		/// <summary>
	//		/// 初始化
	//		/// </summary>
	//		public static void initialize() {
	//			Models.initialize();
	//		}
	//	}

	//	/// <summary>
	//	/// 初始化
	//	/// </summary>
	//	public static void initialize() {
	//		Types.initialize();
	//		ChannelsTags.initialize();
	//		Django.initialize();
	//		Unity.initialize();
	//	}
	//}

}
