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

	using Scripts.Data;
	using Scripts.Entities;
	using Scripts.Utils;

	/// <summary>
	/// 测试窗口
	/// </summary>
	public partial class SubForm : Form {

		/// <summary>
		/// 数据
		/// </summary>
		PropertyInfo prop; // 属性信息

		CoreEntity root; // 根数据
		TableInfo rootTable; // 根数据表

		/// <summary>
		/// 构造函数
		/// </summary>
		public SubForm(PropertyInfo prop, CoreEntity root) {
			this.prop = prop; this.root = root;

			rootTable = DBManager.getTableInfo(root.GetType());

			InitializeComponent();
		}

		/// <summary>
		/// 析构函数
		/// </summary>
		~SubForm() { }

		#region 默认事件

		private void SubForm_Load(object sender, EventArgs e) {
			setupDataView();
			setupRootCombox();
		}

		private void dataCombox_SelectedIndexChanged(object sender, EventArgs e) {
			saveItems();
			setupDataView(currentRoot);
		}

		private void saveData_Click(object sender, EventArgs e) {
			saveItems();
		}

		#endregion

		#region 快捷数据获取

		/// <summary>
		/// 数据库
		/// </summary>
		public CoreContext db => DBManager.db;

		/// <summary>
		/// 表类型列表
		/// </summary>
		public List<TableInfo> tables => DBManager.tables;

		/// <summary>
		/// 当前数据表
		/// </summary>
		public CoreEntity currentRoot => rootCombox.SelectedValue as CoreEntity;

		#endregion

		#region 配置控件

		/// <summary>
		/// 配置数据表
		/// </summary>
		void setupDataView() {
			dataView.onSave = saveItems;
			dataView.onDelete = deleteItem;
			dataView.onEditCell = editSubItems;
		}

		/// <summary>
		/// 初始化数据库表下拉框
		/// </summary>
		void setupRootCombox() {
			var index = rootTable.items.IndexOf(root);

			rootCombox.DataSource = rootTable.items;
			rootCombox.DisplayMember = "displayName";
			rootCombox.SelectedIndex = index;
		}

		#endregion

		#region 数据视图配置

		/// <summary>
		/// 配置数据视图
		/// </summary>
		/// <param name="tableType"></param>
		void setupDataView(CoreEntity root) {
			dataView.setup(root, prop, bindingSource);
		}

		#endregion

		#region 数据库操作

		/// <summary>
		/// 更改子数据
		/// </summary>
		public void editSubItems(PropertyInfo prop, CoreEntity root) {
			var form = new SubForm(prop, root);
			form.Show();
		}

		/// <summary>
		/// 填充所有数据
		/// </summary>
		public void deleteItem(object item) {

		}

		/// <summary>
		/// 保存
		/// </summary>
		public void saveItems() {

		}

		#endregion
	}
}
