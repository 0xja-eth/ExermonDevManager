using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Windows.Forms;

using Microsoft.EntityFrameworkCore;

namespace ExermonDevManager.Forms {

	using Scripts.Data;
	using Scripts.Entities;
	using Scripts.Utils;

	/// <summary>
	/// 测试窗口
	/// </summary>
	public partial class TestForm : Form {

		/// <summary>
		/// 表信息
		/// </summary>
		public class TableInfo {

			public string tableName { get; set; }
			public string name { get; set; }
			public Type type { get; set; }

			/// <summary>
			/// 构造函数
			/// </summary>
			public TableInfo(string tableName, string name, Type type) {
				this.tableName = tableName.ToLower();
				this.name = string.Format(
					HeaderTextFormat, name, this.tableName);
				this.type = type;
			}
		}

		/// <summary>
		/// 按钮文本
		/// </summary>
		const string DataButtonText = "查看";
		const string HeaderTextFormat = "{0}({1})";
		const string AdapterNameFormat = "{0}TableAdapter";

		/// <summary>
		/// 数据库连接
		/// </summary>
		CoreContext db;

		/// <summary>
		/// 表类型列表
		/// </summary>
		public List<TableInfo> tables = new List<TableInfo>();

		public List<Scripts.Entities.Module> modules;

		/// <summary>
		/// 构造函数
		/// </summary>
		public TestForm() {
			db = new CoreContext();
			InitializeComponent();
		}

		/// <summary>
		/// 析构函数
		/// </summary>
		~TestForm() {
			db.Dispose();
		}

		#region 默认事件

		private void TestForm_Load(object sender, EventArgs e) {
			initializeTableData();
			initializeTableCombox();
			initializeDataBase();
		}

		private void tableCombox_SelectedIndexChanged(object sender, EventArgs e) {
			setupDataView(currentTableInfo);
		}

		private void dataView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
			var rid = e.RowIndex;
			var row = dataView.Rows[rid];

			setupDataRow(row);
		}

		private void dataView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			int col = e.ColumnIndex, row = e.RowIndex;
			var cell = dataView.Rows[row].Cells[col];

