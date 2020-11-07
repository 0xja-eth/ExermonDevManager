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
	using Scripts.Controls;

	public partial class ModifyCustomEnums : ExerFormForCustomEnum { 
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
		public ModifyCustomEnums() {
			InitializeComponent();
		}

		#region 默认事件

		#endregion

		#region 窗口事件

		/// <summary>
		/// 确认回调
		/// </summary>
		protected override void onConfirm() {
			base.onConfirm(); Close();
		}

		#endregion
		
	}
}
