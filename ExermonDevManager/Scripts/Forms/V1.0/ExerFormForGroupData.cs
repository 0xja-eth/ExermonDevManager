using System.Windows.Forms;

namespace ExermonDevManager.Scripts.Forms {

	using Data;
	using Controls;

	public class ExerFormForGroupData : ExermonForm<GroupData> {

		/// <summary>
		/// 对应的列表
		/// </summary>
		public override ExerListView listView { get { return null; } }

		/// <summary>
		/// 构造函数
		/// </summary>
		public ExerFormForGroupData() { }

	}
}
