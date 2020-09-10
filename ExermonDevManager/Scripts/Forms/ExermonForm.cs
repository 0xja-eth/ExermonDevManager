using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

using System.Reflection;

namespace ExermonDevManager.Scripts.Forms {

	using Data;
	using Utils;
	using Controls;

	/// <summary>
	/// 程序基本窗体
	/// </summary>
	public abstract class ExermonForm : Form {

		/// <summary>
		/// 父窗体
		/// </summary>
		public ExermonForm parentForm = null;

		/// <summary>
		/// 当前页
		/// </summary>
		public virtual GroupBox currentPage => null;

		/// <summary>
		/// 与字段关联的控件
		/// </summary>
		public List<IExerControl> fieldControls = new List<IExerControl>();

		/// <summary>
		/// 列表控件
		/// </summary>
		public abstract ExerListView listView { get; }

		/// <summary>
		/// 确认按钮
		/// </summary>
		public virtual Button confirmBtn { get { return null; } }

		/// <summary>
		/// 标志
		/// </summary>
		public SubFormFlag flag { get; set; } = null;
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public ExermonForm() {
			if (DesignMode) return;

			Load += (_, __) => { if (!DesignMode) onLoad(); }; 
			Closed += (_, __) => onClosed();
		}

		#region 初始化/配置

		///// <summary>
		///// 空白文本
		///// </summary>
		///// <returns></returns>
		//protected virtual string blankText() {
		//	return null;
		//}

		/// <summary>
		/// 非自动的控件名称数组
		/// </summary>
		/// <returns></returns>
		protected virtual Control[] notAutoControlNames() {
			return new Control[] { };
		}

		#endregion

		#region 窗口事件

		/// <summary>
		/// 载入回调
		/// </summary>
		protected virtual void onLoad() {
			loadData(); configure();
		}

		/// <summary>
		/// 退出回调
		/// </summary>
		protected virtual void onClosed() {
			flag?.onFormClosed();
		}

		/// <summary>
		/// 确认回调
		/// </summary>
		protected virtual void onConfirm() { }

		#endregion

		#region 数据操作

		/// <summary>
		/// 读取数据
		/// </summary>
		protected virtual void loadData() { }

		/// <summary>
		/// 是否为空
		/// </summary>
		/// <returns></returns>
		public virtual bool isEmpty() { return true; }

		#endregion

		#region 控件操作

		/// <summary>
		/// 对应的列表
		/// </summary>
		public int listItemCount() {
			if (listView == null) return 0;
			return listView.itemsCount();
		}

		/// <summary>
		/// 设置编辑页可用情况
		/// </summary>
		public virtual void setCurrentEnable(bool val) {
			if (currentPage != null)
				currentPage.Enabled = val;
		}

		#region 控件配置

		/// <summary>
		/// 配置窗口（初次）
		/// </summary>
		public void configure() {
			configAutoControls();
			configCustomControls();
		}

		/// <summary>
		/// 自动配置控件
		/// </summary>
		protected virtual void configAutoControls() {
			if (confirmBtn != null)
				confirmBtn.Click += (_, __) => onConfirm();

			var notList = notAutoControlNames();
			doConfigAutoControl(this, notList);
		}

		/// <summary>
		/// 执行配置
		/// </summary>
		/// <param name="control"></param>
		void doConfigAutoControl(Control c, Control[] notList) {
			if (notList.Contains(c)) return;

			IExerControl ec;

			if ((ec = c as IExerControl) != null) {
				ec.registerUpdateEvent((_, __) => updateCurrent());

				c.Click += (_, __) => updateCurrent();
				c.KeyUp += (_, __) => updateCurrent();
				c.LostFocus += (_, __) => updateCurrent();

				fieldControls.Add(ec);
			} else foreach (Control sub in c.Controls)
				doConfigAutoControl(sub, notList);
		}

		/// <summary>
		/// 自定义配置控件
		/// </summary>
		protected virtual void configCustomControls() { }

		#endregion

		#region 控件刷新/更新

		/// <summary>
		/// 刷新内容（当前项改变后调用）
		/// </summary>
		public void refresh() {
			if (isEmpty()) return;
			refreshMain(); update();
		}

		/// <summary>
		/// 子类重载刷新过程
		/// </summary>
		protected virtual void refreshMain() { }

		/// <summary>
		/// 更新当前项（操作变化后调用）
		/// </summary>
		public void update() {
			setCurrentEnable(true);
			if (isEmpty()) return;

			updateAutoControls();
			updateCustomControls();
		}

		/// <summary>
		/// 更新当前项（操作变化后调用）
		/// </summary>
		public void updateCurrent() {
			setCurrentEnable(true);
			if (isEmpty()) return;

			//updateAutoControls();
			updateCustomControls();
		}

		/// <summary>
		/// 更新自动控件
		/// </summary>
		void updateAutoControls() {
			foreach (var c in fieldControls) c.update();
		}

		/// <summary>
		/// 更新自定义控件
		/// </summary>
		protected virtual void updateCustomControls() { }

		#endregion

		#endregion
	}

