using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LitJson;

namespace ExermonDevManager.Core.Managers {

	using Data;
	using Entities;

	/// <summary>
	/// 数据管理类
	/// </summary>
	public static class DataManager {
		
		/// <summary>
		/// 路径常量定义
		/// </summary>
		public static readonly string RootPath = "./data/";

		#region 统一接口

		/// <summary>
		/// 获取数据列表
		/// </summary>
		public static IList getDataList(Type type) {
			if (type.IsSubclassOf(typeof(BaseEntity)))
				return EntitiesManager.getItems(type);
			else
				return poolGet(type);
		}

		#endregion

		#region 缓存池管理

		/// <summary>
		/// 对象缓存池
		/// </summary>
		// TODO: 值类型修改为 IList
		public static Dictionary<Type, List<BaseData>> objects =
			new Dictionary<Type, List<BaseData>>();

		/// <summary>
		/// 添加对象到缓存池
		/// </summary>
		/// <param name="type"></param>
		/// <param name="data"></param>
		public static void poolAdd<T>(T data) where T : BaseData {
			poolAdd(typeof(T), data);
		}
		public static void poolAdd(Type type, BaseData data) {
			if (!poolContains(type))
				objects[type] = new List<BaseData>();

			var index = poolIndex(type, data.id);
			if (index <= -1) objects[type].Add(data);
			else objects[type][index] = data;

			//else if (replace) objects[type][index] = data;
		}

		/// <summary>
		/// 缓存池是否存在指定类型
		/// </summary>
		static bool poolContains(Type type) {
			return objects.ContainsKey(type);
		}
		static bool poolContains<T>() where T : BaseData {
			return poolContains(typeof(T));
		}
		static bool poolContains(Type type, BaseData data) {
			return poolIndex(type, data) >= 0;
		}
		static bool poolContains<T>(T data) where T : BaseData {
			return poolContains(typeof(T), data);
		}

		/// <summary>
		/// 添加对象到缓存池
		/// </summary>
		/// <param name="type"></param>
		/// <param name="data"></param>
		public static void poolDelete<T>(T data) where T : BaseData {
			poolDelete(typeof(T), data);
		}
		public static void poolDelete(Type type, BaseData data) {
			if (!poolContains(type))
				objects[type] = new List<BaseData>();

			var index = poolIndex(type, data.id);
			if (index >= 0) objects[type].RemoveAt(index);
		}

		/// <summary>
		/// 缓存池对象数量
		/// </summary>
		public static int poolCount(Type type) {
			if (!poolContains(type)) return 0;
			return objects[type].Count;
		}
		public static int poolCount<T>() where T : BaseData {
			return poolCount(typeof(T));
		}

		/// <summary>
		/// 缓存池最大ID数目
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static int poolMaxIndex(Type type, int offset = 0) {
			if (!poolContains(type)) return offset - 1;
			var res = offset;
			foreach (var obj in objects[type])
				res = Math.Max(res, obj.id);
			return res;
		}
		public static int poolMaxIndex<T>(int offset = 0) where T : BaseData {
			return poolMaxIndex(typeof(T), offset);
		}

		/// <summary>
		/// 获取缓存池指定条件对象
		/// </summary>
		public static List<BaseData> poolGet(Type type) {
			if (!poolContains(type)) return new List<BaseData>();
			return objects[type];
		}
		public static BaseData poolGet(Type type, int id) {
			if (!poolContains(type)) return null;
			return objects[type].Find(data => data.id == id);
		}
		public static List<T> poolGet<T>() where T : BaseData {
			var type = typeof(T);
			var list = new List<T>();
			var objects = poolGet(type);

			foreach (var object_ in objects)
				list.Add(object_ as T);

			return list;
		}
		public static T poolGet<T>(int id) where T : BaseData {
			return poolGet<T>(data => data.id == id);
		}
		public static T poolGet<T>(Predicate<T> p) where T : BaseData {
			return poolGet<T>().Find(p);
		}

		/// <summary>
		/// 添加对象到缓存池
		/// </summary>
		/// <param name="type"></param>
		/// <param name="data"></param>
		public static void poolSet<T>(List<T> objects) where T : BaseData {
			var list = new List<BaseData>(objects.Count);

			foreach (var object_ in objects) list.Add(object_);

			poolSet(typeof(T), list);
		}
		public static void poolSet(Type type, List<BaseData> objects) {
			DataManager.objects[type] = objects;
		}

