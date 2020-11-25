using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Windows.Forms;

using System.IO;

using System.Runtime.InteropServices;

namespace ExermonDevManager.Forms {

	using Core.Data;
	using Core.Entities;
	using Core.Managers;

	using Core.CodeGen;

	public partial class TemplateManageForm : Form {

		public TemplateManageForm() {
			InitializeComponent();
		}

		#region 默认事件

		private void TemplateManageForm_Load(object sender, EventArgs e) {
			setupTableCombox(); updateEditButton();
		}

		private void tableCombox_SelectedIndexChanged(object sender, EventArgs e) {
			setTable(currentTableInfo);
		}

		private void templateList_SelectedIndexChanged(object sender, EventArgs e) {
			setTemplateItem(currentTemplateItem);
		}

		private void templateTree_AfterSelect(object sender, TreeViewEventArgs e) {
			setBlock(currentBlock);
		}

		private void openAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			if (templateTree.Nodes.Count <= 0) return;
			templateTree.Nodes[0].ExpandAll();
		}

		private void closeAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			if (templateTree.Nodes.Count <= 0) return;
			templateTree.Nodes[0].Collapse();
		}

		private void editButton_Click(object sender, EventArgs e) {
			var curPath = Application.StartupPath;
			var templatePath = currentTemplateItem.templatePath();
			templatePath = Path.Combine(curPath, templatePath);

			Process.Start(editorPath, templatePath);
		}

		private void selectPath_Click(object sender, EventArgs e) {
			fileDialog.InitialDirectory = editorPath;
			var res = fileDialog.ShowDialog(this);

			if (res == DialogResult.OK) {
				editorPath = fileDialog.FileName;
				updateEditButton();
			}
		}

		private void openDirectory_Click(object sender, EventArgs e) {
			var curPath = Application.StartupPath;
			var path = Path.Combine(curPath, TemplateManager.RootPath);
			var proc = string.IsNullOrEmpty(editorPath) ? "explorer.exe" : editorPath;

			Process.Start(proc, path);
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
		/// 当前模板项
		/// </summary>
		public TemplateItem currentTemplateItem => templateList.getCurrentData<TemplateItem>();

		/// <summary>
		/// 当前块
		/// </summary>
		public Block currentBlock => templateTree.SelectedNode.Tag as Block;

		/// <summary>
		/// 编辑器路径
		/// </summary>
		public string editorPath {
			get => ConfigManager.config.editorPath;
			set { ConfigManager.config.editorPath = value; }
		}

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

		/// <summary>
		/// 更新编辑按钮
		/// </summary>
		void updateEditButton() {
			var templatePath = currentTemplateItem?.templatePath();
			editButton.Enabled = !string.IsNullOrEmpty(editorPath) &&
				!string.IsNullOrEmpty(templatePath);
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
			if (table == null) templateList.clearData();
			else {
				var manager = CoreData.getGenerateManager(table.type);
				templateList.setupAll(manager.getTemplateItems());
			}
		}

		/// <summary>
		/// 设置模板项
		/// </summary>
		/// <param name="item"></param>
		public void setTemplateItem(TemplateItem item) {
			var template = item?.template();
			templateCode.Text = template?.content;
			buildTemplateTree(template);
			updateEditButton();
		}

		/// <summary>
		/// 建立模板结构树
		/// </summary>
		/// <param name="template">模板</param>
		void buildTemplateTree(CodeTemplate template) {
			templateTree.Nodes.Clear();

			processBlock(template?.output());
		}

		/// <summary>
		/// 处理块
		/// </summary>
		/// <param name="block"></param>
		void processBlock(Block block, TreeNode node = null) {
			if (block == null) return;

			node = node == null ?
				templateTree.Nodes.Add(block.nodeText()) :
				node.Nodes.Add(block.nodeText());

			node.Tag = block;

			var subBlocks = block.getSubBlocks();
			foreach (var sub in subBlocks)
				processBlock(sub, node);
		}

		/// <summary>
		/// 设置块
		/// </summary>
		/// <param name="block"></param>
		public void setBlock(Block block) {
			nodeContent.Text = block?.detailText();
		}

		#endregion
	}
}
