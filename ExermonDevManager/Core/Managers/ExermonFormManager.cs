using System;
using System.Collections.Generic;
using System.Reflection;

using ExermonDevManager.Forms;

namespace ExermonDevManager.Core.Managers {

	using Data;
	using Entities;

	using Forms;

	/// <summary>
	/// 窗口管理类
	/// </summary>
	public static class ExermonFormManager {

		/// <summary>
		/// 子窗口管理池
		/// </summary>
		static Dictionary<Type, Type> formMap = new Dictionary<Type, Type>();

		/// <summary>
		/// 获取指定类型对应的子窗口类型
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static Type getFormType(Type type) {
			if (formMap.ContainsKey(type)) return formMap[type];

			return typeof(GeneralSubForm);
		}

		/// <summary>
		/// 开启一个新子窗口
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static ExerSubForm startSubForm(PropertyInfo prop, CoreData root) {
			if (root == null) return null;

			var pType = prop.PropertyType;
			var dType = pType.GetGenericArguments()[0];
			var fType = getFormType(dType);

			// 创建窗口
			var res = Activator.CreateInstance(fType) as ExerSubForm;
			res?.setupRoot(prop, root);

			return res;
		}
		
		/// <summary>
		/// 注册窗口
		/// </summary>
		/// <param name="type"></param>
		public static void registerForm(Type type) {
			if (!type.IsGenericType) return;
			Console.WriteLine("Register form: " + type);

			var dType = type.GetGenericArguments()[0];
			formMap[dType] = type;
		}

		/// <summary>
		/// 注册窗口
		/// </summary>
		/// <param name="types"></param>
		public static void registerForms(Type[] types) {
			foreach (var type in types)
				registerForm(type);
		}
	}
}
