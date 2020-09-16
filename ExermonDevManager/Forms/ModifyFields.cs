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

	public partial class ModifyFields : ExerFormForModelField { 
		//ExermonForm<Param> {

		/// <summary>
		/// 常量定义
		/// </summary>
		//const string CurrentFormat = "当前选中：{0}.{1} ({2}): {3}";

		/// <summary>
		/// 对应的列表
		/// </summary>
		public override ExerListView listView => paramList;

		/// <summary>
		/// 各种按钮
		/// </summary>
		public override Button copyBtn => copy;
		public override Button deleteBtn => delete;
		public override Button moveUpBtn => moveUp;
		public override Button moveDownBtn => moveDown;

		public override Button confirmBtn => confirm;

		public override Button createBtn => create;

		public override GroupBox currentPage => curPage;

		/// <summary>
		/// 构造函数
		/// </summary>
		public ModifyFields() {
			InitializeComponent();
		}

		#region 默认事件
		
		private void intType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Unity.Models.Int);
		}

		private void doubleType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Unity.Models.Double);
		}

		private void strType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Unity.Models.String);
		}

		private void boolType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Unity.Models.Bool);
		}

		private void dateType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Unity.Models.Date_);
		}

		private void dateTimeType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Unity.Models.DateTime_);
		}

		private void tupleType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Unity.Models.Tuple_);
		}

		private void cancelChoices_Click(object sender, EventArgs e) {
			choices.SelectedIndex = -1;
		}

		#endregion

		#region 初始化/配置

		/// <summary>
		/// 非自动控件名称
		/// </summary>
		/// <returns></returns>
		protected override Control[] notAutoControlNames() {
			return new Control[] { bCode, fCode };
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

		#region 控件操作

		/// <summary>
		/// 配置类型
		/// </summary>
		/// <param name="type"></param>
		void setType(Model type) {
			fType.select(type);
			updateCustomControls();
		}

		#region 控件配置

		/// <summary>
		/// 刷新窗口
		/// </summary>
		protected override void configCustomControls() {
			base.configCustomControls();
			setupComboxes();
		}

		/// <summary>
		/// 配置下拉框数据
		/// </summary>
		void setupComboxes() {
			fType.setup<Model>();
			fType.filterFunc = m => (m as Model).isFrontend;

			toModel.setup<Model>();
			toModel.filterFunc = m => (m as Model).isBackend;

			bType.setup<DjangoFieldType>();
			choices.setup<CustomEnumGroup>();
			onDelete.setup<DjangoOnDeleteChoice>();
		}

		#endregion

		#region 控件绑定/更新

		/// <summary>
		/// 更新
		/// </summary>
		protected override void updateCustomControls() {
			base.updateCustomControls();
			updateControlsEnable();
			updateCodePreviews();
		}

		/// <summary>
		/// 更新控件有效情况
		/// </summary>
		void updateControlsEnable() {
			var enableNames = item.getEnableFieldNames();
			foreach (var c in fieldControls)
				doUpdateControl(c as Control, enableNames);
		}

		/// <summary>
		/// 执行配置
		/// </summary>
		/// <param name="control"></param>
		void doUpdateControl(Control c, List<string> enables) {
			if (c == null || c == listView) return;

			var name = c.Name;
			// 是 ComboBox 类型
			if ((c as ComboBox) != null) name += "Id";
			c.Enabled = enables.Contains(name);
		}

		/// <summary>
		/// 更新代码预览
		/// </summary>
		void updateCodePreviews() {
		}

		#endregion

		#endregion

	}
}
