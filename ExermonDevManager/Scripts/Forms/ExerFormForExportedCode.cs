using System.Windows.Forms;

namespace ExermonDevManager.Scripts.Forms {

	using CodeGen;
	using Controls;

	public class ExerFormForExportedCode : ExermonForm<GeneratedCode> {

		/// <summary>
		/// 对应的列表
		/// </summary>
		public override ExerListView listView { get { return null; } }

		/// <summary>
		/// 构造函数
		/// </summary>
		public ExerFormForExportedCode() { }

	}
}
