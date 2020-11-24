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

	/// <summary>
	/// 接口参数类
	/// </summary>
	public class InterfaceParam : Param<GroupData> {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public int typeId { get; set; }
		[ControlField("类型")]
		public GroupData type { get; set; }
		[AutoConvert]
		[ControlField("维度")]
		public int dimension { get; set; }

		/// <summary>
		/// 所属模型
		/// </summary>
		//[AutoConvert]
		//public int? groupDataId { get; set; }
		public GroupData groupData => ownerType as GroupData;

		public int? reqInterfaceId { get; set; }
		public ReqResInterface reqInterface { get; set; }

		public int? resInterfaceId { get; set; }
		public ReqResInterface resInterface { get; set; }

		public int? emitInterfaceId { get; set; }
		public EmitInterface emitInterface { get; set; }

		/// <summary>
		/// 获取所属类型
		/// </summary>
		/// <returns></returns>
		//protected CacheAttr<GroupData> ownerType_ = null;
		//protected GroupData _ownerType_() {
		//	var types = poolGet<GroupData>();
		//	foreach (var type in types)
		//		if (type.params_.Contains(this))
		//			return type;
		//	return null;
		//}
		//public sealed override int? ownerTypeId {
		//	get => groupDataId;
		//	set { groupDataId = value; }
		//}
		//public sealed override Type_ ownerType {
		//	get => groupData;
		//	set { groupData = value as GroupData; }
		//}

		///// <summary>
		///// 获取类型实例
		///// </summary>
		///// <returns></returns>
		//protected CacheAttr<GroupData> type_ = null;
		//protected GroupData _type_() {
		//	return poolGet<GroupData>(typeId);
		//}
		//public GroupData type() {
		//	return type_?.value();
		//}

		/// <summary>
		/// 实际显示的类型名称
		/// </summary>
		/// <returns></returns>
		public string typeName() {
			var res = type.name;
			if (dimension == 0) return res;
			if (dimension == 1) return res + "（数组）";

			var format = res + "（{0}维数组）";
			return string.Format(format, dimension);
		}

		/// <summary>
		/// 实际显示的类型代码
		/// </summary>
		/// <returns></returns>
		[ControlField("类型", 10)]
		public string typeCode() {
			var res = type.code;
			for (int i = 0; i < dimension; ++i)
				res += "[]";
			return res;
		}

		/// <summary>
		/// 是否为用ID名参数
		/// </summary>
		/// <returns></returns>
		public bool isUid() { return name == "uid"; }
	}
	
}
