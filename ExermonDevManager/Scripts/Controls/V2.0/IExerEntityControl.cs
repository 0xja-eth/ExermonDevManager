
using System;
using System.Collections;
using System.ComponentModel;

namespace ExermonDevManager.Scripts.Controls {
	using Data;
	using Entities;

	/// <summary>
	/// Exer基本控件接口
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IExerEntityControl : IComponent {

		/// <summary>
		/// 注册更新事件
		/// </summary>
		/// <param name="event_"></param>
		void registerUpdateEvent(Action action);

		/// <summary>
		/// 绑定数据
		/// </summary>
		void bind(CoreEntity data);

	}
}
