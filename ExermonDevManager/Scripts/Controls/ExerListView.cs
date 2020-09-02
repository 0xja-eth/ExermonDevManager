using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExermonDevManager.Scripts.Controls {

	using Data;

	/// <summary>
	/// ExerListView控件
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public partial class ExerListView : ListView, IExerControl {

		/// <summary>
		/// 过滤函数
		/// </summary>
		public delegate bool FilterFunc(ControlData item);

		/// <summary>
		/// 数据
		/// </summary>
		public IList data;

		/// <summary>
		/// 数据索引
		/// </summary>
		public List<int> dataIndices = new List<int>();

		/// <summary>
		/// 过滤函数
		/// </summary>
		public FilterFunc filterFunc = null;

		/// <summary>
		/// 构造函数
		/// </summary>
		public ExerListView() {
			InitializeComponent();
		}

		#region 数据设定/配置

		/// <summary>
		/// 快捷配置全部
		/// </summary>
		public virtual void setupAll<T>() where T : ControlData {
			setupColumns<T>();
			setup<T>();
		}
		public virtual void setupAll<T>(List<T> data) where T : ControlData {
			setupColumns<T>();
			setup(data);
		}
		public virtual void setupAll<T, G>()
			where T : ControlData where G : ControlData {
			setupGroups<G>();
			setupColumns<T>();
			setup<T>();
		}
		public void setupAll<T, G>(List<T> data)
			where T : ControlData where G : ControlData {
			setupGroups<G>();
			setupColumns<T>();
			setup(data);
		}
		public void setupAll<T, G>(List<G> groupData, List<T> data)
			where T : ControlData where G : ControlData {
			setupGroups(groupData);
			setupColumns<T>();
			setup(data);
		}

		/// <summary>
		/// 配置（设定数据）
		/// </summary>
		public void setup<T>() where T : ControlData {
			setup(BaseData.poolGet<T>());
		}
		public void setup(IList data) {
			this.data = data; update();
			//updateList();
		}

		/// <summary>
		/// 设置列表组
		/// </summary>
		public void setupGroups<G>() where G : ControlData {
			setupGroups(BaseData.poolGet<G>());
		}
		public void setupGroups(IList data) {
			Groups.Clear();
			foreach (var item_ in data) {
				var item = item_ as ControlData;
				Groups.Add(item.id.ToString(), item.groupText());
			}
		}

		/// <summary>
		/// 配置列（固定）
		/// </summary>
		public void setupColumns<T>() where T : ControlData {
			Columns.Clear();

			var fields = ControlData.getFieldSettings(typeof(T));
			foreach (var field in fields)
				Columns.Add(field.name, field.width);
		}

		/// <summary>
		/// 是否包含某数据
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public virtual bool isInclude(ControlData item) {
			if (!item.isIncluded()) return false;
			if (filterFunc == null) return true;
			return filterFunc(item);
		}

		/// <summary>
		/// 注册更新事件
		/// </summary>
		/// <param name="event_"></param>
		public void registerUpdateEvent(EventHandler event_) { }

		/// <summary>
		/// 绑定数据
		/// </summary>
		/// <param name="data"></param>
		public virtual void bind(BaseData data) { }

		#endregion

		#region 数据操作

		/// <summary>
		/// 添加数据
		/// </summary>
		/// <param name="item"></param>
		public void addData(ControlData item) {
			var index = data.IndexOf(item);
			if (index >= 0) return;

			dataIndices.Add(dataCount());
			data.Add(item);

			update(); select(dataCount() - 1);
		}

		/// <summary>
		/// 添加数据
		/// </summary>
		/// <param name="item"></param>
		public void removeData(ControlData item) {
			var index = data.IndexOf(item);
			if (index < 0) return;

			dataIndices.Remove(index);
			data.RemoveAt(index);

			update();
		}

		/// <summary>
		/// 复制数据
		/// </summary>
		/// <param name="item"></param>
		public void copyData(ControlData item) {
			addData(item.copy(false) as ControlData);
			select(dataCount() - 1);
		}

		/// <summary>
		/// 交换数据
		/// </summary>
		/// <param name="item"></param>
		public void swapData(ControlData data, int delta) {
			var from = getIndex(data);
			swapData(from, from + delta);
			select(getCurrentIndex() + delta);
		}
		public void swapData(int from, int to) {
			if (from == to) return;

			var fDataIndex = getDataIndex(from);
			var tDataIndex = getDataIndex(to);

			var fData = getDataByDataIndex(fDataIndex);
			var tData = getDataByDataIndex(tDataIndex);

			if (fData == null || tData == null) return;

			tData.swapId(fData);
			data[fDataIndex] = tData;
			data[tDataIndex] = fData;

			update();
		}

		/// <summary>
		/// 清空数据
		/// </summary>
		public void clearData() {
			data.Clear(); update();
		}

		///// <summary>
		///// 更新并选择
		///// </summary>
		///// <param name="index"></param>
		//public void updateAndSelect(int index) {

		//}

		#endregion

		#region 数据获取
		/*
		 名词约定：
		 索引（index）：Items 中的索引
		 数据（data/item）: data 中的值，函数名用 data 表示，内部用 item 表示
		 数据索引（dataIndex）: dataIndices 中的值
		*/

		/// <summary>
		/// 项目数量
		/// </summary>
		/// <returns></returns>
		public int itemsCount() {
			return Items.Count;
		}

		/// <summary>
		/// 数据数量
		/// </summary>
		/// <returns></returns>
		public int dataCount(bool full = false) {
			if (data == null) return 0;
			return full ? data.Count : dataIndices.Count;
		}

		/// <summary>
		/// 是否为空
		/// </summary>
		/// <returns></returns>
		public bool isEmpty() {
			return dataCount(true) <= 0;
		}

		/// <summary>
		/// 选择项目数量
		/// </summary>
		/// <returns></returns>
		public int selectedItemsCount() {
			return SelectedItems.Count;
		}

		/// <summary>
		/// 选中项目数量
		/// </summary>
		/// <returns></returns>
		public int checkedItemsCount() {
			return CheckedItems.Count;
		}

		#region 获取数据

		/// <summary>
		/// 索引 => 数据
		/// </summary>
		/// <param name="index">选择索引</param>
		/// <returns></returns>
		public ControlData getData(int index) {
			if (isEmpty() || index == -1) return null;
			return getDataByDataIndex(getDataIndex(index));
		}
		public T getData<T>(int index) where T : ControlData {
			return getData(index) as T;
		}

		/// <summary>
		/// 索引 => 列表项
		/// </summary>
		/// <param name="index">选择索引下标</param>
		/// <returns></returns>
		public ListViewItem getListItem(int index = 0) {
			if (isEmpty() || index == -1) return null;
			index = adjustIndex(index, itemsCount());
			return Items[index];
		}

		/// <summary>
		/// 选择索引下标 => 索引
		/// </summary>
		/// <param name="sIndex">选择索引下标</param>
		/// <returns></returns>
		public int getSelectedIndex(int sIndex = 0) {
			if (isEmpty() || sIndex == -1) return -1;
			var cnt = selectedItemsCount();
			if (cnt <= 0) return -1;

			sIndex = adjustIndex(sIndex, cnt);

			return SelectedIndices[sIndex];
		}

		/// <summary>
		/// 选择索引下标 => 数据
		/// </summary>
		/// <param name="sIndex">选择索引下标</param>
		/// <returns></returns>
		public ControlData getSelectedData(int sIndex = 0) {
			var index = getSelectedIndex(sIndex);
			return getData(index);
		}
		public T getSelectedData<T>(int sIndex = 0) where T : ControlData {
			return getSelectedData(sIndex) as T;
		}

		/// <summary>
		/// 选中索引下标 => 索引
		/// </summary>
		/// <param name="cIndex">选择索引下标</param>
		/// <returns></returns>
		public int getCheckedIndex(int cIndex = 0) {
			if (isEmpty() || cIndex == -1) return -1;
			var cnt = checkedItemsCount();
			if (cnt <= 0) return -1;

			cIndex = adjustIndex(cIndex, cnt);

			return CheckedIndices[cIndex];
		}

		/// <summary>
		/// 选择索引下标 => 数据
		/// </summary>
		/// <param name="cIndex">选择索引下标</param>
		/// <returns></returns>
		public ControlData getCheckedData(int cIndex = 0) {
			var index = getCheckedIndex(cIndex);
			return getData(index);
		}
		public T getCheckedData<T>(int cIndex = 0) where T : ControlData {
			return getCheckedData(cIndex) as T;
		}

		/// <summary>
		/// 索引 => 数据索引
		/// </summary>
		/// <param name="index">选择索引</param>
		/// <returns></returns>
		protected int getDataIndex(int index) {
			if (isEmpty() || index == -1) return -1;
			index = adjustIndex(index, dataCount());
			return dataIndices[index];
		}

		/// <summary>
		/// 索引 => 数据
		/// </summary>
		/// <param name="index">数据索引</param>
		/// <returns></returns>
		protected ControlData getDataByDataIndex(int index) {
			if (isEmpty() || index == -1) return null;
			index = adjustIndex(index, dataCount(true));
			return data[index] as ControlData;
		}

		/// <summary>
		/// 获取当前数据
		/// </summary>
		/// <returns></returns>
		public ControlData getCurrentData() {
			return getSelectedData();
		}
		public T getCurrentData<T>() where T : ControlData {
			return getCurrentData() as T;
		}

		/// <summary>
		/// 获取当前数据ID
		/// </summary>
		/// <returns></returns>
		public int getCurrentDataId() {
			var curData = getCurrentData();
			if (curData == null) return -1;
			return curData.id;
		}

		/// <summary>
		/// 获取当前数据ID
		/// </summary>
		/// <returns></returns>
		public int getCurrentIndex() {
			return getSelectedIndex();
		}

		#endregion

		#region 获取选择索引

		/// <summary>
		/// 数据 => 选择索引
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int getIndex(ControlData item) {
			return dataIndices.FindIndex(
				index => getDataByDataIndex(index) == item);
		}

		/// <summary>
		/// 数据ID => 选择索引
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int getIndex(int itemId) {
			return dataIndices.FindIndex(
				index => getDataByDataIndex(index)?.id == itemId);
		}

		#endregion

		/// <summary>
		/// 调整索引
		/// </summary>
		int adjustIndex(int index, int cnt) {
			return Math.Max(Math.Min(index, cnt - 1), 0);
		}

		#endregion

		#region 选择操作

		/// <summary>
		/// 选择数据
		/// </summary>
		/// <param name="item"></param>
		public void select(ControlData item) {
			selectIndex(getIndex(item));
		}

		/// <summary>
		/// 选择数据ID
		/// </summary>
		/// <param name="itemId"></param>
		public void select(int itemId) {
			selectIndex(getIndex(itemId));
		}

		/// <summary>
		/// 全选
		/// </summary>
		public void select() {
			foreach (ListViewItem item in Items)
				item.Selected = true;
		}

		/// <summary>
		/// 选择选项ID
		/// </summary>
		/// <param name="itemId"></param>
		public void selectIndex(int index) {
			var item = getListItem(index);
			if (item == null) return;
			item.Selected = true;
		}

		/// <summary>
		/// 取消选择数据
		/// </summary>
		/// <param name="item"></param>
		public void deselect(ControlData item) {
			deselectIndex(getIndex(item));
		}

		/// <summary>
		/// 取消选择数据ID
		/// </summary>
		/// <param name="itemId"></param>
		public void deselect(int itemId) {
			deselectIndex(getIndex(itemId));
		}

		/// <summary>
		/// 全不选
		/// </summary>
		public void deselect() {
			foreach (ListViewItem item in Items)
				item.Selected = false;
		}

		/// <summary>
		/// 取消选择选项ID
		/// </summary>
		/// <param name="itemId"></param>
		public void deselectIndex(int index) {
			var item = getListItem(index);
			if (item == null) return;
			item.Selected = false;
		}

		#endregion

		#region 选中操作

		/// <summary>
		/// 选中数据
		/// </summary>
		/// <param name="item"></param>
		public void check(ControlData item) {
			checkIndex(getIndex(item));
		}

		/// <summary>
		/// 选中数据ID
		/// </summary>
		/// <param name="itemId"></param>
		public void check(int itemId) {
			checkIndex(getIndex(itemId));
		}

		/// <summary>
		/// 全选
		/// </summary>
		public void check() {
			foreach (ListViewItem item in Items)
				item.Checked = true;
		}

		/// <summary>
		/// 选中选项ID
		/// </summary>
		/// <param name="itemId"></param>
		public void checkIndex(int index) {
			var item = getListItem(index);
			if (item == null) return;
			item.Checked = true;
		}

		/// <summary>
		/// 取消选中数据
		/// </summary>
		/// <param name="item"></param>
		public void uncheck(ControlData item) {
			uncheckIndex(getIndex(item));
		}

		/// <summary>
		/// 取消选中数据ID
		/// </summary>
		/// <param name="itemId"></param>
		public void uncheck(int itemId) {
			uncheckIndex(getIndex(itemId));
		}

		/// <summary>
		/// 全不选
		/// </summary>
		public void uncheck() {
			foreach (ListViewItem item in Items)
				item.Checked = false;
		}

		/// <summary>
		/// 取消选中选项ID
		/// </summary>
		/// <param name="itemId"></param>
		public void uncheckIndex(int index) {
			var item = getListItem(index);
			if (item == null) return;
			item.Checked = false;
		}

		#endregion

		#region 更新

		/// <summary>
		/// 更新内容
		/// </summary>
		public void update() {
			updateList();
			updateItems();
		}

		/// <summary>
		/// 更新列表情况
		/// </summary>
		void updateList() {
			dataIndices.Clear();
			for (int i = 0; i < data.Count; ++i)
				if (isInclude(data[i] as ControlData))
					dataIndices.Add(i);
		}

		/// <summary>
		/// 更新内容
		/// </summary>
		public void updateItems() {
			int oldCnt = itemsCount();
			int newCnt = dataCount();

			// 遍历新项
			for (int i = 0; i < newCnt; ++i) {
				var item = getData(i);
				if (i >= oldCnt) createItem(item);
				else updateItem(Items[i], item);
			}

			// 删除剩余项
			for (int i = oldCnt - 1; i >= newCnt; --i)
				Items.RemoveAt(i);
		}

		/// <summary>
		/// 创建项
		/// </summary>
		/// <param name="item"></param>
		void createItem(ControlData item) {
			updateItem(Items.Add(""), item);
		}

		/// <summary>
		/// 更新项
		/// </summary>
		protected virtual void updateItem(
			ListViewItem listItem, ControlData item) {
			var data = item.getFieldData();
			var groupKey = item.groupKey();

			var text = data[0].value ?? "空";
			if (text == "") text = "空";
			listItem.Text = text;

			//item.SubItems.Clear();
			for (int i = 1; i < data.Count; ++i) {
				text = data[i].value ?? "-";
				if (text == "") text = "-";

				if (i < listItem.SubItems.Count)
					listItem.SubItems[i].Text = text;
				else
					listItem.SubItems.Add(text);
			}

			if (groupKey != null)
				listItem.Group = Groups[groupKey];
		}

		#endregion
	}

}
