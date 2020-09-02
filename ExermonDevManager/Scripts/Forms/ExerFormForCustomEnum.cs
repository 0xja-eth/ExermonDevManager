using System.Windows.Forms;

namespace ExermonDevManager.Scripts.Forms {

	using Data;
	using Controls;

	//public class Test : ExermonForm<ExermonDevManager.Scripts.Data.ReqResInterface> {
	public class ExerFormForCustomEnum : ExermonForm<CustomEnum> {

		/// <summary>
		/// 对应的列表
		/// </summary>
		public override ExerListView listView { get { return null; } }

		/// <summary>
		/// 构造函数
		/// </summary>
		public ExerFormForCustomEnum() { }

	}
}
