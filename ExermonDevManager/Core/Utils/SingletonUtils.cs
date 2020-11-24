using System;

namespace ExermonDevManager.Core.Utils {

	/// <summary>
	/// 语言
	/// </summary>
	public abstract class Singleton<T> where T : Singleton<T>, new() {

		/// <summary>
		/// 多例错误
		/// </summary>
		class MultCaseException : Exception {
			const string ErrorText = "单例模式下不允许多例存在！";
			public MultCaseException() : base(ErrorText) { }
		}

		/// <summary>
		/// 单例函数
		/// </summary>
		protected static T _self;
		public static T Get() {
			if (_self == null) _self = new T();
			return _self;
		}

		/// <summary>
		/// 初始化
		/// </summary>
		protected Singleton() {
			if (_self != null) throw new MultCaseException();
		}
	}
}
