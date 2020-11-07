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

	public partial class EmitInterfaceManager : ExerFormForEmitInterface { 
		//ExermonForm<ReqResInterface> {

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

		/// <summary>
		/// 构造函数
		/// </summary>
		public EmitInterfaceManager() {
			InitializeComponent();
		}

		#region 默认事件

		private void editReqParams_Click(object sender, EventArgs e) {
			var form = paramsForm.setupForm(this);
			form.setItems(item.params_);
			form.Show();
		}
		
		private void clearReqParams_Click(object sender, EventArgs e) {
			item.params_.Clear();
			update();
		}

		private void paramList_SelectedIndexChanged(object sender, EventArgs e) {
		}

		private void paramList_DoubleClick(object sender, EventArgs e) {
			var data = paramList.getCurrentData<InterfaceParam>();
			FormUtils.openForm<GroupDataManager, GroupData>(data.typeId);
		}

		#endregion

		#region 控件操作

		#region 控件配置

		/// <summary>
		/// 刷新窗口
		/// </summary>
		protected override void configCustomControls() {
			base.configCustomControls();
			setupComboxes();
			setupParamLists();
		}

		/// <summary>
		/// 配置项目列表
		/// </summary>
		protected override void setupItemList() {
			base.setupItemList();
			itemList.setupGroups<Module>();
		}

		/// <summary>
		/// 配置下拉框数据
		/// </summary>
		void setupComboxes() {
			bModule.setup<Module>();
		}

		/// <summary>
		/// 配置参数列表
		/// </summary>
		void setupParamLists() {
			paramList.setupColumns<InterfaceParam>();
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
			paramList.setup(item.params_);
		}

		#endregion

		#endregion
	}
}
