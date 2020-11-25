
namespace ExermonDevManager.Frameworks.ExerUnity.Forms {

	partial class ModelFieldForm {
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
			this.dataView = new ExermonDevManager.Core.Controls.ExermonDataGridView();
			this.exermon_managerDataSet = new ExermonDevManager.exermon_managerDataSet();
			this.rootCombox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.saveButton = new System.Windows.Forms.Button();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.curPage = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.autoConvert = new ExermonDevManager.Core.Controls.ExermonCheckBox();
			this.autoLoad = new ExermonDevManager.Core.Controls.ExermonCheckBox();
			this.keyName = new ExermonDevManager.Core.Controls.ExermonTextBox();
			this.format = new ExermonDevManager.Core.Controls.ExermonTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.defaultNew = new ExermonDevManager.Core.Controls.ExermonCheckBox();
			this.fDefault = new ExermonDevManager.Core.Controls.ExermonTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.description = new ExermonDevManager.Core.Controls.ExermonTextBox();
			this.protectedSet = new ExermonDevManager.Core.Controls.ExermonCheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.useList = new ExermonDevManager.Core.Controls.ExermonCheckBox();
			this.name = new ExermonDevManager.Core.Controls.ExermonTextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.fType = new ExermonDevManager.Core.Controls.ExermonComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.boolType = new System.Windows.Forms.LinkLabel();
			this.label5 = new System.Windows.Forms.Label();
			this.doubleType = new System.Windows.Forms.LinkLabel();
			this.dateTimeType = new System.Windows.Forms.LinkLabel();
			this.strType = new System.Windows.Forms.LinkLabel();
			this.dimension = new ExermonDevManager.Core.Controls.ExermonNumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.intType = new System.Windows.Forms.LinkLabel();
			this.fCode = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.exerEntityTextBox1 = new ExermonDevManager.Core.Controls.ExermonTextBox();
			this.label11 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exermon_managerDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.curPage.SuspendLayout();
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
			this.dataView.Size = new System.Drawing.Size(195, 359);
			this.dataView.TabIndex = 0;
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
			this.rootCombox.Size = new System.Drawing.Size(346, 20);
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
			this.saveButton.Location = new System.Drawing.Point(417, 14);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 3;
			this.saveButton.Text = "保存数据";
			this.saveButton.UseVisualStyleBackColor = true;
			// 
			// curPage
			// 
			this.curPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.curPage.Controls.Add(this.exerEntityTextBox1);
			this.curPage.Controls.Add(this.label11);
			this.curPage.Controls.Add(this.groupBox2);
			this.curPage.Controls.Add(this.label9);
			this.curPage.Controls.Add(this.defaultNew);
			this.curPage.Controls.Add(this.fDefault);
			this.curPage.Controls.Add(this.label4);
			this.curPage.Controls.Add(this.description);
			this.curPage.Controls.Add(this.protectedSet);
			this.curPage.Controls.Add(this.label6);
			this.curPage.Controls.Add(this.useList);
			this.curPage.Controls.Add(this.name);
			this.curPage.Controls.Add(this.label18);
			this.curPage.Controls.Add(this.fType);
			this.curPage.Controls.Add(this.label7);
			this.curPage.Controls.Add(this.boolType);
			this.curPage.Controls.Add(this.label5);
			this.curPage.Controls.Add(this.doubleType);
			this.curPage.Controls.Add(this.dateTimeType);
			this.curPage.Controls.Add(this.strType);
			this.curPage.Controls.Add(this.dimension);
			this.curPage.Controls.Add(this.label8);
			this.curPage.Controls.Add(this.intType);
			this.curPage.Location = new System.Drawing.Point(213, 42);
			this.curPage.Name = "curPage";
			this.curPage.Size = new System.Drawing.Size(279, 359);
			this.curPage.TabIndex = 52;
			this.curPage.TabStop = false;
			this.curPage.Text = "编辑页";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.autoConvert);
			this.groupBox2.Controls.Add(this.autoLoad);
			this.groupBox2.Controls.Add(this.keyName);
			this.groupBox2.Controls.Add(this.format);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(6, 271);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(267, 81);
			this.groupBox2.TabIndex = 1016;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "AutoConvert参数";
			// 
			// autoConvert
			// 
			this.autoConvert.AutoSize = true;
			this.autoConvert.Location = new System.Drawing.Point(149, 51);
			this.autoConvert.Name = "autoConvert";
			this.autoConvert.Size = new System.Drawing.Size(90, 16);
			this.autoConvert.TabIndex = 1012;
			this.autoConvert.Text = "autoConvert";
			this.autoConvert.UseVisualStyleBackColor = true;
			// 
			// autoLoad
			// 
			this.autoLoad.AutoSize = true;
			this.autoLoad.Location = new System.Drawing.Point(149, 24);
			this.autoLoad.Name = "autoLoad";
			this.autoLoad.Size = new System.Drawing.Size(72, 16);
			this.autoLoad.TabIndex = 1011;
			this.autoLoad.Text = "autoLoad";
			this.autoLoad.UseVisualStyleBackColor = true;
			// 
			// keyName
			// 
			this.keyName.Location = new System.Drawing.Point(41, 22);
			this.keyName.Name = "keyName";
			this.keyName.Size = new System.Drawing.Size(102, 21);
			this.keyName.TabIndex = 1006;
			// 
			// format
			// 
			this.format.Location = new System.Drawing.Point(41, 49);
			this.format.Name = "format";
			this.format.Size = new System.Drawing.Size(102, 21);
			this.format.TabIndex = 1008;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 12);
			this.label3.TabIndex = 1007;
			this.label3.Text = "格式";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 1005;
			this.label2.Text = "键名";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(97, 176);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(17, 12);
			this.label9.TabIndex = 34;
			this.label9.Text = "维";
			// 
			// defaultNew
			// 
			this.defaultNew.AutoSize = true;
			this.defaultNew.Location = new System.Drawing.Point(201, 224);
			this.defaultNew.Name = "defaultNew";
			this.defaultNew.Size = new System.Drawing.Size(72, 16);
			this.defaultNew.TabIndex = 1015;
			this.defaultNew.Text = "默认实例";
			this.defaultNew.UseVisualStyleBackColor = true;
			// 
			// fDefault
			// 
			this.fDefault.Location = new System.Drawing.Point(45, 222);
			this.fDefault.Name = "fDefault";
			this.fDefault.Size = new System.Drawing.Size(150, 21);
			this.fDefault.TabIndex = 1014;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 225);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 12);
			this.label4.TabIndex = 1013;
			this.label4.Text = "默认";
			// 
			// description
			// 
			this.description.Location = new System.Drawing.Point(45, 74);
			this.description.Multiline = true;
			this.description.Name = "description";
			this.description.Size = new System.Drawing.Size(228, 40);
			this.description.TabIndex = 1003;
			// 
			// protectedSet
			// 
			this.protectedSet.AutoSize = true;
			this.protectedSet.Location = new System.Drawing.Point(12, 249);
			this.protectedSet.Name = "protectedSet";
			this.protectedSet.Size = new System.Drawing.Size(102, 16);
			this.protectedSet.TabIndex = 1010;
			this.protectedSet.Text = "protected set";
			this.protectedSet.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 77);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(29, 12);
			this.label6.TabIndex = 27;
			this.label6.Text = "描述";
			// 
			// useList
			// 
			this.useList.AutoSize = true;
			this.useList.Location = new System.Drawing.Point(126, 175);
			this.useList.Name = "useList";
			this.useList.Size = new System.Drawing.Size(84, 16);
			this.useList.TabIndex = 1009;
			this.useList.Text = "使用List<>";
			this.useList.UseVisualStyleBackColor = true;
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(45, 20);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(228, 21);
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
			// fType
			// 
			this.fType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.fType.filter = null;
			this.fType.FormattingEnabled = true;
			this.fType.Location = new System.Drawing.Point(45, 120);
			this.fType.Name = "fType";
			this.fType.Size = new System.Drawing.Size(228, 20);
			this.fType.TabIndex = 1001;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(10, 123);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(29, 12);
			this.label7.TabIndex = 30;
			this.label7.Text = "类型";
			// 
			// boolType
			// 
			this.boolType.AutoSize = true;
			this.boolType.Location = new System.Drawing.Point(174, 149);
			this.boolType.Name = "boolType";
			this.boolType.Size = new System.Drawing.Size(29, 12);
			this.boolType.TabIndex = 37;
			this.boolType.TabStop = true;
			this.boolType.Text = "bool";
			this.boolType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.boolType_LinkClicked);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 149);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 12);
			this.label5.TabIndex = 43;
			this.label5.Text = "快捷类型";
			// 
			// doubleType
			// 
			this.doubleType.AutoSize = true;
			this.doubleType.Location = new System.Drawing.Point(98, 149);
			this.doubleType.Name = "doubleType";
			this.doubleType.Size = new System.Drawing.Size(41, 12);
			this.doubleType.TabIndex = 45;
			this.doubleType.TabStop = true;
			this.doubleType.Text = "double";
			this.doubleType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.doubleType_LinkClicked);
			// 
			// dateTimeType
			// 
			this.dateTimeType.AutoSize = true;
			this.dateTimeType.Location = new System.Drawing.Point(209, 149);
			this.dateTimeType.Name = "dateTimeType";
			this.dateTimeType.Size = new System.Drawing.Size(53, 12);
			this.dateTimeType.TabIndex = 47;
			this.dateTimeType.TabStop = true;
			this.dateTimeType.Text = "datetime";
			this.dateTimeType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dateTimeType_LinkClicked);
			// 
			// strType
			// 
			this.strType.AutoSize = true;
			this.strType.Location = new System.Drawing.Point(145, 149);
			this.strType.Name = "strType";
			this.strType.Size = new System.Drawing.Size(23, 12);
			this.strType.TabIndex = 36;
			this.strType.TabStop = true;
			this.strType.Text = "str";
			this.strType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.strType_LinkClicked);
			// 
			// dimension
			// 
			this.dimension.Location = new System.Drawing.Point(45, 174);
			this.dimension.Name = "dimension";
			this.dimension.Size = new System.Drawing.Size(46, 21);
			this.dimension.TabIndex = 1002;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(10, 176);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(29, 12);
			this.label8.TabIndex = 32;
			this.label8.Text = "数组";
			// 
			// intType
			// 
			this.intType.AutoSize = true;
			this.intType.Location = new System.Drawing.Point(69, 149);
			this.intType.Name = "intType";
			this.intType.Size = new System.Drawing.Size(23, 12);
			this.intType.TabIndex = 35;
			this.intType.TabStop = true;
			this.intType.Text = "int";
			this.intType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.intType_LinkClicked);
			// 
			// fCode
			// 
			this.fCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fCode.Location = new System.Drawing.Point(12, 419);
			this.fCode.Multiline = true;
			this.fCode.Name = "fCode";
			this.fCode.ReadOnly = true;
			this.fCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.fCode.Size = new System.Drawing.Size(480, 90);
			this.fCode.TabIndex = 1008;
			this.fCode.WordWrap = false;
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(10, 404);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(53, 12);
			this.label10.TabIndex = 1017;
			this.label10.Text = "代码预览";
			// 
			// exerEntityTextBox1
			// 
			this.exerEntityTextBox1.Location = new System.Drawing.Point(45, 47);
			this.exerEntityTextBox1.Name = "exerEntityTextBox1";
			this.exerEntityTextBox1.Size = new System.Drawing.Size(228, 21);
			this.exerEntityTextBox1.TabIndex = 1018;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(10, 50);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(29, 12);
			this.label11.TabIndex = 1017;
			this.label11.Text = "代码";
			// 
			// ModelFieldSubForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(504, 521);
			this.Controls.Add(this.fCode);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.curPage);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.rootCombox);
			this.Controls.Add(this.dataView);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size(520, 560);
			this.Name = "ModelFieldSubForm";
			this.Text = "关系数据编辑";
			((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exermon_managerDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.curPage.ResumeLayout(false);
			this.curPage.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dimension)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Core.Controls.ExermonDataGridView dataView;
		private System.Windows.Forms.ComboBox rootCombox;
		private System.Windows.Forms.Label label1;
		private exermon_managerDataSet exermon_managerDataSet;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.BindingSource bindingSource;
		private System.Windows.Forms.GroupBox curPage;
		private Core.Controls.ExermonTextBox keyName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private Core.Controls.ExermonCheckBox autoConvert;
		private Core.Controls.ExermonCheckBox autoLoad;
		private Core.Controls.ExermonTextBox format;
		private System.Windows.Forms.Label label3;
		private Core.Controls.ExermonCheckBox protectedSet;
		private Core.Controls.ExermonCheckBox defaultNew;
		private Core.Controls.ExermonTextBox fDefault;
		private System.Windows.Forms.Label label4;
		private Core.Controls.ExermonCheckBox useList;
		private Core.Controls.ExermonComboBox fType;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.LinkLabel dateTimeType;
		private System.Windows.Forms.Label label9;
		private Core.Controls.ExermonNumericUpDown dimension;
		private System.Windows.Forms.LinkLabel intType;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.LinkLabel strType;
		private System.Windows.Forms.LinkLabel doubleType;
		private System.Windows.Forms.LinkLabel boolType;
		private Core.Controls.ExermonTextBox description;
		private System.Windows.Forms.Label label6;
		private Core.Controls.ExermonTextBox name;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox fCode;
		private System.Windows.Forms.Label label10;
		private Core.Controls.ExermonTextBox exerEntityTextBox1;
		private System.Windows.Forms.Label label11;
	}
}