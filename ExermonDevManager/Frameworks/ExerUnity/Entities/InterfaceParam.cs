using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

using System.ComponentModel.DataAnnotations.Schema;

namespace ExermonDevManager.Frameworks.ExerUnity.Entities {

	using Core.Data;
	using Core.Entities;
	
	/// <summary>
	/// 接口参数类
	/// </summary>
	[TableSetting("接口参数", false)]
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
		/// 四个属性选一个进行关联
		/// </summary>
		public GroupData groupData => ownerType as GroupData;

		public int? reqInterfaceId { get; set; }
		public ReqResInterface reqInterface { get; set; }

		public int? resInterfaceId { get; set; }
		public ReqResInterface resInterface { get; set; }

		public int? emitInterfaceId { get; set; }
		public EmitInterface emitInterface { get; set; }
		
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
			var res = type.typeCode;
			for (int i = 0; i < dimension; ++i)
				res += "[]";
			return res;
		}
	}
	
}
