using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExermonDevManager.Forms {
	
	using Scripts.Entities;
	using Scripts.Utils;

	using Scripts.CodeGen;

	public partial class TemplateManageForm : Form {

		public TemplateManageForm() {
			InitializeComponent();
		}

		#region 默认事件

		private void TemplateManageForm_Load(object sender, EventArgs e) {
			setupTableCombox();
		}

		private void tableCombox_SelectedIndexChanged(object sender, EventArgs e) {
			refresh();
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
		public List<TableInfo> tables => DBManager.rootTables;

		/// <summary>
		/// 当前数据表
		/// </summary>
		public TableInfo currentTableInfo => tableCombox.SelectedValue as TableInfo;

		#endregion

		#region 配置控件

		/// <summary>
		/// 初始化数据库表下拉框
		/// </summary>
		void setupTableCombox() {
			tableCombox.DataSource = tables;
			tableCombox.DisplayMember = "displayName";
			tableCombox.SelectedIndex = -1;
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
		/// <param name="table"></param>
		public void setTable(TableInfo table) {

		}

		#endregion

	}
}
