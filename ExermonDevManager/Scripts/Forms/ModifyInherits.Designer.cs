namespace ExermonDevManager.Scripts.Forms {
	using Scripts.Data;

	partial class ModifyInherits<T> : ExermonForm<T>
		where T : Type_, new() {
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("1");
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("12");
			this.currentList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.label1 = new System.Windows.Forms.Label();
			this.typeList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label2 = new System.Windows.Forms.Label();
			this.confirm = new System.Windows.Forms.Button();
			this.clear = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// currentList
			// 
			this.currentList.HideSelection = false;
			this.currentList.Location = new System.Drawing.Point(12, 28);
			this.currentList.MultiSelect = false;
			this.currentList.Name = "currentList";
			this.currentList.Size = new System.Drawing.Size(227, 89);
			this.currentList.TabIndex = 3;
			this.currentList.UseCompatibleStateImageBehavior = false;
			this.currentList.View = System.Windows.Forms.View.Details;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "当前继承关系";
			// 
			// typeList
			// 
			this.typeList.CheckBoxes = true;
			this.typeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.typeList.HideSelection = false;
			listViewItem1.StateImageIndex = 0;
			listViewItem2.StateImageIndex = 0;
			this.typeList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
			this.typeList.Location = new System.Drawing.Point(12, 151);
			this.typeList.Name = "typeList";
			this.typeList.Size = new System.Drawing.Size(227, 238);
			this.typeList.TabIndex = 5;
			this.typeList.UseCompatibleStateImageBehavior = false;
			this.typeList.View = System.Windows.Forms.View.Details;
			this.typeList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.typeList_ItemCheck);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 132);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(197, 12);
			this.label2.TabIndex = 6;
			this.label2.Text = "类型列表（从这里选择要继承的类）";
			// 
			// confirm
			// 
			this.confirm.Location = new System.Drawing.Point(166, 395);
			this.confirm.Name = "confirm";
			this.confirm.Size = new System.Drawing.Size(73, 23);
			this.confirm.TabIndex = 73;
			this.confirm.Text = "保存并退出";
			this.confirm.UseVisualStyleBackColor = true;
			// 
			// clear
			// 
			this.clear.Location = new System.Drawing.Point(87, 395);
			this.clear.Name = "clear";
			this.clear.Size = new System.Drawing.Size(73, 23);
			this.clear.TabIndex = 74;
			this.clear.Text = "清空继承类";
			this.clear.UseVisualStyleBackColor = true;
			this.clear.Click += new System.EventHandler(this.clear_Click);
			// 
			// ModifyInherits
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(251, 428);
			this.Controls.Add(this.clear);
			this.Controls.Add(this.confirm);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.typeList);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.currentList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximumSize = new System.Drawing.Size(267, 467);
			this.MinimumSize = new System.Drawing.Size(267, 467);
			this.Name = "ModifyInherits";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "修改继承关系";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ExermonDevManager.Scripts.Controls.ExerListView currentList;
		private System.Windows.Forms.Label label1;
		private ExermonDevManager.Scripts.Controls.ExerListView typeList;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Button confirm;
		private System.Windows.Forms.Button clear;
	}
}