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

	using Scripts.Forms;
	using Scripts.Entities;
	using Scripts.Utils;

	/// <summary>
	/// 测试窗口
	/// </summary>
	public partial class MainForm2 : Form {

		/// <summary>
		/// 按钮文本
		/// </summary>
		//const string SourceNameFormat = "{0}BindingSource";

		/// <summary>
		/// 构造函数
		/// </summary>
		public MainForm2() {
			DBManager.initialize();
			InitializeComponent();
		}

		/// <summary>
		/// 析构函数
		/// </summary>
		~MainForm2() {
			DBManager.terminate();
		}

		#region 默认事件

		private void TestForm_Load(object sender, EventArgs e) {
			setupDataView();
			setupTableCombox();
		}

		private void tableCombox_SelectedIndexChanged(object sender, EventArgs e) {
			saveTables();
			setupDataView(currentTableInfo);
		}

		private void saveData_Click(object sender, EventArgs e) {
			saveTables();
		}
		
		#endregion

		#region 快捷数据获取

		/// <summary>
		/// 数据库
		/// </summary>
		public CoreContext db => DBManager.db;

		/// <summary>
		/// 表类型列表
		/// </summary>
		public List<TableInfo> tables => DBManager.tables;

		/// <summary>
		/// 当前数据表
		/// </summary>
		public TableInfo currentTableInfo => tableCombox.SelectedValue as TableInfo;

		#endregion

		#region 配置控件

		/// <summary>
		/// 配置数据表
		/// </summary>
		void setupDataView() {
			dataView.onSave = saveTables;
			dataView.onDelete = deleteItem;
			dataView.onEditCell = editSubItems;
		}

		/// <summary>
		/// 初始化数据库表下拉框
		/// </summary>
		void setupTableCombox() {
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
			dataView.setup(table, bindingSource);
		}

		#endregion

		#region 数据库操作

		/// <summary>
		/// 更改子数据
		/// </summary>
		public void editSubItems(PropertyInfo prop, CoreEntity root) {
			var form = SubFormManager.startSubForm(prop, root);
			form.Show();
		}

		/// <summary>
		/// 填充所有数据
		/// </summary>
		public void deleteItem(object item) {
			currentTableInfo?.delete(item);
		}
		
		/// <summary>
		/// 填充所有数据
		/// </summary>
		public void saveTables() {
			dataView.EndEdit();
			bindingSource.EndEdit();

			DBManager.saveTables();
		}

		#endregion

		#region 数据库数据获取

		///// <summary>
		///// 获取表名
		///// </summary>
		///// <param name="tType">表类型</param>
		///// <returns>表名</returns>
		//string getTableName(Type tType) {
		//	foreach (var table in tables)
		//		if (table.type == tType)
		//			return table.tableName;
		//	return "";
		//}

		///// <summary>
		///// 获取数据源对象
		///// </summary>
		///// <param name="tType">表类型</param>
		///// <returns>数据源对象</returns>
		//BindingSource getDataSource(Type tType) {
		//	var name = getTableName(tType);
		//	name = string.Format(SourceNameFormat, name);

		//	var tInfo = GetType().GetField(name, ReflectionUtils.DefaultFlag);

		//	return tInfo?.GetValue(this) as BindingSource;
		//}

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
