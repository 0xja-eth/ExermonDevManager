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
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
			this.label1 = new System.Windows.Forms.Label();
			this.tableCombox = new System.Windows.Forms.ComboBox();
			this.templateList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.templateCode = new System.Windows.Forms.TextBox();
			this.edit = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.changePath = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.templateTree = new System.Windows.Forms.TreeView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.nodeContent = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
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
			this.tableCombox.Size = new System.Drawing.Size(515, 20);
			this.tableCombox.TabIndex = 3;
			this.tableCombox.SelectedIndexChanged += new System.EventHandler(this.tableCombox_SelectedIndexChanged);
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
            listViewItem2});
			this.templateList.Location = new System.Drawing.Point(12, 53);
			this.templateList.Name = "templateList";
			this.templateList.Size = new System.Drawing.Size(389, 114);
			this.templateList.TabIndex = 5;
			this.templateList.UseCompatibleStateImageBehavior = false;
			this.templateList.View = System.Windows.Forms.View.Details;
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
			this.templateCode.Size = new System.Drawing.Size(313, 361);
			this.templateCode.TabIndex = 7;
			this.templateCode.WordWrap = false;
			// 
			// edit
			// 
			this.edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.edit.Location = new System.Drawing.Point(407, 115);
			this.edit.Name = "edit";
			this.edit.Size = new System.Drawing.Size(165, 23);
			this.edit.TabIndex = 9;
			this.edit.Text = "使用 Sublime Text 3 编辑";
			this.edit.UseVisualStyleBackColor = true;
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
			// changePath
			// 
			this.changePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.changePath.Location = new System.Drawing.Point(407, 144);
			this.changePath.Name = "changePath";
			this.changePath.Size = new System.Drawing.Size(165, 23);
			this.changePath.TabIndex = 11;
			this.changePath.Text = "选择 Sublime Text 3 路径";
			this.changePath.UseVisualStyleBackColor = true;
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
			this.templateTree.Size = new System.Drawing.Size(237, 256);
			this.templateTree.TabIndex = 13;
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
			this.splitContainer1.Panel2.Controls.Add(this.nodeContent);
			this.splitContainer1.Panel2.Controls.Add(this.label4);
			this.splitContainer1.Panel2.Controls.Add(this.templateTree);
			this.splitContainer1.Size = new System.Drawing.Size(560, 376);
			this.splitContainer1.SplitterDistance = 316;
			this.splitContainer1.TabIndex = 14;
			// 
			// nodeContent
			// 
			this.nodeContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nodeContent.Location = new System.Drawing.Point(3, 277);
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
			// TemplateManageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 561);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.changePath);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.edit);
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
		private Scripts.Controls.ExerListView templateList;
		private System.Windows.Forms.TextBox templateCode;
		private System.Windows.Forms.Button edit;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button changePath;
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
	}
}