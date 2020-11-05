namespace ExermonDevManager.Forms {
	partial class TestForm {
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
			this.components = new System.ComponentModel.Container();
			this.dataView = new System.Windows.Forms.DataGridView();
			this.exermonmanagerDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.exermon_managerDataSet = new ExermonDevManager.exermon_managerDataSet();
			this.tableCombox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.djangofieldtypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.djangofieldtypesTableAdapter = new ExermonDevManager.exermon_managerDataSetTableAdapters.djangofieldtypesTableAdapter();
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buildInDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exermonmanagerDataSetBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exermon_managerDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.djangofieldtypesBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dataView
			// 
			this.dataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataView.AutoGenerateColumns = false;
			this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.buildInDataGridViewCheckBoxColumn});
			this.dataView.DataSource = this.djangofieldtypesBindingSource;
			this.dataView.Location = new System.Drawing.Point(12, 42);
			this.dataView.Name = "dataView";
			this.dataView.RowTemplate.Height = 23;
			this.dataView.Size = new System.Drawing.Size(699, 396);
			this.dataView.TabIndex = 0;
			// 
			// exermonmanagerDataSetBindingSource
			// 
			this.exermonmanagerDataSetBindingSource.DataSource = this.exermon_managerDataSet;
			this.exermonmanagerDataSetBindingSource.Position = 0;
			// 
			// exermon_managerDataSet
			// 
			this.exermon_managerDataSet.DataSetName = "exermon_managerDataSet";
			this.exermon_managerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// tableCombox
			// 
			this.tableCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tableCombox.FormattingEnabled = true;
			this.tableCombox.Location = new System.Drawing.Point(65, 16);
			this.tableCombox.Name = "tableCombox";
			this.tableCombox.Size = new System.Drawing.Size(289, 20);
			this.tableCombox.TabIndex = 1;
			this.tableCombox.SelectedIndexChanged += new System.EventHandler(this.tableCombox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "选择表";
			// 
			// djangofieldtypesBindingSource
			// 
			this.djangofieldtypesBindingSource.DataMember = "djangofieldtypes";
			this.djangofieldtypesBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// djangofieldtypesTableAdapter
			// 
			this.djangofieldtypesTableAdapter.ClearBeforeFill = true;
			// 
			// idDataGridViewTextBoxColumn
			// 
			this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
			this.idDataGridViewTextBoxColumn.HeaderText = "id";
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			// 
			// nameDataGridViewTextBoxColumn
			// 
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "name";
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			// 
			// descriptionDataGridViewTextBoxColumn
			// 
			this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
			this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
			this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
			// 
			// typeDataGridViewTextBoxColumn
			// 
			this.typeDataGridViewTextBoxColumn.DataPropertyName = "type";
			this.typeDataGridViewTextBoxColumn.HeaderText = "type";
			this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
			// 
			// buildInDataGridViewCheckBoxColumn
			// 
			this.buildInDataGridViewCheckBoxColumn.DataPropertyName = "buildIn";
			this.buildInDataGridViewCheckBoxColumn.HeaderText = "buildIn";
			this.buildInDataGridViewCheckBoxColumn.Name = "buildInDataGridViewCheckBoxColumn";
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(723, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tableCombox);
			this.Controls.Add(this.dataView);
			this.Name = "TestForm";
			this.Text = "TestForm";
			this.Load += new System.EventHandler(this.TestForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exermonmanagerDataSetBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exermon_managerDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.djangofieldtypesBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataView;
		private System.Windows.Forms.BindingSource exermonmanagerDataSetBindingSource;
		private exermon_managerDataSet exermon_managerDataSet;
		private System.Windows.Forms.ComboBox tableCombox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.BindingSource djangofieldtypesBindingSource;
		private exermon_managerDataSetTableAdapters.djangofieldtypesTableAdapter djangofieldtypesTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn buildInDataGridViewCheckBoxColumn;
	}
}