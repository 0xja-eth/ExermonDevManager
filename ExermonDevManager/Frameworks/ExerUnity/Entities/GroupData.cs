using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExermonDevManager.Frameworks.ExerUnity.Entities {

	using Core.Data;
	using Core.Entities;

	/// <summary>
	/// 继承关系
	/// </summary>
	[TableSetting("组合数据继承", false)]
	public class GroupDataInheritDerive : InheritDerive<GroupData> { }

	/// <summary>
	/// 组合数据
	/// </summary>
	public class GroupData : Type_<GroupData, InterfaceParam, GroupDataInheritDerive> {

		/// <summary>
		/// 关联的模型
		/// </summary>
		[AutoConvert]
		public int? modelId { get; set; }
		[AutoConvert]
		public Model model { get; set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		public GroupData() { }
		public GroupData(string name, string code, bool buildIn = true) :
			base(name, code, buildIn) { }
		public GroupData(string name, bool buildIn = true) :
			base(name, buildIn) { }

		/// <summary>
		/// 类型代码
		/// </summary>
		/// <returns></returns>
		public string typeCode => model?.code ?? code;
	}
}
