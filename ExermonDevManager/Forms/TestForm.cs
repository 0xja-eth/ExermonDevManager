using System;
using System.Collections.Generic;
using System.Reflection;
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

		/// <summary>
		/// 数据库连接
		/// </summary>
		CoreContext db;

		/// <summary>
		/// 表类型列表
		/// </summary>
		public List<TableInfo> tables = new List<TableInfo>();

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
		}

		private void tableCombox_SelectedIndexChanged(object sender, EventArgs e) {
			setupDataView(tableCombox.SelectedValue as TableInfo);
		}

		#endregion

		#region 初始化

		/// <summary>
		/// 初始化表格数据
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
			//tableCombox.ValueMember = "type";
		}

		/// <summary>
		/// 配置数据视图
		/// </summary>
		/// <param name="tableType"></param>
		void setupDataView(TableInfo table) {
			if (table == null) 
				dataView.DataSource = null;
			else {
				dataView.DataSource = getDataSource(table.type);
				setupDataViewCols(table.type);
			}
		}

		/// <summary>
		/// 配置数据视图列
		/// </summary>
		/// <param name="tType"></param>
		void setupDataViewCols(Type tType) {
			dataView.Columns.Clear();

			var attrs = CoreData.getFieldSettings(tType);

			foreach(var attr in attrs) {
				var prop = attr.memberInfo as PropertyInfo;
				if (prop == null) return;

				var type = prop.PropertyType;

				DataGridViewColumn col;

				if (type == typeof(bool)) // 布尔值
					col = createCheckboxCol(prop);
				else if (type.IsEnum) // 枚举值
					col = createEnumCol(prop, type);
				else if (type.IsSubclassOf(typeof(CoreEntity))) // 下拉框
					col = createComboxCol(prop, type);
				else if (type.Name == typeof(List<>).Name) // 联查
					col = createButtonCol(prop);
				else // 默认
					col = createTextBoxCol(prop);

				col.HeaderText = string.Format(
					HeaderTextFormat, attr.name, prop.Name);

				dataView.Columns.Add(col);
			}
		}

		/// <summary>
		/// 创建CheckBox列
		/// </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		DataGridViewColumn createCheckboxCol(PropertyInfo prop) {
			var res = new DataGridViewCheckBoxColumn();
			res.DataPropertyName = prop.Name;
			return res;
		}

		/// <summary>
		/// 创建下拉框列
		/// </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		DataGridViewColumn createComboxCol(PropertyInfo prop, Type type) {
			var res = new DataGridViewComboBoxColumn();

			res.DataSource = getDataSource(type);
			res.DataPropertyName = prop.Name + "Id";

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
		DataGridViewColumn createEnumCol(PropertyInfo prop, Type type) {
			var res = new DataGridViewComboBoxColumn();

			var enums = new List<EnumInfo>();
			var values = Enum.GetValues(type);
			foreach(int val in values) 
				enums.Add(new EnumInfo(val, Enum.GetName(type, val)));

			res.DataSource = enums;
			res.DisplayMember = "name";
			res.ValueMember = "value";

			res.DataPropertyName = prop.Name + "Id";

			return res;
		}

		/// <summary>
		/// 创建按钮列
		/// </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		DataGridViewColumn createButtonCol(PropertyInfo prop) {
			var res = new DataGridViewButtonColumn();
			res.Text = DataButtonText;
			return res;
		}

		/// <summary>
		/// 创建文本框列
		/// </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		DataGridViewColumn createTextBoxCol(PropertyInfo prop) {
			var res = new DataGridViewTextBoxColumn();
			res.DataPropertyName = prop.Name;
			return res;
		}

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
		object getDataSource(Type tType) {
			var dbType = exermon_managerDataSet.GetType();

			var tName = getTableName(tType);
			var tInfo = dbType.GetProperty(tName);

			return tInfo?.GetValue(exermon_managerDataSet);
		}

		#endregion

	}
}
