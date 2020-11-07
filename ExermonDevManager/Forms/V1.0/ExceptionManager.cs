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
	using Scripts.CodeGen;

	public partial class ExceptionManager : ExerFormForException {
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

		#region 代码生成接口实现
		
		/// <summary>
		/// 子窗口
		/// </summary>
		SubFormFlag<CodePreview> codePreviewForm = new SubFormFlag<CodePreview>();

		/// <summary>
		/// 打开代码预览窗口
		/// </summary>
		public void openCodePreview() {
			var form = codePreviewForm.setupForm(this);
			form.setup(item); form.Show();
		}

		#endregion

		public ExceptionManager() {
			InitializeComponent();
		}

		#region 默认事件

		private void codePreview_Click(object sender, EventArgs e) {
			openCodePreview();
		}

		private void autoCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			doAutoCode();
		}

		#endregion

		#region 数据操作

		/// <summary>
		/// 自动编号
		/// </summary>
		public void doAutoCode() {
			var moduleId = item.moduleId;
			var items = BaseData.poolGet<Exception_>();
			items = items.FindAll(e => e.moduleId == moduleId);

			var code = 0;
			foreach (var item in items)
				code = Math.Max(code, item.code);

			this.code.Value = code + 1;
		}

		#endregion

		#region 控件配置

		/// <summary>
		/// 刷新窗口
		/// </summary>
		protected override void configCustomControls() {
			base.configCustomControls();
			setupComboxes();
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
			module.setup<Module>();
		}

		#region 控件绑定/更新

		/// <summary>
		/// 更新自定义控件
		/// </summary>
		protected override void updateCustomControls() {
			base.updateCustomControls();
			updateCodePreview();
		}

		/// <summary>
		/// 更新代码预览
		/// </summary>
		void updateCodePreview() {
			codePreviewForm.form?.refreshGenerator();
			//bCode = Exception_.genPyExceptionCode();
		}

		#endregion

		#endregion
	}
}
