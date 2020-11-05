namespace ExermonDevManager.Forms {
	partial class ModelManager {
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
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.genGroupData = new System.Windows.Forms.Button();
			this.editTypeSettings = new System.Windows.Forms.Button();
			this.showParent = new System.Windows.Forms.CheckBox();
			this.clearParams = new System.Windows.Forms.Button();
			this.editParams = new System.Windows.Forms.Button();
			this.paramList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.code = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.description = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.name = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.itemList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.label5 = new System.Windows.Forms.Label();
			this.moveDown = new System.Windows.Forms.Button();
			this.moveUp = new System.Windows.Forms.Button();
			this.copy = new System.Windows.Forms.Button();
			this.delete = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.inheritClasses = new System.Windows.Forms.TextBox();
			this.editInherit = new System.Windows.Forms.Button();
			this.deriveClasses = new System.Windows.Forms.TextBox();
			this.derivable = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.curPage = new System.Windows.Forms.GroupBox();
			this.codePreview = new System.Windows.Forms.Button();
			this.keyName = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.abstract_ = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.isBackend = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.isFrontend = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.label15 = new System.Windows.Forms.Label();
			this.module = new ExermonDevManager.Scripts.Controls.ExerComboBox();
			this.create = new System.Windows.Forms.Button();
			this.save = new System.Windows.Forms.Button();
			this.groupBox5.SuspendLayout();
			this.curPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.genGroupData);
			this.groupBox5.Controls.Add(this.editTypeSettings);
			this.groupBox5.Controls.Add(this.showParent);
			this.groupBox5.Controls.Add(this.clearParams);
			this.groupBox5.Controls.Add(this.editParams);
			this.groupBox5.Controls.Add(this.paramList);
			this.groupBox5.Location = new System.Drawing.Point(13, 248);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(422, 264);
			this.groupBox5.TabIndex = 54;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "属性列表";
			// 
			// genGroupData
			// 
			this.genGroupData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.genGroupData.Location = new System.Drawing.Point(277, 49);
			this.genGroupData.Name = "genGroupData";
			this.genGroupData.Size = new System.Drawing.Size(139, 23);
			this.genGroupData.TabIndex = 1012;
			this.genGroupData.Text = "生成组合数据";
			this.genGroupData.UseVisualStyleBackColor = true;
			// 
			// editTypeSettings
			// 
			this.editTypeSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.editTypeSettings.Location = new System.Drawing.Point(277, 20);
			this.editTypeSettings.Name = "editTypeSettings";
			this.editTypeSettings.Size = new System.Drawing.Size(139, 23);
			this.editTypeSettings.TabIndex = 1007;
			this.editTypeSettings.Text = "修改数据转化设定";
			this.editTypeSettings.UseVisualStyleBackColor = true;
			this.editTypeSettings.Click += new System.EventHandler(this.editTypeSettings_Click);
			// 
			// showParent
			// 
			this.showParent.AutoSize = true;
			this.showParent.Location = new System.Drawing.Point(175, 24);
			this.showParent.Name = "showParent";
			this.showParent.Size = new System.Drawing.Size(96, 16);
			this.showParent.TabIndex = 45;
			this.showParent.Text = "显示父类属性";
			this.showParent.UseVisualStyleBackColor = true;
			this.showParent.CheckedChanged += new System.EventHandler(this.showParent_CheckedChanged);
			// 
			// clearParams
			// 
			this.clearParams.Location = new System.Drawing.Point(85, 20);
			this.clearParams.Name = "clearParams";
			this.clearParams.Size = new System.Drawing.Size(73, 23);
			this.clearParams.TabIndex = 1006;
			this.clearParams.Text = "清空";
			this.clearParams.UseVisualStyleBackColor = true;
			this.clearParams.Click += new System.EventHandler(this.clearParams_Click);
			// 
			// editParams
			// 
			this.editParams.Location = new System.Drawing.Point(6, 20);
			this.editParams.Name = "editParams";
			this.editParams.Size = new System.Drawing.Size(73, 23);
			this.editParams.TabIndex = 1005;
			this.editParams.Text = "修改";
			this.editParams.UseVisualStyleBackColor = true;
			this.editParams.Click += new System.EventHandler(this.editParams_Click);
			// 
			// paramList
			// 
			this.paramList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.paramList.HideSelection = false;
			this.paramList.Location = new System.Drawing.Point(6, 78);
			this.paramList.MultiSelect = false;
			this.paramList.Name = "paramList";
			this.paramList.Size = new System.Drawing.Size(410, 180);
			this.paramList.TabIndex = 2;
			this.paramList.UseCompatibleStateImageBehavior = false;
			this.paramList.View = System.Windows.Forms.View.Details;
			// 
			// code
			// 
			this.code.Location = new System.Drawing.Point(258, 20);
			this.code.Name = "code";
			this.code.Size = new System.Drawing.Size(143, 21);
			this.code.TabIndex = 1001;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(199, 23);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 12);
			this.label8.TabIndex = 52;
			this.label8.Text = "代码命名";
			// 
			// description
			// 
			this.description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.description.Location = new System.Drawing.Point(46, 47);
			this.description.Multiline = true;
			this.description.Name = "description";
			this.description.Size = new System.Drawing.Size(389, 54);
			this.description.TabIndex = 1002;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 50);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(29, 12);
			this.label6.TabIndex = 50;
			this.label6.Text = "描述";
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(46, 20);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(143, 21);
			this.name.TabIndex = 1000;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(11, 23);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(29, 12);
			this.label7.TabIndex = 48;
			this.label7.Text = "名称";
			// 
			// itemList
			// 
			this.itemList.HideSelection = false;
			this.itemList.Location = new System.Drawing.Point(12, 33);
			this.itemList.MultiSelect = false;
			this.itemList.Name = "itemList";
			this.itemList.Size = new System.Drawing.Size(179, 465);
			this.itemList.TabIndex = 46;
			this.itemList.UseCompatibleStateImageBehavior = false;
			this.itemList.View = System.Windows.Forms.View.Tile;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.SystemColors.Control;
			this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(10, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(179, 22);
			this.label5.TabIndex = 47;
			this.label5.Text = "模型列表";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// moveDown
			// 
			this.moveDown.Location = new System.Drawing.Point(85, 519);
			this.moveDown.Name = "moveDown";
			this.moveDown.Size = new System.Drawing.Size(73, 23);
			this.moveDown.TabIndex = 74;
			this.moveDown.Text = "下移";
			this.moveDown.UseVisualStyleBackColor = true;
			// 
			// moveUp
			// 
			this.moveUp.Location = new System.Drawing.Point(6, 519);
			this.moveUp.Name = "moveUp";
			this.moveUp.Size = new System.Drawing.Size(73, 23);
			this.moveUp.TabIndex = 73;
			this.moveUp.Text = "上移";
			this.moveUp.UseVisualStyleBackColor = true;
			// 
			// copy
			// 
			this.copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.copy.Location = new System.Drawing.Point(283, 519);
			this.copy.Name = "copy";
			this.copy.Size = new System.Drawing.Size(73, 23);
			this.copy.TabIndex = 72;
			this.copy.Text = "复制";
			this.copy.UseVisualStyleBackColor = true;
			// 
			// delete
			// 
			this.delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.delete.Location = new System.Drawing.Point(362, 519);
			this.delete.Name = "delete";
			this.delete.Size = new System.Drawing.Size(73, 23);
			this.delete.TabIndex = 71;
			this.delete.Text = "删除";
			this.delete.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 163);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 76;
			this.label1.Text = "继承的类";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 194);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 77;
			this.label2.Text = "派生的类";
			// 
			// inheritClasses
			// 
			this.inheritClasses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.inheritClasses.Location = new System.Drawing.Point(70, 160);
			this.inheritClasses.Name = "inheritClasses";
			this.inheritClasses.ReadOnly = true;
			this.inheritClasses.Size = new System.Drawing.Size(287, 21);
			this.inheritClasses.TabIndex = 78;
			// 
			// editInherit
			// 
			this.editInherit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.editInherit.Location = new System.Drawing.Point(362, 158);
			this.editInherit.Name = "editInherit";
			this.editInherit.Size = new System.Drawing.Size(73, 23);
			this.editInherit.TabIndex = 1003;
			this.editInherit.Text = "编辑";
			this.editInherit.UseVisualStyleBackColor = true;
			this.editInherit.Click += new System.EventHandler(this.editInherit_Click);
			// 
			// deriveClasses
			// 
			this.deriveClasses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.deriveClasses.Location = new System.Drawing.Point(70, 191);
			this.deriveClasses.Multiline = true;
			this.deriveClasses.Name = "deriveClasses";
			this.deriveClasses.ReadOnly = true;
			this.deriveClasses.Size = new System.Drawing.Size(287, 51);
			this.deriveClasses.TabIndex = 79;
			// 
			// derivable
			// 
			this.derivable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.derivable.AutoSize = true;
			this.derivable.Location = new System.Drawing.Point(363, 193);
			this.derivable.Name = "derivable";
			this.derivable.Size = new System.Drawing.Size(72, 16);
			this.derivable.TabIndex = 1004;
			this.derivable.Text = "可被继承";
			this.derivable.UseVisualStyleBackColor = true;
			// 
			// curPage
			// 
			this.curPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.curPage.Controls.Add(this.codePreview);
			this.curPage.Controls.Add(this.keyName);
			this.curPage.Controls.Add(this.label3);
			this.curPage.Controls.Add(this.abstract_);
			this.curPage.Controls.Add(this.isBackend);
			this.curPage.Controls.Add(this.isFrontend);
			this.curPage.Controls.Add(this.label15);
			this.curPage.Controls.Add(this.module);
			this.curPage.Controls.Add(this.derivable);
			this.curPage.Controls.Add(this.deriveClasses);
			this.curPage.Controls.Add(this.editInherit);
			this.curPage.Controls.Add(this.inheritClasses);
			this.curPage.Controls.Add(this.label2);
			this.curPage.Controls.Add(this.label1);
			this.curPage.Controls.Add(this.moveDown);
			this.curPage.Controls.Add(this.moveUp);
			this.curPage.Controls.Add(this.copy);
			this.curPage.Controls.Add(this.delete);
			this.curPage.Controls.Add(this.groupBox5);
			this.curPage.Controls.Add(this.code);
			this.curPage.Controls.Add(this.label8);
			this.curPage.Controls.Add(this.description);
			this.curPage.Controls.Add(this.label6);
			this.curPage.Controls.Add(this.name);
			this.curPage.Controls.Add(this.label7);
			this.curPage.Location = new System.Drawing.Point(197, 8);
			this.curPage.Name = "curPage";
			this.curPage.Size = new System.Drawing.Size(450, 548);
			this.curPage.TabIndex = 81;
			this.curPage.TabStop = false;
			this.curPage.Text = "编辑页";
			// 
			// codePreview
			// 
			this.codePreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.codePreview.Location = new System.Drawing.Point(164, 519);
			this.codePreview.Name = "codePreview";
			this.codePreview.Size = new System.Drawing.Size(113, 23);
			this.codePreview.TabIndex = 1012;
			this.codePreview.Text = "代码预览";
			this.codePreview.UseVisualStyleBackColor = true;
			this.codePreview.Click += new System.EventHandler(this.codePreview_Click);
			// 
			// keyName
			// 
			this.keyName.Location = new System.Drawing.Point(154, 133);
			this.keyName.Name = "keyName";
			this.keyName.Size = new System.Drawing.Size(106, 21);
			this.keyName.TabIndex = 1011;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 136);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(137, 12);
			this.label3.TabIndex = 1010;
			this.label3.Text = "关系键名（后台，可选）";
			// 
			// abstract_
			// 
			this.abstract_.AutoSize = true;
			this.abstract_.Location = new System.Drawing.Point(344, 109);
			this.abstract_.Name = "abstract_";
			this.abstract_.Size = new System.Drawing.Size(60, 16);
			this.abstract_.TabIndex = 1009;
			this.abstract_.Text = "抽象类";
			this.abstract_.UseVisualStyleBackColor = true;
			// 
			// isBackend
			// 
			this.isBackend.AutoSize = true;
			this.isBackend.Location = new System.Drawing.Point(266, 109);
			this.isBackend.Name = "isBackend";
			this.isBackend.Size = new System.Drawing.Size(72, 16);
			this.isBackend.TabIndex = 1008;
			this.isBackend.Text = "后端可用";
			this.isBackend.UseVisualStyleBackColor = true;
			// 
			// isFrontend
			// 
			this.isFrontend.AutoSize = true;
			this.isFrontend.Location = new System.Drawing.Point(188, 109);
			this.isFrontend.Name = "isFrontend";
			this.isFrontend.Size = new System.Drawing.Size(72, 16);
			this.isFrontend.TabIndex = 1007;
			this.isFrontend.Text = "前端可用";
			this.isFrontend.UseVisualStyleBackColor = true;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(11, 110);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(53, 12);
			this.label15.TabIndex = 26;
			this.label15.Text = "所属模块";
			// 
			// module
			// 
			this.module.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.module.FormattingEnabled = true;
			this.module.Location = new System.Drawing.Point(70, 107);
			this.module.Name = "module";
			this.module.SelectedData = null;
			this.module.SelectedDataId = -1;
			this.module.Size = new System.Drawing.Size(108, 20);
			this.module.TabIndex = 1006;
			// 
			// create
			// 
			this.create.Location = new System.Drawing.Point(12, 504);
			this.create.Name = "create";
			this.create.Size = new System.Drawing.Size(179, 23);
			this.create.TabIndex = 82;
			this.create.Text = "添加";
			this.create.UseVisualStyleBackColor = true;
			// 
			// save
			// 
			this.save.Location = new System.Drawing.Point(12, 533);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(179, 23);
			this.save.TabIndex = 83;
			this.save.Text = "保存";
			this.save.UseVisualStyleBackColor = true;
			// 
			// ModelManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(659, 568);
			this.Controls.Add(this.save);
			this.Controls.Add(this.create);
			this.Controls.Add(this.curPage);
			this.Controls.Add(this.itemList);
			this.Controls.Add(this.label5);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximumSize = new System.Drawing.Size(9999, 607);
			this.MinimumSize = new System.Drawing.Size(675, 607);
			this.Name = "ModelManager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "模型管理";
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.curPage.ResumeLayout(false);
			this.curPage.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button clearParams;
		private System.Windows.Forms.Button editParams;
		private ExermonDevManager.Scripts.Controls.ExerListView paramList;
		private ExermonDevManager.Scripts.Controls.ExerTextBox code;
		private System.Windows.Forms.Label label8;
		private ExermonDevManager.Scripts.Controls.ExerTextBox description;
		private System.Windows.Forms.Label label6;
		private ExermonDevManager.Scripts.Controls.ExerTextBox name;
		private System.Windows.Forms.Label label7;
		private ExermonDevManager.Scripts.Controls.ExerListView itemList;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button moveDown;
		private System.Windows.Forms.Button moveUp;
		private System.Windows.Forms.Button copy;
		private System.Windows.Forms.Button delete;
		private System.Windows.Forms.CheckBox showParent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox inheritClasses;
		private System.Windows.Forms.Button editInherit;
		private System.Windows.Forms.TextBox deriveClasses;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox derivable;
		private System.Windows.Forms.GroupBox curPage;
		private System.Windows.Forms.Button create;
		private System.Windows.Forms.Button save;
		private System.Windows.Forms.Label label15;
		private ExermonDevManager.Scripts.Controls.ExerComboBox module;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox isBackend;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox isFrontend;
		private System.Windows.Forms.Button editTypeSettings;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox abstract_;
		private Scripts.Controls.ExerTextBox keyName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button genGroupData;
		private System.Windows.Forms.Button codePreview;
	}
}