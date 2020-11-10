using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Windows.Forms;

using System.ComponentModel;

using Microsoft.EntityFrameworkCore;

namespace ExermonDevManager.Forms {

	using Scripts.Forms;
	using Scripts.Controls;
	using Scripts.Entities;

	/// <summary>
	/// 测试窗口
	/// </summary>
	//public partial class ModelFieldSubForm : Form {
	public partial class ModelFieldSubForm : SubFormForModelField {

		/// <summary>
		/// 构造函数
		/// </summary>
		public ModelFieldSubForm() { InitializeComponent(); }
		
	}
}
