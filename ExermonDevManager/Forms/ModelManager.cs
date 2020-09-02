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

	public partial class ModelManager : ExerFormForModel, ICodeGenerator {
		
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

		/// <summary>
		/// 子窗口
		/// </summary>
		SubFormFlag<ModifyFields> fieldsForm = new SubFormFlag<ModifyFields>();
		SubFormFlag<ModifyTypeSettings> typeSettingsForm = new SubFormFlag<ModifyTypeSettings>();
		SubFormFlag<ModifyModelInherits> inheritsForm =
			new SubFormFlag<ModifyModelInherits>();

		/// <summary>
		/// 构造函数
		/// </summary>
		public ModelManager() {
			InitializeComponent();
		}

		#region 默认事件

		private void editParams_Click(object sender, EventArgs e) {
			var form = fieldsForm.setupForm(this);
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

		private void editTypeSettings_Click(object sender, EventArgs e) {
			var form = typeSettingsForm.setupForm(this);
			form.setItems(item.typeSettings);
			form.Show();
		}

		private void codePreview_Click(object sender, EventArgs e) {
			openCodePreview();
		}

		#endregion

		#region 初始化/配置

		/// <summary>
		/// 非自动控件名称
		/// </summary>
		/// <returns></returns>
		protected override Control[] notAutoControlNames() {
			return new Control[] { inheritClasses, deriveClasses, showParent};
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
			module.setup<Module>();
		}

		/// <summary>
		/// 配置参数列表
		/// </summary>
		void setupParamLists() {
			paramList.setupColumns<ModelField>();
			paramList.setupGroups<Model>();
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
			updateCodePreview();
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
		/// 更新代码预览
		/// </summary>
		void updateCodePreview() {
			fCode = item.genCSCode();
			bCode = item.genPyCode();
		}

		/// <summary>
		/// 更新控件可用性
		/// </summary>
		void updateControlsEnable() {
			keyName.Enabled = item.isBackend;
			editTypeSettings.Enabled = item.isBackend;
		}

		#endregion

		#endregion
	}
}
