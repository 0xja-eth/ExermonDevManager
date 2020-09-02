namespace ExermonDevManager.Forms {
	partial class MainForm {
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent() {
			this.reqResInterface = new System.Windows.Forms.Button();
			this.groupData = new System.Windows.Forms.Button();
			this.saveData = new System.Windows.Forms.Button();
			this.exportCode = new System.Windows.Forms.Button();
			this.module = new System.Windows.Forms.Button();
			this.emitInterface = new System.Windows.Forms.Button();
			this.exception = new System.Windows.Forms.Button();
			this.model = new System.Windows.Forms.Button();
			this.customEnumGroup = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// reqResInterface
			// 
			this.reqResInterface.Location = new System.Drawing.Point(12, 55);
			this.reqResInterface.Name = "reqResInterface";
			this.reqResInterface.Size = new System.Drawing.Size(228, 37);
			this.reqResInterface.TabIndex = 1;
			this.reqResInterface.Text = "请求-响应接口管理";
			this.reqResInterface.UseVisualStyleBackColor = true;
			this.reqResInterface.Click += new System.EventHandler(this.reqResInterface_Click);
			// 
			// groupData
			// 
			this.groupData.Location = new System.Drawing.Point(12, 141);
			this.groupData.Name = "groupData";
			this.groupData.Size = new System.Drawing.Size(228, 37);
			this.groupData.TabIndex = 3;
			this.groupData.Text = "组合数据管理";
			this.groupData.UseVisualStyleBackColor = true;
			this.groupData.Click += new System.EventHandler(this.groupData_Click);
			// 
			// saveData
			// 
			this.saveData.Location = new System.Drawing.Point(12, 387);
			this.saveData.Name = "saveData";
			this.saveData.Size = new System.Drawing.Size(228, 37);
			this.saveData.TabIndex = 4;
			this.saveData.Text = "保存数据";
			this.saveData.UseVisualStyleBackColor = true;
			this.saveData.Click += new System.EventHandler(this.saveData_Click);
			// 
			// exportCode
			// 
			this.exportCode.Location = new System.Drawing.Point(12, 430);
			this.exportCode.Name = "exportCode";
			this.exportCode.Size = new System.Drawing.Size(228, 37);
			this.exportCode.TabIndex = 5;
			this.exportCode.Text = "导出代码";
			this.exportCode.UseVisualStyleBackColor = true;
			// 
			// module
			// 
			this.module.Location = new System.Drawing.Point(12, 12);
			this.module.Name = "module";
			this.module.Size = new System.Drawing.Size(228, 37);
			this.module.TabIndex = 0;
			this.module.Text = "模块管理";
			this.module.UseVisualStyleBackColor = true;
			this.module.Click += new System.EventHandler(this.module_Click);
			// 
			// emitInterface
			// 
			this.emitInterface.Location = new System.Drawing.Point(12, 98);
			this.emitInterface.Name = "emitInterface";
			this.emitInterface.Size = new System.Drawing.Size(228, 37);
			this.emitInterface.TabIndex = 2;
			this.emitInterface.Text = "发射接口管理";
			this.emitInterface.UseVisualStyleBackColor = true;
			this.emitInterface.Click += new System.EventHandler(this.emitInterface_Click);
			// 
			// exception
			// 
			this.exception.Location = new System.Drawing.Point(12, 270);
			this.exception.Name = "exception";
			this.exception.Size = new System.Drawing.Size(228, 37);
			this.exception.TabIndex = 6;
			this.exception.Text = "异常管理";
			this.exception.UseVisualStyleBackColor = true;
			this.exception.Click += new System.EventHandler(this.exception_Click);
			// 
			// model
			// 
			this.model.Location = new System.Drawing.Point(12, 184);
			this.model.Name = "model";
			this.model.Size = new System.Drawing.Size(228, 37);
			this.model.TabIndex = 7;
			this.model.Text = "模型管理";
			this.model.UseVisualStyleBackColor = true;
			this.model.Click += new System.EventHandler(this.model_Click);
			// 
			// customEnumGroup
			// 
			this.customEnumGroup.Location = new System.Drawing.Point(12, 227);
			this.customEnumGroup.Name = "customEnumGroup";
			this.customEnumGroup.Size = new System.Drawing.Size(228, 37);
			this.customEnumGroup.TabIndex = 8;
			this.customEnumGroup.Text = "自定义枚举管理";
			this.customEnumGroup.UseVisualStyleBackColor = true;
			this.customEnumGroup.Click += new System.EventHandler(this.customEnumGroup_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(252, 479);
			this.Controls.Add(this.customEnumGroup);
			this.Controls.Add(this.model);
			this.Controls.Add(this.exception);
			this.Controls.Add(this.emitInterface);
			this.Controls.Add(this.module);
			this.Controls.Add(this.exportCode);
			this.Controls.Add(this.saveData);
			this.Controls.Add(this.groupData);
			this.Controls.Add(this.reqResInterface);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Exermon开发管理系统";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button reqResInterface;
		private System.Windows.Forms.Button groupData;
		private System.Windows.Forms.Button saveData;
		private System.Windows.Forms.Button exportCode;
		private System.Windows.Forms.Button module;
		private System.Windows.Forms.Button emitInterface;
		private System.Windows.Forms.Button exception;
		private System.Windows.Forms.Button model;
		private System.Windows.Forms.Button customEnumGroup;
	}
}

