using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using ExermonDevManager.Forms;

namespace ExermonDevManager.Scripts.Utils {

	using Data;
	using Forms;
	using Controls;

	/// <summary>
	/// 子窗口标志（基类）
	/// </summary>
	public abstract class SubFormFlag {

		/// <summary>
		/// 窗体关闭回调
		/// </summary>
		public abstract void onFormClosed();
	}

	/// <summary>
	/// 子窗口标记
	/// </summary>
	public class SubFormFlag<T> : SubFormFlag where T : ExermonForm, new() {

		/// <summary>
		/// 子窗体
		/// </summary>
		public T form = null;

		/// <summary>
		/// 配置窗口
		/// </summary>
		/// <param name="form"></param>
		public T setupForm(ExermonForm parent = null) {
			if (form != null) return form; // 开启中
			form = new T(); form.flag = this;
			form.parentForm = parent;
			return form;
		}

		/// <summary>
		/// 开启窗口
		/// </summary>
		/// <param name="form"></param>
		public void openForm(ExermonForm parent = null) {
			setupForm(parent).Show();
		}

		/// <summary>
		/// 关闭窗口
		/// </summary>
		/// <param name="form"></param>
		public void closeForm() {
			form?.Close();
		}

		/// <summary>
		/// 窗体关闭回调
		/// </summary>
		public override void onFormClosed() {
			form = null;
		}
	}

	/// <summary>
	/// 窗体工具类
	/// </summary>
	public static class FormUtils {

		/// <summary>
		/// 主窗体
		/// </summary>
		public static MainForm mainForm = null;

		#region 数据操作

		///// <summary>
		///// 设置下拉框数据
		///// </summary>
		//public static void setupComboData<T>(ComboBox control)
		//	where T : ControlData {
		//	setupComboData(control, BaseData.poolGet<T>());
		//}
		//public static void setupComboData<T>(ComboBox control, List<T> objects)
		//	where T : ControlData {
		//	control.Tag = objects;
		//	control.Items.Clear();

		//	foreach (var obj in objects)
		//		control.Items.Add(obj.comboText());
		//}

		///// <summary>
		///// 选择
		///// </summary>
		///// <param name="control"></param>
		//public static void selectCombo(ComboBox control) {

		//}

		//public static void setupComboData(Type type, ComboBox control) {
		//	setupComboData(type, control, BaseData.poolGet(type));
		//}
		//public static void setupComboData(Type type,
		//	ComboBox control, List<BaseData> objects) {
		//	control.Items.Clear();

		//	foreach (var obj in objects) {
		//		var obj_ = obj as ControlData;
		//		if (obj_ != null)
		//			control.Items.Add(obj_.comboText());
		//	}
		//}

		#endregion

		#region 绑定操作

		///// <summary>
		///// 绑定文本盒
		///// </summary>
		//public static void bindControl(BaseData data, Control control, 
		//	string controlKey, string dataKey = null, string format = "{0}") {

		//	dataKey = dataKey ?? string.Format(format, control.Name);

		//	control.DataBindings.Clear();
		//	control.DataBindings.Add(controlKey, data, dataKey, 
		//		false, DataSourceUpdateMode.OnPropertyChanged);
		//}

		///// <summary>
		///// 绑定文本盒
		///// </summary>
		//public static void bindText(BaseData data,
		//	TextBox control, string name = null) {
		//	bindControl(data, control, "Text", name);
		//}

		///// <summary>
		///// 绑定下拉框
		///// </summary>
		//public static void bindCheck(BaseData data,
		//	CheckBox control, string name = null) {
		//	bindControl(data, control, "Checked", name);
		//}

		///// <summary>
		///// 绑定下拉框
		///// </summary>
		//public static void bindCombo(BaseData data,
		//	ComboBox control, string name = null) {
		//	var exerControl = control as ExerComboBox;
		//	if (exerControl != null)
		//		bindControl(data, control, "SelectedDataId", name, "{0}Id");
		//	else
		//		bindControl(data, control, "SelectedIndex", name, "{0}Id");
		//}

		///// <summary>
		///// 绑定下拉框
		///// </summary>
		//public static void bindNumberInput(BaseData data,
		//	NumericUpDown control, string name = null) {
		//	bindControl(data, control, "Value", name);
		//}

		#endregion

		#region 窗口交互

		/// <summary>
		/// 打开窗口
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public static void openForm<T>() 
			where T : ExermonForm, new() {
			mainForm?.openForm<T>();
		}
		public static void openForm<T, C>(int index)
			where T : ExermonForm<C>, new()
			where C : CoreData, new() {
			if (index < 0) return;
			mainForm?.openForm<T, C>(index);
		}
		public static void openForm<T, C>(C data)
			where T : ExermonForm<C>, new()
			where C : CoreData, new() {
			if (data == null) return;
			mainForm?.openForm<T, C>(data);
		}

		#endregion
	}
}