		/// <summary>
		/// 获取对应对象下标
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="id"></param>
		/// <returns></returns>
		public static int poolIndex<T>(T data) where T : BaseData {
			return poolIndex(typeof(T), data);
		}
		public static int poolIndex<T>(int id) where T : BaseData {
			return poolIndex<T>(data => data.id == id);
		}
		public static int poolIndex<T>(Predicate<T> p) where T : BaseData {
			return poolGet<T>().FindIndex(p);
		}
		public static int poolIndex(Type type, BaseData data) {
			if (!poolContains(type)) return -1;
			return objects[type].IndexOf(data);
		}
		public static int poolIndex(Type type, int id) {
			if (!poolContains(type)) return -1;
			return objects[type].FindIndex(data => data.id == id);
		}

		/// <summary>
		/// 移动数据
		/// </summary>
		/// <param name="type">类型</param>
		/// <param name="from">起始索引</param>
		/// <param name="to">目标索引</param>
		public static void poolMove<T>(int from, int to) where T : BaseData {
			poolMove(typeof(T), from, to);
		}
		public static void poolMove<T>(T data, int to) where T : BaseData {
			poolMove(typeof(T), data, to);
		}
		public static void poolMove(Type type, int from, int to) {
			var count = poolCount(type);
			if (count <= 0) return;

			from = Math.Max(Math.Min(from, count), 0);
			to = Math.Max(Math.Min(to, count), 0);

			if (from == to) return;

			var fromItem = objects[type][from];
			var toItem = objects[type][to];

			toItem.swapId(fromItem);
			objects[type][to] = fromItem;
			objects[type][from] = toItem;
		}
		public static void poolMove(Type type, BaseData data, int to) {
			poolMove(type, poolIndex(type, data), to);
		}
		public static void poolMoveDelta<T>(T data, int delta) where T : BaseData {
			poolMoveDelta(typeof(T), data, delta);
		}
		public static void poolMoveDelta(Type type, BaseData data, int delta) {
			var from = poolIndex(type, data);
			poolMove(type, from, from + delta);
		}

		/// <summary>
		/// 通过JsonData读取缓存池数据
		/// </summary>
		public static void loadPool<T>(JsonData data) where T : BaseData {
			loadPool(typeof(T), data);
		}
		public static void loadPool(Type type, JsonData data) {
			if (!data.IsArray) return;
			foreach (JsonData item in data) DataLoader.load(type, item);
		}

		/// <summary>
		/// 转化缓存池数据到JsonData
		/// </summary>
		/// <returns></returns>
		public static JsonData convertPool<T>() where T : BaseData {
			return convertPool(typeof(T));
		}
		public static JsonData convertPool(Type type) {
			var objects = poolGet(type);

			var res = new JsonData();
			res.SetJsonType(JsonType.Array);
			foreach (var obj in objects)
				if (obj.isSaveEnable())
					res.Add(DataLoader.convert(type, obj));

			return res;
		}

		#endregion

		#region 存取管理
		
		/// <summary>
		/// 数据类型列表
		/// </summary>
		public static List<Type> dataTypes = new List<Type>();

		/// <summary>
		/// 注册类型
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public static void registerType<T>() where T : BaseData {
			dataTypes.Add(typeof(T));
		}

		/// <summary>
		/// 保存所有数据
		/// </summary>
		public static void saveAllData() {
			foreach (var type in dataTypes) saveData(type);
		}

		/// <summary>
		/// 保存单个数据
		/// </summary>
		/// <param name="type"></param>
		public static void saveData(Type type) {
			var fileName = type.Name + ".json";
			var data = convertPool(type);
			StorageManager.saveJsonIntoFile(
				data, RootPath, fileName);
		}

		/// <summary>
		/// 读取所有数据
		/// </summary>
		static void loadAllData() {
			foreach (var type in dataTypes) loadData(type);
		}

		/// <summary>
		/// 读取单个数据
		/// </summary>
		/// <param name="type"></param>
		public static void loadData(Type type) {
			var fileName = type.Name + ".json";
			var data = StorageManager.loadJsonFromFile(
				RootPath, fileName);
			loadPool(type, data);
		}

		#endregion

		/// <summary>
		/// 初始化
		/// </summary>
		public static void initialize() {
			loadAllData();
		}
	}
}
