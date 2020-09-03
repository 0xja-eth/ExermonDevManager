namespace ExermonDevManager.Forms {

	using Scripts.Forms;
	using Scripts.Data;

	partial class ModifyParams {
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "uid",
            "int"}, -1);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "cids",
            "int[]"}, -1);
			this.paramList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.copy = new System.Windows.Forms.Button();
			this.delete = new System.Windows.Forms.Button();
			this.dictType = new System.Windows.Forms.LinkLabel();
			this.boolType = new System.Windows.Forms.LinkLabel();
			this.strType = new System.Windows.Forms.LinkLabel();
			this.intType = new System.Windows.Forms.LinkLabel();
			this.label9 = new System.Windows.Forms.Label();
			this.dimension = new ExermonDevManager.Scripts.Controls.ExerNumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.type = new ExermonDevManager.Scripts.Controls.ExerComboBox();
			this.description = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.name = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.confirm = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.varType = new System.Windows.Forms.LinkLabel();
			this.doubleType = new System.Windows.Forms.LinkLabel();
			this.dateType = new System.Windows.Forms.LinkLabel();
			this.dateTimeType = new System.Windows.Forms.LinkLabel();
			this.tupleType = new System.Windows.Forms.LinkLabel();
			this.moveUp = new System.Windows.Forms.Button();
			this.moveDown = new System.Windows.Forms.Button();
			this.curPage = new System.Windows.Forms.GroupBox();
			this.newType = new System.Windows.Forms.Button();
			this.create = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dimension)).BeginInit();
			this.curPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// paramList
			// 
			this.paramList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			this.paramList.HideSelection = false;
			this.paramList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
			this.paramList.Location = new System.Drawing.Point(12, 12);
			this.paramList.MultiSelect = false;
			this.paramList.Name = "paramList";
			this.paramList.Size = new System.Drawing.Size(301, 184);
			this.paramList.TabIndex = 3;
			this.paramList.UseCompatibleStateImageBehavior = false;
			this.paramList.View = System.Windows.Forms.View.Details;
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
			// copy
			// 
			this.copy.Location = new System.Drawing.Point(140, 211);
			this.copy.Name = "copy";
			this.copy.Size = new System.Drawing.Size(73, 23);
			this.copy.TabIndex = 40;
			this.copy.Text = "复制";
			this.copy.UseVisualStyleBackColor = true;
			// 
			// delete
			// 
			this.delete.Location = new System.Drawing.Point(219, 211);
			this.delete.Name = "delete";
			this.delete.Size = new System.Drawing.Size(73, 23);
			this.delete.TabIndex = 39;
			this.delete.Text = "删除";
			this.delete.UseVisualStyleBackColor = true;
			// 
			// dictType
			// 
			this.dictType.AutoSize = true;
			this.dictType.Location = new System.Drawing.Point(223, 79);
			this.dictType.Name = "dictType";
			this.dictType.Size = new System.Drawing.Size(29, 12);
			this.dictType.TabIndex = 38;
			this.dictType.TabStop = true;
			this.dictType.Text = "dict";
			this.dictType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dictType_LinkClicked);
			// 
			// boolType
			// 
			this.boolType.AutoSize = true;
			this.boolType.Location = new System.Drawing.Point(188, 79);
			this.boolType.Name = "boolType";
			this.boolType.Size = new System.Drawing.Size(29, 12);
			this.boolType.TabIndex = 37;
			this.boolType.TabStop = true;
			this.boolType.Text = "bool";
			this.boolType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.boolType_LinkClicked);
			// 
			// strType
			// 
			this.strType.AutoSize = true;
			this.strType.Location = new System.Drawing.Point(159, 79);
			this.strType.Name = "strType";
			this.strType.Size = new System.Drawing.Size(23, 12);
			this.strType.TabIndex = 36;
			this.strType.TabStop = true;
			this.strType.Text = "str";
			this.strType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.strType_LinkClicked);
			// 
			// intType
			// 
			this.intType.AutoSize = true;
			this.intType.Location = new System.Drawing.Point(83, 79);
			this.intType.Name = "intType";
			this.intType.Size = new System.Drawing.Size(23, 12);
			this.intType.TabIndex = 35;
			this.intType.TabStop = true;
			this.intType.Text = "int";
			this.intType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.intType_LinkClicked);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(113, 105);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(17, 12);
			this.label9.TabIndex = 34;
			this.label9.Text = "维";
			// 
			// dimension
			// 
			this.dimension.Location = new System.Drawing.Point(45, 103);
			this.dimension.Name = "dimension";
			this.dimension.Size = new System.Drawing.Size(62, 21);
			this.dimension.TabIndex = 1002;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(10, 105);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(29, 12);
			this.label8.TabIndex = 32;
			this.label8.Text = "数组";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(10, 50);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(29, 12);
			this.label7.TabIndex = 30;
			this.label7.Text = "类型";
			// 
			// type
			// 
			this.type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.type.FormattingEnabled = true;
			this.type.Location = new System.Drawing.Point(45, 47);
			this.type.Name = "type";
			this.type.SelectedData = null;
			this.type.SelectedDataId = -1;
			this.type.Size = new System.Drawing.Size(159, 20);
			this.type.TabIndex = 1001;
			// 
			// description
			// 
			this.description.Location = new System.Drawing.Point(45, 130);
			this.description.Multiline = true;
			this.description.Name = "description";
			this.description.Size = new System.Drawing.Size(247, 75);
			this.description.TabIndex = 1003;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 133);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(29, 12);
			this.label6.TabIndex = 27;
			this.label6.Text = "描述";
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(45, 20);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(85, 21);
			this.name.TabIndex = 1000;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 23);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 12);
			this.label5.TabIndex = 25;
			this.label5.Text = "名称";
			// 
			// confirm
			// 
			this.confirm.Location = new System.Drawing.Point(219, 240);
			this.confirm.Name = "confirm";
			this.confirm.Size = new System.Drawing.Size(73, 23);
			this.confirm.TabIndex = 42;
			this.confirm.Text = "确认并关闭";
			this.confirm.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 43;
			this.label2.Text = "快捷类型";
			// 
			// varType
			// 
			this.varType.AutoSize = true;
			this.varType.Location = new System.Drawing.Point(258, 79);
			this.varType.Name = "varType";
			this.varType.Size = new System.Drawing.Size(23, 12);
			this.varType.TabIndex = 44;
			this.varType.TabStop = true;
			this.varType.Text = "var";
			this.varType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.varType_LinkClicked);
			// 
			// doubleType
			// 
			this.doubleType.AutoSize = true;
			this.doubleType.Location = new System.Drawing.Point(112, 79);
			this.doubleType.Name = "doubleType";
			this.doubleType.Size = new System.Drawing.Size(41, 12);
			this.doubleType.TabIndex = 45;
			this.doubleType.TabStop = true;
			this.doubleType.Text = "double";
			this.doubleType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.doubleType_LinkClicked);
			// 
			// dateType
			// 
			this.dateType.AutoSize = true;
			this.dateType.Location = new System.Drawing.Point(153, 103);
			this.dateType.Name = "dateType";
			this.dateType.Size = new System.Drawing.Size(29, 12);
			this.dateType.TabIndex = 46;
			this.dateType.TabStop = true;
			this.dateType.Text = "date";
			this.dateType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dateType_LinkClicked);
			// 
			// dateTimeType
			// 
			this.dateTimeType.AutoSize = true;
			this.dateTimeType.Location = new System.Drawing.Point(188, 103);
			this.dateTimeType.Name = "dateTimeType";
			this.dateTimeType.Size = new System.Drawing.Size(53, 12);
			this.dateTimeType.TabIndex = 47;
			this.dateTimeType.TabStop = true;
			this.dateTimeType.Text = "datetime";
			this.dateTimeType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dateTimeType_LinkClicked);
			// 
			// tupleType
			// 
			this.tupleType.AutoSize = true;
			this.tupleType.Location = new System.Drawing.Point(246, 103);
			this.tupleType.Name = "tupleType";
			this.tupleType.Size = new System.Drawing.Size(35, 12);
			this.tupleType.TabIndex = 48;
			this.tupleType.TabStop = true;
			this.tupleType.Text = "tuple";
			this.tupleType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.tupleType_LinkClicked);
			// 
			// moveUp
			// 
			this.moveUp.Location = new System.Drawing.Point(10, 211);
			this.moveUp.Name = "moveUp";
			this.moveUp.Size = new System.Drawing.Size(73, 23);
			this.moveUp.TabIndex = 49;
			this.moveUp.Text = "上移";
			this.moveUp.UseVisualStyleBackColor = true;
			// 
			// moveDown
			// 
			this.moveDown.Location = new System.Drawing.Point(10, 240);
			this.moveDown.Name = "moveDown";
			this.moveDown.Size = new System.Drawing.Size(73, 23);
			this.moveDown.TabIndex = 50;
			this.moveDown.Text = "下移";
			this.moveDown.UseVisualStyleBackColor = true;
			// 
			// curPage
			// 
			this.curPage.Controls.Add(this.moveDown);
			this.curPage.Controls.Add(this.moveUp);
			this.curPage.Controls.Add(this.tupleType);
			this.curPage.Controls.Add(this.dateTimeType);
			this.curPage.Controls.Add(this.dateType);
			this.curPage.Controls.Add(this.doubleType);
			this.curPage.Controls.Add(this.varType);
			this.curPage.Controls.Add(this.label2);
			this.curPage.Controls.Add(this.confirm);
			this.curPage.Controls.Add(this.copy);
			this.curPage.Controls.Add(this.delete);
			this.curPage.Controls.Add(this.dictType);
			this.curPage.Controls.Add(this.boolType);
			this.curPage.Controls.Add(this.strType);
			this.curPage.Controls.Add(this.intType);
			this.curPage.Controls.Add(this.label9);
			this.curPage.Controls.Add(this.dimension);
			this.curPage.Controls.Add(this.label8);
			this.curPage.Controls.Add(this.newType);
			this.curPage.Controls.Add(this.label7);
			this.curPage.Controls.Add(this.type);
			this.curPage.Controls.Add(this.description);
			this.curPage.Controls.Add(this.label6);
			this.curPage.Controls.Add(this.name);
			this.curPage.Controls.Add(this.label5);
			this.curPage.Location = new System.Drawing.Point(12, 231);
			this.curPage.Name = "curPage";
			this.curPage.Size = new System.Drawing.Size(301, 274);
			this.curPage.TabIndex = 51;
			this.curPage.TabStop = false;
			this.curPage.Text = "编辑页";
			// 
			// newType
			// 
			this.newType.Location = new System.Drawing.Point(210, 45);
			this.newType.Name = "newType";
			this.newType.Size = new System.Drawing.Size(82, 23);
			this.newType.TabIndex = 31;
			this.newType.Text = "新增类型";
			this.newType.UseVisualStyleBackColor = true;
			this.newType.Click += new System.EventHandler(this.newType_Click);
			// 
			// create
			// 
			this.create.Location = new System.Drawing.Point(152, 202);
			this.create.Name = "create";
			this.create.Size = new System.Drawing.Size(161, 23);
			this.create.TabIndex = 52;
			this.create.Text = "添加";
			this.create.UseVisualStyleBackColor = true;
			// 
			// ModifyParams
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(325, 517);
			this.Controls.Add(this.create);
			this.Controls.Add(this.curPage);
			this.Controls.Add(this.paramList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximumSize = new System.Drawing.Size(341, 556);
			this.MinimumSize = new System.Drawing.Size(341, 556);
			this.Name = "ModifyParams";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "参数修改";
			((System.ComponentModel.ISupportInitialize)(this.dimension)).EndInit();
			this.curPage.ResumeLayout(false);
			this.curPage.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private ExermonDevManager.Scripts.Controls.ExerListView paramList;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Button copy;
		private System.Windows.Forms.Button delete;
		private System.Windows.Forms.LinkLabel dictType;
		private System.Windows.Forms.LinkLabel boolType;
		private System.Windows.Forms.LinkLabel strType;
		private System.Windows.Forms.LinkLabel intType;
		private System.Windows.Forms.Label label9;
		private ExermonDevManager.Scripts.Controls.ExerNumericUpDown dimension;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private ExermonDevManager.Scripts.Controls.ExerComboBox type;
		private ExermonDevManager.Scripts.Controls.ExerTextBox description;
		private System.Windows.Forms.Label label6;
		private ExermonDevManager.Scripts.Controls.ExerTextBox name;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button confirm;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel varType;
		private System.Windows.Forms.LinkLabel doubleType;
		private System.Windows.Forms.LinkLabel dateType;
		private System.Windows.Forms.LinkLabel dateTimeType;
		private System.Windows.Forms.LinkLabel tupleType;
		private System.Windows.Forms.Button moveUp;
		private System.Windows.Forms.Button moveDown;
		private System.Windows.Forms.GroupBox curPage;
		private System.Windows.Forms.Button create;
		private System.Windows.Forms.Button newType;
	}
}