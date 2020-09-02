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

	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
		}

		/// <summary>
		/// 子窗口管理字典
		/// </summary>
		Dictionary<Type, SubFormFlag> subFormFlags = 
			new Dictionary<Type, SubFormFlag>();

		#region 默认事件

		private void MainForm_Load(object sender, EventArgs e) {
			initForm();
			DataManager.loadAllData();
		}

		private void module_Click(object sender, EventArgs e) {
			openForm<ModuleManager>();
		}

		private void reqResInterface_Click(object sender, EventArgs e) {
			openForm<ReqResInterfaceManager>();
		}

		private void emitInterface_Click(object sender, EventArgs e) {
			openForm<EmitInterfaceManager>();
		}

		private void groupData_Click(object sender, EventArgs e) {
			openForm<GroupDataManager>();
		}

		private void model_Click(object sender, EventArgs e) {
			openForm<ModelManager>();
		}

		private void customEnumGroup_Click(object sender, EventArgs e) {
			openForm<CustomEnumGroupManager>();
		}

		private void exception_Click(object sender, EventArgs e) {
			openForm<ExceptionManager>();
		}

		private void saveData_Click(object sender, EventArgs e) {
			DataManager.saveAllData();
		}

		#endregion

		#region 窗口配置

		/// <summary>
		/// 初始化
		/// </summary>
		void initForm() {
			FormUtils.mainForm = this;

			registerSubForm<ModuleManager>();
			registerSubForm<ReqResInterfaceManager>();
			registerSubForm<EmitInterfaceManager>();
			registerSubForm<GroupDataManager>();
			registerSubForm<ModelManager>();
			registerSubForm<CustomEnumGroupManager>();
			registerSubForm<ExceptionManager>();
		}

		#endregion

		#region 子窗口操作

		/// <summary>
		/// 注册子窗口
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="subForm"></param>
		public void registerSubForm<T>(SubFormFlag<T> subForm = null) 
			where T: ExermonForm, new() {
			subForm = subForm ?? new SubFormFlag<T>();
			subFormFlags.Add(typeof(T), subForm);
		}

		/// <summary>
		/// 获取子窗口
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public SubFormFlag<T> getSubForm<T>() where T : ExermonForm, new() {
			var type = typeof(T);
			if (!subFormFlags.ContainsKey(type)) return null;
			return subFormFlags[type] as SubFormFlag<T>;
		}

		/// <summary>
		/// 打开窗口
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void openForm<T>() where T : ExermonForm, new() {
			getSubForm<T>()?.openForm();
		}
		public void openForm<T, C>(int index)
			where T : ExermonForm<C>, new()
			where C : ControlData, new() {

			var sub = getSubForm<T>();
			sub?.openForm();

			var form = sub?.form as T;
			if (form != null) form.index = index;
		}
		public void openForm<T, C>(C data)
			where T : ExermonForm<C>, new()
			where C : ControlData, new() {

			var sub = getSubForm<T>();
			sub?.openForm();

			var form = sub?.form as T;
			if (form != null) form.item = data;
		}

		#endregion

	}
}
