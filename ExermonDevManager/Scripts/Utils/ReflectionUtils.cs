using System;
using System.Reflection;

namespace ExermonDevManager.Scripts.Utils {

	/// <summary>
	/// 反射工具类
	/// </summary>
	public static class ReflectionUtils { 

		/// <summary>
		/// 默认绑定标志
		/// </summary>
		public static readonly BindingFlags DefaultFlag =
			BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		#region 获取实例

		/// <summary>
		/// 获取字段
		/// </summary>
		public static T getField<T>(object obj, string name) {
			if (obj == null) return default;
			var info = obj.GetType().GetField(name, DefaultFlag);
			return (T)info?.GetValue(obj);
		}

		/// <summary>
		/// 获取属性
		/// </summary>
		public static T getProperty<T>(object obj, string name) {
			if (obj == null) return default;
			var info = obj.GetType().GetProperty(name, DefaultFlag);
			return (T)info?.GetValue(obj);
		}

		/// <summary>
		/// 快速处理成员
		/// </summary>
		public static void processMember<M>(Type type, Action<M> processFunc) where M : MemberInfo {

			var memberInfos = getMemberInfos<M>(type);
			if (memberInfos == null) return;

			foreach (var m in memberInfos) {
				var member = m as M;
				if (member == null) continue;

				processFunc(member);
			}
		}
		public static void processMember<M, T>(Type type, Action<M> processFunc) where M : MemberInfo {
			var tType = typeof(T);
			processMember<M>(type, m => {
				var mType = getMemberType<M>(m);
				if (mType == tType || mType.IsSubclassOf(tType))
					processFunc(m);
			});
		}

		#endregion

		#region 快速处理

		/// <summary>
		/// 快速处理特性
		/// </summary>
		public static void processAttribute<M, A>(Type type, Action<M, A> processFunc)
			where M : MemberInfo where A : Attribute {
			processMember<M>(type, m => {
				foreach (Attribute a in m.GetCustomAttributes(false)) {
					var attr = a as A;
					if (attr == null) continue;

					processFunc(m, attr);
				}
			});
		}

		/// <summary>
		/// 处理字段
		/// </summary>
		public static void processField<T>(object self, Action<T> processFunc) {
			var tType = typeof(T);
			var sType = self.GetType();
			processMember<FieldInfo>(sType, m => {
				var mType = m.FieldType;
				if (mType == tType || mType.IsSubclassOf(tType))
					processFunc((T)m.GetValue(self));
			});
		}

		/// <summary>
		/// 处理属性
		/// </summary>
		public static void processProperty<T>(object self, Action<T> processFunc) {
			var tType = typeof(T);
			var sType = self.GetType();
			processMember<PropertyInfo>(sType, m => {
				var mType = m.PropertyType;
				if (mType == tType || mType.IsSubclassOf(tType))
					processFunc((T)m.GetValue(self));
			});
		}

		#endregion

		#region 获取Info

		/// <summary>
		/// 获取成员信息数组
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static MemberInfo[] getMemberInfos(Type type, MemberTypes memberType) {

			switch (memberType) {
				case MemberTypes.All:
					return type.GetMembers(DefaultFlag);
				case MemberTypes.Field:
					return type.GetFields(DefaultFlag);
				case MemberTypes.Property:
					return type.GetProperties(DefaultFlag);
				case MemberTypes.Event:
					return type.GetEvents(DefaultFlag);
				case MemberTypes.Method:
					return type.GetMethods(DefaultFlag);
				default: return null;
			}
		}
		public static MemberInfo[] getMemberInfos<M>(Type type) where M : MemberInfo {
			var memberType = typeof(M);

			if (memberType == typeof(MemberInfo))
				return getMemberInfos(type, MemberTypes.All);
			if (memberType == typeof(FieldInfo))
				return getMemberInfos(type, MemberTypes.Field);
			if (memberType == typeof(PropertyInfo))
				return getMemberInfos(type, MemberTypes.Property);
			if (memberType == typeof(EventInfo))
				return getMemberInfos(type, MemberTypes.Event);
			if (memberType == typeof(MethodInfo))
				return getMemberInfos(type, MemberTypes.Method);

			return null;
		}
		public static Type getMemberType<M>(MemberInfo info) where M : MemberInfo {
			var memberType = typeof(M);

			if (memberType == typeof(FieldInfo))
				return (info as FieldInfo).FieldType;
			if (memberType == typeof(PropertyInfo))
				return (info as PropertyInfo).PropertyType;
			if (memberType == typeof(EventInfo))
				return (info as EventInfo).EventHandlerType;

			return null;
		}

		#endregion

	}
}
