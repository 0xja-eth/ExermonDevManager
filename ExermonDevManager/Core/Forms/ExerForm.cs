using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

using System.Reflection;

namespace ExermonDevManager.Core.Forms {

	using Controls;

	using Data;
	using Entities;

	using Utils;
	using Managers;

	/// <summary>
	/// 艾瑟萌窗体
	/// </summary>
	public abstract class ExerForm : Form {

		/// <summary>
		/// 常量定义
		/// </summary>
		const string CurrentPageName = "currentPage";
		const string SaveButtonName = "saveButton";
		const string DataViewName = "dataView";
		const string BindingSourceName = "bindingSource";

		/// <summary>
		/// 控件
		/// </summary>
		public virtual GroupBox currentPage_ { get; protected set; }
		public virtual Button saveButton_ { get; protected set; }
		public virtual ExerDataGridView dataView_ { get; protected set; }
		public virtual BindingSource bindingSource_ { get; protected set; }

		/// <summary>
		/// 数据
		/// </summary>
		public IList items { get; protected set; } // 数据
		public Type itemType { get; protected set; } // 子数据类型

		/// <summary>
		/// 与字段关联的控件
		/// </summary>
		protected List<IExerEditControl> fieldControls = new List<IExerEditControl>();

		/// <summary>
		/// 当前项
		/// </summary>
		public CoreData currentItem => dataView_.currentItem();

		/// <summary>
		/// 是否实体
		/// </summary>
		public bool isEntity => itemType != null && itemType.IsSubclassOf(typeof(BaseEntity));

		/// <summary>
		/// 构造函数
		/// </summary>
		public ExerForm() {
			if (DesignMode) return;

			Load += (_, __) => { if (!DesignMode) onLoad(); }; 
		}

		#region 配置

		/// <summary>
		/// 配置
		/// </summary>
		/// <param name="type"></param>
		/// <param name="items"></param>
		public void setupItems(IList items) {
			this.items = items;
			itemType = items == null ? null :
				items.GetType().GetGenericArguments()[0];

			refreshItems();
		}
		
		/// <summary>
		/// 非自动的控件名称数组
		/// </summary>
		/// <returns></returns>
		protected virtual Control[] notAutoControlNames() {
			return new Control[] { };
		}

		#endregion

		#region 事件

		/// <summary>
		/// 载入回调
		/// </summary>
		protected virtual void onLoad() {
			setupControls();
			setupEvents();

			configure();
		}

		/// <summary>
		/// 配置所有内置控件
		/// </summary>
		protected virtual void setupControls() {
			currentPage_ = ReflectionUtils.getField<GroupBox>(this, CurrentPageName);
			saveButton_ = ReflectionUtils.getField<Button>(this, SaveButtonName);
			dataView_ = ReflectionUtils.getField<ExerDataGridView>(this, DataViewName);
			bindingSource_ = ReflectionUtils.getField<BindingSource>(this, BindingSourceName);
		}

		/// <summary>
		/// 配置事件
		/// </summary>
		protected virtual void setupEvents() {
			Closed += (_, __) => onClosed();

			if (saveButton_ != null)
				saveButton_.Click += (_, __) => onSave();

			if (dataView_ != null) setupDataView();

			if (bindingSource_ != null)
				bindingSource_.ListChanged += onSourceListChanged;
		}
		
		/// <summary>
		/// 配置数据表
		/// </summary>
		void setupDataView() {
			dataView_.SelectionChanged += (_, __) => onCurrentChanged();

			dataView_.onSave = onSave;
			dataView_.onDelete = onDelete;
			dataView_.onEditCell = onEdit;
		}

		#region 内置回调

		/// <summary>
		/// 退出回调
		/// </summary>
		protected virtual void onClosed() { }

		/// <summary>
		/// 根数据改变回调
		/// </summary>
		protected virtual void onCurrentChanged() {
			refresh();
		}

		/// <summary>
		/// 保存回调
		/// </summary>
		protected virtual void onSave() { saveItems(); }

		/// <summary>
		/// 删除回调
		/// </summary>
		protected virtual void onDelete(object item) { deleteItem(item); }

		/// <summary>
		/// 更改子数据
		/// </summary>
		protected virtual void onEdit(PropertyInfo prop, CoreData root) {
			editSubItems(prop, root);
		}

