namespace ExermonDevManager.Forms {

	using Scripts.Forms;
	using Scripts.Data;

	partial class EmitInterfaceManager {
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
			this.exportCode = new System.Windows.Forms.Button();
			this.moveDown = new System.Windows.Forms.Button();
			this.moveUp = new System.Windows.Forms.Button();
			this.copy = new System.Windows.Forms.Button();
			this.delete = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.bModule = new ExermonDevManager.Scripts.Controls.ExerComboBox();
			this.itemList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.clearParams = new System.Windows.Forms.Button();
			this.editParams = new System.Windows.Forms.Button();
			this.paramList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.route = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.description = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.name = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.curPage = new System.Windows.Forms.GroupBox();
			this.create = new System.Windows.Forms.Button();
			this.save = new System.Windows.Forms.Button();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.curPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// exportCode
			// 
			this.exportCode.Location = new System.Drawing.Point(301, 362);
			this.exportCode.Name = "exportCode";
			this.exportCode.Size = new System.Drawing.Size(205, 24);
			this.exportCode.TabIndex = 70;
			this.exportCode.Text = "导出单项代码";
			this.exportCode.UseVisualStyleBackColor = true;
			// 
			// moveDown
			// 
			this.moveDown.Location = new System.Drawing.Point(301, 513);
			this.moveDown.Name = "moveDown";
			this.moveDown.Size = new System.Drawing.Size(73, 23);
			this.moveDown.TabIndex = 69;
			this.moveDown.Text = "下移";
			this.moveDown.UseVisualStyleBackColor = true;
			// 
			// moveUp
			// 
			this.moveUp.Location = new System.Drawing.Point(301, 484);
			this.moveUp.Name = "moveUp";
			this.moveUp.Size = new System.Drawing.Size(73, 23);
			this.moveUp.TabIndex = 68;
			this.moveUp.Text = "上移";
			this.moveUp.UseVisualStyleBackColor = true;
			// 
			// copy
			// 
			this.copy.Location = new System.Drawing.Point(433, 484);
			this.copy.Name = "copy";
			this.copy.Size = new System.Drawing.Size(73, 23);
			this.copy.TabIndex = 64;
			this.copy.Text = "复制";
			this.copy.UseVisualStyleBackColor = true;
			// 
			// delete
			// 
			this.delete.Location = new System.Drawing.Point(433, 513);
			this.delete.Name = "delete";
			this.delete.Size = new System.Drawing.Size(73, 23);
			this.delete.TabIndex = 63;
			this.delete.Text = "删除";
			this.delete.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Location = new System.Drawing.Point(301, 256);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(205, 100);
			this.groupBox4.TabIndex = 66;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "前端配置";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.bModule);
			this.groupBox3.Location = new System.Drawing.Point(301, 135);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(205, 115);
			this.groupBox3.TabIndex = 65;
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
			this.bModule.Location = new System.Drawing.Point(89, 22);
			this.bModule.Name = "bModule";
			this.bModule.Size = new System.Drawing.Size(107, 20);
			this.bModule.TabIndex = 1006;
			// 
			// itemList
			// 
			this.itemList.HideSelection = false;
			this.itemList.Location = new System.Drawing.Point(12, 34);
			this.itemList.MultiSelect = false;
			this.itemList.Name = "itemList";
			this.itemList.Size = new System.Drawing.Size(179, 464);
			this.itemList.TabIndex = 54;
			this.itemList.UseCompatibleStateImageBehavior = false;
			this.itemList.View = System.Windows.Forms.View.Tile;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.clearParams);
			this.groupBox1.Controls.Add(this.editParams);
			this.groupBox1.Controls.Add(this.paramList);
			this.groupBox1.Location = new System.Drawing.Point(13, 135);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(282, 401);
			this.groupBox1.TabIndex = 62;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "发射数据";
			// 
			// clearParams
			// 
			this.clearParams.Location = new System.Drawing.Point(85, 20);
			this.clearParams.Name = "clearParams";
			this.clearParams.Size = new System.Drawing.Size(73, 23);
			this.clearParams.TabIndex = 44;
			this.clearParams.Text = "清空";
			this.clearParams.UseVisualStyleBackColor = true;
			this.clearParams.Click += new System.EventHandler(this.clearReqParams_Click);
			// 
			// editParams
			// 
			this.editParams.Location = new System.Drawing.Point(6, 20);
			this.editParams.Name = "editParams";
			this.editParams.Size = new System.Drawing.Size(73, 23);
			this.editParams.TabIndex = 1004;
			this.editParams.Text = "修改";
			this.editParams.UseVisualStyleBackColor = true;
			this.editParams.Click += new System.EventHandler(this.editReqParams_Click);
			// 
			// paramList
			// 
			this.paramList.HideSelection = false;
			this.paramList.Location = new System.Drawing.Point(6, 49);
			this.paramList.MultiSelect = false;
			this.paramList.Name = "paramList";
			this.paramList.Size = new System.Drawing.Size(270, 346);
			this.paramList.TabIndex = 2;
			this.paramList.UseCompatibleStateImageBehavior = false;
			this.paramList.View = System.Windows.Forms.View.Details;
			this.paramList.SelectedIndexChanged += new System.EventHandler(this.paramList_SelectedIndexChanged);
			this.paramList.DoubleClick += new System.EventHandler(this.paramList_DoubleClick);
			// 
			// route
			// 
			this.route.Location = new System.Drawing.Point(230, 20);
			this.route.Name = "route";
			this.route.Size = new System.Drawing.Size(276, 21);
			this.route.TabIndex = 1001;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(195, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 12);
			this.label4.TabIndex = 60;
			this.label4.Text = "类型";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.SystemColors.Control;
			this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(179, 22);
			this.label3.TabIndex = 59;
			this.label3.Text = "接口列表";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// description
			// 
			this.description.Location = new System.Drawing.Point(46, 47);
			this.description.Multiline = true;
			this.description.Name = "description";
			this.description.Size = new System.Drawing.Size(460, 82);
			this.description.TabIndex = 1002;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 57;
			this.label2.Text = "描述";
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(46, 20);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(143, 21);
			this.name.TabIndex = 1000;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 55;
			this.label1.Text = "名称";
			// 
			// curPage
			// 
			this.curPage.Controls.Add(this.exportCode);
			this.curPage.Controls.Add(this.moveDown);
			this.curPage.Controls.Add(this.moveUp);
			this.curPage.Controls.Add(this.copy);
			this.curPage.Controls.Add(this.delete);
			this.curPage.Controls.Add(this.groupBox4);
			this.curPage.Controls.Add(this.groupBox3);
			this.curPage.Controls.Add(this.groupBox1);
			this.curPage.Controls.Add(this.route);
			this.curPage.Controls.Add(this.label4);
			this.curPage.Controls.Add(this.description);
			this.curPage.Controls.Add(this.label2);
			this.curPage.Controls.Add(this.name);
			this.curPage.Controls.Add(this.label1);
			this.curPage.Location = new System.Drawing.Point(197, 9);
			this.curPage.Name = "curPage";
			this.curPage.Size = new System.Drawing.Size(518, 547);
			this.curPage.TabIndex = 71;
			this.curPage.TabStop = false;
			this.curPage.Text = "编辑页";
			// 
			// create
			// 
			this.create.Location = new System.Drawing.Point(12, 504);
			this.create.Name = "create";
			this.create.Size = new System.Drawing.Size(179, 23);
			this.create.TabIndex = 45;
			this.create.Text = "添加";
			this.create.UseVisualStyleBackColor = true;
			// 
			// save
			// 
			this.save.Location = new System.Drawing.Point(12, 533);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(179, 23);
			this.save.TabIndex = 72;
			this.save.Text = "保存";
			this.save.UseVisualStyleBackColor = true;
			// 
			// EmitInterfaceManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(729, 568);
			this.Controls.Add(this.save);
			this.Controls.Add(this.create);
			this.Controls.Add(this.curPage);
			this.Controls.Add(this.itemList);
			this.Controls.Add(this.label3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximumSize = new System.Drawing.Size(745, 607);
			this.MinimumSize = new System.Drawing.Size(745, 607);
			this.Name = "EmitInterfaceManager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "发射接口管理";
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.curPage.ResumeLayout(false);
			this.curPage.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button exportCode;
		private System.Windows.Forms.Button moveDown;
		private System.Windows.Forms.Button moveUp;
		private System.Windows.Forms.Button copy;
		private System.Windows.Forms.Button delete;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label15;
		private ExermonDevManager.Scripts.Controls.ExerComboBox bModule;
		private ExermonDevManager.Scripts.Controls.ExerListView itemList;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button clearParams;
		private System.Windows.Forms.Button editParams;
		private ExermonDevManager.Scripts.Controls.ExerListView paramList;
		private ExermonDevManager.Scripts.Controls.ExerTextBox route;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private ExermonDevManager.Scripts.Controls.ExerTextBox description;
		private System.Windows.Forms.Label label2;
		private ExermonDevManager.Scripts.Controls.ExerTextBox name;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox curPage;
		private System.Windows.Forms.Button create;
		private System.Windows.Forms.Button save;
	}
}