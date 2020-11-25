using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Windows.Forms;

using System.ComponentModel;

using Microsoft.EntityFrameworkCore;

namespace ExermonDevManager.Frameworks.ExerUnity.Forms {

	using Core.Forms;
	using Core.Controls;
	using Core.Data;

	/// <summary>
	/// 测试窗口
	/// </summary>
	//public partial class ModelFieldSubForm : Form {
	public partial class ModelFieldForm : ExerFormForModelField {

		/// <summary>
		/// 构造函数
		/// </summary>
		public ModelFieldForm() { InitializeComponent(); }

		#region 默认事件

		private void intType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType("int");
		}

		private void doubleType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType("double");
		}

		private void strType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType("string");
		}

		private void boolType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType("bool");
		}

		private void dateType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType("Date");
		}

		private void dateTimeType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType("DateTime");
		}

		private void tupleType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType("Tuple<int, string>");
		}

		#endregion

		#region 控件操作

		/// <summary>
		/// 配置类型
		/// </summary>
		/// <param name="type"></param>
		protected void setType(string name) {
			//var type = Default.Unity.Models.get(name);
			//fType.SelectedValue = type.id;
			//updateCustomControls();
		}

		#endregion
	}
}