			(cell.Tag as Action)?.Invoke();
		}

		private void saveData_Click(object sender, EventArgs e) {
			saveTables();
		}

		#endregion

		#region 快捷数据获取

		/// <summary>
		/// 当前数据表
		/// </summary>
		public TableInfo currentTableInfo => tableCombox.SelectedValue as TableInfo;

		#endregion

		#region 初始化

		/// <summary>
		/// 初始化数据库
		/// </summary>
		void initializeDataBase() {
			fillTables();

			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.typesettings”中。您可以根据需要移动或删除它。
			//this.typesettingsTableAdapter.Fill(this.exermon_managerDataSet.typesettings);
			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.typesettingmodels”中。您可以根据需要移动或删除它。
			//this.typesettingmodelsTableAdapter.Fill(this.exermon_managerDataSet.typesettingmodels);
			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.typesettingmodelfields”中。您可以根据需要移动或删除它。
			//this.typesettingmodelfieldsTableAdapter.Fill(this.exermon_managerDataSet.typesettingmodelfields);
			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.reqresinterfaces”中。您可以根据需要移动或删除它。
			//this.reqresinterfacesTableAdapter.Fill(this.exermon_managerDataSet.reqresinterfaces);
			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.modelinheritderives”中。您可以根据需要移动或删除它。
			//this.modelinheritderivesTableAdapter.Fill(this.exermon_managerDataSet.modelinheritderives);
			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.modelfields”中。您可以根据需要移动或删除它。
			//this.modelfieldsTableAdapter.Fill(this.exermon_managerDataSet.modelfields);
			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.interfaceparams”中。您可以根据需要移动或删除它。
			//this.interfaceparamsTableAdapter.Fill(this.exermon_managerDataSet.interfaceparams);
			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.groupdatas”中。您可以根据需要移动或删除它。
			//this.groupdatasTableAdapter.Fill(this.exermon_managerDataSet.groupdatas);
			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.groupdatainheritderives”中。您可以根据需要移动或删除它。
			//this.groupdatainheritderivesTableAdapter.Fill(this.exermon_managerDataSet.groupdatainheritderives);
			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.exceptions”中。您可以根据需要移动或删除它。
			//this.exceptionsTableAdapter.Fill(this.exermon_managerDataSet.exceptions);
			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.emitinterfaces”中。您可以根据需要移动或删除它。
			//this.emitinterfacesTableAdapter.Fill(this.exermon_managerDataSet.emitinterfaces);
			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.djangoondeletechoices”中。您可以根据需要移动或删除它。
			//this.djangoondeletechoicesTableAdapter.Fill(this.exermon_managerDataSet.djangoondeletechoices);
			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.modules”中。您可以根据需要移动或删除它。
			//this.modulesTableAdapter.Fill(this.exermon_managerDataSet.modules);
			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.models”中。您可以根据需要移动或删除它。
			//this.modelsTableAdapter.Fill(this.exermon_managerDataSet.models);
			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.customenumgroups”中。您可以根据需要移动或删除它。
			//this.customenumgroupsTableAdapter.Fill(this.exermon_managerDataSet.customenumgroups);
			//// TODO: 这行代码将数据加载到表“exermon_managerDataSet.channeltags”中。您可以根据需要移动或删除它。
			//this.channeltagsTableAdapter.Fill(this.exermon_managerDataSet.channeltags);

		}

		/// <summary>
		/// 初始化数据库表设置数据
		/// </summary>
		void initializeTableData() {
			tables.Clear();

			ReflectionUtils.processAttribute<PropertyInfo, CoreContext.TableSettingAttribute>(
				typeof(CoreContext), (p, a) => {
					if (!a.root) return;

					var type = p.PropertyType;
					if (!type.IsGenericType) return;

					var tType = type.GenericTypeArguments[0];
					tables.Add(new TableInfo(p.Name, a.name, tType));
				}
			);
		}

		/// <summary>
		/// 初始化数据库表下拉框
		/// </summary>
		void initializeTableCombox() {
			tableCombox.DataSource = tables;
			tableCombox.DisplayMember = "name";
		}

		#endregion

		#region 数据视图配置

		/// <summary>
		/// 配置数据视图
		/// </summary>
		/// <param name="tableType"></param>
		void setupDataView(TableInfo table) {
			dataView.DataSource = getDataSource(table?.type);
			setupDataViewCols(table?.type);
		}

		/// <summary>
		/// 配置数据视图列
		/// </summary>
		/// <param name="tType"></param>
		void setupDataViewCols(Type tType) {
			dataView.Columns.Clear();

			if (tType == null) return;

			var attrs = CoreData.getFieldSettings(tType);

			foreach (var attr in attrs) {
				var prop = attr.memberInfo as PropertyInfo;
				if (prop == null) continue;

				dataView.Columns.Add(genCol(prop, attr));
			}
		}

		#region 列控制

		/// <summary>
		/// 生成列
		/// </summary>
		/// <param name="attr"></param>
		/// <param name="prop"></param>
		/// <returns></returns>
		DataGridViewColumn genCol(PropertyInfo prop, 
			CoreData.ControlFieldAttribute attr) {
			var type = prop.PropertyType;

			DataGridViewColumn res;

			if (type == typeof(bool)) // 布尔值
				res = genCheckboxCol(prop);
			else if (type.IsEnum) // 枚举值
				res = genEnumCol(prop, type);
			else if (type.IsSubclassOf(typeof(CoreEntity))) // 下拉框
				res = genComboxCol(prop, type);
			else if (type.Name == typeof(List<>).Name) // 联查
				res = genButtonCol(prop);
			else // 默认
				res = genTextBoxCol(prop);

			res.HeaderText = string.Format(
				HeaderTextFormat, attr.name, prop.Name);

			return res;
		}

		/// <summary>
		/// 创建CheckBox列
		/// </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		DataGridViewColumn genCheckboxCol(PropertyInfo prop) {
			var res = new DataGridViewCheckBoxColumn();
			res.DataPropertyName = prop.Name;
			return res;
		}

		/// <summary>
		/// 枚举信息
		/// </summary>
		struct EnumInfo {

			public int value { get; set; }
			public string name { get; set; }

			public EnumInfo(int value, string name) {
				this.value = value; this.name = name;
			}
		}

		/// <summary>
		/// 创建枚举列
		/// </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		DataGridViewColumn genEnumCol(PropertyInfo prop, Type type) {
			var res = new DataGridViewComboBoxColumn();

			var enums = new List<EnumInfo>();
			var values = Enum.GetValues(type);
			foreach (int val in values)
				enums.Add(new EnumInfo(val, Enum.GetName(type, val)));

			res.DataSource = enums;
			res.DisplayMember = "name";
			res.ValueMember = "value";

			res.DataPropertyName = prop.Name;

			return res;
		}

		/// <summary>
		/// 创建下拉框列
		/// </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		DataGridViewColumn genComboxCol(PropertyInfo prop, Type type) {
			var res = new DataGridViewComboBoxColumn();

			res.DataSource = getDataSource(type);
			res.DisplayMember = "name";
			res.ValueMember = "id";

			res.DataPropertyName = prop.Name + "Id";

			return res;
		}

		/// <summary>
		/// 创建按钮列
		/// </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		DataGridViewColumn genButtonCol(PropertyInfo prop) {
			var res = new DataGridViewButtonColumn();
			res.DataPropertyName = "";
			res.Tag = prop;
			return res;
		}

		/// <summary>
		/// 创建文本框列
		/// </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		DataGridViewColumn genTextBoxCol(PropertyInfo prop) {
			var res = new DataGridViewTextBoxColumn();
			res.DataPropertyName = prop.Name;
			return res;
		}

		#endregion

		#region 行控制

		/// <summary>
		/// 配置数据行
		/// </summary>
		void setupDataRow(DataGridViewRow row) {
			var data = row.DataBoundItem as DataRowView;
			if (data == null) return;

			foreach (DataGridViewCell cell in row.Cells)
				setupDataCell(cell, data);
		}

		/// <summary>
		/// 配置数据单元格
		/// </summary>
		/// <param name="cell"></param>
		void setupDataCell(DataGridViewCell cell, DataRowView data) {
			var flag = setupButtonCell(cell as DataGridViewButtonCell, data) ||
				setupCheckboxCell(cell as DataGridViewCheckBoxCell, data);
		}

		/// <summary>
		/// 配置按钮单元格
		/// </summary>
		bool setupButtonCell(DataGridViewButtonCell cell, DataRowView data) {
			if (cell == null) return false;

			var col = cell.OwningColumn as DataGridViewButtonColumn;
			var pInfo = col.Tag as PropertyInfo;

			cell.Value = DataButtonText;
			cell.Tag = new Action(() => {
				if (pInfo == null) return;
				var subData = pInfo.GetValue(data);
			});

			return true;
		}

		/// <summary>
		/// 配置CheckBox单元格
		/// </summary>
		bool setupCheckboxCell(DataGridViewCheckBoxCell cell, DataRowView data) {
			if (cell == null) return false;

			var val = data[cell.OwningColumn.DataPropertyName];

			if (val == null) cell.Value = false;
			else cell.Value = (bool)val;

			return true;
		}

		#endregion

		#endregion

		#region 数据库操作

		/// <summary>
		/// 填充所有数据
		/// </summary>
		void fillTables() {
			foreach (var table in tables)
				fillTable(table.type);
		}

		/// <summary>
		/// 填充单个数据
		/// </summary>
		/// <param name="tType"></param>
		void fillTable(Type tType) {
			callDataAdapter(tType, AdapterCallType.Fill);
		}

		/// <summary>
		/// 填充所有数据
		/// </summary>
		void saveTables() {
			foreach (var table in tables)
				saveTable(table.type);
		}

		/// <summary>
		/// 填充单个数据
		/// </summary>
		/// <param name="tType"></param>
		void saveTable(Type tType) {
			var source = getDataSource(tType);
			callDataAdapter(tType, AdapterCallType.Update, source);
			source.AcceptChanges();
		}

		#endregion

		#region 数据库数据获取

		/// <summary>
		/// 获取表名
		/// </summary>
		/// <param name="tType">表类型</param>
		/// <returns>表名</returns>
		string getTableName(Type tType) {
			foreach (var table in tables)
				if (table.type == tType)
					return table.tableName;
			return "";
		}

		/// <summary>
		/// 获取数据源对象
		/// </summary>
		/// <param name="tType">表类型</param>
		/// <returns>数据源对象</returns>
		DataTable getDataSource(Type tType) {

			var dbType = exermon_managerDataSet.GetType();

			var tName = getTableName(tType);
			var tInfo = dbType.GetProperty(tName);

			return tInfo?.GetValue(exermon_managerDataSet) as DataTable;
		}

		/// <summary>
		/// 获取数据适配器
		/// </summary>
		/// <param name="tType">表类型</param>
		/// <returns>数据源对象</returns>
		object getDataAdapter(Type tType) {

			var name = getTableName(tType);
			name = string.Format(AdapterNameFormat, name);

			var tInfo = GetType().GetField(name, 
				ReflectionUtils.DefaultFlag);

			return tInfo?.GetValue(this);
		}

		/// <summary>
		/// 适配器调用类型
		/// </summary>
		public enum AdapterCallType {
			Fill, Update
		}

		/// <summary>
		/// 获取数据适配器
		/// </summary>
		/// <param name="tType">表类型</param>
		/// <returns>数据源对象</returns>
		void callDataAdapter(Type tType, AdapterCallType cType) {
			var adapter = getDataAdapter(tType);
			var source = getDataSource(tType);

			callDataAdapter(adapter, cType, source);
		}
		void callDataAdapter(Type tType, AdapterCallType cType, DataTable source) {
			var adapter = getDataAdapter(tType);

			callDataAdapter(adapter, cType, source);
		}
		void callDataAdapter(Type tType, object adapter, AdapterCallType cType) {
			var source = getDataSource(tType);

			callDataAdapter(adapter, cType, source);
		}
		void callDataAdapter(object adapter, AdapterCallType cType, DataTable source) {

			var aType = adapter.GetType();
			var mInfo = aType.GetMethod(cType.ToString(),
				new Type[] { source.GetType() });

			mInfo.Invoke(adapter, new object[] { source });
		}

		#endregion

	}
}
