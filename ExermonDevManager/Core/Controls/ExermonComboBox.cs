using System;
using System.Collections;
using System.ComponentModel;

using System.Windows.Forms;

namespace ExermonDevManager.Core.Controls {

	using Data;
	using Entities;
	using Managers;

	/// <summary>
	/// Exer下拉框
	/// </summary>
	public partial class ExermonComboBox : 
		ComboBox, IExermonEditControl, INotifyPropertyChanged {

		/// <summary>
		/// 内置数据源
		/// </summary>
		protected BindingSource source;

		/// <summary>
		/// 过滤
		/// </summary>
		public string filter {
			get => source.Filter;
			set {
				source.Filter = value;
				DataSource = source;
			}
		}

		/// <summary>
		/// 当前数据索引
		/// </summary>
		//[Bindable(true)] [Browsable(false)]
		//public int? NullableSelectedValue {
		//	get => (int)SelectedValue <= 0 ? null : (int?)SelectedValue;
		//	set {
		//		if (value == null) SelectedIndex = -1;
		//		else SelectedValue = value.Value;

		//		onPropertyChanged("NullableSelectedValue");
		//	}
		//}

		///// <summary>
		///// 当前数据
		///// </summary>
		//public CoreEntity SelectedData {
		//	get => SelectedValue as CoreEntity;
		//	set { SelectedValue = value; }
		//}

		/// <summary>
		/// 数据绑定接口实现
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		protected void onPropertyChanged(string name) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public ExermonComboBox() {
			InitializeComponent();
			//SelectedIndexChanged += (_, __) =>
			//	onPropertyChanged("NullableSelectedValue");
			source = new BindingSource();
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
		/// 配置数据源
		/// </summary>
		/// <param name="source"></param>
		public void setupSource(IList list) {
			source.DataSource = list;

			DataSource = source;
			DisplayMember = "displayName";
			ValueMember = "id";
		}

		/// <summary>
		/// 绑定数据
		/// </summary>
		/// <param name="data"></param>
		public virtual void bind(CoreData data) {
			var entity = data as BaseEntity;

			// 对应属性的类型
			var vType = data?.getPropType(Name);
			if (vType == null || !vType.IsSubclassOf(
				typeof(CoreData))) return;

			if (source.DataSource == null) 
				setupSource(Managers.DataManager.getDataList(vType));

			bindValue(data);
		}

		/// <summary>
		/// 绑定值
		/// </summary>
		/// <param name="data"></param>
		void bindValue(CoreData data) {
			var bName = Name + "Id";
			var vType = data?.getPropType(bName);

			// 如果 vType为空 或者 不是外键
			if (vType == null) return;

			DataBindings.Clear();
			DataBindings.Add("SelectedValue", data, bName,
				false, DataSourceUpdateMode.OnPropertyChanged);
		}
		//void bindValue(BaseEntity data) {
		//	var bName = Name + "Id";
		//	var vType = data?.getPropType(bName);

		//	// 如果 vType为空 或者 不是外键
		//	if (vType == null) return;

		//	//string bindingProp = vType == typeof(int?) ? 
		//	//	"NullableSelectedValue" : "SelectedValue";

		//	bindValue(data as CoreData);
		//}
	}

}
