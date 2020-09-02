using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExermonDevManager.Scripts.Controls {

	using Data;

	/// <summary>
	/// Exer下拉框
	/// </summary>
	public partial class ExerComboBox : ComboBox, IExerControl, INotifyPropertyChanged {

		///// <summary>
		///// 当前数据索引
		///// </summary>
		//public abstract int SelectedDataId { get; set; }

		/// <summary>
		/// 过滤函数
		/// </summary>
		public delegate bool FilterFunc(ControlData data);

		/// <summary>
		/// 数据
		/// </summary>
		public IList data;

		/// <summary>
		/// 数据索引
		/// </summary>
		public List<int> dataIndices = new List<int>();

		/// <summary>
		/// 当前数据索引
		/// </summary>
		[Bindable(true)]
		public int SelectedDataId {
			get { return getCurrentDataId(); }
			set {
				select(value);
				onPropertyChanged("SelectedDataId");
			}
		}

		/// <summary>
		/// 当前数据
		/// </summary>
		public ControlData SelectedData {
			get { return getCurrentData(); }
			set { select(value); }
		}

		/// <summary>
		/// 过滤函数
		/// </summary>
		public FilterFunc filterFunc = null;

		/// <summary>
		/// 构造函数
		/// </summary>
		public ExerComboBox() {
			InitializeComponent();
			SelectedIndexChanged += (_, __) => 
				onPropertyChanged("SelectedDataId");
		}
		
		/// <summary>
		/// 数据绑定接口实现
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		protected void onPropertyChanged(string name) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		#region 数据操作

		/// <summary>
		/// 配置（设定数据）
		/// </summary>
		public void setup<T>() where T : ControlData {
			setup(BaseData.poolGet<T>());
		}
		public void setup(IList data) {
			this.data = data; // update();
		}

		/// <summary>
		/// 是否包含某数据
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public virtual bool isInclude(ControlData data) {
			if (data == null) return false;
			if (!data.isIncluded()) return false;
			if (filterFunc == null) return true;
			return filterFunc(data);
		}

		/// <summary>
		/// 绑定数据
		/// </summary>
		/// <param name="data"></param>
		public virtual void bind(BaseData data) {
			DataBindings.Clear();
			DataBindings.Add("SelectedDataId", data, Name + "Id",
				false, DataSourceUpdateMode.OnPropertyChanged);
		}
		
		/// <summary>
		/// 注册更新事件
		/// </summary>
		/// <param name="event_"></param>
		public void registerUpdateEvent(EventHandler event_) {
			SelectedIndexChanged += event_;
		}

		#endregion

		#region 数据获取
		/*
		 名词约定：
		 选择索引（index）：Items 中的索引
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

		#region 获取数据

		/// <summary>
		/// 选择索引 => 数据
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
		/// 选择索引 => 数据索引
		/// </summary>
		/// <param name="index">选择索引</param>
		/// <returns></returns>
		protected int getDataIndex(int index) {
			if (isEmpty() || index == -1) return -1;
			index = adjustIndex(index, data.Count);
			return dataIndices[index];
		}

		/// <summary>
		/// 数据索引 => 数据
		/// </summary>
		/// <param name="index">数据索引</param>
		/// <returns></returns>
		protected ControlData getDataByDataIndex(int index) {
			if (isEmpty() || index == -1) return null;
			index = adjustIndex(index, data.Count);
			return data[index] as ControlData;
		}

		/// <summary>
		/// 获取当前数据
		/// </summary>
		/// <returns></returns>
		public ControlData getCurrentData() {
			return getData(SelectedIndex);
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
		/// 选择选项ID
		/// </summary>
		/// <param name="itemId"></param>
		public void selectIndex(int index) {
			if (index != -1)
				index = adjustIndex(index, itemsCount());
			SelectedIndex = index;
		}

		/// <summary>
		/// 清除选择
		/// </summary>
		public void clear() {
			selectIndex(-1);
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
		void updateItems() {
			var oldCnt = itemsCount();
			var newCnt = dataCount();

			// 遍历新项
			for (int i = 0; i < newCnt; ++i) {
				var item = getData(i);
				if (i >= oldCnt)
					Items.Add(item.comboText());
				else
					Items[i] = item.comboText();
			}

			// 删除剩余项
			for (int i = oldCnt - 1; i >= newCnt; --i)
				Items.RemoveAt(i);
		}

		#endregion
	}
	
}
