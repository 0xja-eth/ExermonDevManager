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
	public partial class ModelFieldSubForm : SubFormForModelField {

		/// <summary>
		/// 构造函数
		/// </summary>
		public ModelFieldSubForm() { InitializeComponent(); }

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

		private void cancelChoices_Click(object sender, EventArgs e) {
			choices.SelectedIndex = -1;
		}

		#endregion

		#region 控件操作

		/// <summary>
		/// 配置类型
		/// </summary>
		/// <param name="type"></param>
		void setType(string name) {
			//var type = Default.Unity.Models.get(name);
			//fType.SelectedValue = type.id;
			//updateCustomControls();
		}

		#region 控件配置

		/// <summary>
		/// 刷新窗口
		/// </summary>
		protected override void configCustomControls() {
			base.configCustomControls();
			setupComboxes();
		}

		/// <summary>
		/// 配置下拉框数据
		/// </summary>
		void setupComboxes() {
			fType.filter = "isFrontend";
			toModel.filter = "isBackend";
		}

		#endregion

		#region 控件绑定/更新

		/// <summary>
		/// 更新
		/// </summary>
		protected override void updateCustomControls() {
			base.updateCustomControls();
			updateControlsEnable();
			updateCodePreviews();
		}

		/// <summary>
		/// 更新控件有效情况
		/// </summary>
		void updateControlsEnable() {
			var enableNames = currentItem.getEnableFieldNames();
			foreach (var c in fieldControls)
				doUpdateControl(c as Control, enableNames);
		}

		/// <summary>
		/// 执行配置
		/// </summary>
		/// <param name="control"></param>
		void doUpdateControl(Control c, List<string> enables) {
			if (c == null) return;

			var name = c.Name;
			// 是 ComboBox 类型
			if ((c as ComboBox) != null) name += "Id";
			c.Enabled = enables.Contains(name);
		}

		/// <summary>
		/// 更新代码预览
		/// </summary>
		void updateCodePreviews() {
			bCode.Text = currentItem.bCode();
			fCode.Text = currentItem.fCode();
		}

		#endregion

		#endregion

	}
}
