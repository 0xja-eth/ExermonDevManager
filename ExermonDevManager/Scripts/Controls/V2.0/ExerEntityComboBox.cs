using System;
using System.Collections;
using System.Windows.Forms;

namespace ExermonDevManager.Scripts.Controls {

	using Entities;

	/// <summary>
	/// Exer下拉框
	/// </summary>
	public partial class ExerEntityComboBox : ComboBox, IExerEntityControl {

		public ExerEntityComboBox() {
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
			SelectedIndexChanged += (_, __) => action();
		}

		/// <summary>
		/// 绑定数据
		/// </summary>
		/// <param name="data"></param>
		public virtual void bind(CoreEntity data) {
			var vType = data?.getPropType(Name);
			// 如果不是外键
			if (!vType.IsSubclassOf(typeof(CoreEntity)))
				return;

			bindValue(data);
			bindSource(DBManager.getItems(vType));
		}

		/// <summary>
		/// 绑定值
		/// </summary>
		/// <param name="data"></param>
		void bindValue(CoreEntity data) {
			DataBindings.Clear();
			DataBindings.Add("SelectedValue", data, Name + "Id",
				false, DataSourceUpdateMode.OnPropertyChanged);
		}

		/// <summary>
		/// 绑定数据源
		/// </summary>
		/// <param name="source"></param>
		void bindSource(IList list) {
			DataSource = list;
			DisplayMember = "displayName";
			ValueMember = "id";
		}
	}

}
