namespace ExermonDevManager.Forms {
	partial class TemplateManageForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
			this.label1 = new System.Windows.Forms.Label();
			this.tableCombox = new System.Windows.Forms.ComboBox();
			this.templateCode = new System.Windows.Forms.TextBox();
			this.editButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.templateTree = new System.Windows.Forms.TreeView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.closeAll = new System.Windows.Forms.LinkLabel();
			this.openAll = new System.Windows.Forms.LinkLabel();
			this.nodeContent = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.templateList = new ExermonDevManager.Core.Controls.ExerListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.fileDialog = new System.Windows.Forms.OpenFileDialog();
			this.selectPath = new System.Windows.Forms.Button();
			this.openDirectory = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "选择表";
			// 
			// tableCombox
			// 
			this.tableCombox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tableCombox.FormattingEnabled = true;
			this.tableCombox.Location = new System.Drawing.Point(57, 12);
			this.tableCombox.Name = "tableCombox";
			this.tableCombox.Size = new System.Drawing.Size(344, 20);
			this.tableCombox.TabIndex = 3;
			this.tableCombox.SelectedIndexChanged += new System.EventHandler(this.tableCombox_SelectedIndexChanged);
			// 
			// templateCode
			// 
			this.templateCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.templateCode.Location = new System.Drawing.Point(0, 15);
			this.templateCode.Multiline = true;
			this.templateCode.Name = "templateCode";
			this.templateCode.ReadOnly = true;
			this.templateCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.templateCode.Size = new System.Drawing.Size(313, 393);
			this.templateCode.TabIndex = 7;
			this.templateCode.WordWrap = false;
			// 
			// editButton
			// 
			this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.editButton.Location = new System.Drawing.Point(407, 115);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(165, 23);
			this.editButton.TabIndex = 9;
			this.editButton.Text = "使用 Sublime Text 3 编辑";
			this.editButton.UseVisualStyleBackColor = true;
			this.editButton.Click += new System.EventHandler(this.editButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 10;
			this.label2.Text = "模板列表";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 12;
			this.label3.Text = "模板内容";
			// 
			// templateTree
			// 
			this.templateTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.templateTree.Location = new System.Drawing.Point(3, 15);
			this.templateTree.Name = "templateTree";
			this.templateTree.Size = new System.Drawing.Size(237, 288);
			this.templateTree.TabIndex = 13;
			this.templateTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.templateTree_AfterSelect);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(12, 173);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.templateCode);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.closeAll);
			this.splitContainer1.Panel2.Controls.Add(this.openAll);
			this.splitContainer1.Panel2.Controls.Add(this.nodeContent);
			this.splitContainer1.Panel2.Controls.Add(this.label4);
			this.splitContainer1.Panel2.Controls.Add(this.templateTree);
			this.splitContainer1.Size = new System.Drawing.Size(560, 376);
			this.splitContainer1.SplitterDistance = 316;
			this.splitContainer1.TabIndex = 14;
			// 
			// closeAll
			// 
			this.closeAll.AutoSize = true;
			this.closeAll.Location = new System.Drawing.Point(121, 0);
			this.closeAll.Name = "closeAll";
			this.closeAll.Size = new System.Drawing.Size(53, 12);
			this.closeAll.TabIndex = 16;
			this.closeAll.TabStop = true;
			this.closeAll.Text = "收起全部";
			this.closeAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.closeAll_LinkClicked);
			// 
			// openAll
			// 
			this.openAll.AutoSize = true;
			this.openAll.Location = new System.Drawing.Point(62, 0);
			this.openAll.Name = "openAll";
			this.openAll.Size = new System.Drawing.Size(53, 12);
			this.openAll.TabIndex = 15;
			this.openAll.TabStop = true;
			this.openAll.Text = "展开全部";
			this.openAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.openAll_LinkClicked);
			// 
			// nodeContent
			// 
			this.nodeContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nodeContent.Location = new System.Drawing.Point(3, 309);
			this.nodeContent.Multiline = true;
			this.nodeContent.Name = "nodeContent";
			this.nodeContent.ReadOnly = true;
			this.nodeContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.nodeContent.Size = new System.Drawing.Size(237, 99);
			this.nodeContent.TabIndex = 14;
			this.nodeContent.WordWrap = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 12);
			this.label4.TabIndex = 13;
			this.label4.Text = "模板结构";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(407, 38);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(165, 74);
			this.label5.TabIndex = 15;
			this.label5.Text = "模板列表显示的是程序内设置好的模板，本软件暂不支持添加数据库表和对应的生成模板，若有需要请直接修改程序代码。";
			// 
			// templateList
			// 
			this.templateList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.templateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.templateList.HideSelection = false;
			this.templateList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
			this.templateList.Location = new System.Drawing.Point(12, 53);
			this.templateList.Name = "templateList";
			this.templateList.Size = new System.Drawing.Size(389, 114);
			this.templateList.TabIndex = 5;
			this.templateList.UseCompatibleStateImageBehavior = false;
			this.templateList.View = System.Windows.Forms.View.Details;
			this.templateList.SelectedIndexChanged += new System.EventHandler(this.templateList_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "类型";
			this.columnHeader1.Width = 96;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "路径";
			this.columnHeader2.Width = 128;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "结点数";
			this.columnHeader3.Width = 48;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "描述";
			this.columnHeader4.Width = 128;
			// 
			// fileDialog
			// 
			this.fileDialog.FileName = "openFileDialog1";
			this.fileDialog.Filter = "可执行文件|*.exe|所有文件|*.*";
			this.fileDialog.Title = "选择 Sublime Text 3 路径";
			// 
			// selectPath
			// 
			this.selectPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.selectPath.Location = new System.Drawing.Point(407, 144);
			this.selectPath.Name = "selectPath";
			this.selectPath.Size = new System.Drawing.Size(165, 23);
			this.selectPath.TabIndex = 16;
			this.selectPath.Text = "选择 Sublime Text 3 路径";
			this.selectPath.UseVisualStyleBackColor = true;
			this.selectPath.Click += new System.EventHandler(this.selectPath_Click);
			// 
			// openDirectory
			// 
			this.openDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.openDirectory.Location = new System.Drawing.Point(407, 10);
			this.openDirectory.Name = "openDirectory";
			this.openDirectory.Size = new System.Drawing.Size(165, 23);
			this.openDirectory.TabIndex = 17;
			this.openDirectory.Text = "打开模板目录";
			this.openDirectory.UseVisualStyleBackColor = true;
			this.openDirectory.Click += new System.EventHandler(this.openDirectory_Click);
			// 
			// TemplateManageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 561);
			this.Controls.Add(this.openDirectory);
			this.Controls.Add(this.selectPath);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.editButton);
			this.Controls.Add(this.templateList);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tableCombox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size(600, 600);
			this.Name = "TemplateManageForm";
			this.Text = "模板管理";
			this.Load += new System.EventHandler(this.TemplateManageForm_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox tableCombox;
		private Core.Controls.ExerListView templateList;
		private System.Windows.Forms.TextBox templateCode;
		private System.Windows.Forms.Button editButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TreeView templateTree;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TextBox nodeContent;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.LinkLabel closeAll;
		private System.Windows.Forms.LinkLabel openAll;
		private System.Windows.Forms.OpenFileDialog fileDialog;
		private System.Windows.Forms.Button selectPath;
		private System.Windows.Forms.Button openDirectory;
	}
}