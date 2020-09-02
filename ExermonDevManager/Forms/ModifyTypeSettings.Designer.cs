namespace ExermonDevManager.Forms {

	using Scripts.Forms;
	using Scripts.Data;

	partial class ModifyTypeSettings {
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
			System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem(new string[] {
            "uid",
            "int"}, -1);
			System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem(new string[] {
            "cids",
            "int[]"}, -1);
			System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem(new string[] {
            "uid",
            "int"}, -1);
			System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem(new string[] {
            "cids",
            "int[]"}, -1);
			System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem(new string[] {
            "uid",
            "int"}, -1);
			System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem(new string[] {
            "cids",
            "int[]"}, -1);
			this.fieldList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.codeReview = new System.Windows.Forms.TextBox();
			this.relList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.confirm = new System.Windows.Forms.Button();
			this.name = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.allFields = new System.Windows.Forms.LinkLabel();
			this.allRels = new System.Windows.Forms.LinkLabel();
			this.create = new System.Windows.Forms.Button();
			this.moveDown = new System.Windows.Forms.Button();
			this.delete = new System.Windows.Forms.Button();
			this.copy = new System.Windows.Forms.Button();
			this.moveUp = new System.Windows.Forms.Button();
			this.typeList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.curPage = new System.Windows.Forms.GroupBox();
			this.allNotRels = new System.Windows.Forms.LinkLabel();
			this.allNotFields = new System.Windows.Forms.LinkLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.description = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.curPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// fieldList
			// 
			this.fieldList.CheckBoxes = true;
			this.fieldList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			this.fieldList.HideSelection = false;
			listViewItem13.StateImageIndex = 0;
			listViewItem14.StateImageIndex = 0;
			this.fieldList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem13,
            listViewItem14});
			this.fieldList.Location = new System.Drawing.Point(6, 66);
			this.fieldList.Name = "fieldList";
			this.fieldList.Size = new System.Drawing.Size(230, 230);
			this.fieldList.TabIndex = 3;
			this.fieldList.UseCompatibleStateImageBehavior = false;
			this.fieldList.View = System.Windows.Forms.View.Details;
			this.fieldList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.fieldList_ItemCheck);
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "名称";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "类型";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "描述";
			this.columnHeader6.Width = 156;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.codeReview);
			this.groupBox2.Location = new System.Drawing.Point(241, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(258, 180);
			this.groupBox2.TabIndex = 1009;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "代码预览";
			// 
			// codeReview
			// 
			this.codeReview.Location = new System.Drawing.Point(6, 20);
			this.codeReview.Multiline = true;
			this.codeReview.Name = "codeReview";
			this.codeReview.ReadOnly = true;
			this.codeReview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.codeReview.Size = new System.Drawing.Size(246, 154);
			this.codeReview.TabIndex = 1010;
			this.codeReview.WordWrap = false;
			// 
			// relList
			// 
			this.relList.CheckBoxes = true;
			this.relList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.relList.HideSelection = false;
			listViewItem15.StateImageIndex = 0;
			listViewItem16.StateImageIndex = 0;
			this.relList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem15,
            listViewItem16});
			this.relList.Location = new System.Drawing.Point(257, 66);
			this.relList.Name = "relList";
			this.relList.Size = new System.Drawing.Size(230, 230);
			this.relList.TabIndex = 1011;
			this.relList.UseCompatibleStateImageBehavior = false;
			this.relList.View = System.Windows.Forms.View.Details;
			this.relList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.relList_ItemCheck);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "名称";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "类型";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "描述";
			this.columnHeader3.Width = 156;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 1012;
			this.label1.Text = "字段列表";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(255, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 1013;
			this.label2.Text = "关系列表";
			// 
			// confirm
			// 
			this.confirm.Location = new System.Drawing.Point(414, 20);
			this.confirm.Name = "confirm";
			this.confirm.Size = new System.Drawing.Size(73, 23);
			this.confirm.TabIndex = 1014;
			this.confirm.Text = "确认并关闭";
			this.confirm.UseVisualStyleBackColor = true;
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(63, 22);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(131, 21);
			this.name.TabIndex = 1016;
			// 
			// allFields
			// 
			this.allFields.AutoSize = true;
			this.allFields.Location = new System.Drawing.Point(65, 51);
			this.allFields.Name = "allFields";
			this.allFields.Size = new System.Drawing.Size(29, 12);
			this.allFields.TabIndex = 1018;
			this.allFields.TabStop = true;
			this.allFields.Text = "全选";
			this.allFields.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.allFields_LinkClicked);
			// 
			// allRels
			// 
			this.allRels.AutoSize = true;
			this.allRels.Location = new System.Drawing.Point(314, 51);
			this.allRels.Name = "allRels";
			this.allRels.Size = new System.Drawing.Size(29, 12);
			this.allRels.TabIndex = 1019;
			this.allRels.TabStop = true;
			this.allRels.Text = "全选";
			this.allRels.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.allRels_LinkClicked);
			// 
			// create
			// 
			this.create.Location = new System.Drawing.Point(185, 12);
			this.create.Name = "create";
			this.create.Size = new System.Drawing.Size(50, 23);
			this.create.TabIndex = 1025;
			this.create.Text = "添加";
			this.create.UseVisualStyleBackColor = true;
			// 
			// moveDown
			// 
			this.moveDown.Location = new System.Drawing.Point(185, 128);
			this.moveDown.Name = "moveDown";
			this.moveDown.Size = new System.Drawing.Size(50, 23);
			this.moveDown.TabIndex = 1024;
			this.moveDown.Text = "下移";
			this.moveDown.UseVisualStyleBackColor = true;
			// 
			// delete
			// 
			this.delete.Location = new System.Drawing.Point(185, 41);
			this.delete.Name = "delete";
			this.delete.Size = new System.Drawing.Size(50, 23);
			this.delete.TabIndex = 1020;
			this.delete.Text = "删除";
			this.delete.UseVisualStyleBackColor = true;
			// 
			// copy
			// 
			this.copy.Location = new System.Drawing.Point(185, 70);
			this.copy.Name = "copy";
			this.copy.Size = new System.Drawing.Size(50, 23);
			this.copy.TabIndex = 1021;
			this.copy.Text = "复制";
			this.copy.UseVisualStyleBackColor = true;
			// 
			// moveUp
			// 
			this.moveUp.Location = new System.Drawing.Point(185, 99);
			this.moveUp.Name = "moveUp";
			this.moveUp.Size = new System.Drawing.Size(50, 23);
			this.moveUp.TabIndex = 1023;
			this.moveUp.Text = "上移";
			this.moveUp.UseVisualStyleBackColor = true;
			// 
			// typeList
			// 
			this.typeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
			this.typeList.HideSelection = false;
			this.typeList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem17,
            listViewItem18});
			this.typeList.Location = new System.Drawing.Point(6, 12);
			this.typeList.Name = "typeList";
			this.typeList.Size = new System.Drawing.Size(173, 185);
			this.typeList.TabIndex = 1026;
			this.typeList.UseCompatibleStateImageBehavior = false;
			this.typeList.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "名称";
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "类型";
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "描述";
			this.columnHeader9.Width = 156;
			// 
			// curPage
			// 
			this.curPage.Controls.Add(this.allNotRels);
			this.curPage.Controls.Add(this.allNotFields);
			this.curPage.Controls.Add(this.label4);
			this.curPage.Controls.Add(this.description);
			this.curPage.Controls.Add(this.label3);
			this.curPage.Controls.Add(this.allRels);
			this.curPage.Controls.Add(this.allFields);
			this.curPage.Controls.Add(this.label2);
			this.curPage.Controls.Add(this.label1);
			this.curPage.Controls.Add(this.relList);
			this.curPage.Controls.Add(this.fieldList);
			this.curPage.Controls.Add(this.name);
			this.curPage.Controls.Add(this.confirm);
			this.curPage.Location = new System.Drawing.Point(6, 203);
			this.curPage.Name = "curPage";
			this.curPage.Size = new System.Drawing.Size(493, 302);
			this.curPage.TabIndex = 1027;
			this.curPage.TabStop = false;
			this.curPage.Text = "编辑页";
			// 
			// allNotRels
			// 
			this.allNotRels.AutoSize = true;
			this.allNotRels.Location = new System.Drawing.Point(349, 51);
			this.allNotRels.Name = "allNotRels";
			this.allNotRels.Size = new System.Drawing.Size(41, 12);
			this.allNotRels.TabIndex = 1024;
			this.allNotRels.TabStop = true;
			this.allNotRels.Text = "全不选";
			this.allNotRels.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.allNotRels_LinkClicked);
			// 
			// allNotFields
			// 
			this.allNotFields.AutoSize = true;
			this.allNotFields.Location = new System.Drawing.Point(100, 51);
			this.allNotFields.Name = "allNotFields";
			this.allNotFields.Size = new System.Drawing.Size(41, 12);
			this.allNotFields.TabIndex = 1023;
			this.allNotFields.TabStop = true;
			this.allNotFields.Text = "全不选";
			this.allNotFields.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.allNotFields_LinkClicked);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(200, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 12);
			this.label4.TabIndex = 1022;
			this.label4.Text = "描述";
			// 
			// description
			// 
			this.description.Location = new System.Drawing.Point(235, 22);
			this.description.Name = "description";
			this.description.Size = new System.Drawing.Size(173, 21);
			this.description.TabIndex = 1021;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 1020;
			this.label3.Text = "类型名称";
			// 
			// ModifyTypeSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(511, 517);
			this.Controls.Add(this.curPage);
			this.Controls.Add(this.typeList);
			this.Controls.Add(this.create);
			this.Controls.Add(this.moveDown);
			this.Controls.Add(this.delete);
			this.Controls.Add(this.copy);
			this.Controls.Add(this.moveUp);
			this.Controls.Add(this.groupBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximumSize = new System.Drawing.Size(999, 556);
			this.MinimumSize = new System.Drawing.Size(341, 556);
			this.Name = "ModifyTypeSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "数据转化设定修改";
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.curPage.ResumeLayout(false);
			this.curPage.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private ExermonDevManager.Scripts.Controls.ExerListView fieldList;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox codeReview;
		private ExermonDevManager.Scripts.Controls.ExerListView relList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button confirm;
		private ExermonDevManager.Scripts.Controls.ExerTextBox name;
		private System.Windows.Forms.LinkLabel allFields;
		private System.Windows.Forms.LinkLabel allRels;
		private System.Windows.Forms.Button create;
		private System.Windows.Forms.Button moveDown;
		private System.Windows.Forms.Button delete;
		private System.Windows.Forms.Button copy;
		private System.Windows.Forms.Button moveUp;
		private ExermonDevManager.Scripts.Controls.ExerListView typeList;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.GroupBox curPage;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private ExermonDevManager.Scripts.Controls.ExerTextBox description;
		private System.Windows.Forms.LinkLabel allNotRels;
		private System.Windows.Forms.LinkLabel allNotFields;
	}
}