using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Windows.Forms;

using System.IO;

using System.Runtime.InteropServices;

namespace ExermonDevManager.Forms {
	
	using Core.Entities;
	using Core.Managers;

	using Core.Forms;

	using Core.CodeGen;

	//public partial class TemplateManageForm : Form {
	public partial class TemplateManageForm : ExerFormForTemplateItem {

		public TemplateManageForm() {
			InitializeComponent();
		}

		#region 默认事件

		private void tableCombox_SelectedIndexChanged(object sender, EventArgs e) {
			switchTable(currentTableInfo);
		}

		private void templateTree_AfterSelect(object sender, TreeViewEventArgs e) {
			switchBlock(currentBlock);
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
			var templatePath = currentItem.templatePath();
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
			var path = Path.Combine(curPath, TemplateManager.rootPath);
			var proc = string.IsNullOrEmpty(editorPath) ? "explorer.exe" : editorPath;

			Process.Start(proc, path);
		}

		#endregion

		#region 快捷数据获取

		/// <summary>
		/// 表类型列表
		/// </summary>
		public List<TableInfo> tables => EntitiesManager.rootTables;

		/// <summary>
		/// 当前数据表
		/// </summary>
		public TableInfo currentTableInfo => tableCombox.SelectedValue as TableInfo;

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

		#region 初始化配置

		/// <summary>
		/// 配置控件
		/// </summary>
		protected override void setupControls() {
			base.setupControls();
			setupTableCombox();
			updateEditButton();
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

		#region 更新控件

		/// <summary>
		/// 更新编辑按钮
		/// </summary>
		void updateEditButton() {
			var templatePath = currentItem?.templatePath();
			editButton.Enabled = !string.IsNullOrEmpty(editorPath) &&
				!string.IsNullOrEmpty(templatePath);
		}

		#endregion

		#region 切换数据

		/// <summary>
		/// 设置表
		/// </summary>
		/// <param name="table"></param>
		public void switchTable(TableInfo table) {
			if (table == null) setupItems(null);
			else {
				var manager = BaseEntity.getGenerateManager(table.type);
				setupItems(manager.getTemplateItems());
			}
		}

		/// <summary>
		/// 设置模板项
		/// </summary>
		/// <param name="item"></param>
		public void switchTemplateItem(TemplateItem item) {
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
		public void switchBlock(Block block) {
			nodeContent.Text = block?.detailText();
		}

		#endregion

		#region 刷新控件

		/// <summary>
		/// 刷新
		/// </summary>
		protected override void refreshMain() {
			base.refreshMain();
			switchTemplateItem(currentItem);
		}

		#endregion
	}
}
