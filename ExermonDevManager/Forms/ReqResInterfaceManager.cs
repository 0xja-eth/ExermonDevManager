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

	public partial class ReqResInterfaceManager : ExerFormForReqResInterface { 
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
		SubFormFlag<ModifyParams> reqParamsForm = new SubFormFlag<ModifyParams>();
		SubFormFlag<ModifyParams> resParamsForm = new SubFormFlag<ModifyParams>();

		/// <summary>
		/// 构造函数
		/// </summary>
		public ReqResInterfaceManager() {
			InitializeComponent();
		}

		#region 默认事件

		private void editReqParams_Click(object sender, EventArgs e) {
			var form = reqParamsForm.setupForm(this);
			form.setItems(item.reqParams);
			form.Show();
		}

		private void editResParams_Click(object sender, EventArgs e) {
			var form = reqParamsForm.setupForm(this);
			form.setItems(item.resParams);
			form.Show();
		}

		private void clearReqParams_Click(object sender, EventArgs e) {
			item.reqParams.Clear();
			update();
		}

		private void clearResParams_Click(object sender, EventArgs e) {
			item.resParams.Clear();
			update();
		}

		private void reqParamList_SelectedIndexChanged(object sender, EventArgs e) {
		}

		private void resParamList_SelectedIndexChanged(object sender, EventArgs e) {
		}

		private void reqParamList_DoubleClick(object sender, EventArgs e) {
			var data = reqParamList.getCurrentData<InterfaceParam>();
			FormUtils.openForm<GroupDataManager, GroupData>(data.typeId);
		}

		private void resParamList_DoubleClick(object sender, EventArgs e) {
			var data = resParamList.getCurrentData<InterfaceParam>();
			FormUtils.openForm<GroupDataManager, GroupData>(data.typeId);
		}

		private void autoFill_Click(object sender, EventArgs e) {
			doAutoFill();
		}

		private void codePreview_Click(object sender, EventArgs e) {

		}

		#endregion

		#region 数据操作

		/// <summary>
		/// 自动填充
		/// </summary>
		public void doAutoFill() {
			var route = item.route;
			var strs = route.Split('/', '\\');

			if (strs.Length <= 2) return;

			var mName = strs[0]; // 模块名称
			var fName = string.Join("_", strs); // 前端名称
			var pName = string.Join("_", strs, 1, strs.Length - 1); // 函数名称

			pName = DataLoader.underline2LowerHump(pName);
			fName = DataLoader.underline2UpperHump(fName);

			var modules = BaseData.poolGet<Module>();
			var module = modules.Find(m => m.code.ToLower() == mName);

			bModule.SelectedIndex = module.id;
			this.fName.Text = fName; bFunc.Text = pName; 
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
			bTag.setup<ChannelsTag>();
		}

		/// <summary>
		/// 配置参数列表
		/// </summary>
		void setupParamLists() {
			reqParamList.setupColumns<InterfaceParam>();
			resParamList.setupColumns<InterfaceParam>();
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
			reqParamList.setup(item.reqParams);
			resParamList.setup(item.resParams);
		}

		#endregion

		#endregion

	}
}
