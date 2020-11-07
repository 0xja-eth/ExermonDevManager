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

	public partial class ModuleManager : ExerFormForModule {

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

		public ModuleManager() {
			InitializeComponent();
		}

		#region 默认事件

		private void editRRInterfaces_Click(object sender, EventArgs e) {
			FormUtils.openForm<ReqResInterfaceManager>();
		}

		private void editEInterfaces_Click(object sender, EventArgs e) {
			FormUtils.openForm<EmitInterfaceManager>();
		}

		private void rrInterfaceList_SelectedIndexChanged(object sender, EventArgs e) {
		}

		private void eInterfaceList_SelectedIndexChanged(object sender, EventArgs e) {
		}

		private void rrInterfaceList_DoubleClick(object sender, EventArgs e) {
			var item = rrInterfaceList.getSelectedData<ReqResInterface>();
			FormUtils.openForm<ReqResInterfaceManager, ReqResInterface>(item);
		}

		private void eInterfaceList_DoubleClick(object sender, EventArgs e) {
			var item = eInterfaceList.getSelectedData<EmitInterface>();
			FormUtils.openForm<EmitInterfaceManager, EmitInterface>(item);
		}

		#endregion

		#region 初始化/配置

		#endregion

		#region 控件操作

		#region 控件配置

		/// <summary>
		/// 刷新窗口
		/// </summary>
		protected override void configCustomControls() {
			base.configCustomControls();
			setupInterfaceLists();
		}

		/// <summary>
		/// 配置参数列表
		/// </summary>
		void setupInterfaceLists() {
			rrInterfaceList.setupColumns<ReqResInterface>();
			eInterfaceList.setupColumns<EmitInterface>();
		}

		#endregion

		#region 控件绑定/更新

		/// <summary>
		/// 刷新
		/// </summary>
		protected override void refreshMain() {
			base.refreshMain();
			refreshInterfaceLists();
		}

		/// <summary>
		/// 刷新参数列表
		/// </summary>
		void refreshInterfaceLists() {
			rrInterfaceList.setup(item.reqResInterfaces());
			eInterfaceList.setup(item.emitInterfaces());
		}

		#endregion

		#endregion
	}
}
