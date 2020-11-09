namespace ExermonDevManager.Forms {
	partial class ModelFieldSubForm {
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
			this.components = new System.ComponentModel.Container();
			this.dataView = new ExermonDevManager.Scripts.Controls.ExerDataGridView();
			this.exermon_managerDataSet = new ExermonDevManager.exermon_managerDataSet();
			this.rootCombox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.saveButton = new System.Windows.Forms.Button();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.curPage = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label20 = new System.Windows.Forms.Label();
			this.listEditable = new ExermonDevManager.Scripts.Controls.ExerEntityCheckBox();
			this.listDisplay = new ExermonDevManager.Scripts.Controls.ExerEntityCheckBox();
			this.typeExclude = new ExermonDevManager.Scripts.Controls.ExerEntityTextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.typeFilter = new ExermonDevManager.Scripts.Controls.ExerEntityTextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.convertFunc = new ExermonDevManager.Scripts.Controls.ExerEntityTextBox();
			this.unique = new ExermonDevManager.Scripts.Controls.ExerEntityCheckBox();
			this.onDelete = new ExermonDevManager.Scripts.Controls.ExerEntityComboBox();
			this.label17 = new System.Windows.Forms.Label();
			this.toModel = new ExermonDevManager.Scripts.Controls.ExerEntityComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.uploadTo = new ExermonDevManager.Scripts.Controls.ExerEntityTextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.autoNowAdd = new ExermonDevManager.Scripts.Controls.ExerEntityCheckBox();
			this.autoNow = new ExermonDevManager.Scripts.Controls.ExerEntityCheckBox();
			this.cancelChoices = new System.Windows.Forms.Button();
			this.choices = new ExermonDevManager.Scripts.Controls.ExerEntityComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.verboseName = new ExermonDevManager.Scripts.Controls.ExerEntityTextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.blank = new ExermonDevManager.Scripts.Controls.ExerEntityCheckBox();
			this.null_ = new ExermonDevManager.Scripts.Controls.ExerEntityCheckBox();
			this.maxLength = new ExermonDevManager.Scripts.Controls.ExerEntityNumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.bDefault = new ExermonDevManager.Scripts.Controls.ExerEntityTextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.bType = new ExermonDevManager.Scripts.Controls.ExerEntityComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.isBackend_ = new ExermonDevManager.Scripts.Controls.ExerEntityCheckBox();
			this.keyName = new ExermonDevManager.Scripts.Controls.ExerEntityTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.backend = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.autoConvert = new ExermonDevManager.Scripts.Controls.ExerEntityCheckBox();
			this.autoLoad = new ExermonDevManager.Scripts.Controls.ExerEntityCheckBox();
			this.format = new ExermonDevManager.Scripts.Controls.ExerEntityTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.defaultNew = new ExermonDevManager.Scripts.Controls.ExerEntityCheckBox();
			this.fDefault = new ExermonDevManager.Scripts.Controls.ExerEntityTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.protectedSet = new ExermonDevManager.Scripts.Controls.ExerEntityCheckBox();
			this.useList = new ExermonDevManager.Scripts.Controls.ExerEntityCheckBox();
			this.isFrontend_ = new ExermonDevManager.Scripts.Controls.ExerEntityCheckBox();
			this.fType = new ExermonDevManager.Scripts.Controls.ExerEntityComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dateTimeType = new System.Windows.Forms.LinkLabel();
			this.label9 = new System.Windows.Forms.Label();
			this.dimension = new ExermonDevManager.Scripts.Controls.ExerEntityNumericUpDown();
			this.intType = new System.Windows.Forms.LinkLabel();
			this.label8 = new System.Windows.Forms.Label();
			this.dateType = new System.Windows.Forms.LinkLabel();
			this.strType = new System.Windows.Forms.LinkLabel();
			this.doubleType = new System.Windows.Forms.LinkLabel();
			this.boolType = new System.Windows.Forms.LinkLabel();
			this.description = new ExermonDevManager.Scripts.Controls.ExerEntityTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.name = new ExermonDevManager.Scripts.Controls.ExerEntityTextBox();
			this.label18 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exermon_managerDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.curPage.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxLength)).BeginInit();
			this.backend.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dimension)).BeginInit();
			this.SuspendLayout();
			// 
			// dataView
			// 
			this.dataView.AllowUserToOrderColumns = true;
			this.dataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataView.Location = new System.Drawing.Point(12, 42);
			this.dataView.Name = "dataView";
			this.dataView.RowTemplate.Height = 23;
			this.dataView.Size = new System.Drawing.Size(284, 513);
			this.dataView.TabIndex = 0;
			this.dataView.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataView_UserAddedRow);
			this.dataView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataView_UserDeletingRow);
			// 
			// exermon_managerDataSet
			// 
			this.exermon_managerDataSet.DataSetName = "exermon_managerDataSet";
			this.exermon_managerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// rootCombox
			// 
			this.rootCombox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rootCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.rootCombox.FormattingEnabled = true;
			this.rootCombox.Location = new System.Drawing.Point(65, 16);
			this.rootCombox.Name = "rootCombox";
			this.rootCombox.Size = new System.Drawing.Size(637, 20);
			this.rootCombox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "选择数据";
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(708, 14);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 3;
			this.saveButton.Text = "保存数据";
			this.saveButton.UseVisualStyleBackColor = true;
			// 
			// bindingSource
			// 
			this.bindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.bindingSource_AddingNew);
			this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
			// 
			// curPage
			// 
			this.curPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.curPage.Controls.Add(this.groupBox1);
			this.curPage.Controls.Add(this.keyName);
			this.curPage.Controls.Add(this.label2);
			this.curPage.Controls.Add(this.backend);
			this.curPage.Controls.Add(this.description);
			this.curPage.Controls.Add(this.label6);
			this.curPage.Controls.Add(this.name);
			this.curPage.Controls.Add(this.label18);
			this.curPage.Location = new System.Drawing.Point(302, 43);
			this.curPage.Name = "curPage";
			this.curPage.Size = new System.Drawing.Size(481, 512);
			this.curPage.TabIndex = 52;
			this.curPage.TabStop = false;
			this.curPage.Text = "编辑页";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
			this.groupBox1.Location = new System.Drawing.Point(12, 255);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(463, 251);
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
			this.typeExclude.Location = new System.Drawing.Point(307, 177);
			this.typeExclude.Name = "typeExclude";
			this.typeExclude.Size = new System.Drawing.Size(150, 21);
			this.typeExclude.TabIndex = 1040;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(254, 180);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(47, 12);
			this.label22.TabIndex = 1039;
			this.label22.Text = "exclude";
			// 
			// typeFilter
			// 
			this.typeFilter.Location = new System.Drawing.Point(86, 178);
			this.typeFilter.Name = "typeFilter";
			this.typeFilter.Size = new System.Drawing.Size(150, 21);
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
			this.convertFunc.Size = new System.Drawing.Size(305, 39);
			this.convertFunc.TabIndex = 1036;
			// 
			// unique
			// 
			this.unique.AutoSize = true;
			this.unique.Location = new System.Drawing.Point(397, 48);
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
			this.onDelete.Location = new System.Drawing.Point(307, 151);
			this.onDelete.Name = "onDelete";
			this.onDelete.Size = new System.Drawing.Size(150, 20);
			this.onDelete.TabIndex = 1033;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(242, 154);
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
			this.toModel.Size = new System.Drawing.Size(168, 20);
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
			this.uploadTo.Size = new System.Drawing.Size(341, 21);
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
			this.cancelChoices.Location = new System.Drawing.Point(403, 72);
			this.cancelChoices.Name = "cancelChoices";
			this.cancelChoices.Size = new System.Drawing.Size(54, 23);
			this.cancelChoices.TabIndex = 1025;
			this.cancelChoices.Text = "重置";
			this.cancelChoices.UseVisualStyleBackColor = true;
			// 
			// choices
			// 
			this.choices.DisplayMember = "34";
			this.choices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.choices.FormattingEnabled = true;
			this.choices.Location = new System.Drawing.Point(237, 74);
			this.choices.Name = "choices";
			this.choices.Size = new System.Drawing.Size(160, 20);
			this.choices.TabIndex = 1024;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(190, 77);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(41, 12);
			this.label14.TabIndex = 1023;
			this.label14.Text = "选择项";
			// 
			// verboseName
			// 
			this.verboseName.Location = new System.Drawing.Point(337, 20);
			this.verboseName.Name = "verboseName";
			this.verboseName.Size = new System.Drawing.Size(120, 21);
			this.verboseName.TabIndex = 1022;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(278, 23);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(53, 12);
			this.label13.TabIndex = 1021;
			this.label13.Text = "显示名称";
			// 
			// blank
			// 
			this.blank.AutoSize = true;
			this.blank.Location = new System.Drawing.Point(337, 48);
			this.blank.Name = "blank";
			this.blank.Size = new System.Drawing.Size(54, 16);
			this.blank.TabIndex = 1017;
			this.blank.Text = "blank";
			this.blank.UseVisualStyleBackColor = true;
			// 
			// null_
			// 
			this.null_.AutoSize = true;
			this.null_.Location = new System.Drawing.Point(286, 48);
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
			this.maxLength.Size = new System.Drawing.Size(117, 21);
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
			this.bDefault.Size = new System.Drawing.Size(230, 21);
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
			this.bType.Size = new System.Drawing.Size(230, 20);
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
			this.keyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.keyName.Location = new System.Drawing.Point(373, 20);
			this.keyName.Name = "keyName";
			this.keyName.Size = new System.Drawing.Size(102, 21);
			this.keyName.TabIndex = 1006;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(278, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 12);
			this.label2.TabIndex = 1005;
			this.label2.Text = "键名（可忽略）";
			// 
			// backend
			// 
			this.backend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.backend.Controls.Add(this.groupBox2);
			this.backend.Controls.Add(this.defaultNew);
			this.backend.Controls.Add(this.fDefault);
			this.backend.Controls.Add(this.label4);
			this.backend.Controls.Add(this.protectedSet);
			this.backend.Controls.Add(this.useList);
			this.backend.Controls.Add(this.isFrontend_);
			this.backend.Controls.Add(this.fType);
			this.backend.Controls.Add(this.label7);
			this.backend.Controls.Add(this.label5);
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
			this.backend.Size = new System.Drawing.Size(463, 156);
			this.backend.TabIndex = 1004;
			this.backend.TabStop = false;
			this.backend.Text = "          ";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.autoConvert);
			this.groupBox2.Controls.Add(this.autoLoad);
			this.groupBox2.Controls.Add(this.format);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new System.Drawing.Point(12, 103);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(445, 42);
			this.groupBox2.TabIndex = 1016;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "AutoConvert参数";
			// 
			// autoConvert
			// 
			this.autoConvert.AutoSize = true;
			this.autoConvert.Location = new System.Drawing.Point(349, 17);
			this.autoConvert.Name = "autoConvert";
			this.autoConvert.Size = new System.Drawing.Size(90, 16);
			this.autoConvert.TabIndex = 1012;
			this.autoConvert.Text = "autoConvert";
			this.autoConvert.UseVisualStyleBackColor = true;
			// 
			// autoLoad
			// 
			this.autoLoad.AutoSize = true;
			this.autoLoad.Location = new System.Drawing.Point(271, 17);
			this.autoLoad.Name = "autoLoad";
			this.autoLoad.Size = new System.Drawing.Size(72, 16);
			this.autoLoad.TabIndex = 1011;
			this.autoLoad.Text = "autoLoad";
			this.autoLoad.UseVisualStyleBackColor = true;
			// 
			// format
			// 
			this.format.Location = new System.Drawing.Point(51, 15);
			this.format.Name = "format";
			this.format.Size = new System.Drawing.Size(204, 21);
			this.format.TabIndex = 1008;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 12);
			this.label3.TabIndex = 1007;
			this.label3.Text = "格式";
			// 
			// defaultNew
			// 
			this.defaultNew.AutoSize = true;
			this.defaultNew.Location = new System.Drawing.Point(385, 24);
			this.defaultNew.Name = "defaultNew";
			this.defaultNew.Size = new System.Drawing.Size(72, 16);
			this.defaultNew.TabIndex = 1015;
			this.defaultNew.Text = "默认实例";
			this.defaultNew.UseVisualStyleBackColor = true;
			// 
			// fDefault
			// 
			this.fDefault.Location = new System.Drawing.Point(311, 22);
			this.fDefault.Name = "fDefault";
			this.fDefault.Size = new System.Drawing.Size(68, 21);
			this.fDefault.TabIndex = 1014;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(276, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 12);
			this.label4.TabIndex = 1013;
			this.label4.Text = "默认";
			// 
			// protectedSet
			// 
			this.protectedSet.AutoSize = true;
			this.protectedSet.Location = new System.Drawing.Point(355, 53);
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
			// fType
			// 
			this.fType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.fType.FormattingEnabled = true;
			this.fType.Location = new System.Drawing.Point(46, 22);
			this.fType.Name = "fType";
			this.fType.Size = new System.Drawing.Size(224, 20);
			this.fType.TabIndex = 1001;
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
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 55);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 12);
			this.label5.TabIndex = 43;
			this.label5.Text = "快捷类型";
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
			// intType
			// 
			this.intType.AutoSize = true;
			this.intType.Location = new System.Drawing.Point(70, 54);
			this.intType.Name = "intType";
			this.intType.Size = new System.Drawing.Size(23, 12);
			this.intType.TabIndex = 35;
			this.intType.TabStop = true;
			this.intType.Text = "int";
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
			// dateType
			// 
			this.dateType.AutoSize = true;
			this.dateType.Location = new System.Drawing.Point(210, 54);
			this.dateType.Name = "dateType";
			this.dateType.Size = new System.Drawing.Size(29, 12);
			this.dateType.TabIndex = 46;
			this.dateType.TabStop = true;
			this.dateType.Text = "date";
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
			// 
			// description
			// 
			this.description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.description.Location = new System.Drawing.Point(45, 47);
			this.description.Multiline = true;
			this.description.Name = "description";
			this.description.Size = new System.Drawing.Size(430, 40);
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
			this.name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.name.Location = new System.Drawing.Point(45, 20);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(227, 21);
			this.name.TabIndex = 1000;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(10, 23);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(29, 12);
			this.label18.TabIndex = 25;
			this.label18.Text = "名称";
			// 
			// ModelFieldSubForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(795, 567);
			this.Controls.Add(this.curPage);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.rootCombox);
			this.Controls.Add(this.dataView);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "ModelFieldSubForm";
			this.Text = "关系数据编辑";
			((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exermon_managerDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.curPage.ResumeLayout(false);
			this.curPage.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxLength)).EndInit();
			this.backend.ResumeLayout(false);
			this.backend.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dimension)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Scripts.Controls.ExerDataGridView dataView;
		private System.Windows.Forms.ComboBox rootCombox;
		private System.Windows.Forms.Label label1;
		private exermon_managerDataSet exermon_managerDataSet;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.BindingSource bindingSource;
		private System.Windows.Forms.GroupBox curPage;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label20;
		private Scripts.Controls.ExerEntityCheckBox listEditable;
		private Scripts.Controls.ExerEntityCheckBox listDisplay;
		private Scripts.Controls.ExerEntityTextBox typeExclude;
		private System.Windows.Forms.Label label22;
		private Scripts.Controls.ExerEntityTextBox typeFilter;
		private System.Windows.Forms.Label label21;
		private Scripts.Controls.ExerEntityTextBox convertFunc;
		private Scripts.Controls.ExerEntityCheckBox unique;
		private Scripts.Controls.ExerEntityComboBox onDelete;
		private System.Windows.Forms.Label label17;
		private Scripts.Controls.ExerEntityComboBox toModel;
		private System.Windows.Forms.Label label16;
		private Scripts.Controls.ExerEntityTextBox uploadTo;
		private System.Windows.Forms.Label label15;
		private Scripts.Controls.ExerEntityCheckBox autoNowAdd;
		private Scripts.Controls.ExerEntityCheckBox autoNow;
		private System.Windows.Forms.Button cancelChoices;
		private Scripts.Controls.ExerEntityComboBox choices;
		private System.Windows.Forms.Label label14;
		private Scripts.Controls.ExerEntityTextBox verboseName;
		private System.Windows.Forms.Label label13;
		private Scripts.Controls.ExerEntityCheckBox blank;
		private Scripts.Controls.ExerEntityCheckBox null_;
		private Scripts.Controls.ExerEntityNumericUpDown maxLength;
		private System.Windows.Forms.Label label12;
		private Scripts.Controls.ExerEntityTextBox bDefault;
		private System.Windows.Forms.Label label10;
		private Scripts.Controls.ExerEntityComboBox bType;
		private System.Windows.Forms.Label label11;
		private Scripts.Controls.ExerEntityCheckBox isBackend_;
		private Scripts.Controls.ExerEntityTextBox keyName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox backend;
		private System.Windows.Forms.GroupBox groupBox2;
		private Scripts.Controls.ExerEntityCheckBox autoConvert;
		private Scripts.Controls.ExerEntityCheckBox autoLoad;
		private Scripts.Controls.ExerEntityTextBox format;
		private System.Windows.Forms.Label label3;
		private Scripts.Controls.ExerEntityCheckBox protectedSet;
		private Scripts.Controls.ExerEntityCheckBox defaultNew;
		private Scripts.Controls.ExerEntityTextBox fDefault;
		private System.Windows.Forms.Label label4;
		private Scripts.Controls.ExerEntityCheckBox useList;
		private Scripts.Controls.ExerEntityCheckBox isFrontend_;
		private Scripts.Controls.ExerEntityComboBox fType;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.LinkLabel dateTimeType;
		private System.Windows.Forms.Label label9;
		private Scripts.Controls.ExerEntityNumericUpDown dimension;
		private System.Windows.Forms.LinkLabel intType;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.LinkLabel dateType;
		private System.Windows.Forms.LinkLabel strType;
		private System.Windows.Forms.LinkLabel doubleType;
		private System.Windows.Forms.LinkLabel boolType;
		private Scripts.Controls.ExerEntityTextBox description;
		private System.Windows.Forms.Label label6;
		private Scripts.Controls.ExerEntityTextBox name;
		private System.Windows.Forms.Label label18;
	}
}