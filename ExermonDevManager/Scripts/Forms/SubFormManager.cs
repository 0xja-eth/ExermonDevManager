using System;
using System.Collections.Generic;
using System.Reflection;

using ExermonDevManager.Forms;

namespace ExermonDevManager.Core.Forms {

	using Data;
	/// <summary>
	/// 子窗口管理类
	/// </summary>
	public static class SubFormManager {

		/// <summary>
		/// 子窗口管理池
		/// </summary>
		public static Dictionary<Type, Type> subFormMap; // = new Dictionary<Type, Type>();

		/// <summary>
		/// 获取指定类型对应的子窗口类型
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static Type getSubFormType(Type type) {
			if (subFormMap == null) initializeMap();
			if (subFormMap.ContainsKey(type)) return subFormMap[type];

			return typeof(GeneralSubForm);
		}

		/// <summary>
		/// 开启一个新子窗口
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static SubForm startSubForm(PropertyInfo prop, CoreEntity root) {

			var type = prop.PropertyType.GetGenericArguments()[0];
			var fType = getSubFormType(type);

			var res = Activator.CreateInstance(fType) as SubForm;
			res.setup(prop, root);

			return res;
		}

		/// <summary>
		/// 初始化映射
		/// </summary>
		public static void initializeMap() {
			subFormMap = new Dictionary<Type, Type>();

			//subFormMap[typeof(ModelField)] = typeof(ModelFieldSubForm);
		}
	}
}
