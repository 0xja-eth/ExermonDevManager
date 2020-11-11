using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using System.Windows.Forms;

namespace ExermonDevManager.Scripts.Controls {

	using Data;
	using Entities;
	using Utils;

	public partial class ExerDataGridView : DataGridView {

		/// <summary>
		/// 常量配置
		/// </summary>
		const string DataButtonText = "修改";
		const string HeaderTextFormat = "{0}({1})";

		/// <summary>
		/// 回调设置
		/// </summary>
		public Action onSave;
		public Action<object> onDelete;
		public Action<PropertyInfo, CoreEntity> onEditCell;

		/// <summary>
		/// 构造函数
		/// </summary>
		public ExerDataGridView() {
			InitializeComponent();
			if (DesignMode) return;
			initialize();
		}

		#region 初始化

		/// <summary>
		/// 初始化
		/// </summary>
		void initialize() {
			PreviewKeyDown += previewKeyDown;
			CellValueChanged += cellValueChanged;
			CellContentClick += cellContentClick;
			UserDeletingRow += userDeletingRow;
			DataError += dataError;
		}

		void previewKeyDown(object sender, PreviewKeyDownEventArgs e) {
			if (e.Control) 
				switch (e.KeyCode) {
					case Keys.V: paste(); break;
					case Keys.S: onSave?.Invoke(); break;
				}
		}

		void cellValueChanged(object sender, DataGridViewCellEventArgs e) {
			if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

			var row = Rows[e.RowIndex];
			var cell = row.Cells[e.ColumnIndex];

			if (cell.Selected) refreshRow(row);
		}

		void cellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

			var row = Rows[e.RowIndex];
			var cell = row.Cells[e.ColumnIndex];

			(cell.Tag as Action)?.Invoke();
		}

