using System.Windows.Forms;

namespace ExermonDevManager.Core.Forms {

	using CodeGen;
	using Controls;

	public class ExerFormForGeneratedCode : ExermonForm<GeneratedCode> {

		/// <summary>
		/// 对应的列表
		/// </summary>
		public override ExerListView listView { get { return null; } }

		/// <summary>
		/// 构造函数
		/// </summary>
		public ExerFormForGeneratedCode() { }

	}
}
