
using System;
using System.Collections;
using System.ComponentModel;

namespace ExermonDevManager.Core.Controls {

	using Data;

	/// <summary>
	/// Exermon 编辑控件接口
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IExermonEditControl : IComponent {

		/// <summary>
		/// 注册更新事件
		/// </summary>
		/// <param name="event_"></param>
		void registerUpdateEvent(Action action);

		/// <summary>
		/// 绑定数据
		/// </summary>
		void bind(CoreData data);

	}
}
