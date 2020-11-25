﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

using System.ComponentModel;

namespace ExermonDevManager.Core.Forms {

	using Controls;

	using Data;
	using Entities;
	using Utils;

	using Managers;

	/// <summary>
	/// 艾瑟萌子窗体
	/// </summary>
	public abstract class ExerSubForm : ExerForm {

		/// <summary>
		/// 常量定义
		/// </summary>
		const string RootComboxName = "rootCombox";

		/// <summary>
		/// 控件
		/// </summary>
		public ComboBox rootCombox_;

		/// <summary>
		/// 数据
		/// </summary>
		public IList tmpItems { get; protected set; } // 临时数据列表（主要用于记录删除的数据）

		/// <summary>
		/// 根数据
		/// </summary>
		public PropertyInfo listProp { get; protected set; } // 根数据数组的属性信息

		public CoreData rootData { get; protected set; } // 根数据
		//public TableInfo rootTable { get; protected set; }; // 根数据表
		public IList rootItems { get; protected set; } // 根数据列表
		
		/// <summary>
		/// 配置
		/// </summary>
		/// <param name="prop">列表属性信息</param>
		/// <param name="root">根数据</param>
		public void setup(PropertyInfo prop, CoreData root) {
			listProp = prop; rootData = root;

			itemType = prop.PropertyType.GetGenericArguments()[0];
			rootItems = DataManager.getDataList(root.GetType());

			//rootTable = DatabaseManager.getTableInfo(root.GetType());
		}

		/// <summary>
		/// 配置临时列表
		/// </summary>
		public void setupItems() {
			items = listProp.GetValue(rootData) as IList;

			var lType = typeof(List<>).MakeGenericType(itemType);
			tmpItems = Activator.CreateInstance(lType) as IList;

			foreach (var item in items) tmpItems.Add(item);
		}

		#region 事件

		/// <summary>
		/// 配置所有内置控件
		/// </summary>
		protected override void setupControls() {
			base.setupControls();
			rootCombox_ = ReflectionUtils.getField<ComboBox>(this, RootComboxName);

			if (rootCombox_ != null) setupRootCombox();
		}

		/// <summary>
		/// 初始化数据库表下拉框
		/// </summary>
		void setupRootCombox() {
			var index = rootItems.IndexOf(rootData);

			rootCombox_.DataSource = rootItems;
			rootCombox_.DisplayMember = "displayName";
			rootCombox_.SelectedIndex = index;
		}

		/// <summary>
		/// 注册事件
		/// </summary>
		protected override void setupEvents() {
			base.setupEvents();

			if (rootCombox_ != null) 
				rootCombox_.SelectedIndexChanged += (_, __) => onRootChanged();
		}

		#region 内置回调

		/// <summary>
		/// 根数据改变回调
		/// </summary>
		protected virtual void onRootChanged() {
			onSave();
			setupItems();
			setupDataView(currentRoot);
		}

		/// <summary>
		/// 保存回调
		/// </summary>
		protected override void onSave() {
			base.onSave(); saveItems();
		}

		/// <summary>
		/// 删除回调
		/// </summary>
		protected override void onDelete(object item) {
			base.onDelete(item); deleteItem(item);
		}

		/// <summary>
		/// 更改子数据
		/// </summary>
		protected override void onEdit(PropertyInfo prop, CoreData root) {
			base.onEdit(prop, root); editSubItems(prop, root);
		}
		
		/// <summary>
		/// 数据添加回调
		/// </summary>
		protected override void onSourceListAdded(
			BindingSource source, int index) {
			if (!isEntity) return;

			var sub = source[index];
			tmpItems.Insert(index, sub);
			db.Add(sub);
		}

		/// <summary>
		/// 数据删除回调
		/// </summary>
		protected override void onSourceListDeleted(
			BindingSource source, int index) {
			if (!isEntity) return;

			db.Remove(tmpItems[index]);
			tmpItems.RemoveAt(index);
		}

		#endregion

		#endregion

		#region 快捷数据获取

		/// <summary>
		/// 数据库
		/// </summary>
		public ExerDbContext db => DatabaseManager.db;
		
		/// <summary>
		/// 当前数据表
		/// </summary>
		public CoreData currentRoot => rootCombox_.SelectedValue as CoreData;

		#endregion

		#region 配置控件
		
		#endregion

		#region 数据视图配置

		/// <summary>
		/// 配置数据视图
		/// </summary>
		/// <param name="tableType"></param>
		void setupDataView(CoreData root) {
			dataView_.setItems(root, listProp, bindingSource_);
		}

		#endregion

		#region 数据库操作

		/// <summary>
		/// 更改子数据
		/// </summary>
		public void editSubItems(PropertyInfo prop, CoreData root) {
			var form = ExermonFormManager.startSubForm(prop, root);
			form?.Show();
		}

		/// <summary>
		/// 删除数据
		/// </summary>
		public void deleteItem(object item) { }

		/// <summary>
		/// 保存
		/// </summary>
		public void saveItems() {
			dataView_.EndEdit();
			bindingSource_.EndEdit();

			DatabaseManager.saveTables();
		}

		#endregion
	}

	/// <summary>
	/// 测试窗口
	/// </summary>
	public abstract class ExerSubForm<T> : ExerSubForm where T : BaseEntity {
		
		/// <summary>
		/// 当前项
		/// </summary>
		public new T currentItem => dataView_.currentItem<T>();
		
	}

}