using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExermonDevManager.Forms {

	using Scripts.Forms;
	using Scripts.Data;
	using Scripts.Controls;

	public partial class ModifyTypeSettings : ExerFormForTypeSetting {

		/// <summary>
		/// 对应的列表
		/// </summary>
		public override ExerListView listView => typeList;

		/// <summary>
		/// 各种按钮
		/// </summary>
		public override Button copyBtn => copy;
		public override Button deleteBtn => delete;
		public override Button moveUpBtn => moveUp;
		public override Button moveDownBtn => moveDown;

		public override Button createBtn => create;

		public override Button confirmBtn => confirm;

		public override GroupBox currentPage => curPage;

		/// <summary>
		/// 构造函数
		/// </summary>
		public ModifyTypeSettings() {
			InitializeComponent();
		}
		
		#region 默认事件

		private void fieldList_ItemCheck(object sender, ItemCheckEventArgs e) {
			if (!fieldList.Focused) return;
			checkField(e.Index, e.NewValue == CheckState.Checked);
		}

		private void relList_ItemCheck(object sender, ItemCheckEventArgs e) {
			if (!relList.Focused) return;
			checkRel(e.Index, e.NewValue == CheckState.Checked);
		}

		private void allFields_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			fieldList.Focus();
			fieldList.check();
			update();
		}

		private void allRels_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			relList.Focus();
			relList.check();
			update();
		}

		private void allNotFields_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			fieldList.Focus();
			fieldList.uncheck();
			update();
		}

		private void allNotRels_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			relList.Focus();
			relList.uncheck();
			update();
		}

		#endregion

		#region 初始化/配置

		/// <summary>
		/// 非自动控件名称
		/// </summary>
		/// <returns></returns>
		protected override Control[] notAutoControlNames() {
			return new Control[] { codeReview };
		}

		#endregion

		#region 窗口事件

		/// <summary>
		/// 确认回调
		/// </summary>
		protected override void onConfirm() {
			base.onConfirm(); Close();
		}

		#endregion

		#region 数据操作

		/// <summary>
		/// 获取当前模型
		/// </summary>
		Model getCurrentModel() {
			return (parentForm as ModelManager)?.item;
		}

		/// <summary>
		/// 新建项回调
		/// </summary>
		/// <param name="item"></param>
		protected override void onItemCreated(Model.TypeSetting item) {
			base.onItemCreated(item);
			item.model = getCurrentModel();
		}

		/// <summary>
		/// 选择字段
		/// </summary>
		public void checkField(int index, bool checked_) {
			var fids = item.fieldIds;

			if (checked_) {
				if (!fids.Contains(index)) fids.Add(index);
			} else fids.Remove(index);

			update();
		}

		/// <summary>
		/// 选择关系
		/// </summary>
		public void checkRel(int index, bool checked_) {
			var model = relList.getData<Model>(index);
			var rids = item.relModelIds; var mid = model.id;

			if (checked_) {
				if (!rids.Contains(mid)) rids.Add(mid);
			} else rids.Remove(mid);

			update();
		}

		#endregion

		#region 控件操作

		#region 控件配置

		/// <summary>
		/// 刷新窗口
		/// </summary>
		protected override void configCustomControls() {
			base.configCustomControls();
			setupFieldList();
			setupRelatedList();
		}

		/// <summary>
		/// 配置字段列表
		/// </summary>
		void setupFieldList() {
			var model = getCurrentModel();
			if (model == null) return;

			fieldList.setupColumns<ModelField>();
			fieldList.setup(model.params_);
		}

		/// <summary>
		/// 配置关系列表
		/// </summary>
		void setupRelatedList() {
			var model = getCurrentModel();
			if (model == null) return;

			var relateds = model.getRelatedModels();

			relList.setupAll<Model, Module>(relateds);
		}

		#endregion

		#region 控件绑定/更新

		/// <summary>
		/// 刷新
		/// </summary>
		protected override void refreshMain() {
			base.refreshMain();
			refreshFieldList();
			refreshRelList();
		}

		/// <summary>
		/// 刷新字段列表
		/// </summary>
		void refreshFieldList() {
			fieldList.uncheck();
			var tmp = new List<int>(item.fieldIds);
			foreach (var id in tmp)
				fieldList.check(id);
		}

		/// <summary>
		/// 刷新关系列表
		/// </summary>
		void refreshRelList() {
			relList.uncheck();
			var models = item.relModels();
			foreach (var rel in models)
				relList.check(rel);
		}

		/// <summary>
		/// 更新
		/// </summary>
		protected override void updateCustomControls() {
			base.updateCustomControls();
			updateCodePreviews();
		}

		/// <summary>
		/// 更新代码预览
		/// </summary>
		void updateCodePreviews() {
			var model = getCurrentModel();
			codeReview.Text = model?.genTypeSettingsCode();
		}

		#endregion

		#endregion
	}
}
