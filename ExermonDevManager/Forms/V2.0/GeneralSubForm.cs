using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Windows.Forms;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel;

namespace ExermonDevManager.Forms {

	using Scripts.Forms;
	using Scripts.Controls;
	using Scripts.Entities;

	/// <summary>
	/// 测试窗口
	/// </summary>
	//public partial class GeneralSubForm : Form {
	public partial class GeneralSubForm : SubFormForBase {

		/// <summary>
		/// 控件
		/// </summary>
		public override Button saveButton => saveData;
		public override ComboBox rootComboBox => rootCombox;
		public override ExerDataGridView dataGridView => dataView;
		public override BindingSource dataBindingSource => bindingSource;

		/// <summary>
		/// 构造函数
		/// </summary>
		public GeneralSubForm() { InitializeComponent(); }

	}
}
