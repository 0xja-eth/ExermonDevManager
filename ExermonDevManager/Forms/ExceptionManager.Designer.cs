namespace ExermonDevManager.Forms {
	partial class ExceptionManager {
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
			this.save = new System.Windows.Forms.Button();
			this.curPage = new System.Windows.Forms.GroupBox();
			this.alertText = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.bModule = new ExermonDevManager.Scripts.Controls.ExerComboBox();
			this.moveDown = new System.Windows.Forms.Button();
			this.moveUp = new System.Windows.Forms.Button();
			this.copy = new System.Windows.Forms.Button();
			this.delete = new System.Windows.Forms.Button();
			this.description = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.name = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.create = new System.Windows.Forms.Button();
			this.itemList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.label5 = new System.Windows.Forms.Label();
			this.code = new ExermonDevManager.Scripts.Controls.ExerNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.codePreview = new System.Windows.Forms.Button();
			this.autoCode = new System.Windows.Forms.LinkLabel();
			this.curPage.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.code)).BeginInit();
			this.SuspendLayout();
			// 
			// save
			// 
			this.save.Location = new System.Drawing.Point(13, 300);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(179, 23);
			this.save.TabIndex = 88;
			this.save.Text = "保存";
			this.save.UseVisualStyleBackColor = true;
			// 
			// curPage
			// 
			this.curPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.curPage.Controls.Add(this.autoCode);
			this.curPage.Controls.Add(this.codePreview);
			this.curPage.Controls.Add(this.code);
			this.curPage.Controls.Add(this.label1);
			this.curPage.Controls.Add(this.alertText);
			this.curPage.Controls.Add(this.label2);
			this.curPage.Controls.Add(this.groupBox3);
			this.curPage.Controls.Add(this.moveDown);
			this.curPage.Controls.Add(this.moveUp);
			this.curPage.Controls.Add(this.copy);
			this.curPage.Controls.Add(this.delete);
			this.curPage.Controls.Add(this.description);
			this.curPage.Controls.Add(this.label6);
			this.curPage.Controls.Add(this.name);
			this.curPage.Controls.Add(this.label7);
			this.curPage.Location = new System.Drawing.Point(198, 10);
			this.curPage.Name = "curPage";
			this.curPage.Size = new System.Drawing.Size(262, 313);
			this.curPage.TabIndex = 86;
			this.curPage.TabStop = false;
			this.curPage.Text = "编辑页";
			// 
			// alertText
			// 
			this.alertText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.alertText.Location = new System.Drawing.Point(46, 126);
			this.alertText.Multiline = true;
			this.alertText.Name = "alertText";
			this.alertText.Size = new System.Drawing.Size(201, 47);
			this.alertText.TabIndex = 1003;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 129);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 24);
			this.label2.TabIndex = 1005;
			this.label2.Text = "前端\r\n提示";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.bModule);
			this.groupBox3.Location = new System.Drawing.Point(13, 179);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(187, 54);
			this.groupBox3.TabIndex = 100;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "后台配置";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(6, 25);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(53, 12);
			this.label15.TabIndex = 26;
			this.label15.Text = "处理模块";
			// 
			// bModule
			// 
			this.bModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.bModule.FormattingEnabled = true;
			this.bModule.Location = new System.Drawing.Point(65, 22);
			this.bModule.Name = "bModule";
			this.bModule.SelectedData = null;
			this.bModule.SelectedDataId = -1;
			this.bModule.Size = new System.Drawing.Size(107, 20);
			this.bModule.TabIndex = 1004;
			// 
			// moveDown
			// 
			this.moveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.moveDown.Location = new System.Drawing.Point(13, 284);
			this.moveDown.Name = "moveDown";
			this.moveDown.Size = new System.Drawing.Size(73, 23);
			this.moveDown.TabIndex = 74;
			this.moveDown.Text = "下移";
			this.moveDown.UseVisualStyleBackColor = true;
			// 
			// moveUp
			// 
			this.moveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.moveUp.Location = new System.Drawing.Point(13, 255);
			this.moveUp.Name = "moveUp";
			this.moveUp.Size = new System.Drawing.Size(73, 23);
			this.moveUp.TabIndex = 73;
			this.moveUp.Text = "上移";
			this.moveUp.UseVisualStyleBackColor = true;
			// 
			// copy
			// 
			this.copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.copy.Location = new System.Drawing.Point(92, 255);
			this.copy.Name = "copy";
			this.copy.Size = new System.Drawing.Size(73, 23);
			this.copy.TabIndex = 72;
			this.copy.Text = "复制";
			this.copy.UseVisualStyleBackColor = true;
			// 
			// delete
			// 
			this.delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.delete.Location = new System.Drawing.Point(92, 284);
			this.delete.Name = "delete";
			this.delete.Size = new System.Drawing.Size(73, 23);
			this.delete.TabIndex = 71;
			this.delete.Text = "删除";
			this.delete.UseVisualStyleBackColor = true;
			// 
			// description
			// 
			this.description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.description.Location = new System.Drawing.Point(46, 74);
			this.description.Multiline = true;
			this.description.Name = "description";
			this.description.Size = new System.Drawing.Size(201, 46);
			this.description.TabIndex = 1002;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 77);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(29, 12);
			this.label6.TabIndex = 50;
			this.label6.Text = "描述";
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(70, 20);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(130, 21);
			this.name.TabIndex = 1000;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(11, 23);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 12);
			this.label7.TabIndex = 48;
			this.label7.Text = "枚举名称";
			// 
			// create
			// 
			this.create.Location = new System.Drawing.Point(13, 271);
			this.create.Name = "create";
			this.create.Size = new System.Drawing.Size(179, 23);
			this.create.TabIndex = 87;
			this.create.Text = "添加";
			this.create.UseVisualStyleBackColor = true;
			// 
			// itemList
			// 
			this.itemList.HideSelection = false;
			this.itemList.Location = new System.Drawing.Point(13, 35);
			this.itemList.MultiSelect = false;
			this.itemList.Name = "itemList";
			this.itemList.Size = new System.Drawing.Size(179, 230);
			this.itemList.TabIndex = 84;
			this.itemList.UseCompatibleStateImageBehavior = false;
			this.itemList.View = System.Windows.Forms.View.Tile;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.SystemColors.Control;
			this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(11, 10);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(179, 22);
			this.label5.TabIndex = 85;
			this.label5.Text = "异常列表";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// code
			// 
			this.code.Location = new System.Drawing.Point(70, 47);
			this.code.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.code.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
			this.code.Name = "code";
			this.code.Size = new System.Drawing.Size(60, 21);
			this.code.TabIndex = 1007;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 1006;
			this.label1.Text = "枚举值";
			// 
			// codePreview
			// 
			this.codePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.codePreview.Location = new System.Drawing.Point(183, 284);
			this.codePreview.Name = "codePreview";
			this.codePreview.Size = new System.Drawing.Size(73, 23);
			this.codePreview.TabIndex = 1008;
			this.codePreview.Text = "代码预览";
			this.codePreview.UseVisualStyleBackColor = true;
			this.codePreview.Click += new System.EventHandler(this.codePreview_Click);
			// 
			// autoCode
			// 
			this.autoCode.AutoSize = true;
			this.autoCode.Location = new System.Drawing.Point(147, 49);
			this.autoCode.Name = "autoCode";
			this.autoCode.Size = new System.Drawing.Size(53, 12);
			this.autoCode.TabIndex = 1009;
			this.autoCode.TabStop = true;
			this.autoCode.Text = "自动编号";
			this.autoCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.autoCode_LinkClicked);
			// 
			// ExceptionManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(472, 335);
			this.Controls.Add(this.save);
			this.Controls.Add(this.curPage);
			this.Controls.Add(this.create);
			this.Controls.Add(this.itemList);
			this.Controls.Add(this.label5);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximumSize = new System.Drawing.Size(615, 374);
			this.MinimumSize = new System.Drawing.Size(488, 374);
			this.Name = "ExceptionManager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "异常管理";
			this.curPage.ResumeLayout(false);
			this.curPage.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.code)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button save;
		private System.Windows.Forms.GroupBox curPage;
		private System.Windows.Forms.Button moveDown;
		private System.Windows.Forms.Button moveUp;
		private System.Windows.Forms.Button copy;
		private System.Windows.Forms.Button delete;
		private ExermonDevManager.Scripts.Controls.ExerTextBox description;
		private System.Windows.Forms.Label label6;
		private ExermonDevManager.Scripts.Controls.ExerTextBox name;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button create;
		private ExermonDevManager.Scripts.Controls.ExerListView itemList;
		private System.Windows.Forms.Label label5;
		private ExermonDevManager.Scripts.Controls.ExerTextBox alertText;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label15;
		private ExermonDevManager.Scripts.Controls.ExerComboBox bModule;
		private System.Windows.Forms.Button codePreview;
		private Scripts.Controls.ExerNumericUpDown code;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel autoCode;
	}
}