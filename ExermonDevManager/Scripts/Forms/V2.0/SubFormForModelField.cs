using System.Windows.Forms;

namespace ExermonDevManager.Scripts.Forms {

	using Entities;
	using Controls;

	//public class SubFormForModelField : Form {
	public class SubFormForModelField : SubForm<ModelField> {

		/// <summary>
		/// 控件
		/// </summary>
		public override Button saveButton => null;
		public override ComboBox rootComboBox => null;
		public override ExerDataGridView dataGridView => null;
		public override BindingSource dataBindingSource => null;

		/// <summary>
		/// 构造函数
		/// </summary>
		public SubFormForModelField() { }

	}
}
