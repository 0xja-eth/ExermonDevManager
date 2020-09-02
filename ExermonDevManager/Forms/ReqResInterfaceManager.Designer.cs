namespace ExermonDevManager.Forms {

	using Scripts.Forms;
	using Scripts.Data;

	partial class ReqResInterfaceManager {
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
			this.moveDown = new System.Windows.Forms.Button();
			this.moveUp = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.clearResParams = new System.Windows.Forms.Button();
			this.editResParams = new System.Windows.Forms.Button();
			this.resParamList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.copy = new System.Windows.Forms.Button();
			this.delete = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label17 = new System.Windows.Forms.Label();
			this.fName = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.bFunc = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.bModule = new ExermonDevManager.Scripts.Controls.ExerComboBox();
			this.bTag = new ExermonDevManager.Scripts.Controls.ExerComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.itemList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.clearReqParams = new System.Windows.Forms.Button();
			this.editReqParams = new System.Windows.Forms.Button();
			this.reqParamList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.route = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.description = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.name = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.curPage = new System.Windows.Forms.GroupBox();
			this.autoFill = new System.Windows.Forms.Button();
			this.create = new System.Windows.Forms.Button();
			this.save = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.curPage.SuspendLayout();
			this.SuspendLayout();
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
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.clearResParams);
			this.groupBox2.Controls.Add(this.editResParams);
			this.groupBox2.Controls.Add(this.resParamList);
			this.groupBox2.Location = new System.Drawing.Point(13, 357);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(282, 182);
			this.groupBox2.TabIndex = 67;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "响应参数";
			// 
			// clearResParams
			// 
			this.clearResParams.Location = new System.Drawing.Point(85, 20);
			this.clearResParams.Name = "clearResParams";
			this.clearResParams.Size = new System.Drawing.Size(73, 23);
			this.clearResParams.TabIndex = 44;
			this.clearResParams.Text = "清空";
			this.clearResParams.UseVisualStyleBackColor = true;
			this.clearResParams.Click += new System.EventHandler(this.clearResParams_Click);
			// 
			// editResParams
			// 
			this.editResParams.Location = new System.Drawing.Point(6, 20);
			this.editResParams.Name = "editResParams";
			this.editResParams.Size = new System.Drawing.Size(73, 23);
			this.editResParams.TabIndex = 1005;
			this.editResParams.Text = "修改";
			this.editResParams.UseVisualStyleBackColor = true;
			this.editResParams.Click += new System.EventHandler(this.editResParams_Click);
			// 
			// resParamList
			// 
			this.resParamList.HideSelection = false;
			this.resParamList.Location = new System.Drawing.Point(6, 49);
			this.resParamList.Name = "resParamList";
			this.resParamList.Size = new System.Drawing.Size(270, 127);
			this.resParamList.TabIndex = 2;
			this.resParamList.UseCompatibleStateImageBehavior = false;
			this.resParamList.View = System.Windows.Forms.View.Details;
			this.resParamList.SelectedIndexChanged += new System.EventHandler(this.resParamList_SelectedIndexChanged);
			this.resParamList.DoubleClick += new System.EventHandler(this.resParamList_DoubleClick);
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
			this.groupBox4.Controls.Add(this.label17);
			this.groupBox4.Controls.Add(this.fName);
			this.groupBox4.Location = new System.Drawing.Point(301, 290);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(205, 100);
			this.groupBox4.TabIndex = 66;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "前端配置";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(6, 26);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(53, 12);
			this.label17.TabIndex = 30;
			this.label17.Text = "接口名称";
			// 
			// fName
			// 
			this.fName.Location = new System.Drawing.Point(89, 23);
			this.fName.Name = "fName";
			this.fName.Size = new System.Drawing.Size(107, 21);
			this.fName.TabIndex = 1009;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.bFunc);
			this.groupBox3.Controls.Add(this.bModule);
			this.groupBox3.Controls.Add(this.bTag);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Location = new System.Drawing.Point(301, 169);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(205, 115);
			this.groupBox3.TabIndex = 65;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "后台配置";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 53);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 12);
			this.label5.TabIndex = 32;
			this.label5.Text = "处理函数";
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
			// bFunc
			// 
			this.bFunc.Location = new System.Drawing.Point(89, 50);
			this.bFunc.Name = "bFunc";
			this.bFunc.Size = new System.Drawing.Size(107, 21);
			this.bFunc.TabIndex = 1007;
			// 
			// bModule
			// 
			this.bModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.bModule.FormattingEnabled = true;
			this.bModule.Location = new System.Drawing.Point(89, 22);
			this.bModule.Name = "bModule";
			this.bModule.SelectedData = null;
			this.bModule.SelectedDataId = -1;
			this.bModule.Size = new System.Drawing.Size(107, 20);
			this.bModule.TabIndex = 1006;
			// 
			// bTag
			// 
			this.bTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.bTag.FormattingEnabled = true;
			this.bTag.Location = new System.Drawing.Point(89, 80);
			this.bTag.Name = "bTag";
			this.bTag.SelectedData = null;
			this.bTag.SelectedDataId = -1;
			this.bTag.Size = new System.Drawing.Size(107, 20);
			this.bTag.TabIndex = 1008;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(6, 83);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(77, 12);
			this.label16.TabIndex = 27;
			this.label16.Text = "Channels标志";
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
			this.groupBox1.Controls.Add(this.clearReqParams);
			this.groupBox1.Controls.Add(this.editReqParams);
			this.groupBox1.Controls.Add(this.reqParamList);
			this.groupBox1.Location = new System.Drawing.Point(13, 169);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(282, 182);
			this.groupBox1.TabIndex = 62;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "请求参数";
			// 
			// clearReqParams
			// 
			this.clearReqParams.Location = new System.Drawing.Point(85, 20);
			this.clearReqParams.Name = "clearReqParams";
			this.clearReqParams.Size = new System.Drawing.Size(73, 23);
			this.clearReqParams.TabIndex = 44;
			this.clearReqParams.Text = "清空";
			this.clearReqParams.UseVisualStyleBackColor = true;
			this.clearReqParams.Click += new System.EventHandler(this.clearReqParams_Click);
			// 
			// editReqParams
			// 
			this.editReqParams.Location = new System.Drawing.Point(6, 20);
			this.editReqParams.Name = "editReqParams";
			this.editReqParams.Size = new System.Drawing.Size(73, 23);
			this.editReqParams.TabIndex = 1004;
			this.editReqParams.Text = "修改";
			this.editReqParams.UseVisualStyleBackColor = true;
			this.editReqParams.Click += new System.EventHandler(this.editReqParams_Click);
			// 
			// reqParamList
			// 
			this.reqParamList.HideSelection = false;
			this.reqParamList.Location = new System.Drawing.Point(6, 49);
			this.reqParamList.MultiSelect = false;
			this.reqParamList.Name = "reqParamList";
			this.reqParamList.Size = new System.Drawing.Size(270, 127);
			this.reqParamList.TabIndex = 2;
			this.reqParamList.UseCompatibleStateImageBehavior = false;
			this.reqParamList.View = System.Windows.Forms.View.Details;
			this.reqParamList.SelectedIndexChanged += new System.EventHandler(this.reqParamList_SelectedIndexChanged);
			this.reqParamList.DoubleClick += new System.EventHandler(this.reqParamList_DoubleClick);
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
			this.label4.Text = "路由";
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
			this.curPage.Controls.Add(this.autoFill);
			this.curPage.Controls.Add(this.moveDown);
			this.curPage.Controls.Add(this.moveUp);
			this.curPage.Controls.Add(this.groupBox2);
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
			// autoFill
			// 
			this.autoFill.Location = new System.Drawing.Point(381, 135);
			this.autoFill.Name = "autoFill";
			this.autoFill.Size = new System.Drawing.Size(125, 24);
			this.autoFill.TabIndex = 1003;
			this.autoFill.Text = "自动填充";
			this.autoFill.UseVisualStyleBackColor = true;
			this.autoFill.Click += new System.EventHandler(this.autoFill_Click);
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
			// ReqResInterfaceManager
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
			this.Name = "ReqResInterfaceManager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "请求-响应接口管理";
			this.groupBox2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.curPage.ResumeLayout(false);
			this.curPage.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button moveDown;
		private System.Windows.Forms.Button moveUp;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button clearResParams;
		private System.Windows.Forms.Button editResParams;
		private ExermonDevManager.Scripts.Controls.ExerListView resParamList;
		private System.Windows.Forms.Button copy;
		private System.Windows.Forms.Button delete;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label17;
		private ExermonDevManager.Scripts.Controls.ExerTextBox fName;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label15;
		private ExermonDevManager.Scripts.Controls.ExerComboBox bModule;
		private ExermonDevManager.Scripts.Controls.ExerComboBox bTag;
		private System.Windows.Forms.Label label16;
		private ExermonDevManager.Scripts.Controls.ExerListView itemList;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button clearReqParams;
		private System.Windows.Forms.Button editReqParams;
		private ExermonDevManager.Scripts.Controls.ExerListView reqParamList;
		private ExermonDevManager.Scripts.Controls.ExerTextBox route;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private ExermonDevManager.Scripts.Controls.ExerTextBox description;
		private System.Windows.Forms.Label label2;
		private ExermonDevManager.Scripts.Controls.ExerTextBox name;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private ExermonDevManager.Scripts.Controls.ExerTextBox bFunc;
		private System.Windows.Forms.GroupBox curPage;
		private System.Windows.Forms.Button autoFill;
		private System.Windows.Forms.Button create;
		private System.Windows.Forms.Button save;
	}
}