using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExermonDevManager.Core.Controls {

	using Data;

	public partial class ExermonNumericUpDown : 
		NumericUpDown, IExermonEditControl {
		public ExermonNumericUpDown() {
			InitializeComponent();
		}

		/// <summary>
		/// 注册更新事件
		/// </summary>
		/// <param name="event_"></param>
		public void registerUpdateEvent(Action action) {
			Click += (_, __) => action();
			KeyUp += (_, __) => action();
			LostFocus += (_, __) => action();
			ValueChanged += (_, __) => action();
		}

		/// <summary>
		/// 绑定数据
		/// </summary>
		/// <param name="data"></param>
		public virtual void bind(CoreData data) {
			DataBindings.Clear();
			DataBindings.Add("Value", data, Name, false, 
				DataSourceUpdateMode.OnPropertyChanged);
		}
	}
}
