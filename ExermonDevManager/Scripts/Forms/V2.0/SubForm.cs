using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace ExermonDevManager.Scripts.Forms {

	using Controls;
	using Entities;
	using Utils;

	/// <summary>
	/// 测试窗口
	/// </summary>
	public abstract class SubForm : Form {

		/// <summary>
		/// 常量定义
		/// </summary>
		const string SaveButtonName = "saveButton";
		const string RootComboxName = "rootCombox";
		const string DataViewName = "dataView";
		const string BindingSourceName = "bindingSource";

		/// <summary>
		/// 控件
		/// </summary>
		public Button saveButton_;
		public ComboBox rootCombox_;
		public ExerDataGridView dataView_;
		public BindingSource bindingSource_;

		/// <summary>
		/// 数据
		/// </summary>
		protected PropertyInfo prop; // 属性信息
		protected IList items; // 数据列表

		protected CoreEntity root; // 根数据
		protected TableInfo rootTable; // 根数据表

		/// <summary>
		/// 构造函数
		/// </summary>
		public SubForm() {
			if (DesignMode) return;
			Load += (_, __) => { if (!DesignMode) onLoad(); };
		}

		/// <summary>
		/// 配置
		/// </summary>
		/// <param name="prop"></param>
		/// <param name="root"></param>
		public void setup(PropertyInfo prop, CoreEntity root) {
			this.prop = prop; this.root = root;
			items = prop.GetValue(root) as IList;
			rootTable = DBManager.getTableInfo(root.GetType());
		}

		#region 窗口事件

		/// <summary>
		/// 载入回调
		/// </summary>
		protected virtual void onLoad() {
			setupControls();
			setupEvents();
			setupDataView();
			setupRootCombox();
		}

		/// <summary>
		/// 配置所有内置控件
		/// </summary>
		public void setupControls() {
			saveButton_ = ReflectionUtils.getField<Button>(this, SaveButtonName);
			rootCombox_ = ReflectionUtils.getField<ComboBox>(this, RootComboxName);
			dataView_ = ReflectionUtils.getField<ExerDataGridView>(this, DataViewName);
			bindingSource_ = ReflectionUtils.getField<BindingSource>(this, BindingSourceName);
		}

		/// <summary>
		/// 注册事件
		/// </summary>
		protected virtual void setupEvents() {
			Closed += (_, __) => onClosed();

			rootCombox_.SelectedIndexChanged += (_, __) => onRootChanged();
			dataView_.SelectionChanged += (_, __) => onCurrentChanged();

			saveButton_.Click += (_, __) => onSave();
		}

		/// <summary>
		/// 退出回调
		/// </summary>
		protected virtual void onClosed() {

		}

		/// <summary>
		/// 根数据改变回调
		/// </summary>
		protected virtual void onRootChanged() {
			onSave(); setupDataView(currentRoot);
		}

		/// <summary>
		/// 根数据改变回调
		/// </summary>
		protected virtual void onCurrentChanged() {

		}

		/// <summary>
		/// 保存回调
		/// </summary>
		protected virtual void onSave() {
			saveItems();
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
		public List<TableInfo> tables => DBManager.rootTables;

		/// <summary>
		/// 当前数据表
		/// </summary>
		public CoreEntity currentRoot => rootCombox_.SelectedValue as CoreEntity;

		#endregion

		#region 配置控件

		/// <summary>
		/// 配置数据表
		/// </summary>
		void setupDataView() {
			dataView_.onSave = saveItems;
			dataView_.onDelete = deleteItem;
			dataView_.onEditCell = editSubItems;
		}

		/// <summary>
		/// 初始化数据库表下拉框
		/// </summary>
		void setupRootCombox() {
			var index = rootTable.items.IndexOf(root);

			rootCombox_.DataSource = rootTable.items;
			rootCombox_.DisplayMember = "displayName";
			rootCombox_.SelectedIndex = index;
		}

		#endregion

		#region 数据视图配置

		/// <summary>
		/// 配置数据视图
		/// </summary>
		/// <param name="tableType"></param>
		void setupDataView(CoreEntity root) {
			dataView_.setup(root, prop, bindingSource_);
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

		}

		/// <summary>
		/// 保存
		/// </summary>
		public void saveItems() {

		}

		#endregion
	}

	/// <summary>
	/// 测试窗口
	/// </summary>
	public abstract class SubForm<T> : SubForm where T : CoreEntity {
		
		/// <summary>
		/// 当前页
		/// </summary>
		public virtual GroupBox currentPage => null;

		/// <summary>
		/// 与字段关联的控件
		/// </summary>
		public List<IExerEntityControl> fieldControls = new List<IExerEntityControl>();

		/// <summary>
		/// 当前项
		/// </summary>
		public T currentItem => dataView_.currentItem<T>();

		/// <summary>
		/// 加载
		/// </summary>
		protected override void onLoad() {
			base.onLoad();
			configure();
		}

		/// <summary>
		/// 非自动的控件名称数组
		/// </summary>
		/// <returns></returns>
		protected virtual Control[] notAutoControlNames() {
			return new Control[] { };
		}

		/// <summary>
		/// 是否为空
		/// </summary>
		/// <returns></returns>
		public virtual bool isCurrentEmpty() {
			return currentItem == null;
		}

		#region 控件操作

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
			var notList = notAutoControlNames();
			doConfigAutoControl(this, notList);
		}

		/// <summary>
		/// 执行配置
		/// </summary>
		/// <param name="control"></param>
		void doConfigAutoControl(Control c, Control[] notList) {
			if (notList.Contains(c)) return;

			IExerEntityControl ec;

			if ((ec = c as IExerEntityControl) != null) {

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

		#region 控件刷新/更新

		/// <summary>
		/// 根数据改变回调
		/// </summary>
		protected override void onCurrentChanged() {
			refresh();
		}

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

}
