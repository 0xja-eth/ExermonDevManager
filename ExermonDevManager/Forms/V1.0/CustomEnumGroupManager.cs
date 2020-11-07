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

	public partial class CustomEnumGroupManager : ExerFormForCustomEnumGroup {
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
		SubFormFlag<ModifyCustomEnums> enumsForm = 
			new SubFormFlag<ModifyCustomEnums>();

		/// <summary>
		/// 构造函数
		/// </summary>
		public CustomEnumGroupManager() {
			InitializeComponent();
		}

		#region 默认事件

		private void editEnums_Click(object sender, EventArgs e) {
			var form = enumsForm.setupForm(this);
			form.setItems(item.values);
			form.Show();
		}

		private void clearEnums_Click(object sender, EventArgs e) {
			item.values.Clear();
			update();
		}

		#endregion

		#region 控件配置

		/// <summary>
		/// 刷新窗口
		/// </summary>
		protected override void configCustomControls() {
			base.configCustomControls();
			setupEnumList();

		}

		/// <summary>
		/// 配置枚举项列表
		/// </summary>
		void setupEnumList() {
			enumList.setupColumns<CustomEnum>();
		}

		#endregion

		#region 控件绑定/更新

		/// <summary>
		/// 刷新
		/// </summary>
		protected override void refreshMain() {
			base.refreshMain();
			refreshEnumList();
		}

		/// <summary>
		/// 刷新枚举项列表
		/// </summary>
		void refreshEnumList() {
			enumList.setup(item.values);
		}
		
		#endregion
	}
}
