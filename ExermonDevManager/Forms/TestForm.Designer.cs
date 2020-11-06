﻿namespace ExermonDevManager.Forms {
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
			this.customenumgroupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tableCombox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.modulesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.modelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.channeltagsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.saveData = new System.Windows.Forms.Button();
			this.djangofieldtypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.djangoondeletechoicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.emitinterfacesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.exceptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.groupdatainheritderivesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.groupdatasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.interfaceparamsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.modelfieldsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.modelinheritderivesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.reqresinterfacesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.typesettingmodelfieldsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.typesettingmodelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.typesettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.exermonmanagerDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.exermon_managerDataSet = new ExermonDevManager.exermon_managerDataSet();
			((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.customenumgroupsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.modulesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.modelsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.channeltagsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.djangofieldtypesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.djangoondeletechoicesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emitinterfacesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exceptionsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupdatainheritderivesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupdatasBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.interfaceparamsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.modelfieldsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.modelinheritderivesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reqresinterfacesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.typesettingmodelfieldsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.typesettingmodelsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.typesettingsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exermonmanagerDataSetBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exermon_managerDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// dataView
			// 
			this.dataView.AllowUserToOrderColumns = true;
			this.dataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataView.Location = new System.Drawing.Point(12, 42);
			this.dataView.Name = "dataView";
			this.dataView.RowTemplate.Height = 23;
			this.dataView.Size = new System.Drawing.Size(699, 396);
			this.dataView.TabIndex = 0;
			this.dataView.DataSourceChanged += new System.EventHandler(this.dataView_DataSourceChanged);
			this.dataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataView_CellContentClick);
			this.dataView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataView_CellEndEdit);
			this.dataView.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dataView_CellStateChanged);
			this.dataView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataView_CellValueChanged);
			this.dataView.CurrentCellChanged += new System.EventHandler(this.dataView_CurrentCellChanged);
			this.dataView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataView_DataBindingComplete);
			this.dataView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataView_DataError);
			this.dataView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataView_RowsAdded);
			this.dataView.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataView_RowStateChanged);
			this.dataView.SelectionChanged += new System.EventHandler(this.dataView_SelectionChanged);
			this.dataView.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataView_UserAddedRow);
			this.dataView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataView_UserDeletingRow);
			// 
			// customenumgroupsBindingSource
			// 
			this.customenumgroupsBindingSource.DataMember = "customenumgroups";
			this.customenumgroupsBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
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
			// modulesBindingSource
			// 
			this.modulesBindingSource.DataMember = "modules";
			this.modulesBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// modelsBindingSource
			// 
			this.modelsBindingSource.DataMember = "models";
			this.modelsBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// channeltagsBindingSource
			// 
			this.channeltagsBindingSource.DataMember = "channeltags";
			this.channeltagsBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// saveData
			// 
			this.saveData.Location = new System.Drawing.Point(424, 16);
			this.saveData.Name = "saveData";
			this.saveData.Size = new System.Drawing.Size(75, 23);
			this.saveData.TabIndex = 3;
			this.saveData.Text = "保存数据";
			this.saveData.UseVisualStyleBackColor = true;
			this.saveData.Click += new System.EventHandler(this.saveData_Click);
			// 
			// djangofieldtypesBindingSource
			// 
			this.djangofieldtypesBindingSource.DataMember = "djangofieldtypes";
			this.djangofieldtypesBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// djangoondeletechoicesBindingSource
			// 
			this.djangoondeletechoicesBindingSource.DataMember = "djangoondeletechoices";
			this.djangoondeletechoicesBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// emitinterfacesBindingSource
			// 
			this.emitinterfacesBindingSource.DataMember = "emitinterfaces";
			this.emitinterfacesBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// exceptionsBindingSource
			// 
			this.exceptionsBindingSource.DataMember = "exceptions";
			this.exceptionsBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// groupdatainheritderivesBindingSource
			// 
			this.groupdatainheritderivesBindingSource.DataMember = "groupdatainheritderives";
			this.groupdatainheritderivesBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// groupdatasBindingSource
			// 
			this.groupdatasBindingSource.DataMember = "groupdatas";
			this.groupdatasBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// interfaceparamsBindingSource
			// 
			this.interfaceparamsBindingSource.DataMember = "interfaceparams";
			this.interfaceparamsBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// modelfieldsBindingSource
			// 
			this.modelfieldsBindingSource.DataMember = "modelfields";
			this.modelfieldsBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// modelinheritderivesBindingSource
			// 
			this.modelinheritderivesBindingSource.DataMember = "modelinheritderives";
			this.modelinheritderivesBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// reqresinterfacesBindingSource
			// 
			this.reqresinterfacesBindingSource.DataMember = "reqresinterfaces";
			this.reqresinterfacesBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// typesettingmodelfieldsBindingSource
			// 
			this.typesettingmodelfieldsBindingSource.DataMember = "typesettingmodelfields";
			this.typesettingmodelfieldsBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// typesettingmodelsBindingSource
			// 
			this.typesettingmodelsBindingSource.DataMember = "typesettingmodels";
			this.typesettingmodelsBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
			// 
			// typesettingsBindingSource
			// 
			this.typesettingsBindingSource.DataMember = "typesettings";
			this.typesettingsBindingSource.DataSource = this.exermonmanagerDataSetBindingSource;
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
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(723, 450);
			this.Controls.Add(this.saveData);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tableCombox);
			this.Controls.Add(this.dataView);
			this.Name = "TestForm";
			this.Text = "艾瑟萌开发管理系统2.0";
			this.Load += new System.EventHandler(this.TestForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.customenumgroupsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.modulesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.modelsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.channeltagsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.djangofieldtypesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.djangoondeletechoicesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emitinterfacesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exceptionsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupdatainheritderivesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupdatasBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.interfaceparamsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.modelfieldsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.modelinheritderivesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reqresinterfacesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.typesettingmodelfieldsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.typesettingmodelsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.typesettingsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exermonmanagerDataSetBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exermon_managerDataSet)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataView;
		private System.Windows.Forms.ComboBox tableCombox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.BindingSource exermonmanagerDataSetBindingSource;
		private exermon_managerDataSet exermon_managerDataSet;
		private System.Windows.Forms.BindingSource modulesBindingSource;
		private System.Windows.Forms.BindingSource modelsBindingSource;
		private System.Windows.Forms.BindingSource channeltagsBindingSource;
		private System.Windows.Forms.BindingSource customenumgroupsBindingSource;
		private System.Windows.Forms.Button saveData;
		private System.Windows.Forms.BindingSource djangofieldtypesBindingSource;
		private System.Windows.Forms.BindingSource djangoondeletechoicesBindingSource;
		private System.Windows.Forms.BindingSource emitinterfacesBindingSource;
		private System.Windows.Forms.BindingSource exceptionsBindingSource;
		private System.Windows.Forms.BindingSource groupdatainheritderivesBindingSource;
		private System.Windows.Forms.BindingSource groupdatasBindingSource;
		private System.Windows.Forms.BindingSource interfaceparamsBindingSource;
		private System.Windows.Forms.BindingSource modelfieldsBindingSource;
		private System.Windows.Forms.BindingSource modelinheritderivesBindingSource;
		private System.Windows.Forms.BindingSource reqresinterfacesBindingSource;
		private System.Windows.Forms.BindingSource typesettingmodelfieldsBindingSource;
		private System.Windows.Forms.BindingSource typesettingmodelsBindingSource;
		private System.Windows.Forms.BindingSource typesettingsBindingSource;
	}
}