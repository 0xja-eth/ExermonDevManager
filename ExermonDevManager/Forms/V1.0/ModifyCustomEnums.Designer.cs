namespace ExermonDevManager.Forms {

	using Scripts.Forms;
	using Scripts.Data;

	partial class ModifyCustomEnums {
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
			this.description = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.name = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.confirm = new System.Windows.Forms.Button();
			this.moveUp = new System.Windows.Forms.Button();
			this.moveDown = new System.Windows.Forms.Button();
			this.curPage = new System.Windows.Forms.GroupBox();
			this.code = new ExermonDevManager.Scripts.Controls.ExerNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.create = new System.Windows.Forms.Button();
			this.curPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.code)).BeginInit();
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
			this.copy.Location = new System.Drawing.Point(140, 106);
			this.copy.Name = "copy";
			this.copy.Size = new System.Drawing.Size(73, 23);
			this.copy.TabIndex = 40;
			this.copy.Text = "复制";
			this.copy.UseVisualStyleBackColor = true;
			// 
			// delete
			// 
			this.delete.Location = new System.Drawing.Point(219, 106);
			this.delete.Name = "delete";
			this.delete.Size = new System.Drawing.Size(73, 23);
			this.delete.TabIndex = 39;
			this.delete.Text = "删除";
			this.delete.UseVisualStyleBackColor = true;
			// 
			// description
			// 
			this.description.Location = new System.Drawing.Point(45, 48);
			this.description.Multiline = true;
			this.description.Name = "description";
			this.description.Size = new System.Drawing.Size(247, 52);
			this.description.TabIndex = 1003;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 51);
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
			this.confirm.Location = new System.Drawing.Point(219, 135);
			this.confirm.Name = "confirm";
			this.confirm.Size = new System.Drawing.Size(73, 23);
			this.confirm.TabIndex = 42;
			this.confirm.Text = "确认并关闭";
			this.confirm.UseVisualStyleBackColor = true;
			// 
			// moveUp
			// 
			this.moveUp.Location = new System.Drawing.Point(10, 106);
			this.moveUp.Name = "moveUp";
			this.moveUp.Size = new System.Drawing.Size(73, 23);
			this.moveUp.TabIndex = 49;
			this.moveUp.Text = "上移";
			this.moveUp.UseVisualStyleBackColor = true;
			// 
			// moveDown
			// 
			this.moveDown.Location = new System.Drawing.Point(10, 135);
			this.moveDown.Name = "moveDown";
			this.moveDown.Size = new System.Drawing.Size(73, 23);
			this.moveDown.TabIndex = 50;
			this.moveDown.Text = "下移";
			this.moveDown.UseVisualStyleBackColor = true;
			// 
			// curPage
			// 
			this.curPage.Controls.Add(this.code);
			this.curPage.Controls.Add(this.label1);
			this.curPage.Controls.Add(this.moveDown);
			this.curPage.Controls.Add(this.moveUp);
			this.curPage.Controls.Add(this.confirm);
			this.curPage.Controls.Add(this.copy);
			this.curPage.Controls.Add(this.delete);
			this.curPage.Controls.Add(this.description);
			this.curPage.Controls.Add(this.label6);
			this.curPage.Controls.Add(this.name);
			this.curPage.Controls.Add(this.label5);
			this.curPage.Location = new System.Drawing.Point(12, 231);
			this.curPage.Name = "curPage";
			this.curPage.Size = new System.Drawing.Size(301, 165);
			this.curPage.TabIndex = 51;
			this.curPage.TabStop = false;
			this.curPage.Text = "编辑页";
			// 
			// code
			// 
			this.code.Location = new System.Drawing.Point(191, 21);
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
			this.code.Size = new System.Drawing.Size(101, 21);
			this.code.TabIndex = 1005;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(144, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 1004;
			this.label1.Text = "枚举值";
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
			// ModifyCustomEnums
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(325, 408);
			this.Controls.Add(this.create);
			this.Controls.Add(this.curPage);
			this.Controls.Add(this.paramList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximumSize = new System.Drawing.Size(341, 447);
			this.MinimumSize = new System.Drawing.Size(341, 447);
			this.Name = "ModifyCustomEnums";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "枚举项修改";
			this.curPage.ResumeLayout(false);
			this.curPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.code)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private ExermonDevManager.Scripts.Controls.ExerListView paramList;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Button copy;
		private System.Windows.Forms.Button delete;
		private ExermonDevManager.Scripts.Controls.ExerTextBox description;
		private System.Windows.Forms.Label label6;
		private ExermonDevManager.Scripts.Controls.ExerTextBox name;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button confirm;
		private System.Windows.Forms.Button moveUp;
		private System.Windows.Forms.Button moveDown;
		private System.Windows.Forms.GroupBox curPage;
		private System.Windows.Forms.Button create;
		private ExermonDevManager.Scripts.Controls.ExerNumericUpDown code;
		private System.Windows.Forms.Label label1;
	}
}