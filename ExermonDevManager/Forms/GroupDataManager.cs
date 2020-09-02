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

	using Scripts.Data;
	using Scripts.Utils;
	using Scripts.Forms;
	using Scripts.Controls;

	public partial class GroupDataManager : ExerFormForGroupData {
		
		/// <summary>
		/// 对应的列表
		/// </summary>
		public override ExerListView listView => itemList;

		/// <summary>
		/// 各种按钮
		/// </summary>
		public override Button copyBtn => copy;
		public override Button deleteBtn => delete;
		public override Button moveUpBtn => moveUp;
		public override Button moveDownBtn => moveDown;

		public override Button createBtn => create;
		public override Button saveBtn => save;

		public override GroupBox currentPage => curPage;

		/// <summary>
		/// 子窗口
		/// </summary>
		SubFormFlag<ModifyParams> paramsForm = new SubFormFlag<ModifyParams>();
		SubFormFlag<ModifyGroupDataInherits> inheritsForm = 
			new SubFormFlag<ModifyGroupDataInherits>();

		/// <summary>
		/// 构造函数
		/// </summary>
		public GroupDataManager() {
			InitializeComponent();
		}

		#region 默认事件

		private void editParams_Click(object sender, EventArgs e) {
			var form = paramsForm.setupForm(this);
			form.setItems(item.params_);
			form.Show();
		}
		
		private void clearParams_Click(object sender, EventArgs e) {
			item.params_.Clear();
			update();
		}

		private void showParent_CheckedChanged(object sender, EventArgs e) {
			refreshParamLists();
		}

		private void editInherit_Click(object sender, EventArgs e) {
			var form = inheritsForm.setupForm(this);
			form.setIndices(item.inherits);
			form.Show();
		}

		private void paramList_SelectedIndexChanged(object sender, EventArgs e) {
		}

		private void paramList_DoubleClick(object sender, EventArgs e) {
			var data = paramList.getCurrentData<InterfaceParam>();
			FormUtils.openForm<GroupDataManager, GroupData>(data.typeId);
		}

		#endregion

		#region 初始化/配置

		/// <summary>
		/// 非自动控件名称
		/// </summary>
		/// <returns></returns>
		protected override Control[] notAutoControlNames() {
			return new Control[] { inheritClasses, deriveClasses, showParent };
		}

		#endregion

		#region 控件操作

		/// <summary>
		/// 是否显示父属性
		/// </summary>
		/// <returns></returns>
		bool isShowParent() {
			return showParent.Checked;
		}

		#region 控件配置

		/// <summary>
		/// 刷新窗口
		/// </summary>
		protected override void configCustomControls() {
			base.configCustomControls();
			setupParamLists();
		}

		/// <summary>
		/// 配置参数列表
		/// </summary>
		void setupParamLists() {
			paramList.setupColumns<InterfaceParam>();
			paramList.setupGroups<GroupData>();
		}

		#endregion

		#region 控件绑定/更新

		/// <summary>
		/// 刷新
		/// </summary>
		protected override void refreshMain() {
			base.refreshMain();
			refreshParamLists();
		}

		/// <summary>
		/// 刷新参数列表
		/// </summary>
		void refreshParamLists() {
			if (isShowParent())
				paramList.setup(item.totalParams());
			else
				paramList.setup(item.params_);
		}

		/// <summary>
		/// 更新窗口
		/// </summary>
		protected override void updateCustomControls() {
			base.updateCustomControls();
			updateInheritInfo();
			updateControlsEnable();
		}

		/// <summary>
		/// 更新继承信息
		/// </summary>
		void updateInheritInfo() {
			var inherits = item.inheritTypes();
			var derives = item.deriveTypes();

			inheritClasses.Text = deriveClasses.Text = "";

			foreach (var type in inherits)
				inheritClasses.Text += type.code + " ";
			foreach (var type in derives)
				deriveClasses.Text += type.code + " ";
		}

		/// <summary>
		/// 更新控件可用性
		/// </summary>
		void updateControlsEnable() {
			setCurrentEnable(!item.buildIn);
		}

		#endregion

		#endregion
	}
}