		void userDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
			onDelete?.Invoke(e.Row.DataBoundItem);
		}

		void dataError(object sender, DataGridViewDataErrorEventArgs e) {
			Console.WriteLine("dataError: " + e);
		}

		#endregion

		/// <summary>
		/// 配置数据视图
		/// </summary>
		/// <param name="tableType"></param>
		public void setItems(TableInfo table, BindingSource source) {
			setItems(table?.type, table?.items, source);
		}
		public void setItems(CoreEntity root, PropertyInfo prop, BindingSource source) {
			var type = prop.PropertyType.GetGenericArguments()[0];
			var items = prop.GetValue(root) as IList;

			setItems(type, items, source);
		}
		public void setItems(Type type, IList items, BindingSource source) {
			source.DataSource = items; DataSource = source;

			createColumns(type); refreshRows();
		}

		#region 列控制

		/// <summary>
		/// 生成所有列
		/// </summary>
		/// <param name="tType"></param>
		public void createColumns(Type tType) {
			Columns.Clear();

			if (tType == null) return;
			var attrs = CoreData.getFieldSettings(tType);

			foreach (var attr in attrs) {
				var prop = attr.memberInfo as PropertyInfo;
				if (prop == null) continue;

				Columns.Add(createColumn(prop, attr));
			}
		}

		/// <summary>
		/// 生成列
		/// </summary>
		/// <param name="attr"></param>
		/// <param name="prop"></param>
		/// <returns></returns>
		DataGridViewColumn createColumn(PropertyInfo prop, 
			CoreData.ControlFieldAttribute attr) {
			var type = prop.PropertyType;

			DataGridViewColumn res;

			if (type == typeof(bool)) // 布尔值
				res = createCheckboxCol(prop);
			else if (type == typeof(int)) // 数值
				res = createNumbericCol(prop);
			else if (type.IsEnum) // 枚举值
				res = createEnumCol(prop, type);
			else if (type.IsSubclassOf(typeof(CoreEntity))) // 下拉框
				res = createComboxCol(prop, type);
			else if (type.Name == typeof(List<>).Name) // 联查
				res = createButtonCol(prop);
			else // 默认
				res = createTextBoxCol(prop);

			res.HeaderText = string.Format(
				HeaderTextFormat, attr.name, prop.Name);

			return res;
		}

		#region 具体列处理

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
		/// 枚举信息
		/// </summary>
		struct EnumInfo {

			public int value { get; set; }
			public string name { get; set; }

			public string displayName => value + ". " + name;

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
			foreach (int val in values)
				enums.Add(new EnumInfo(val, Enum.GetName(type, val)));

			res.DataSource = enums;
			res.DisplayMember = "displayName";
			res.ValueMember = "value";

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

			res.DataSource = DBManager.getItems(type);
			res.DisplayMember = "displayName";
			res.ValueMember = "id";

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
			res.DataPropertyName = "";
			res.Text = DataButtonText;
			res.Tag = prop;
			return res;
		}

		/// <summary>
		/// 创建数字输入列
		/// </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		DataGridViewColumn createNumbericCol(PropertyInfo prop) {
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
		DataGridViewColumn createTextBoxCol(PropertyInfo prop) {
			var res = new DataGridViewTextBoxColumn();
			res.DataPropertyName = prop.Name;
			return res;
		}

		#endregion

		#endregion

		#region 行控制

		/// <summary>
		/// 刷新所有行
		/// </summary>
		public void refreshRows() {
			foreach (DataGridViewRow row in Rows) refreshRow(row);
		}

		/// <summary>
		/// 刷新数据行
		/// </summary>
		public void refreshRow(DataGridViewRow row) {
			var data = row.DataBoundItem as CoreEntity;

			foreach (DataGridViewCell cell in row.Cells) refreshCell(cell, data);
		}

		/// <summary>
		/// 配置数据单元格
		/// </summary>
		/// <param name="cell"></param>
		public void refreshCell(DataGridViewCell cell) {
			var data = cell.OwningRow.DataBoundItem;
			refreshCell(cell, data as CoreEntity);
		}
		void refreshCell(DataGridViewCell cell, CoreEntity data) {
			var _ = refreshButtonCell(cell as DataGridViewButtonCell, data) ||
				refreshCheckboxCell(cell as DataGridViewCheckBoxCell, data) ||
				refreshComboxCell(cell as DataGridViewComboBoxCell, data);
		}

		#region 具体行处理

		/// <summary>
		/// 配置按钮单元格
		/// </summary>
		bool refreshButtonCell(DataGridViewButtonCell cell, CoreEntity data) {
			if (data == null || cell == null) return false;

			var col = cell.OwningColumn as DataGridViewButtonColumn;
			var prop = col.Tag as PropertyInfo;

			cell.Value = DataButtonText;

			if (onEditCell != null && prop != null) 
				cell.Tag = new Action(
					() => onEditCell.Invoke(prop, data)
				);
			else cell.Tag = null;

			return true;
		}

		/// <summary>
		/// 配置CheckBox单元格
		/// </summary>
		bool refreshCheckboxCell(DataGridViewCheckBoxCell cell, CoreEntity data) {
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
		bool refreshComboxCell(DataGridViewComboBoxCell cell, CoreEntity data) {
			if (cell == null) return false;

			var val = data?[cell.OwningColumn.DataPropertyName];
			var vType = val?.GetType();

			if (vType == typeof(int)) {
				if (val == null || (int)val <= 0) cell.Value = 1;
				else cell.Value = val;
			//} else if (vType == typeof(Enum)) {
			//	if (val == null) cell.Value = Enum.ToObject(vType, ;
			//	else cell.Value = val;
			}

			return true;
		}

		#endregion

		#endregion

		#region 复制功能

		/// <summary>
		/// 粘贴
		/// </summary>
		public int paste(bool cut = false) {
			try {
				var pasteText = Clipboard.GetText();

				if (string.IsNullOrEmpty(pasteText)) return -1;

				int rowNum = 0, colNum = 0;
				// 获得当前剪贴板内容的行、列数
				for (int i = 0; i < pasteText.Length; i++) {
					var c = pasteText[i];
					if (c == '\t') colNum++;
					else if (c == '\n') rowNum++;
				}

				object[,] data;
				// 粘贴板上的数据来自于EXCEL时，每行末都有\n，在DATAGRIDVIEW内复制时，最后一行末没有\n
				if (pasteText.Last() == '\n') rowNum--;

				colNum /= rowNum + 1;
				data = new object[rowNum + 1, colNum + 1];

				string rowStr;

				// 对数组赋值
				for (int i = 0; i < (rowNum + 1); i++) {
					for (int c = 0; c < (colNum + 1); c++) {
						rowStr = null;
						//一行中的最后一列
						if (c == colNum && pasteText.IndexOf("\r") != -1)
							rowStr = pasteText.Substring(0, pasteText.IndexOf("\r"));

						//最后一行的最后一列
						if (c == colNum && pasteText.IndexOf("\r") == -1)
							rowStr = pasteText.Substring(0);

						//其他行列
						if (c != colNum) {
							rowStr = pasteText.Substring(0, pasteText.IndexOf("\t"));
							pasteText = pasteText.Substring(pasteText.IndexOf("\t") + 1);
						}
						if (rowStr == string.Empty) rowStr = null;

						data[i, c] = rowStr;
					}
					//截取下一行数据
					pasteText = pasteText.Substring(pasteText.IndexOf("\n") + 1);
				}

				/*检测值是否是列头*/
				/*
                //获取当前选中单元格所在的列序号
                int columnindex = CurrentRow.Cells.IndexOf(CurrentCell);
                //获取获取当前选中单元格所在的行序号
                int rowindex = CurrentRow.Index;
				*/

				int colIndex = -1, rowIndex = -1;
				int colIndexTmp = -1, rowIndexTmp = -1;

				if (SelectedCells.Count != 0) {
					colIndexTmp = SelectedCells[0].ColumnIndex;
					rowIndexTmp = SelectedCells[0].RowIndex;
				}

				// 取到最左上角的 单元格编号
				foreach (DataGridViewCell cell in SelectedCells) {

					colIndex = cell.ColumnIndex;
					if (colIndex > colIndexTmp)
						colIndex = colIndexTmp; // 交换
					else
						colIndexTmp = colIndex;

					rowIndex = cell.RowIndex;
					if (rowIndex > rowIndexTmp) 
						rowIndex = rowIndexTmp;
					else
						rowIndexTmp = rowIndex;
				}

				//if (type == -1) colIndex = rowIndex = 0;

				// 如果行数超过当前列表行数
				if (rowIndex + rowNum + 1 > RowCount) {
					int mm = rowNum + rowIndex + 1 - RowCount;
					for (int j = 0; j < mm + 1; j++) {
						//DataBindings.Clear();
						Rows.Add(new DataGridViewRow());
					}
				}

				// 如果列数超过当前列表列数
				//if (colIndex + colNum + 1 > ColumnCount) {
				//	int mmm = colNum + colIndex + 1 - ColumnCount;
				//	for (int j = 0; j < mmm; j++) {
				//		DataBindings.Clear();
				//		var col = new DataGridViewTextBoxColumn();
				//		Columns.Insert(colIndex + 1, col);
				//	}
				//}

				//增加超过的行列
				for (int j = 0; j < (rowNum + 1); j++) 
					for (int c = 0; c < (colNum + 1); c++) 
						if (c + colIndex < Columns.Count) {
							//var col = Columns[c + colIndex];
							var row = Rows[j + rowIndex];
							var cell = row.Cells[c + colIndex];

							cell.Value = data[j, c];
							cell.Selected = true;
							//if (cell.ReadOnly == false) {
							//}
							//if (col.CellType.Name == "DataGridViewTextBoxCell")
						}

				//清空剪切板内容
				if (cut) Clipboard.Clear();

				return 1;
			} catch {
				return -1;
			}
		}

		#endregion

		#region 数据获取

		/// <summary>
		/// 当前数据
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public CoreEntity currentItem() {
			var source = DataSource as BindingSource;
			return source.Current as CoreEntity;
		}

		/// <summary>
		/// 当前数据
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T currentItem<T>() where T : CoreEntity {
			var source = DataSource as BindingSource;
			return source.Current as T;
		}

		/// <summary>
		/// 是否为空
		/// </summary>
		/// <returns></returns>
		public bool isEmpty() {
			var source = DataSource as BindingSource;
			return source.Count <= 0;
		}

		#endregion

	}
}
