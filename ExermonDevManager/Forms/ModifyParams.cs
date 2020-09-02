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
	using Scripts.Utils;
	using Scripts.Controls;

	public partial class ModifyParams : ExerFormForInterfaceParam { 
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
		public ModifyParams() {
			InitializeComponent();
		}

		#region 默认事件
		
		private void intType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Types.Int);
		}

		private void doubleType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Types.Double);
		}

		private void strType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Types.Str);
		}

		private void boolType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Types.Bool);
		}

		private void dictType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Types.Dict);
		}

		private void varType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Types.Var);
		}

		private void dateType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Types.Date_);
		}

		private void dateTimeType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Types.DateTime_);
		}

		private void tupleType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			setType(Default.Types.DataTuple_);
		}

		private void newType_Click(object sender, EventArgs e) {
			FormUtils.openForm<GroupDataManager>();
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
		void setType(GroupData type) {
			//var index = BaseData.poolIndex(type);
			//this.type.SelectedIndex = index;
			this.type.select(type);
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
			type.setup<GroupData>();
		}

		#endregion

		#endregion
	}
}
