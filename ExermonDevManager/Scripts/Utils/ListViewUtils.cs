//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using System.Windows.Forms;

//namespace ExermonDevManager.Scripts.Utils {

//	using Data;

//	/// <summary>
//	/// 列表视图工具类
//	/// </summary>
//	public static class ListViewUtils {

//		#region 获取相关

//		/// <summary>
//		/// 获取项数
//		/// </summary>
//		/// <returns></returns>
//		public static int itemCount(ListView control) {
//			return control.Items.Count;
//		}

//		/// <summary>
//		/// 获取项数
//		/// </summary>
//		/// <returns></returns>
//		public static int itemDataCount<T>(ListView control) 
//			where T: ControlData {
//			var objects = control.Tag as List<T>;
//			if (objects == null) return 0;
//			return objects.Count;
//		}

//		/// <summary>
//		/// 获取选中项数
//		/// </summary>
//		/// <returns></returns>
//		public static int selectedItemCount(ListView control) {
//			return control.SelectedItems.Count;
//		}

//		/// <summary>
//		/// 获取选择项数
//		/// </summary>
//		/// <returns></returns>
//		public static int checkedItemCount(ListView control) {
//			return control.CheckedItems.Count;
//		}

//		/// <summary>
//		/// 获取项
//		/// </summary>
//		/// <returns></returns>
//		public static ListViewItem getItem(ListView control, int index) {
//			if (index < 0) return null;

//			var cnt = itemCount(control);
//			if (cnt <= 0) return null;

//			index = adjustIndex(index, cnt - 1);
//			return control.Items[index];
//		}
//		public static ListViewItem getItem<T>(ListView control, T item) 
//			where T : ControlData {
//			return getItem(control, getIndex(control, item));
//		}

//		/// <summary>
//		/// 获取选中项
//		/// </summary>
//		/// <returns></returns>
//		public static ListViewItem getSelectedItem(ListView control, int index = 0) {
//			if (index < 0) return null;

//			var cnt = selectedItemCount(control);
//			if (cnt <= 0) return null;

//			index = adjustIndex(index, cnt - 1);
//			//index = Math.Min(Math.Max(index, 0), cnt - 1);
//			return control.SelectedItems[index];
//		}

//		/// <summary>
//		/// 获取选中项索引
//		/// </summary>
//		/// <returns></returns>
//		public static int getSelectedIndex(ListView control, int index = 0) {
//			if (index < 0) return -1;

//			var cnt = selectedItemCount(control);
//			if (cnt <= 0) return -1;

//			index = adjustIndex(index, cnt - 1);
//			//index = Math.Min(Math.Max(index, 0), cnt - 1);
//			return control.SelectedIndices[index];
//		}

//		/// <summary>
//		/// 获取选择项
//		/// </summary>
//		/// <returns></returns>
//		public static ListViewItem getCheckedItem(ListView control, int index = 0) {
//			if (index < 0) return null;

//			var cnt = checkedItemCount(control);
//			if (cnt <= 0) return null;

//			index = adjustIndex(index, cnt - 1);
//			//index = Math.Min(Math.Max(index, 0), cnt - 1);
//			return control.CheckedItems[index];
//		}

//		/// <summary>
//		/// 获取选择项索引
//		/// </summary>
//		/// <returns></returns>
//		public static int getCheckedIndex(ListView control, int index = 0) {
//			if (index < 0) return -1;

//			var cnt = checkedItemCount(control);
//			if (cnt <= 0) return -1;

//			index = adjustIndex(index, cnt - 1);
//			//index = Math.Min(Math.Max(index, 0), cnt - 1);
//			return control.CheckedIndices[index];
//		}

//		/// <summary>
//		/// 调整索引
//		/// </summary>
//		/// <returns></returns>
//		public static int adjustIndex(int index, int cnt) {
//			return Math.Min(Math.Max(index, 0), cnt);
//		}

//		#endregion

//		#region 选择/选中

