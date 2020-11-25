using System.Windows.Forms;

namespace ExermonDevManager.Frameworks.ExerUnity.Forms {

	using Entities;
	using Core.Forms;

	//public class ExerFormForModelField : Form { }
	public class ExerFormForModelField : ExerSubForm<ModelField> {

		#region 控件操作
		
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
		}

		#endregion

		#region 控件绑定/更新

		/// <summary>
		/// 更新
		/// </summary>
		protected override void updateCustomControls() {
			base.updateCustomControls();
			updateControlsEnable();
			updateCodePreviews();
		}

		/// <summary>
		/// 更新控件有效情况
		/// </summary>
		void updateControlsEnable() {
			//var enableNames = currentItem.getEnableFieldNames();
			//foreach (var c in fieldControls)
			//	doUpdateControl(c as Control, enableNames);
		}

		///// <summary>
		///// 执行配置
		///// </summary>
		///// <param name="control"></param>
		//void doUpdateControl(Control c, List<string> enables) {
		//	if (c == null) return;

		//	var name = c.Name;
		//	// 是 ComboBox 类型
		//	if ((c as ComboBox) != null) name += "Id";
		//	c.Enabled = enables.Contains(name);
		//}

		/// <summary>
		/// 更新代码预览
		/// </summary>
		void updateCodePreviews() {
			//bCode.Text = currentItem.bCode();
			//fCode.Text = currentItem.fCode();
		}

		#endregion

		#endregion
	}

	}