		/// <summary>
		/// 数据源变化回调
		/// </summary>
		protected void onSourceListChanged(object sender, ListChangedEventArgs e) {
			var index = e.NewIndex;
			var source = sender as BindingSource;

			switch (e.ListChangedType) {
				case ListChangedType.ItemAdded:
					onSourceListAdded(source, index); break;
				case ListChangedType.ItemDeleted:
					onSourceListDeleted(source, index); break;
			}
		}

		/// <summary>
		/// 数据添加回调
		/// </summary>
		protected virtual void onSourceListAdded(
			BindingSource source, int index) { }

		/// <summary>
		/// 数据删除回调
		/// </summary>
		protected virtual void onSourceListDeleted(
			BindingSource source, int index) { }

		#endregion

		#endregion

		#region 快捷数据获取

		/// <summary>
		/// 数据库
		/// </summary>
		public ExerDbContext db => EntitiesManager.db;
		
		#endregion

		#region 数据操作

		/// <summary>
		/// 是否为空
		/// </summary>
		/// <returns></returns>
		public virtual bool isCurrentEmpty() {
			return currentItem == null;
		}

		/// <summary>
		/// 删除数据
		/// </summary>
		public virtual void deleteItem(object item) { }

		/// <summary>
		/// 保存
		/// </summary>
		public virtual void saveItems() {
			dataView_.EndEdit();
			bindingSource_.EndEdit();

			if (isEntity)
				EntitiesManager.saveTables();
			else
				DataManager.saveAllData();
		}

		#endregion

		#region 内容操作

		/// <summary>
		/// 配置数据视图
		/// </summary>
		/// <param name="tableType"></param>
		public void refreshItems() {
			dataView_?.setItems(itemType, items, bindingSource_);
		}

		/// <summary>
		/// 设置编辑页可用情况
		/// </summary>
		public virtual void setCurrentEnable(bool val) {
			if (currentPage_ == null) return;
			currentPage_.Enabled = val;
		}

		/// <summary>
		/// 更改子数据
		/// </summary>
		public void editSubItems(PropertyInfo prop, CoreData root) {
			var form = ExerFormManager.startSubForm(prop, root);
			form?.Show();
		}

		#region 内容控件配置

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
			var notList = notAutoControlNames();
			doConfigAutoControl(this, notList);
		}

		/// <summary>
		/// 执行配置
		/// </summary>
		/// <param name="control"></param>
		void doConfigAutoControl(Control c, Control[] notList) {
			if (notList.Contains(c)) return;

			IExerEditControl ec;

			if ((ec = c as IExerEditControl) != null) {

				ec.registerUpdateEvent(update);
				fieldControls.Add(ec);

			} else foreach (Control sub in c.Controls)
					doConfigAutoControl(sub, notList);
		}

		/// <summary>
		/// 自定义配置控件
		/// </summary>
		protected virtual void configCustomControls() { }

		#endregion

		#region 内容控件刷新/更新

		/// <summary>
		/// 刷新内容（当前项改变后调用）
		/// </summary>
		public void refresh() {
			if (isCurrentEmpty()) return;
			refreshMain(); update();
		}

		/// <summary>
		/// 子类重载刷新过程
		/// </summary>
		protected virtual void refreshMain() {
			bindControls();
		}

		/// <summary>
		/// 更新当前项（操作变化后调用）
		/// </summary>
		public void update() {
			setCurrentEnable(true);
			if (isCurrentEmpty()) return;

			updateCustomControls();
		}

		/// <summary>
		/// 更新自定义控件
		/// </summary>
		protected virtual void updateCustomControls() { }

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
			foreach (var c in fieldControls) c.bind(currentItem);
		}

		/// <summary>
		/// 自定义绑定控件
		/// </summary>
		protected virtual void bindCustomControls() { }

		#endregion

		#endregion
	}

	/// <summary>
	/// 程序基本窗体
	/// </summary>
	/// <typeparam name="T">修改对象类型</typeparam>
	public abstract class ExerForm<T> : ExerForm where T: CoreData, new() {
		
		/// <summary>
		/// 数据
		/// </summary>
		public new List<T> items {
			get => base.items as List<T>;
			protected set { base.items = value; }
		} 

		/// <summary>
		/// 当前项
		/// </summary>
		public new T currentItem => dataView_.currentItem<T>();
		
	}
}
