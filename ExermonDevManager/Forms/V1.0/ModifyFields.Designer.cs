namespace ExermonDevManager.Forms {

	using Scripts.Forms;
	using Scripts.Data;

	partial class ModifyFields {
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
			this.boolType = new System.Windows.Forms.LinkLabel();
			this.strType = new System.Windows.Forms.LinkLabel();
			this.intType = new System.Windows.Forms.LinkLabel();
			this.label9 = new System.Windows.Forms.Label();
			this.dimension = new ExermonDevManager.Scripts.Controls.ExerNumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.fType = new ExermonDevManager.Scripts.Controls.ExerComboBox();
			this.description = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.name = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.confirm = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.doubleType = new System.Windows.Forms.LinkLabel();
			this.dateType = new System.Windows.Forms.LinkLabel();
			this.dateTimeType = new System.Windows.Forms.LinkLabel();
			this.moveUp = new System.Windows.Forms.Button();
			this.moveDown = new System.Windows.Forms.Button();
			this.curPage = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label20 = new System.Windows.Forms.Label();
			this.listEditable = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.listDisplay = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.typeExclude = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.typeFilter = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.convertFunc = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.unique = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.onDelete = new ExermonDevManager.Scripts.Controls.ExerComboBox();
			this.label17 = new System.Windows.Forms.Label();
			this.toModel = new ExermonDevManager.Scripts.Controls.ExerComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.uploadTo = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.autoNowAdd = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.autoNow = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.cancelChoices = new System.Windows.Forms.Button();
			this.choices = new ExermonDevManager.Scripts.Controls.ExerComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.verboseName = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.blank = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.null_ = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.maxLength = new ExermonDevManager.Scripts.Controls.ExerNumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.bDefault = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.bType = new ExermonDevManager.Scripts.Controls.ExerComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.isBackend_ = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.keyName = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.backend = new System.Windows.Forms.GroupBox();
			this.defaultNew = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.fDefault = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.autoConvert = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.autoLoad = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.format = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.protectedSet = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.useList = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.isFrontend_ = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.create = new System.Windows.Forms.Button();
			this.fCode = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label19 = new System.Windows.Forms.Label();
			this.bCode = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dimension)).BeginInit();
			this.curPage.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxLength)).BeginInit();
			this.backend.SuspendLayout();
			this.groupBox2.SuspendLayout();
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
			this.paramList.Size = new System.Drawing.Size(272, 213);
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
			this.copy.Location = new System.Drawing.Point(290, 70);
			this.copy.Name = "copy";
			this.copy.Size = new System.Drawing.Size(73, 23);
			this.copy.TabIndex = 40;
			this.copy.Text = "复制";
			this.copy.UseVisualStyleBackColor = true;
			// 
			// delete
			// 
			this.delete.Location = new System.Drawing.Point(290, 41);
			this.delete.Name = "delete";
			this.delete.Size = new System.Drawing.Size(73, 23);
			this.delete.TabIndex = 39;
			this.delete.Text = "删除";
			this.delete.UseVisualStyleBackColor = true;
			// 
			// boolType
			// 
			this.boolType.AutoSize = true;
			this.boolType.Location = new System.Drawing.Point(175, 54);
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
			this.strType.Location = new System.Drawing.Point(146, 54);
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
			this.intType.Location = new System.Drawing.Point(70, 54);
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
			this.label9.Location = new System.Drawing.Point(114, 78);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(17, 12);
			this.label9.TabIndex = 34;
			this.label9.Text = "维";
			// 
			// dimension
			// 
			this.dimension.Location = new System.Drawing.Point(46, 76);
			this.dimension.Name = "dimension";
			this.dimension.Size = new System.Drawing.Size(62, 21);
			this.dimension.TabIndex = 1002;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(11, 78);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(29, 12);
			this.label8.TabIndex = 32;
			this.label8.Text = "数组";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(11, 25);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(29, 12);
			this.label7.TabIndex = 30;
			this.label7.Text = "类型";
			// 
			// fType
			// 
			this.fType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.fType.FormattingEnabled = true;
			this.fType.Location = new System.Drawing.Point(46, 22);
			this.fType.Name = "fType";
			this.fType.SelectedData = null;
			this.fType.SelectedDataId = -1;
			this.fType.Size = new System.Drawing.Size(93, 20);
			this.fType.TabIndex = 1001;
			// 
			// description
			// 
			this.description.Location = new System.Drawing.Point(45, 47);
			this.description.Multiline = true;
			this.description.Name = "description";
			this.description.Size = new System.Drawing.Size(302, 40);
			this.description.TabIndex = 1003;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 50);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(29, 12);
			this.label6.TabIndex = 27;
			this.label6.Text = "描述";
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(45, 20);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(107, 21);
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
			this.confirm.Location = new System.Drawing.Point(290, 202);
			this.confirm.Name = "confirm";
			this.confirm.Size = new System.Drawing.Size(73, 23);
			this.confirm.TabIndex = 42;
			this.confirm.Text = "确认并关闭";
			this.confirm.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 43;
			this.label2.Text = "快捷类型";
			// 
			// doubleType
			// 
			this.doubleType.AutoSize = true;
			this.doubleType.Location = new System.Drawing.Point(99, 54);
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
			this.dateType.Location = new System.Drawing.Point(210, 54);
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
			this.dateTimeType.Location = new System.Drawing.Point(245, 54);
			this.dateTimeType.Name = "dateTimeType";
			this.dateTimeType.Size = new System.Drawing.Size(53, 12);
			this.dateTimeType.TabIndex = 47;
			this.dateTimeType.TabStop = true;
			this.dateTimeType.Text = "datetime";
			this.dateTimeType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dateTimeType_LinkClicked);
			// 
			// moveUp
			// 
			this.moveUp.Location = new System.Drawing.Point(290, 99);
			this.moveUp.Name = "moveUp";
			this.moveUp.Size = new System.Drawing.Size(73, 23);
			this.moveUp.TabIndex = 49;
			this.moveUp.Text = "上移";
			this.moveUp.UseVisualStyleBackColor = true;
			// 
			// moveDown
			// 
			this.moveDown.Location = new System.Drawing.Point(290, 128);
			this.moveDown.Name = "moveDown";
			this.moveDown.Size = new System.Drawing.Size(73, 23);
			this.moveDown.TabIndex = 50;
			this.moveDown.Text = "下移";
			this.moveDown.UseVisualStyleBackColor = true;
			// 
			// curPage
			// 
			this.curPage.Controls.Add(this.groupBox1);
			this.curPage.Controls.Add(this.keyName);
			this.curPage.Controls.Add(this.label1);
			this.curPage.Controls.Add(this.backend);
			this.curPage.Controls.Add(this.description);
			this.curPage.Controls.Add(this.label6);
			this.curPage.Controls.Add(this.name);
			this.curPage.Controls.Add(this.label5);
			this.curPage.Location = new System.Drawing.Point(12, 231);
			this.curPage.Name = "curPage";
			this.curPage.Size = new System.Drawing.Size(691, 274);
			this.curPage.TabIndex = 51;
			this.curPage.TabStop = false;
			this.curPage.Text = "编辑页";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.listEditable);
			this.groupBox1.Controls.Add(this.listDisplay);
			this.groupBox1.Controls.Add(this.typeExclude);
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Controls.Add(this.typeFilter);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.convertFunc);
			this.groupBox1.Controls.Add(this.unique);
			this.groupBox1.Controls.Add(this.onDelete);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.toModel);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.uploadTo);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.autoNowAdd);
			this.groupBox1.Controls.Add(this.autoNow);
			this.groupBox1.Controls.Add(this.cancelChoices);
			this.groupBox1.Controls.Add(this.choices);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.verboseName);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.blank);
			this.groupBox1.Controls.Add(this.null_);
			this.groupBox1.Controls.Add(this.maxLength);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.bDefault);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.bType);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.isBackend_);
			this.groupBox1.Location = new System.Drawing.Point(353, 20);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(332, 248);
			this.groupBox1.TabIndex = 1007;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "          ";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(117, 203);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(29, 39);
			this.label20.TabIndex = 1043;
			this.label20.Text = "转化\r\n函数";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// listEditable
			// 
			this.listEditable.AutoSize = true;
			this.listEditable.Location = new System.Drawing.Point(9, 227);
			this.listEditable.Name = "listEditable";
			this.listEditable.Size = new System.Drawing.Size(102, 16);
			this.listEditable.TabIndex = 1042;
			this.listEditable.Text = "list_editable";
			this.listEditable.UseVisualStyleBackColor = true;
			// 
			// listDisplay
			// 
			this.listDisplay.AutoSize = true;
			this.listDisplay.Location = new System.Drawing.Point(9, 205);
			this.listDisplay.Name = "listDisplay";
			this.listDisplay.Size = new System.Drawing.Size(96, 16);
			this.listDisplay.TabIndex = 1041;
			this.listDisplay.Text = "list_display";
			this.listDisplay.UseVisualStyleBackColor = true;
			// 
			// typeExclude
			// 
			this.typeExclude.Location = new System.Drawing.Point(229, 178);
			this.typeExclude.Name = "typeExclude";
			this.typeExclude.Size = new System.Drawing.Size(97, 21);
			this.typeExclude.TabIndex = 1040;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(176, 181);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(47, 12);
			this.label22.TabIndex = 1039;
			this.label22.Text = "exclude";
			// 
			// typeFilter
			// 
			this.typeFilter.Location = new System.Drawing.Point(86, 178);
			this.typeFilter.Name = "typeFilter";
			this.typeFilter.Size = new System.Drawing.Size(84, 21);
			this.typeFilter.TabIndex = 1038;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(7, 181);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(71, 12);
			this.label21.TabIndex = 1037;
			this.label21.Text = "type_filter";
			// 
			// convertFunc
			// 
			this.convertFunc.Location = new System.Drawing.Point(152, 203);
			this.convertFunc.Multiline = true;
			this.convertFunc.Name = "convertFunc";
			this.convertFunc.Size = new System.Drawing.Size(174, 39);
			this.convertFunc.TabIndex = 1036;
			// 
			// unique
			// 
			this.unique.AutoSize = true;
			this.unique.Location = new System.Drawing.Point(228, 48);
			this.unique.Name = "unique";
			this.unique.Size = new System.Drawing.Size(60, 16);
			this.unique.TabIndex = 1034;
			this.unique.Text = "unique";
			this.unique.UseVisualStyleBackColor = true;
			// 
			// onDelete
			// 
			this.onDelete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.onDelete.FormattingEnabled = true;
			this.onDelete.Location = new System.Drawing.Point(249, 151);
			this.onDelete.Name = "onDelete";
			this.onDelete.SelectedData = null;
			this.onDelete.SelectedDataId = -1;
			this.onDelete.Size = new System.Drawing.Size(77, 20);
			this.onDelete.TabIndex = 1033;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(190, 154);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(59, 12);
			this.label17.TabIndex = 1032;
			this.label17.Text = "on_delete";
			// 
			// toModel
			// 
			this.toModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.toModel.FormattingEnabled = true;
			this.toModel.Location = new System.Drawing.Point(68, 151);
			this.toModel.Name = "toModel";
			this.toModel.SelectedData = null;
			this.toModel.SelectedDataId = -1;
			this.toModel.Size = new System.Drawing.Size(115, 20);
			this.toModel.TabIndex = 1031;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(7, 154);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(53, 12);
			this.label16.TabIndex = 1030;
			this.label16.Text = "关联模型";
			// 
			// uploadTo
			// 
			this.uploadTo.Location = new System.Drawing.Point(116, 124);
			this.uploadTo.Name = "uploadTo";
			this.uploadTo.Size = new System.Drawing.Size(210, 21);
			this.uploadTo.TabIndex = 1029;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(7, 128);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(101, 12);
			this.label15.TabIndex = 1028;
			this.label15.Text = "上传路径（代码）";
			// 
			// autoNowAdd
			// 
			this.autoNowAdd.AutoSize = true;
			this.autoNowAdd.Location = new System.Drawing.Point(87, 102);
			this.autoNowAdd.Name = "autoNowAdd";
			this.autoNowAdd.Size = new System.Drawing.Size(96, 16);
			this.autoNowAdd.TabIndex = 1027;
			this.autoNowAdd.Text = "auto_now_add";
			this.autoNowAdd.UseVisualStyleBackColor = true;
			// 
			// autoNow
			// 
			this.autoNow.AutoSize = true;
			this.autoNow.Location = new System.Drawing.Point(9, 102);
			this.autoNow.Name = "autoNow";
			this.autoNow.Size = new System.Drawing.Size(72, 16);
			this.autoNow.TabIndex = 1026;
			this.autoNow.Text = "auto_now";
			this.autoNow.UseVisualStyleBackColor = true;
			// 
			// cancelChoices
			// 
			this.cancelChoices.Location = new System.Drawing.Point(272, 72);
			this.cancelChoices.Name = "cancelChoices";
			this.cancelChoices.Size = new System.Drawing.Size(54, 23);
			this.cancelChoices.TabIndex = 1025;
			this.cancelChoices.Text = "重置";
			this.cancelChoices.UseVisualStyleBackColor = true;
			this.cancelChoices.Click += new System.EventHandler(this.cancelChoices_Click);
			// 
			// choices
			// 
			this.choices.DisplayMember = "34";
			this.choices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.choices.FormattingEnabled = true;
			this.choices.Location = new System.Drawing.Point(164, 74);
			this.choices.Name = "choices";
			this.choices.SelectedData = null;
			this.choices.SelectedDataId = -1;
			this.choices.Size = new System.Drawing.Size(102, 20);
			this.choices.TabIndex = 1024;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(117, 77);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(41, 12);
			this.label14.TabIndex = 1023;
			this.label14.Text = "选择项";
			// 
			// verboseName
			// 
			this.verboseName.Location = new System.Drawing.Point(259, 20);
			this.verboseName.Name = "verboseName";
			this.verboseName.Size = new System.Drawing.Size(67, 21);
			this.verboseName.TabIndex = 1022;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(200, 23);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(53, 12);
			this.label13.TabIndex = 1021;
			this.label13.Text = "显示名称";
			// 
			// blank
			// 
			this.blank.AutoSize = true;
			this.blank.Location = new System.Drawing.Point(168, 48);
			this.blank.Name = "blank";
			this.blank.Size = new System.Drawing.Size(54, 16);
			this.blank.TabIndex = 1017;
			this.blank.Text = "blank";
			this.blank.UseVisualStyleBackColor = true;
			// 
			// null_
			// 
			this.null_.AutoSize = true;
			this.null_.Location = new System.Drawing.Point(117, 48);
			this.null_.Name = "null_";
			this.null_.Size = new System.Drawing.Size(48, 16);
			this.null_.TabIndex = 1016;
			this.null_.Text = "null";
			this.null_.UseVisualStyleBackColor = true;
			// 
			// maxLength
			// 
			this.maxLength.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.maxLength.Location = new System.Drawing.Point(66, 75);
			this.maxLength.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.maxLength.Name = "maxLength";
			this.maxLength.Size = new System.Drawing.Size(45, 21);
			this.maxLength.TabIndex = 1020;
			this.maxLength.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(7, 77);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(53, 12);
			this.label12.TabIndex = 1019;
			this.label12.Text = "最大长度";
			// 
			// bDefault
			// 
			this.bDefault.Location = new System.Drawing.Point(42, 46);
			this.bDefault.Name = "bDefault";
			this.bDefault.Size = new System.Drawing.Size(68, 21);
			this.bDefault.TabIndex = 1018;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(7, 49);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(29, 12);
			this.label10.TabIndex = 1017;
			this.label10.Text = "默认";
			// 
			// bType
			// 
			this.bType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.bType.FormattingEnabled = true;
			this.bType.Location = new System.Drawing.Point(42, 20);
			this.bType.Name = "bType";
			this.bType.SelectedData = null;
			this.bType.SelectedDataId = -1;
			this.bType.Size = new System.Drawing.Size(152, 20);
			this.bType.TabIndex = 1016;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(7, 23);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(29, 12);
			this.label11.TabIndex = 1015;
			this.label11.Text = "类型";
			// 
			// isBackend_
			// 
			this.isBackend_.AutoSize = true;
			this.isBackend_.Location = new System.Drawing.Point(6, -1);
			this.isBackend_.Name = "isBackend_";
			this.isBackend_.Size = new System.Drawing.Size(72, 16);
			this.isBackend_.TabIndex = 1009;
			this.isBackend_.Text = "后端可用";
			this.isBackend_.UseVisualStyleBackColor = true;
			// 
			// keyName
			// 
			this.keyName.Location = new System.Drawing.Point(252, 20);
			this.keyName.Name = "keyName";
			this.keyName.Size = new System.Drawing.Size(95, 21);
			this.keyName.TabIndex = 1006;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(157, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 12);
			this.label1.TabIndex = 1005;
			this.label1.Text = "键名（可忽略）";
			// 
			// backend
			// 
			this.backend.Controls.Add(this.defaultNew);
			this.backend.Controls.Add(this.fDefault);
			this.backend.Controls.Add(this.label4);
			this.backend.Controls.Add(this.autoConvert);
			this.backend.Controls.Add(this.autoLoad);
			this.backend.Controls.Add(this.format);
			this.backend.Controls.Add(this.label3);
			this.backend.Controls.Add(this.protectedSet);
			this.backend.Controls.Add(this.useList);
			this.backend.Controls.Add(this.isFrontend_);
			this.backend.Controls.Add(this.fType);
			this.backend.Controls.Add(this.label7);
			this.backend.Controls.Add(this.label2);
			this.backend.Controls.Add(this.dateTimeType);
			this.backend.Controls.Add(this.label9);
			this.backend.Controls.Add(this.dimension);
			this.backend.Controls.Add(this.intType);
			this.backend.Controls.Add(this.label8);
			this.backend.Controls.Add(this.dateType);
			this.backend.Controls.Add(this.strType);
			this.backend.Controls.Add(this.doubleType);
			this.backend.Controls.Add(this.boolType);
			this.backend.Location = new System.Drawing.Point(12, 93);
			this.backend.Name = "backend";
			this.backend.Size = new System.Drawing.Size(335, 175);
			this.backend.TabIndex = 1004;
			this.backend.TabStop = false;
			this.backend.Text = "          ";
			// 
			// defaultNew
			// 
			this.defaultNew.AutoSize = true;
			this.defaultNew.Location = new System.Drawing.Point(255, 24);
			this.defaultNew.Name = "defaultNew";
			this.defaultNew.Size = new System.Drawing.Size(72, 16);
			this.defaultNew.TabIndex = 1015;
			this.defaultNew.Text = "默认实例";
			this.defaultNew.UseVisualStyleBackColor = true;
			// 
			// fDefault
			// 
			this.fDefault.Location = new System.Drawing.Point(181, 22);
			this.fDefault.Name = "fDefault";
			this.fDefault.Size = new System.Drawing.Size(68, 21);
			this.fDefault.TabIndex = 1014;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(146, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 12);
			this.label4.TabIndex = 1013;
			this.label4.Text = "默认";
			// 
			// autoConvert
			// 
			this.autoConvert.AutoSize = true;
			this.autoConvert.Location = new System.Drawing.Point(237, 103);
			this.autoConvert.Name = "autoConvert";
			this.autoConvert.Size = new System.Drawing.Size(90, 16);
			this.autoConvert.TabIndex = 1012;
			this.autoConvert.Text = "autoConvert";
			this.autoConvert.UseVisualStyleBackColor = true;
			// 
			// autoLoad
			// 
			this.autoLoad.AutoSize = true;
			this.autoLoad.Location = new System.Drawing.Point(159, 103);
			this.autoLoad.Name = "autoLoad";
			this.autoLoad.Size = new System.Drawing.Size(72, 16);
			this.autoLoad.TabIndex = 1011;
			this.autoLoad.Text = "autoLoad";
			this.autoLoad.UseVisualStyleBackColor = true;
			// 
			// format
			// 
			this.format.Location = new System.Drawing.Point(46, 101);
			this.format.Name = "format";
			this.format.Size = new System.Drawing.Size(62, 21);
			this.format.TabIndex = 1008;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 12);
			this.label3.TabIndex = 1007;
			this.label3.Text = "格式";
			// 
			// protectedSet
			// 
			this.protectedSet.AutoSize = true;
			this.protectedSet.Location = new System.Drawing.Point(13, 128);
			this.protectedSet.Name = "protectedSet";
			this.protectedSet.Size = new System.Drawing.Size(102, 16);
			this.protectedSet.TabIndex = 1010;
			this.protectedSet.Text = "protected set";
			this.protectedSet.UseVisualStyleBackColor = true;
			// 
			// useList
			// 
			this.useList.AutoSize = true;
			this.useList.Location = new System.Drawing.Point(159, 77);
			this.useList.Name = "useList";
			this.useList.Size = new System.Drawing.Size(84, 16);
			this.useList.TabIndex = 1009;
			this.useList.Text = "使用List<>";
			this.useList.UseVisualStyleBackColor = true;
			// 
			// isFrontend_
			// 
			this.isFrontend_.AutoSize = true;
			this.isFrontend_.Location = new System.Drawing.Point(6, 0);
			this.isFrontend_.Name = "isFrontend_";
			this.isFrontend_.Size = new System.Drawing.Size(72, 16);
			this.isFrontend_.TabIndex = 1008;
			this.isFrontend_.Text = "前端可用";
			this.isFrontend_.UseVisualStyleBackColor = true;
			// 
			// create
			// 
			this.create.Location = new System.Drawing.Point(290, 12);
			this.create.Name = "create";
			this.create.Size = new System.Drawing.Size(73, 23);
			this.create.TabIndex = 52;
			this.create.Text = "添加";
			this.create.UseVisualStyleBackColor = true;
			// 
			// fCode
			// 
			this.fCode.Location = new System.Drawing.Point(13, 41);
			this.fCode.Multiline = true;
			this.fCode.Name = "fCode";
			this.fCode.ReadOnly = true;
			this.fCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.fCode.Size = new System.Drawing.Size(309, 69);
			this.fCode.TabIndex = 1008;
			this.fCode.WordWrap = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label19);
			this.groupBox2.Controls.Add(this.bCode);
			this.groupBox2.Controls.Add(this.label18);
			this.groupBox2.Controls.Add(this.fCode);
			this.groupBox2.Location = new System.Drawing.Point(369, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(334, 213);
			this.groupBox2.TabIndex = 1009;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "代码预览";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(11, 123);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(53, 12);
			this.label19.TabIndex = 1011;
			this.label19.Text = "后台代码";
			// 
			// bCode
			// 
			this.bCode.Location = new System.Drawing.Point(13, 138);
			this.bCode.Multiline = true;
			this.bCode.Name = "bCode";
			this.bCode.ReadOnly = true;
			this.bCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.bCode.Size = new System.Drawing.Size(309, 69);
			this.bCode.TabIndex = 1010;
			this.bCode.WordWrap = false;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(11, 26);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(53, 12);
			this.label18.TabIndex = 1009;
			this.label18.Text = "前端代码";
			// 
			// ModifyFields
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(715, 517);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.create);
			this.Controls.Add(this.curPage);
			this.Controls.Add(this.paramList);
			this.Controls.Add(this.confirm);
			this.Controls.Add(this.moveDown);
			this.Controls.Add(this.delete);
			this.Controls.Add(this.copy);
			this.Controls.Add(this.moveUp);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximumSize = new System.Drawing.Size(731, 556);
			this.MinimumSize = new System.Drawing.Size(341, 556);
			this.Name = "ModifyFields";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "参数修改";
			((System.ComponentModel.ISupportInitialize)(this.dimension)).EndInit();
			this.curPage.ResumeLayout(false);
			this.curPage.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxLength)).EndInit();
			this.backend.ResumeLayout(false);
			this.backend.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private ExermonDevManager.Scripts.Controls.ExerListView paramList;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Button copy;
		private System.Windows.Forms.Button delete;
		private System.Windows.Forms.LinkLabel boolType;
		private System.Windows.Forms.LinkLabel strType;
		private System.Windows.Forms.LinkLabel intType;
		private System.Windows.Forms.Label label9;
		private ExermonDevManager.Scripts.Controls.ExerNumericUpDown dimension;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private ExermonDevManager.Scripts.Controls.ExerComboBox fType;
		private ExermonDevManager.Scripts.Controls.ExerTextBox description;
		private System.Windows.Forms.Label label6;
		private ExermonDevManager.Scripts.Controls.ExerTextBox name;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button confirm;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel doubleType;
		private System.Windows.Forms.LinkLabel dateType;
		private System.Windows.Forms.LinkLabel dateTimeType;
		private System.Windows.Forms.Button moveUp;
		private System.Windows.Forms.Button moveDown;
		private System.Windows.Forms.GroupBox curPage;
		private System.Windows.Forms.Button create;
		private System.Windows.Forms.GroupBox backend;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox isFrontend_;
		private ExermonDevManager.Scripts.Controls.ExerTextBox keyName;
		private System.Windows.Forms.Label label1;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox useList;
		private ExermonDevManager.Scripts.Controls.ExerTextBox format;
		private System.Windows.Forms.Label label3;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox protectedSet;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox autoLoad;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox autoConvert;
		private ExermonDevManager.Scripts.Controls.ExerTextBox fDefault;
		private System.Windows.Forms.Label label4;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox defaultNew;
		private System.Windows.Forms.GroupBox groupBox1;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox isBackend_;
		private ExermonDevManager.Scripts.Controls.ExerTextBox bDefault;
		private System.Windows.Forms.Label label10;
		private ExermonDevManager.Scripts.Controls.ExerComboBox bType;
		private System.Windows.Forms.Label label11;
		private ExermonDevManager.Scripts.Controls.ExerNumericUpDown maxLength;
		private System.Windows.Forms.Label label12;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox blank;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox null_;
		private ExermonDevManager.Scripts.Controls.ExerTextBox verboseName;
		private System.Windows.Forms.Label label13;
		private ExermonDevManager.Scripts.Controls.ExerTextBox uploadTo;
		private System.Windows.Forms.Label label15;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox autoNowAdd;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox autoNow;
		private ExermonDevManager.Scripts.Controls.ExerComboBox choices;
		private ExermonDevManager.Scripts.Controls.ExerComboBox toModel;
		private System.Windows.Forms.Label label16;
		private ExermonDevManager.Scripts.Controls.ExerComboBox onDelete;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox fCode;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox bCode;
		private System.Windows.Forms.Label label18;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox unique;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox listEditable;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox listDisplay;
		private ExermonDevManager.Scripts.Controls.ExerTextBox typeExclude;
		private System.Windows.Forms.Label label22;
		private ExermonDevManager.Scripts.Controls.ExerTextBox typeFilter;
		private System.Windows.Forms.Label label21;
		private ExermonDevManager.Scripts.Controls.ExerTextBox convertFunc;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Button cancelChoices;
		private System.Windows.Forms.Label label14;
	}
}