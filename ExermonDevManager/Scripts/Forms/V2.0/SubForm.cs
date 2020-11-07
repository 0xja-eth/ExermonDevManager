using System;
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
		/// 控件
		/// </summary>
		public abstract Button saveButton { get; }
		public abstract ComboBox rootComboBox { get; }
		public abstract ExerDataGridView dataGridView { get; }
		public abstract BindingSource dataBindingSource { get; }

		/// <summary>
		/// 数据
		/// </summary>
		protected PropertyInfo prop; // 属性信息

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
			rootTable = DBManager.getTableInfo(root.GetType());
		}

		#region 窗口事件

		/// <summary>
		/// 载入回调
		/// </summary>
		protected virtual void onLoad() {
			setupEvents();
			setupDataView();
			setupRootCombox();
		}

		/// <summary>
		/// 注册事件
		/// </summary>
		protected virtual void setupEvents() {
			Closed += (_, __) => onClosed();

			rootComboBox.SelectedIndexChanged += (_, __) => onRootChanged();
			dataGridView.SelectionChanged += (_, __) => onCurrentChanged();

			saveButton.Click += (_, __) => onSave();
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
		public List<TableInfo> tables => DBManager.tables;

		/// <summary>
		/// 当前数据表
		/// </summary>
		public CoreEntity currentRoot => rootComboBox.SelectedValue as CoreEntity;

		#endregion

		#region 配置控件

		/// <summary>
		/// 配置数据表
		/// </summary>
		void setupDataView() {
			dataGridView.onSave = saveItems;
			dataGridView.onDelete = deleteItem;
			dataGridView.onEditCell = editSubItems;
		}

		/// <summary>
		/// 初始化数据库表下拉框
		/// </summary>
		void setupRootCombox() {
			var index = rootTable.items.IndexOf(root);

			rootComboBox.DataSource = rootTable.items;
			rootComboBox.DisplayMember = "displayName";
			rootComboBox.SelectedIndex = index;
		}

		#endregion

		#region 数据视图配置

		/// <summary>
		/// 配置数据视图
		/// </summary>
		/// <param name="tableType"></param>
		void setupDataView(CoreEntity root) {
			dataGridView.setup(root, prop, dataBindingSource);
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
		/// 当前项
		/// </summary>
		public T currentItem {
			get {
				if (dataGridView.SelectedRows.Count > 0)
					return dataGridView.SelectedRows[0].DataBoundItem as T;
				if (dataGridView.SelectedCells.Count > 0)
					return dataGridView.SelectedCells[0].OwningRow.DataBoundItem as T;
				return null;
			}
		}

		/// <summary>
		/// 根数据改变回调
		/// </summary>
		protected override void onCurrentChanged() {
			drawItem(currentItem);
		}

		/// <summary>
		/// 绘制具体数据
		/// </summary>
		/// <param name="item"></param>
		void drawItem(T item) {
			var enable = item == null;
			if (currentPage != null)
				currentPage.Enabled = enable;
			if (!enable) return;

			drawExactItem(item);
		}

		/// <summary>
		/// 绘制具体数据
		/// </summary>
		/// <param name="item"></param>
		protected virtual void drawExactItem(T item) {

		}

	}

}
