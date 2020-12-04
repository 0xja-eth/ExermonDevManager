using System;
using System.Collections.Generic;

namespace ExermonDevManager.Core.Utils {

	/// <summary>
	/// 回调管理类
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class DictList<T1, T2> {

		/// <summary>
		/// 回调设置
		/// </summary>
		Dictionary<T1, LinkedList<T2>> data = 
			new Dictionary<T1, LinkedList<T2>>();

		/// <summary>
		/// 获取原始数据
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		public LinkedList<T2> this[T1 key] {
			get => get(key, false);
			set { data[key] = value; }
		}

		/// <summary>
		/// 添加元素
		/// </summary>
		/// <param name="key">键</param>
		/// <param name="value">值</param>
		public void add(T1 key, T2 value) {
			addListDict(data, key, value);
		}

		/// <summary>
		/// 移除元素
		/// </summary>
		/// <param name="key">键</param>
		/// <param name="value">值</param>
		public void remove(T1 key, T2 value) {
			removeListDict(data, key, value);
		}

		/// <summary>
		/// 移除元素
		/// </summary>
		/// <param name="key">键</param>
		/// <param name="value">值</param>
		public void clear(T1 key) {
			clearListDict(data, key);
		}

		/// <summary>
		/// 清除全部
		/// </summary>
		public void clearAll() {
			data.Clear();
		}

		/// <summary>
		/// 包含键
		/// </summary>
		/// <param name="key">键</param>
		public bool contains(T1 key, bool includeNull = false) {
			return hasListDict(data, key, includeNull);
		}

		/// <summary>
		/// 包含键
		/// </summary>
		/// <param name="key">键</param>
		/// <param name="create">创建值</param>
		public LinkedList<T2> get(T1 key, bool create = true) {
			return getListDict(data, key, create);
		}

		#region 列表字典工具函数

		/// <summary>
		/// 添加一个列表字典
		/// </summary>
		public static void addListDict(
			Dictionary<T1, LinkedList<T2>> dict, T1 key, T2 value) {
			getListDict(dict, key, true).AddLast(value);
		}

		/// <summary>
		/// 添加一个列表字典
		/// </summary>
		public static void removeListDict(
			Dictionary<T1, LinkedList<T2>> dict, T1 key, T2 value) {
			getListDict(dict, key, true).Remove(value);
		}

		/// <summary>
		/// 清空一个列表字典
		/// </summary>
		public static void clearListDict(
			Dictionary<T1, LinkedList<T2>> dict, T1 key) {
			getListDict(dict, key, true).Clear();
		}

		/// <summary>
		/// 是否存在键
		/// </summary>
		public static bool hasListDict(
			Dictionary<T1, LinkedList<T2>> dict, T1 key, bool includeNull = false) {
			if (!dict.ContainsKey(key)) return false;
			return includeNull || dict[key] != null;
		}

		/// <summary>
		/// 获取值（数组）（如果没有键可以创建）
		/// </summary>
		public static LinkedList<T2> getListDict(
			Dictionary<T1, LinkedList<T2>> dict, T1 key, bool create = true) {
			if (dict.ContainsKey(key)) return dict[key];
			if (create) return dict[key] = new LinkedList<T2>();
			return null;
		}

		#endregion
	}
}
