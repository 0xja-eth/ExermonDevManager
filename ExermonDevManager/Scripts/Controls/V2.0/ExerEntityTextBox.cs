using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExermonDevManager.Scripts.Controls {

	using Entities;

	public partial class ExerEntityTextBox : TextBox, IExerEntityControl {
		public ExerEntityTextBox() {
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
			TextChanged += (_, __) => action();
		}

		/// <summary>
		/// 绑定数据
		/// </summary>
		/// <param name="data"></param>
		public virtual void bind(CoreEntity data) {
			DataBindings.Clear();
			DataBindings.Add("Text", data, Name, false,
				DataSourceUpdateMode.OnPropertyChanged);
		}

	}
}
