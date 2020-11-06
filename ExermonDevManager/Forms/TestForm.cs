using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Windows.Forms;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel;

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

			public Type type { get; protected set; }
			public PropertyInfo prop { get; protected set; }

			public string tableName { get; protected set; }
			public string displayName { get; protected set; }

			public IEnumerable items { get; protected set; }
			public BindingSource source { get; protected set; }

			/// <summary>
			/// 构造函数
			/// </summary>
			public TableInfo(PropertyInfo prop, string name, Type type) {
				this.type = type; this.prop = prop;

				tableName = prop.Name.ToLower();
				displayName = string.Format(HeaderTextFormat, name, tableName);
			}

			/// <summary>
			/// 读取数据
			/// </summary>
			/// <param name="db"></param>
			public void loadData(CoreContext db) {
				var dbSet = prop.GetValue(db);
				
				var eType = typeof(Enumerable);
				var flags = ReflectionUtils.DefaultFlag | BindingFlags.Static;

				var mInfo = eType.GetMethod("ToList", flags);
				mInfo = mInfo.MakeGenericMethod(new Type[] { type });

				items = mInfo.Invoke(null, new object[] { dbSet }) as IEnumerable;
			}

			/// <summary>
			/// 绑定源
			/// </summary>
			/// <param name="source"></param>
			public void bindSource(BindingSource source) {
				this.source = source;
				source.DataSource = items;
			}
		}

		/// <summary>
		/// 按钮文本
		/// </summary>
		const string DataButtonText = "修改";
		const string HeaderTextFormat = "{0}({1})";

		const string AdapterNameFormat = "{0}TableAdapter";
		const string SourceNameFormat = "{0}BindingSource";

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
			saveTables();
			setupDataView(currentTableInfo);
		}

		private void dataView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
			Console.WriteLine("dataView_RowsAdded: " + 
				e.RowIndex + ", " + e.RowCount);
		}

		private void dataView_UserAddedRow(object sender, DataGridViewRowEventArgs e) {
			Console.WriteLine("dataView_UserAddedRow: " + e.Row);
		}

		private void dataView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e) {
			Console.WriteLine("dataView_RowStateChanged: " + 
				e.Row + ", " + e.StateChanged);
		}

		private void dataView_SelectionChanged(object sender, EventArgs e) {
			Console.WriteLine("dataView_SelectionChanged: " + e);
		}

		private void dataView_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e) {
			Console.WriteLine("dataView_CellStateChanged: " + 
				e.Cell + ", " + e.StateChanged);
		}

		private void dataView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
			Console.WriteLine("dataView_CellValueChanged: " +
				e.RowIndex + ", " + e.ColumnIndex);

			if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

			var row = dataView.Rows[e.RowIndex];
			var cell = row.Cells[e.ColumnIndex];

			if (cell.Selected) setupDataRow(row);
		}

		private void dataView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			Console.WriteLine("dataView_CellContentClick: " +
				e.RowIndex + ", " + e.ColumnIndex);

			if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
			
			var row = dataView.Rows[e.RowIndex];
			var cell = row.Cells[e.ColumnIndex];

			(cell.Tag as Action)?.Invoke();
		}

		private void dataView_CurrentCellChanged(object sender, EventArgs e) {
			Console.WriteLine("dataView_CurrentCellChanged: " + 
				dataView.CurrentCell);
		}

		private void dataView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
			Console.WriteLine("dataView_DataBindingComplete: " + e.ListChangedType);
		}

		private void dataView_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
			Console.WriteLine("dataView_CellEndEdit: " + e);
		}

		private void dataView_DataSourceChanged(object sender, EventArgs e) {
			Console.WriteLine("dataView_DataSourceChanged: " + e);
		}

		private void dataView_DataError(object sender, DataGridViewDataErrorEventArgs e) {
			Console.WriteLine("dataView_DataError: " + e);
		}

		private void dataView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
			var item = e.Row.DataBoundItem;
			if (item != null) db.Remove(item);
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
					tables.Add(new TableInfo(p, a.name, tType));
				}
			);
		}

		/// <summary>
		/// 初始化数据库表下拉框
		/// </summary>
		void initializeTableCombox() {
			tableCombox.DataSource = tables;
			tableCombox.DisplayMember = "displayName";
			tableCombox.SelectedIndex = -1;
		}

		#endregion

		#region 数据视图配置

		/// <summary>
		/// 配置数据视图
		/// </summary>
		/// <param name="tableType"></param>
		void setupDataView(TableInfo table) {
			dataView.DataSource = table?.source;
			// getDataSource(table?.type);
			setupDataViewCols(table?.type);
			setupDataRows();
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
			else if (type == typeof(int)) // 数值
				res = genNumbericCol(prop);
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
		/// 创建数字输入列
		/// </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		DataGridViewColumn genNumbericCol(PropertyInfo prop) {
			var res = new DataGridViewTextBoxColumn();
			res.DataPropertyName = prop.Name;
			res.ValueType = typeof(int);
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
		/// 配置所有行
		/// </summary>
		void setupDataRows() {
			foreach (DataGridViewRow row in dataView.Rows)
				setupDataRow(row);
		}

		/// <summary>
		/// 配置数据行
		/// </summary>
		void setupDataRow(DataGridViewRow row) {
			var data = row.DataBoundItem as CoreEntity;

			foreach (DataGridViewCell cell in row.Cells)
				setupDataCell(cell, data);
		}

		/// <summary>
		/// 配置数据单元格
		/// </summary>
		/// <param name="cell"></param>
		void setupDataCell(DataGridViewCell cell, CoreEntity data) {
			var flag = setupButtonCell(cell as DataGridViewButtonCell, data) ||
				setupCheckboxCell(cell as DataGridViewCheckBoxCell, data) ||
				setupComboxCell(cell as DataGridViewComboBoxCell, data);
		}

		/// <summary>
		/// 配置按钮单元格
		/// </summary>
		bool setupButtonCell(DataGridViewButtonCell cell, CoreEntity data) {
			if (data == null || cell == null) return false;

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
		bool setupCheckboxCell(DataGridViewCheckBoxCell cell, CoreEntity data) {
			if (cell == null) return false;

			var val = data?[cell.OwningColumn.DataPropertyName];

			if (val == null) cell.Value = false;
			else cell.Value = (bool)val;

			return true;
		}

		/// <summary>
		/// 配置下拉框单元格
		/// </summary>
		/// <param name="cell"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		bool setupComboxCell(DataGridViewComboBoxCell cell, CoreEntity data) {
			if (cell == null) return false;

			var val = data?[cell.OwningColumn.DataPropertyName];

			if (val == null) cell.Value = 1;
			else cell.Value = val;

			return true;
		}

		#endregion

		#endregion

		#region 数据库操作

		/// <summary>
		/// 填充所有数据
		/// </summary>
		void fillTables() {
			foreach (var table in tables) {
				var source = getDataSource(table.type);
				table.loadData(db); table.bindSource(source);
			}
			//fillTable(table.type);
		}

		///// <summary>
		///// 填充单个数据
		///// </summary>
		///// <param name="tType"></param>
		//void fillTable(Type tType) {
		//	callDataAdapter(tType, AdapterCallType.Fill);
		//}

		/// <summary>
		/// 填充所有数据
		/// </summary>
		void saveTables() {
			dataView.EndEdit();

			foreach (var table in tables) {
				if (table.source == null) continue;

				table.source.EndEdit();

				foreach (var item in table.items)
					if (db.Entry(item).State == EntityState.Detached) db.Add(item);
			}

			db.SaveChanges();
		}

		///// <summary>
		///// 填充单个数据
		///// </summary>
		///// <param name="tType"></param>
		//void saveTable(Type tType) {
		//	var source = getDataSource(tType);
		//	callDataAdapter(tType, AdapterCallType.Update, source);
		//	source.AcceptChanges();
		//}

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

		///// <summary>
		///// 获取数据源对象
		///// </summary>
		///// <param name="tType">表类型</param>
		///// <returns>数据源对象</returns>
		//DataTable getDataSource(Type tType) {

		//	var dbType = exermon_managerDataSet.GetType();

		//	var tName = getTableName(tType);
		//	var tInfo = dbType.GetProperty(tName);

		//	return tInfo?.GetValue(exermon_managerDataSet) as DataTable;
		//}
		/// <summary>
		/// 获取数据源对象
		/// </summary>
		/// <param name="tType">表类型</param>
		/// <returns>数据源对象</returns>
		BindingSource getDataSource(Type tType) {
			var name = getTableName(tType);
			name = string.Format(SourceNameFormat, name);

			var tInfo = GetType().GetField(name, ReflectionUtils.DefaultFlag);

			return tInfo?.GetValue(this) as BindingSource;
		}

		///// <summary>
		///// 获取数据适配器
		///// </summary>
		///// <param name="tType">表类型</param>
		///// <returns>数据源对象</returns>
		//object getDataAdapter(Type tType) {

		//	var name = getTableName(tType);
		//	name = string.Format(AdapterNameFormat, name);

		//	var tInfo = GetType().GetField(name, 
		//		ReflectionUtils.DefaultFlag);

		//	return tInfo?.GetValue(this);
		//}

		///// <summary>
		///// 适配器调用类型
		///// </summary>
		//public enum AdapterCallType {
		//	Fill, Update
		//}

		///// <summary>
		///// 获取数据适配器
		///// </summary>
		///// <param name="tType">表类型</param>
		///// <returns>数据源对象</returns>
		//void callDataAdapter(Type tType, AdapterCallType cType) {
		//	var adapter = getDataAdapter(tType);
		//	var source = getDataSource(tType);

		//	callDataAdapter(adapter, cType, source);
		//}
		//void callDataAdapter(Type tType, AdapterCallType cType, DataTable source) {
		//	var adapter = getDataAdapter(tType);

		//	callDataAdapter(adapter, cType, source);
		//}
		//void callDataAdapter(Type tType, object adapter, AdapterCallType cType) {
		//	var source = getDataSource(tType);

		//	callDataAdapter(adapter, cType, source);
		//}
		//void callDataAdapter(object adapter, AdapterCallType cType, DataTable source) {

		//	var aType = adapter.GetType();
		//	var mInfo = aType.GetMethod(cType.ToString(),
		//		new Type[] { source.GetType() });

		//	mInfo.Invoke(adapter, new object[] { source });
		//}

		#endregion
	}
}
