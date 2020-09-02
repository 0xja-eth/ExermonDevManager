namespace ExermonDevManager.Forms {
	partial class ModuleManager {
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
			this.moveDown = new System.Windows.Forms.Button();
			this.moveUp = new System.Windows.Forms.Button();
			this.copy = new System.Windows.Forms.Button();
			this.delete = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.editEInterfaces = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.eInterfaceList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.editRRInterfaces = new System.Windows.Forms.Button();
			this.rrInterfaceList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.code = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.description = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.name = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.create = new System.Windows.Forms.Button();
			this.itemList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.label5 = new System.Windows.Forms.Label();
			this.curPage.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// save
			// 
			this.save.Location = new System.Drawing.Point(13, 535);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(179, 23);
			this.save.TabIndex = 88;
			this.save.Text = "保存";
			this.save.UseVisualStyleBackColor = true;
			// 
			// curPage
			// 
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
			this.curPage.Location = new System.Drawing.Point(198, 10);
			this.curPage.Name = "curPage";
			this.curPage.Size = new System.Drawing.Size(520, 548);
			this.curPage.TabIndex = 86;
			this.curPage.TabStop = false;
			this.curPage.Text = "编辑页";
			// 
			// moveDown
			// 
			this.moveDown.Location = new System.Drawing.Point(92, 519);
			this.moveDown.Name = "moveDown";
			this.moveDown.Size = new System.Drawing.Size(73, 23);
			this.moveDown.TabIndex = 74;
			this.moveDown.Text = "下移";
			this.moveDown.UseVisualStyleBackColor = true;
			// 
			// moveUp
			// 
			this.moveUp.Location = new System.Drawing.Point(13, 519);
			this.moveUp.Name = "moveUp";
			this.moveUp.Size = new System.Drawing.Size(73, 23);
			this.moveUp.TabIndex = 73;
			this.moveUp.Text = "上移";
			this.moveUp.UseVisualStyleBackColor = true;
			// 
			// copy
			// 
			this.copy.Location = new System.Drawing.Point(356, 519);
			this.copy.Name = "copy";
			this.copy.Size = new System.Drawing.Size(73, 23);
			this.copy.TabIndex = 72;
			this.copy.Text = "复制";
			this.copy.UseVisualStyleBackColor = true;
			// 
			// delete
			// 
			this.delete.Location = new System.Drawing.Point(435, 519);
			this.delete.Name = "delete";
			this.delete.Size = new System.Drawing.Size(73, 23);
			this.delete.TabIndex = 71;
			this.delete.Text = "删除";
			this.delete.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.editEInterfaces);
			this.groupBox5.Controls.Add(this.label2);
			this.groupBox5.Controls.Add(this.label1);
			this.groupBox5.Controls.Add(this.eInterfaceList);
			this.groupBox5.Controls.Add(this.editRRInterfaces);
			this.groupBox5.Controls.Add(this.rrInterfaceList);
			this.groupBox5.Location = new System.Drawing.Point(13, 160);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(495, 353);
			this.groupBox5.TabIndex = 54;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "接口列表";
			// 
			// editEInterfaces
			// 
			this.editEInterfaces.Location = new System.Drawing.Point(95, 195);
			this.editEInterfaces.Name = "editEInterfaces";
			this.editEInterfaces.Size = new System.Drawing.Size(73, 23);
			this.editEInterfaces.TabIndex = 1007;
			this.editEInterfaces.Text = "编辑";
			this.editEInterfaces.UseVisualStyleBackColor = true;
			this.editEInterfaces.Click += new System.EventHandler(this.editEInterfaces_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 200);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 1006;
			this.label2.Text = "发射接口";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 12);
			this.label1.TabIndex = 1005;
			this.label1.Text = "请求-响应接口";
			// 
			// eInterfaceList
			// 
			this.eInterfaceList.HideSelection = false;
			this.eInterfaceList.Location = new System.Drawing.Point(6, 224);
			this.eInterfaceList.MultiSelect = false;
			this.eInterfaceList.Name = "eInterfaceList";
			this.eInterfaceList.Size = new System.Drawing.Size(483, 123);
			this.eInterfaceList.TabIndex = 1004;
			this.eInterfaceList.UseCompatibleStateImageBehavior = false;
			this.eInterfaceList.View = System.Windows.Forms.View.Details;
			this.eInterfaceList.SelectedIndexChanged += new System.EventHandler(this.eInterfaceList_SelectedIndexChanged);
			this.eInterfaceList.DoubleClick += new System.EventHandler(this.eInterfaceList_DoubleClick);
			// 
			// editRRInterfaces
			// 
			this.editRRInterfaces.Location = new System.Drawing.Point(95, 20);
			this.editRRInterfaces.Name = "editRRInterfaces";
			this.editRRInterfaces.Size = new System.Drawing.Size(73, 23);
			this.editRRInterfaces.TabIndex = 1003;
			this.editRRInterfaces.Text = "编辑";
			this.editRRInterfaces.UseVisualStyleBackColor = true;
			this.editRRInterfaces.Click += new System.EventHandler(this.editRRInterfaces_Click);
			// 
			// rrInterfaceList
			// 
			this.rrInterfaceList.HideSelection = false;
			this.rrInterfaceList.Location = new System.Drawing.Point(6, 49);
			this.rrInterfaceList.MultiSelect = false;
			this.rrInterfaceList.Name = "rrInterfaceList";
			this.rrInterfaceList.Size = new System.Drawing.Size(483, 140);
			this.rrInterfaceList.TabIndex = 2;
			this.rrInterfaceList.UseCompatibleStateImageBehavior = false;
			this.rrInterfaceList.View = System.Windows.Forms.View.Details;
			this.rrInterfaceList.SelectedIndexChanged += new System.EventHandler(this.rrInterfaceList_SelectedIndexChanged);
			this.rrInterfaceList.DoubleClick += new System.EventHandler(this.rrInterfaceList_DoubleClick);
			// 
			// code
			// 
			this.code.Location = new System.Drawing.Point(258, 20);
			this.code.Name = "code";
			this.code.Size = new System.Drawing.Size(250, 21);
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
			this.description.Location = new System.Drawing.Point(46, 47);
			this.description.Multiline = true;
			this.description.Name = "description";
			this.description.Size = new System.Drawing.Size(462, 107);
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
			// create
			// 
			this.create.Location = new System.Drawing.Point(13, 506);
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
			this.itemList.Size = new System.Drawing.Size(179, 465);
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
			this.label5.Text = "模块列表";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ModuleManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(729, 568);
			this.Controls.Add(this.save);
			this.Controls.Add(this.curPage);
			this.Controls.Add(this.create);
			this.Controls.Add(this.itemList);
			this.Controls.Add(this.label5);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximumSize = new System.Drawing.Size(745, 607);
			this.MinimumSize = new System.Drawing.Size(745, 607);
			this.Name = "ModuleManager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "模块管理";
			this.curPage.ResumeLayout(false);
			this.curPage.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button save;
		private System.Windows.Forms.GroupBox curPage;
		private System.Windows.Forms.Button moveDown;
		private System.Windows.Forms.Button moveUp;
		private System.Windows.Forms.Button copy;
		private System.Windows.Forms.Button delete;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button editRRInterfaces;
		private ExermonDevManager.Scripts.Controls.ExerListView rrInterfaceList;
		private ExermonDevManager.Scripts.Controls.ExerTextBox code;
		private System.Windows.Forms.Label label8;
		private ExermonDevManager.Scripts.Controls.ExerTextBox description;
		private System.Windows.Forms.Label label6;
		private ExermonDevManager.Scripts.Controls.ExerTextBox name;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button create;
		private ExermonDevManager.Scripts.Controls.ExerListView itemList;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button editEInterfaces;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private ExermonDevManager.Scripts.Controls.ExerListView eInterfaceList;
	}
}