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
	using Scripts.Forms;
	using Scripts.Controls;

	public partial class ExceptionManager : ExerFormForException, ICodeGenerator {
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

		string fCode_ = "";
		public string fCode {
			get => fCode_;
			set { fCode_ = value; sendChangeInfo("fCode"); }
		}
		string bCode_ = "";
		public string bCode {
			get => bCode_;
			set { bCode_ = value; sendChangeInfo("bCode"); }
		}

		/// <summary>
		/// 实现的接口。
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// 属性改变后需要调用的方法，触发PropertyChanged事件。
		/// </summary>
		/// <param name="propertyName">属性名</param>
		private void sendChangeInfo(string propertyName) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// 打开代码预览窗口
		/// </summary>
		public void openCodePreview() {
			var form = new CodePreview();
			form.setupGenerator(this);
			form.Show();
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
			var moduleId = item.bModuleId;
			var items = BaseData.poolGet<Exception_>();
			items = items.FindAll(e => e.bModuleId == moduleId);

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
			bModule.setup<Module>();
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
			bCode = Exception_.genPyExceptionCode();
		}

		#endregion

		#endregion
	}
}