	/// <summary>
	/// 程序基本窗体
	/// </summary>
	/// <typeparam name="T">修改对象类型</typeparam>
	public abstract class ExermonForm<T> : ExermonForm where T: CoreData, new() {

		//protected List<T> items = null;
		//protected List<int> indices = null;

		/// <summary>
		/// 数据列表
		/// </summary>
		[Browsable(false)]
		public List<T> items {
			get { return listView?.data as List<T>; }
			set { listView?.setup(value); refresh(); }
		}

		/// <summary>
		/// 数据
		/// </summary>
		[Browsable(false)]
		public T item {
			get { return listView?.getCurrentData<T>(); }
			set {
				defaultItem = value;
				//var item = this.item;
				//if (item != null) item.cacheable = true;
				//if (value != null) value.cacheable = false;

				setCurrentEnable(value != null);

				listView?.select(value);
				//refresh();
			}
		}
		T defaultItem = null;
		//public T defaultItem { get; set; } = null;

		/// <summary>
		/// 当前索引
		/// </summary>
		[Browsable(false)]
		public int index {
			get { return listView?.getCurrentIndex() ?? -1; }
			set {
				var item = listView?.getData<T>(value);
				this.item = item;
			}
		}
		//public int defaultIndex {
		//	get { return listView.getIndex(defaultItem); }
		//	set { defaultItem = listView?.getData<T>(value); }
		//}

		/// <summary>
		/// 是否为根本数据类型
		/// </summary>
		protected bool rootData = false;

		/// <summary>
		/// 各种按钮
		/// </summary>
		public virtual Button copyBtn => null; 
		public virtual Button deleteBtn => null;
		public virtual Button moveUpBtn => null;
		public virtual Button moveDownBtn => null;

		public virtual Button createBtn => null;
		public virtual Button saveBtn => null;

		/// <summary>
		/// 构造函数
		/// </summary>
		public ExermonForm() { }

		#region 初始化/配置

		/// <summary>
		/// 当前页标题文本格式
		/// </summary>
		/// <returns></returns>
		protected virtual string currentPageFormat() {
			return "正在修改：{0}. {1}";
		}
		
		#endregion

		#region 窗口事件

		/// <summary>
		/// 初始化窗体
		/// </summary>
		protected override void onLoad() {
			base.onLoad();
			selectDefault();
		}

		/// <summary>
		/// 退出回调
		/// </summary>
		protected override void onClosed() {
			base.onClosed();
			parentForm?.update();
			//syncData();
		}

		/// <summary>
		/// 选择改变回调
		/// </summary>
		protected virtual void onSelectChanged() {
			refresh();
			//setIndex(listView.getSelectedIndex());
		}

		#endregion

		#region 数据操作

		/// <summary>
		/// 读取数据
		/// </summary>
		protected override void loadData() {
			//if (items == null) setItems();
		}

		/// <summary>
		/// 是否为空
		/// </summary>
		/// <returns></returns>
		public override bool isEmpty() {
			return item == null;
		}

		/// <summary>
		/// 选择默认项
		/// </summary>
		void selectDefault() {
			if (defaultItem == null)
				defaultItem = listView?.getData<T>(0);
			item = defaultItem;
		}

		/// <summary>
		/// 设置ID集
		/// </summary>
		/// <param name="items"></param>
		public void setIndices(List<int> indices) {
			setItems(); rootData = false;
			listView.filterFunc = item => 
				indices.Contains(item.id);
		}

		/// <summary>
		/// 设置项目集
		/// </summary>
		/// <param name="items"></param>
		public void setItems() {
			setItems(BaseData.poolGet<T>());
			rootData = true;
		}
		public void setItems(List<T> items) {
			listView.filterFunc = null;
			this.items = items;
			rootData = false;
		}

		///// <summary>
		///// 设置ID
		///// </summary>
		///// <param name="index"></param>
		//public void setIndex(int index) {
		//	defaultIndex = currentIndex = index;
		//	if (index < 0)
		//		_setItem(null);
		//	else if (index < items.Count)
		//		_setItem(items[index]);
		//	else
		//		createItem();
		//}

		///// <summary>
		///// 设置项目
		///// </summary>
		///// <param name="item"></param>
		//public void setItem(T item, bool force = false) {
		//	if (force) _setItem(item);
		//	else select(itemIndex(item));
		//}

		///// <summary>
		///// 设置项目
		///// </summary>
		///// <param name="item"></param>
		//void _setItem(T item) {
		//	if (this.item != null) this.item.cacheable = true;
		//	if (item != null) item.cacheable = false;

		//	setCurrentEnable(item != null);

		//	if (item == null) item = new T();
		//	this.item = item;

		//	refresh(); 
		//}

		#region 数据修改

		/// <summary>
		/// 添加新项
		/// </summary>
		void createItem() {
			var item = new T();
			onItemCreated(item);
			addItem(item);
		}

		/// <summary>
		/// 新建项回调
		/// </summary>
		protected virtual void onItemCreated(T item) { }

		/// <summary>
		/// 复制
		/// </summary>
		public void copyItem() {
			listView?.copyData(item);
			index = listView.dataCount() - 1;
		}

