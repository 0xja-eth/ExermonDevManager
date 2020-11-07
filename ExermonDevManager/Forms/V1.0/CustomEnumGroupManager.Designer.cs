namespace ExermonDevManager.Forms {
	partial class CustomEnumGroupManager {
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
			this.isBackend = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.isFrontend = new ExermonDevManager.Scripts.Controls.ExerCheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.clearEnums = new System.Windows.Forms.Button();
			this.editEnums = new System.Windows.Forms.Button();
			this.enumList = new ExermonDevManager.Scripts.Controls.ExerListView();
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
			this.curPage.SuspendLayout();
			this.groupBox1.SuspendLayout();
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
			this.curPage.Controls.Add(this.isBackend);
			this.curPage.Controls.Add(this.isFrontend);
			this.curPage.Controls.Add(this.groupBox1);
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
			this.curPage.Size = new System.Drawing.Size(389, 313);
			this.curPage.TabIndex = 86;
			this.curPage.TabStop = false;
			this.curPage.Text = "编辑页";
			// 
			// isBackend
			// 
			this.isBackend.AutoSize = true;
			this.isBackend.Location = new System.Drawing.Point(310, 141);
			this.isBackend.Name = "isBackend";
			this.isBackend.Size = new System.Drawing.Size(72, 16);
			this.isBackend.TabIndex = 1010;
			this.isBackend.Text = "后端可用";
			this.isBackend.UseVisualStyleBackColor = true;
			// 
			// isFrontend
			// 
			this.isFrontend.AutoSize = true;
			this.isFrontend.Location = new System.Drawing.Point(310, 119);
			this.isFrontend.Name = "isFrontend";
			this.isFrontend.Size = new System.Drawing.Size(72, 16);
			this.isFrontend.TabIndex = 1009;
			this.isFrontend.Text = "前端可用";
			this.isFrontend.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.clearEnums);
			this.groupBox1.Controls.Add(this.editEnums);
			this.groupBox1.Controls.Add(this.enumList);
			this.groupBox1.Location = new System.Drawing.Point(6, 119);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(297, 194);
			this.groupBox1.TabIndex = 1003;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "枚举项";
			// 
			// clearEnums
			// 
			this.clearEnums.Location = new System.Drawing.Point(85, 20);
			this.clearEnums.Name = "clearEnums";
			this.clearEnums.Size = new System.Drawing.Size(73, 23);
			this.clearEnums.TabIndex = 44;
			this.clearEnums.Text = "清空";
			this.clearEnums.UseVisualStyleBackColor = true;
			this.clearEnums.Click += new System.EventHandler(this.clearEnums_Click);
			// 
			// editEnums
			// 
			this.editEnums.Location = new System.Drawing.Point(6, 20);
			this.editEnums.Name = "editEnums";
			this.editEnums.Size = new System.Drawing.Size(73, 23);
			this.editEnums.TabIndex = 1004;
			this.editEnums.Text = "修改";
			this.editEnums.UseVisualStyleBackColor = true;
			this.editEnums.Click += new System.EventHandler(this.editEnums_Click);
			// 
			// enumList
			// 
			this.enumList.HideSelection = false;
			this.enumList.Location = new System.Drawing.Point(6, 49);
			this.enumList.MultiSelect = false;
			this.enumList.Name = "enumList";
			this.enumList.Size = new System.Drawing.Size(285, 138);
			this.enumList.TabIndex = 2;
			this.enumList.UseCompatibleStateImageBehavior = false;
			this.enumList.View = System.Windows.Forms.View.Details;
			// 
			// moveDown
			// 
			this.moveDown.Location = new System.Drawing.Point(309, 225);
			this.moveDown.Name = "moveDown";
			this.moveDown.Size = new System.Drawing.Size(73, 23);
			this.moveDown.TabIndex = 74;
			this.moveDown.Text = "下移";
			this.moveDown.UseVisualStyleBackColor = true;
			// 
			// moveUp
			// 
			this.moveUp.Location = new System.Drawing.Point(309, 196);
			this.moveUp.Name = "moveUp";
			this.moveUp.Size = new System.Drawing.Size(73, 23);
			this.moveUp.TabIndex = 73;
			this.moveUp.Text = "上移";
			this.moveUp.UseVisualStyleBackColor = true;
			// 
			// copy
			// 
			this.copy.Location = new System.Drawing.Point(310, 254);
			this.copy.Name = "copy";
			this.copy.Size = new System.Drawing.Size(73, 23);
			this.copy.TabIndex = 72;
			this.copy.Text = "复制";
			this.copy.UseVisualStyleBackColor = true;
			// 
			// delete
			// 
			this.delete.Location = new System.Drawing.Point(310, 283);
			this.delete.Name = "delete";
			this.delete.Size = new System.Drawing.Size(73, 23);
			this.delete.TabIndex = 71;
			this.delete.Text = "删除";
			this.delete.UseVisualStyleBackColor = true;
			// 
			// description
			// 
			this.description.Location = new System.Drawing.Point(46, 47);
			this.description.Multiline = true;
			this.description.Name = "description";
			this.description.Size = new System.Drawing.Size(337, 66);
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
			this.name.Location = new System.Drawing.Point(109, 20);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(273, 21);
			this.name.TabIndex = 1000;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(11, 23);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(101, 12);
			this.label7.TabIndex = 48;
			this.label7.Text = "名称（代码命名）";
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
			this.label5.Text = "枚举列表";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// CustomEnumGroupManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(599, 335);
			this.Controls.Add(this.save);
			this.Controls.Add(this.curPage);
			this.Controls.Add(this.create);
			this.Controls.Add(this.itemList);
			this.Controls.Add(this.label5);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximumSize = new System.Drawing.Size(615, 374);
			this.MinimumSize = new System.Drawing.Size(615, 374);
			this.Name = "CustomEnumGroupManager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "自定义枚举管理";
			this.curPage.ResumeLayout(false);
			this.curPage.PerformLayout();
			this.groupBox1.ResumeLayout(false);
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
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button clearEnums;
		private System.Windows.Forms.Button editEnums;
		private ExermonDevManager.Scripts.Controls.ExerListView enumList;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox isBackend;
		private ExermonDevManager.Scripts.Controls.ExerCheckBox isFrontend;
	}
}