//		/// <summary>
//		/// 选中
//		/// </summary>
//		public static void select(ListView control, int index) {
//			var item = getItem(control, index);
//			if (item != null) item.Selected = true;
//		}
//		public static void select<T>(ListView control, T obj) 
//			where T : ControlData{
//			var item = getItem(control, obj);
//			if (item != null) item.Selected = true;
//		}
//		public static void select(ListView control) {
//			foreach (ListViewItem item in control.Items)
//				item.Selected = true;
//		}

//		/// <summary>
//		/// 取消选中
//		/// </summary>
//		public static void deselect(ListView control, int index) {
//			var item = getItem(control, index);
//			if (item != null) item.Selected = false;
//		}
//		public static void deselect<T>(ListView control, T obj)
//			where T : ControlData {
//			var item = getItem(control, obj);
//			if (item != null) item.Selected = false;
//		}
//		public static void deselect(ListView control) {
//			foreach (ListViewItem item in control.Items)
//				item.Selected = false;
//		}

//		/// <summary>
//		/// 选择
//		/// </summary>
//		public static void check(ListView control, int index) {
//			var item = getItem(control, index);
//			if (item != null) item.Checked = true;
//		}
//		public static void check<T>(ListView control, T obj)
//			where T : ControlData {
//			var item = getItem(control, obj);
//			if (item != null) item.Checked = true;
//		}
//		public static void check(ListView control) {
//			foreach (ListViewItem item in control.Items)
//				item.Checked = true;
//		}

//		/// <summary>
//		/// 取消选则
//		/// </summary>
//		public static void uncheck(ListView control, int index) {
//			var item = getItem(control, index);
//			if (item != null) item.Checked = false;
//		}
//		public static void uncheck<T>(ListView control, T obj)
//			where T : ControlData {
//			var item = getItem(control, obj);
//			if (item != null) item.Checked = false;
//		}
//		public static void uncheck(ListView control) {
//			foreach (ListViewItem item in control.Items)
//				item.Checked = false;
//		}

//		#endregion

//		#region 数据相关

//		#region 数据获取

//		/// <summary>
//		/// 获取项数据
//		/// </summary>
//		/// <returns></returns>
//		public static T getData<T>(ListView control, int index)
//			where T : ControlData {
//			if (index < 0) return null;

//			var cnt = itemDataCount<T>(control);
//			if (cnt <= 0) return null;

//			var objects = control.Tag as List<T>;

//			index = adjustIndex(index, cnt - 1);
//			//index = Math.Min(Math.Max(index, 0), cnt - 1);
//			return objects[index];
//		}

//		/// <summary>
//		/// 获取选择的数据
//		/// </summary>
//		/// <typeparam name="T"></typeparam>
//		/// <param name="control"></param>
//		/// <param name="index"></param>
//		/// <returns></returns>
//		public static T getSelectedData<T>(ListView control, int index = 0)
//			where T : ControlData {
//			var dataId = getSelectedIndex(control, index);
//			if (dataId < 0) return null;

//			return getData<T>(control, dataId);
//		}

//		/// <summary>
//		/// 获取选中的数据
//		/// </summary>
//		/// <typeparam name="T"></typeparam>
//		/// <param name="control"></param>
//		/// <param name="index"></param>
//		/// <returns></returns>
//		public static T getCheckedData<T>(ListView control, int index = 0)
//			where T : ControlData {
//			var dataId = getCheckedIndex(control, index);
//			if (dataId < 0) return null;

//			return getData<T>(control, dataId);
//		}

//		/// <summary>
//		/// 获取项索引
//		/// </summary>
//		/// <returns></returns>
//		public static int getIndex<T>(ListView control, T obj)
//			where T : ControlData {
//			var objects = control.Tag as List<T>;
//			if (objects == null) return -1;
//			return objects.IndexOf(obj);
//		}

//		#endregion

//		#region 数据配置/绑定