		/// <summary>
		/// 删除
		/// </summary>
		public void deleteItem() {
			listView?.removeData(item);
			index = index;
		}

		/// <summary>
		/// 上移
		/// </summary>
		public void moveUpItem() {
			listView?.swapData(item, -1);
			index -= 1;
		}

		/// <summary>
		/// 下移
		/// </summary>
		public void moveDownItem() {
			listView?.swapData(item, 1);
			index += 1;
		}
		
		/// <summary>
		/// 添加
		/// </summary>
		public void addItem(T item) {
			if (listView == null) return;
			listView.addData(item);
			index = listView.dataCount() - 1;
		}

		/// <summary>
		/// 移除
		/// </summary>
		public void removeItem(T item) {
			listView?.removeData(item);
			index = index;
		}

		/// <summary>
		/// 移除
		/// </summary>
		public void clearItems() {
			listView?.clearData();
			index = -1;
		}

		/// <summary>
		/// 添加新项
		/// </summary>
		public int itemIndex(T item) {
			if (listView == null) return -1;
			return listView.getIndex(item);
		}
		/*
		/// <summary>
		/// 同步更改
		/// </summary>
		public void syncData() {
			if (rootData) BaseData.poolSet(items);
			if (indices != null) itemsToIndices();
			parentForm?.updateCurrent();
		}

		/// <summary>
		/// 将项目转化为索引集
		/// </summary>
		void itemsToIndices() {
			indices.Clear();
			foreach (var item in items)
				indices.Add(item.id);
		}
		*/
		#endregion

		#endregion

		#region 控件操作

		/// <summary>
		/// 设置编辑页可用情况
		/// </summary>
		public override void setCurrentEnable(bool val) {
			var disable = isEmpty(); // items == null || items.Count <= 0;

			base.setCurrentEnable(!disable && val);
		}

		///// <summary>
		///// 选择（特定项目，程序调用，不可用于事件）
		///// </summary>
		///// <param name="index"></param>
		//public void select(int index) {
		//	//if (listView == null) return;
		//	listView?.selectIndex(index);

		//	//var cnt = items.Count;
		//	//if (cnt <= 0) deselect();
		//	//else {
		//	//	index = listView.adjustIndex(index, cnt - 1);
		//	//	setIndex(index);

		//	//	listView.selectIndex(index);
		//	//}
		//}

		///// <summary>
		///// 取消选择
		///// </summary>
		//public void deselect() {
		//	//if (listView == null) return;
		//	listView?.deselect();
		//	//ListViewUtils.deselect(listView);
		//}

		///// <summary>
		///// 更新且选择
		///// </summary>
		///// <param name="index"></param>
		//public void updateAndSelect(int index) {
		//	updateItemList(); select(index);
		//}

		#region 控件配置

		/// <summary>
		/// 自动配置控件
		/// </summary>
		sealed protected override void configAutoControls() {
			base.configAutoControls();

			if (copyBtn != null) copyBtn.Click += (_, __) => copyItem();
			if (deleteBtn != null) deleteBtn.Click += (_, __) => deleteItem();
			if (moveUpBtn != null) moveUpBtn.Click += (_, __) => moveUpItem();
			if (moveDownBtn != null) moveDownBtn.Click += (_, __) => moveDownItem();

			if (createBtn != null) createBtn.Click += (_, __) => createItem();
			//if (saveBtn != null) saveBtn.Click += (_, __) => syncData();

			if (listView != null) listView.SelectedIndexChanged += 
					(_, __) => onSelectChanged();
		}

		/// <summary>
		/// 自定义配置控件
		/// </summary>
		protected override void configCustomControls() {
			setupItemList();
		}

		/// <summary>
		/// 配置项目列表
		/// </summary>
		protected virtual void setupItemList() {
			if (listView == null) return;
			listView.setupColumns<T>();
			listView.filterFunc = (item) => !item.buildIn;
			if (items == null) listView.setup<T>();
		}

		#endregion

		#region 控件刷新/更新

		/// <summary>
		/// 刷新
		/// </summary>
		protected override void refreshMain() {
			base.refreshMain();
			bindControls();
		}
		
		/// <summary>
		/// 配置绑定
		/// </summary>
		void bindControls() {
			bindAutoControls();
			bindCustomControls();
		}

		/// <summary>
		/// 自动绑定控件
		/// </summary>
		void bindAutoControls() {
			foreach (var c in fieldControls) c.bind(item);
		}

		/// <summary>
		/// 自定义绑定控件
		/// </summary>
		protected virtual void bindCustomControls() { }

		/// <summary>
		/// 更新当前
		/// </summary>
		protected override void updateCustomControls() {
			base.updateCustomControls();

			item.clearCaches();
			updateCurrentPageTitle();
		}

		/// <summary>
		/// 更新当前页面标题
		/// </summary>
		void updateCurrentPageTitle() {
			if (currentPage == null) return;
			currentPage.Text = string.Format(
				currentPageFormat(), index + 1, item.name);
		}

		#endregion

		#endregion
	}
}
