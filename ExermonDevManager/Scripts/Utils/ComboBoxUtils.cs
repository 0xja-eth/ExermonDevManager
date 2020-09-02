//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using System.Windows.Forms;

//namespace ExermonDevManager.Scripts.Utils {

//	using Data;

//	/// <summary>
//	/// 下拉框工具类
//	/// </summary>
//	public static class ComboBoxUtils {

//		#region 获取相关

//		/// <summary>
//		/// 获取项数
//		/// </summary>
//		/// <returns></returns>
//		public static int itemCount(ComboBox control) {
//			return control.Items.Count;
//		}

//		/// <summary>
//		/// 获取项数
//		/// </summary>
//		/// <returns></returns>
//		public static int itemDataCount<T>(ComboBox control) 
//			where T: ControlData {
//			var objects = control.Tag as List<T>;
//			if (objects == null) return 0;
//			return objects.Count;
//		}
		
//		#endregion

//		#region 选择/选中

//		/// <summary>
//		/// 选中
//		/// </summary>
//		public static void select(ComboBox control, int index) {
//			var cnt = itemCount(control);
//			index = adjustIndex(index, cnt - 1);
//			control.SelectedIndex = index;
//		}
//		public static void select<T>(ComboBox control, T obj) 
//			where T : ControlData{
//			select(control, getIndex(control, obj));
//		}

//		/// <summary>
//		/// 调整索引
//		/// </summary>
//		/// <returns></returns>
//		public static int adjustIndex(int index, int cnt) {
//			return Math.Min(Math.Max(index, 0), cnt);
//		}

//		#endregion

//		#region 数据相关

//		#region 数据获取

//		/// <summary>
//		/// 获取项数据
//		/// </summary>
//		/// <returns></returns>
//		public static T getData<T>(ComboBox control, int index)
//			where T : ControlData {
//			if (index < 0) return null;

//			var cnt = itemDataCount<T>(control);
//			if (cnt <= 0) return null;

//			var objects = control.Tag as List<T>;

//			index = adjustIndex(index, cnt - 1);
//			return objects[index];
//		}
		
//		/// <summary>
//		/// 获取项索引
//		/// </summary>
//		/// <returns></returns>
//		public static int getIndex<T>(ComboBox control, T obj)
//			where T : ControlData {
//			var objects = control.Tag as List<T>;
//			if (objects == null) return -1;
//			return objects.IndexOf(obj);
//		}

//		#endregion

//		#region 数据配置/更新
		
//		/// <summary>
//		/// 设置列表数据
//		/// </summary>
//		public static void setupItems<T>(ComboBox control) where T : ControlData {
//			setupItems(control, BaseData.poolGet<T>());
//		}
//		public static void setupItems<T>(ComboBox control, List<T> objects) where T : ControlData {
//			control.Tag = objects;
//			updateItems<T>(control);
//		}

//		/// <summary>
//		/// 更新项
//		/// </summary>
//		public static void updateItems<T>(ComboBox control) where T : ControlData {
//			var objects = control.Tag as List<T>;
//			if (objects == null) return;

//			control.Items.Clear();
//			foreach (var obj in objects)
//				control.Items.Add(obj.comboText());
//		}
		
//		#endregion

//		#endregion
//	}
//}