//		/// <summary>
//		/// 设置列表数据
//		/// </summary>
//		public static void setupColumns<T>(ListView control)
//			where T : ControlData {
//			control.Columns.Clear();

//			var fields = ControlData.getFieldSettings(typeof(T));
//			foreach (var field in fields)
//				control.Columns.Add(field.name, field.width);
//		}

//		/// <summary>
//		/// 设置列表组
//		/// </summary>
//		public static void setupGroups<T>(ListView control)
//			where T : ControlData {
//			setupGroups(control, BaseData.poolGet<T>());
//		}
//		public static void setupGroups<T>(ListView control, List<T> objects)
//			where T : ControlData {
//			control.Groups.Clear();

//			foreach (var obj in objects)
//				control.Groups.Add(obj.id.ToString(), obj.groupText());
//		}

//		/// <summary>
//		/// 设置列表数据
//		/// </summary>
//		public static void setupItems<T>(ListView control,
//			string blank = null) where T : ControlData {
//			setupItems(control, BaseData.poolGet<T>(), blank);
//		}
//		public static void setupItems<T>(ListView control,
//			List<T> objects, string blank = null) where T : ControlData {
//			control.Items.Clear();

//			bind(control, objects);
//			updateItems<T>(control, blank);
//		}

//		/// <summary>
//		/// 绑定
//		/// </summary>
//		public static void bind<T>(ListView control) where T : ControlData {
//			bind(control, BaseData.poolGet<T>());
//		}
//		public static void bind<T>(ListView control, List<T> objects) where T : ControlData {
//			control.Tag = objects;
//		}

//		#endregion

//		#region 数据更新

//		/// <summary>
//		/// 更新列表数据
//		/// </summary>
//		public static void updateItems<T>(ListView control,
//			string blank = null) where T : ControlData {

//			var objects = control.Tag as List<T>;
//			if (objects == null) objects = new List<T>();

//			int oriItemCnt = control.Items.Count;
//			int newItemCnt = objects.Count;

//			// 首先枚举现有项，并进行更新
//			for (int i = oriItemCnt - 1; i >= 0; --i)
//				if (i >= newItemCnt) // 多余项
//					control.Items.RemoveAt(i);
//				else
//					updateItem(control,
//						control.Items[i], objects[i]);

//			// 添加新项
//			for (int i = oriItemCnt; i < newItemCnt; ++i)
//				createItem(control, objects[i]);

//			if (blank != null) control.Items.Add(blank);
//		}

//		/// <summary>
//		/// 更新项
//		/// </summary>
//		public static void updateItem<T>(ListView control,
//			ListViewItem item, T obj) where T : ControlData {
//			var data = obj.getFieldData();
//			var groupKey = obj.groupKey();

//			var text = data[0].value ?? "空";
//			if (text == "") text = "空";
//			item.Text = text;

//			//item.SubItems.Clear();
//			for (int i = 1; i < data.Count; ++i) {
//				text = data[i].value ?? "-";
//				if (text == "") text = "-";
//				if (i < item.SubItems.Count)
//					item.SubItems[i].Text = text;
//				else
//					item.SubItems.Add(text);
//			}

//			if (groupKey != null)
//				item.Group = control.Groups[groupKey];
//		}

//		/// <summary>
//		/// 创建项
//		/// </summary>
//		public static void createItem<T>(ListView control,
//			T obj) where T : ControlData {
//			var data = obj.getFieldData();
//			var item = control.Items.Add(data[0].value);
//			updateItem(control, item, obj);
//		}

//		/// <summary>
//		/// 更新项
//		/// </summary>
//		public static void updateCurrentItem<T>(
//			ListView control) where T : ControlData {
//			if (control.SelectedIndices.Count <= 0) return;

//			var index = control.SelectedIndices[0];
//			var objects = control.Tag as List<T>;
//			var item = control.Items[index];

//			if (index < objects.Count)
//				updateItem(control, item, objects[index]);
//		}

//		#endregion

//		#endregion
//	}
//}
