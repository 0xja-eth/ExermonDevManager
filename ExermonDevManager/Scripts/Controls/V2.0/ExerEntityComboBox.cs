using System;
using System.Collections;
using System.ComponentModel;

using System.Windows.Forms;

namespace ExermonDevManager.Scripts.Controls {

	using Entities;

	/// <summary>
	/// Exer下拉框
	/// </summary>
	public partial class ExerEntityComboBox : 
		ComboBox, IExerEntityControl, INotifyPropertyChanged {

		public ExerEntityComboBox() {
			InitializeComponent();
			SelectedIndexChanged += (_, __) =>
				onPropertyChanged("SelectedDataId");
		}

		/// <summary>
		/// 当前数据索引
		/// </summary>
		[Bindable(true)]
		public int? SelectedDataId {
			get => SelectedData?.id;
			set {
				var items = DataSource as IList;
				SelectedIndex = items.IndexOf(value);
				onPropertyChanged("SelectedDataId");
			}
		}

		/// <summary>
		/// 当前数据
		/// </summary>
		public CoreEntity SelectedData {
			get => SelectedValue as CoreEntity;
			set { SelectedValue = value; }
		}

		/// <summary>
		/// 数据绑定接口实现
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		protected void onPropertyChanged(string name) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
			DataBindings.Add("SelectedDataId", data, Name + "Id",
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
