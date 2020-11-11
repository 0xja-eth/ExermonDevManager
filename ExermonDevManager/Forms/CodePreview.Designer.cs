namespace ExermonDevManager.Forms {
	partial class CodePreview {
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.itemList = new ExermonDevManager.Scripts.Controls.ExerListView();
			this.label1 = new System.Windows.Forms.Label();
			this.code = new ExermonDevManager.Scripts.Controls.ExerTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.refresh = new System.Windows.Forms.Button();
			this.exportCurrent = new System.Windows.Forms.Button();
			this.exportAll = new System.Windows.Forms.Button();
			this.setting = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.itemList);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.code);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Size = new System.Drawing.Size(628, 483);
			this.splitContainer1.SplitterDistance = 191;
			this.splitContainer1.TabIndex = 1;
			// 
			// itemList
			// 
			this.itemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.itemList.HideSelection = false;
			this.itemList.Location = new System.Drawing.Point(6, 24);
			this.itemList.MultiSelect = false;
			this.itemList.Name = "itemList";
			this.itemList.Size = new System.Drawing.Size(182, 456);
			this.itemList.TabIndex = 85;
			this.itemList.UseCompatibleStateImageBehavior = false;
			this.itemList.View = System.Windows.Forms.View.Details;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "文件列表";
			// 
			// code
			// 
			this.code.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.code.Location = new System.Drawing.Point(3, 24);
			this.code.Multiline = true;
			this.code.Name = "code";
			this.code.ReadOnly = true;
			this.code.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.code.Size = new System.Drawing.Size(418, 456);
			this.code.TabIndex = 3;
			this.code.WordWrap = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "代码";
			// 
			// refresh
			// 
			this.refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.refresh.Location = new System.Drawing.Point(12, 489);
			this.refresh.Name = "refresh";
			this.refresh.Size = new System.Drawing.Size(95, 23);
			this.refresh.TabIndex = 2;
			this.refresh.Text = "刷新";
			this.refresh.UseVisualStyleBackColor = true;
			// 
			// exportCurrent
			// 
			this.exportCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.exportCurrent.Location = new System.Drawing.Point(364, 489);
			this.exportCurrent.Name = "exportCurrent";
			this.exportCurrent.Size = new System.Drawing.Size(123, 23);
			this.exportCurrent.TabIndex = 4;
			this.exportCurrent.Text = "导出当前项";
			this.exportCurrent.UseVisualStyleBackColor = true;
			// 
			// exportAll
			// 
			this.exportAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.exportAll.Location = new System.Drawing.Point(235, 489);
			this.exportAll.Name = "exportAll";
			this.exportAll.Size = new System.Drawing.Size(123, 23);
			this.exportAll.TabIndex = 3;
			this.exportAll.Text = "导出全部";
			this.exportAll.UseVisualStyleBackColor = true;
			// 
			// setting
			// 
			this.setting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.setting.Location = new System.Drawing.Point(493, 489);
			this.setting.Name = "setting";
			this.setting.Size = new System.Drawing.Size(123, 23);
			this.setting.TabIndex = 5;
			this.setting.Text = "导出设置";
			this.setting.UseVisualStyleBackColor = true;
			this.setting.Click += new System.EventHandler(this.setting_Click);
			// 
			// CodePreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(628, 519);
			this.Controls.Add(this.setting);
			this.Controls.Add(this.exportCurrent);
			this.Controls.Add(this.exportAll);
			this.Controls.Add(this.refresh);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size(644, 558);
			this.Name = "CodePreview";
			this.Text = "代码预览";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button refresh;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button exportCurrent;
		private System.Windows.Forms.Button exportAll;
		private Scripts.Controls.ExerListView itemList;
		private Scripts.Controls.ExerTextBox code;
		private System.Windows.Forms.Button setting;
	}
}