
using System;
using System.Collections;
using System.ComponentModel;

namespace ExermonDevManager.Core.Controls {
	using Data;

	/// <summary>
	/// Exer基本控件接口
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IExerControl : IComponent {

		//void setup<T>() where T : ControlData;
		//void setup(IList data);

		/// <summary>
		/// 注册更新事件
		/// </summary>
		/// <param name="event_"></param>
		void registerUpdateEvent(EventHandler event_);

		/// <summary>
		/// 绑定数据
		/// </summary>
		void bind(BaseData data);

		/// <summary>
		/// 更新绘制
		/// </summary>
		void update();

	}
}
