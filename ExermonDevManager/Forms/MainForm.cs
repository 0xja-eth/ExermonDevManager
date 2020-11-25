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

	using Core.Entities;
	using Core.Managers;

	using Core.CodeGen;

	using Core.Forms;

	/// <summary>
	/// 测试窗口
	/// </summary>
	public partial class MainForm : Form {

		/// <summary>
		/// 按钮文本
		/// </summary>
		//const string SourceNameFormat = "{0}BindingSource";

		/// <summary>
		/// 构造函数
		/// </summary>
		public MainForm() {
			InitializeComponent();
		}

		#region 默认事件

		private void TestForm_Load(object sender, EventArgs e) {
			initialize();
			setupDataView();
			setupTableCombox();
		}

		private void MainForm2_FormClosed(object sender, FormClosedEventArgs e) {
			DatabaseManager.terminate();
			ConfigManager.save();
		}

		private void tableCombox_SelectedIndexChanged(object sender, EventArgs e) {
			saveTables(); setTable(currentTableInfo);
		}

		private void saveData_Click(object sender, EventArgs e) {
			saveTables();
		}

		private void tableSetting_Click(object sender, EventArgs e) {
			var form = new TemplateManageForm();
			form.Show();
		}

		private void genCode_Click(object sender, EventArgs e) {
			if (currentTableInfo == null) return;
			var form = new CodePreview();
			form.setupGenerator(currentTableInfo.type);
			form.Show();
		}

		#endregion

		#region 快捷数据获取

		/// <summary>
		/// 数据库
		/// </summary>
		public ExerDbContext db => DatabaseManager.db;

		/// <summary>
		/// 表类型列表
		/// </summary>
		public List<TableInfo> tables => DatabaseManager.rootTables;

		/// <summary>
		/// 当前数据表
		/// </summary>
		public TableInfo currentTableInfo => tableCombox.SelectedValue as TableInfo;

		/// <summary>
		/// 当前项
		/// </summary>
		public BaseEntity currentItem => dataView.currentItem();

		#endregion

		/// <summary>
		/// 初始化所有管理类
		/// </summary>
		void initialize() {
			DatabaseManager.initialize();
			ConfigManager.initialize();
			TemplateManager.initialize();
			LanguageManager.initialize();
		}

		#region 配置控件

		/// <summary>
		/// 配置数据表
		/// </summary>
		void setupDataView() {
			dataView.onSave = saveTables;
			dataView.onDelete = deleteItem;
			dataView.onEditCell = editSubItems;
		}

		/// <summary>
		/// 初始化数据库表下拉框
		/// </summary>
		void setupTableCombox() {
			tableCombox.DataSource = tables;
			tableCombox.DisplayMember = "displayName";
			tableCombox.SelectedIndex = -1;
		}

		#endregion

		#region 数据库操作

		/// <summary>
		/// 更改子数据
		/// </summary>
		public void editSubItems(PropertyInfo prop, BaseEntity root) {
			var form = ExermonFormManager.startSubForm(prop, root);
			form.Show();
		}

		/// <summary>
		/// 填充所有数据
		/// </summary>
		public void deleteItem(object item) {
			currentTableInfo?.delete(item);
		}
		
		/// <summary>
		/// 填充所有数据
		/// </summary>
		public void saveTables() {
			dataView.EndEdit();
			bindingSource.EndEdit();

			DatabaseManager.saveTables();
		}

		#endregion

		#region 界面绘制

		/// <summary>
		/// 刷新
		/// </summary>
		public void refresh() {
			setTable(currentTableInfo);
		}

		/// <summary>
		/// 设置表
		/// </summary>
		/// <param name="tableType"></param>
		public void setTable(TableInfo table) {
			dataView.setItems(table, bindingSource);
		}

		#endregion

	}
}
