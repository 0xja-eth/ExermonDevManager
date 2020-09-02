using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExermonDevManager.Scripts.Forms {

	using Data;
	using Controls;

	public partial class ModifyInherits<T> : ExermonForm<T> 
		where T : Type_, new() {

		/// <summary>
		/// 对应的列表
		/// </summary>
		public override ExerListView listView => currentList;

		/// <summary>
		/// 确认按钮
		/// </summary>
		public override Button confirmBtn => confirm;

		/// <summary>
		/// 所有可继承的类型
		/// </summary>
		List<T> allTypes;

		/// <summary>
		/// 构造函数
		/// </summary>
		public ModifyInherits() {
			InitializeComponent();
		}

		#region 默认事件

		protected void typeList_ItemCheck(object sender, ItemCheckEventArgs e) {
			check(e.Index, e.NewValue == CheckState.Checked);
			//var item = allTypes[e.Index];

			//if (e.NewValue == CheckState.Checked) addItem(item);
			//else if (e.NewValue == CheckState.Unchecked) removeItem(item);
		}

		protected void clear_Click(object sender, EventArgs e) {
			clearItems();
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

		#region 数据操作

		/// <summary>
		/// 获取当前类型
		/// </summary>
		public T getCurrentType() {
			return (parentForm as ExermonForm<T>)?.item;
		}

		/// <summary>
		/// 选择
		/// </summary>
		public void check(int index, bool checked_) {
			var item = allTypes[index];

			if (checked_) addItem(item);
			else removeItem(item);
		}

		#endregion

		#region 控件操作

		#region 控件配置

		/// <summary>
		/// 刷新窗口
		/// </summary>
		protected override void configCustomControls() {
			base.configCustomControls();
			setupTypeLists();
			setupTypeListChecking();
		}

		/// <summary>
		/// 配置类型列表
		/// </summary>
		void setupTypeLists() {
			var curType = getCurrentType();
			var curDerives = curType.deriveTypes<T>();

			allTypes = BaseData.poolGet<T>();
			allTypes.RemoveAll(t => t == curType ||
				curDerives.Contains(t));
			allTypes.RemoveAll(t => !t.derivable);

			typeList.setupColumns<T>();
			typeList.setup(allTypes);
		}

		/// <summary>
		/// 配置类型列表选择情况
		/// </summary>
		void setupTypeListChecking() {
			typeList.uncheck();
			foreach (var item in items)
				typeList.check(item);
		}

		#endregion

		#region 控件绑定/更新


		#endregion

		#endregion
	}

	/// <summary>
	/// 子窗体
	/// </summary>
	public class ModifyInheritsForGroupData : ModifyInherits<GroupData> { }
	public class ModifyInheritsForModel : ModifyInherits<Model> { }
}
