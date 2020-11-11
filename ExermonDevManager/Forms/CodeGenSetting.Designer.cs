namespace ExermonDevManager.Forms {
	partial class CodeGenSetting {
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
			this.label1 = new System.Windows.Forms.Label();
			this.exportPath = new System.Windows.Forms.TextBox();
			this.browse = new System.Windows.Forms.Button();
			this.open = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.browserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "导出路径";
			// 
			// exportPath
			// 
			this.exportPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.exportPath.Location = new System.Drawing.Point(71, 14);
			this.exportPath.Name = "exportPath";
			this.exportPath.Size = new System.Drawing.Size(165, 21);
			this.exportPath.TabIndex = 1;
			// 
			// browse
			// 
			this.browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browse.Location = new System.Drawing.Point(242, 12);
			this.browse.Name = "browse";
			this.browse.Size = new System.Drawing.Size(59, 23);
			this.browse.TabIndex = 2;
			this.browse.Text = "浏览";
			this.browse.UseVisualStyleBackColor = true;
			this.browse.Click += new System.EventHandler(this.browse_Click);
			// 
			// open
			// 
			this.open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.open.Location = new System.Drawing.Point(307, 12);
			this.open.Name = "open";
			this.open.Size = new System.Drawing.Size(59, 23);
			this.open.TabIndex = 3;
			this.open.Text = "打开";
			this.open.UseVisualStyleBackColor = true;
			this.open.Click += new System.EventHandler(this.open_Click);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(12, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(354, 54);
			this.label2.TabIndex = 4;
			this.label2.Text = "更多设置敬请期待";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// browserDialog
			// 
			this.browserDialog.Description = "指定一个导出的目录";
			// 
			// CodeGenSetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(378, 101);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.open);
			this.Controls.Add(this.browse);
			this.Controls.Add(this.exportPath);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size(394, 140);
			this.Name = "CodeGenSetting";
			this.Text = "代码生成设置";
			this.Load += new System.EventHandler(this.CodeGenSetting_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox exportPath;
		private System.Windows.Forms.Button browse;
		private System.Windows.Forms.Button open;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.FolderBrowserDialog browserDialog;
	}
}