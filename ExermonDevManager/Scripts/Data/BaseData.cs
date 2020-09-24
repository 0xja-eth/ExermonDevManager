using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using LitJson;

namespace ExermonDevManager.Scripts.Data {

	using Utils;

	/// <summary>
	/// 可自动转化的属性特性
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class AutoConvertAttribute : Attribute {

		/// <summary>
		/// 键名
		/// </summary>
		public string keyName;

		/// <summary>
		/// 防止覆盖
		/// </summary>
		public bool preventCover;

		/// <summary>
		/// 忽略空值
		/// </summary>
		public bool ignoreNull;

		/// <summary>
		/// 自动读取
		/// </summary>
		public bool autoLoad;

		/// <summary>
		/// 自动转化
		/// </summary>
		public bool autoConvert;

		/// <summary>
		/// 转换格式
		/// </summary>
		public string format;

		/// <summary>
		/// 构造函数
		/// </summary>
		public AutoConvertAttribute(string keyName = null,
			bool autoLoad = true, bool autoConvert = true,
			bool preventCover = true, bool ignoreNull = false, string format = "") {
			this.keyName = keyName;
			this.preventCover = preventCover;
			this.ignoreNull = ignoreNull;
			this.format = format;
			this.autoLoad = autoLoad;
			this.autoConvert = autoConvert;
		}
	}

	/// <summary>
	/// 缓存属性基类
	/// </summary>
	public abstract class CacheAttr {

		/// <summary>
		/// 清除缓存
		/// </summary>
		public abstract void clear();
	}

	/// <summary>
	/// 缓存属性
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class CacheAttr<T> : CacheAttr {

		/// <summary>
		/// 缓存读取函数
		/// </summary>
		/// <returns></returns>
		public delegate T LoadFunc();

		/// <summary>
		/// 内部变量
		/// </summary>
		T data = default;
		public LoadFunc func;
		public BaseData object_;

		/// <summary>
		/// 获取值
		/// </summary>
		public T value() {
			if (!object_.cacheable) clear();
			if (data == default) data = func.Invoke();
			return data;
		}

		/// <summary>
		/// 清除缓存
		/// </summary>
		public override void clear() {
			data = default;
		}

	}
	
	/// <summary>
	/// 游戏数据父类
	/// </summary>
	public abstract class BaseData {

		#region 缓存池操作

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
		static int poolCount(Type type) {
			if (!poolContains(type)) return 0;
			return objects[type].Count;
		}
		static int poolCount<T>() where T : BaseData {
			return poolCount(typeof(T));
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
			BaseData.objects[type] = objects;
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

		/// <summary>
		/// 添加自己到缓存池
		/// </summary>
		protected void addToPool(bool autoId = true) {
			if (!useObjectsPool()) return;

			if (autoId && this.autoId()) id = currentId();
			poolAdd(GetType(), this); //, isReplaceable());
		}

		/// <summary>
		/// 当前ID
		/// </summary>
		protected int currentId() {
			return poolCount(GetType());
		}

		#endregion
		
		/// <summary>
		/// 属性
		/// </summary>
		public int id { get; protected set; }

		/// <summary>
		/// 能否缓存标记
		/// </summary>
		public bool cacheable = true;

		/// <summary>
		/// 是否为复制对象（复制对象无法进行复制）
		/// </summary>
		bool copied = false;

		/// <summary>
		/// 原始数据
		/// </summary>
		JsonData rawData;

		#region 配置

		/// <summary>
		/// 可替换的
		/// </summary>
		//protected virtual bool isReplaceable() { return true; }

		/// <summary>
		/// 可以保存到文件
		/// </summary>
		protected virtual bool isSaveEnable() { return true; }

		/// <summary>
		/// 是否使用缓存池
		/// </summary>
		protected virtual bool useObjectsPool() { return idEnable(); }

		/// <summary>
		/// 是否自动分配ID
		/// </summary>
		protected virtual bool autoId() { return idEnable(); }

		/// <summary>
		/// 是否需要ID
		/// </summary>
		protected virtual bool idEnable() { return true; }

		#endregion
		
		#region 读取/转化

		/// <summary>
		/// 数据加载
		/// </summary>
		/// <param name="json">数据</param>
		public void load(JsonData json) {
			rawData = json;
			//Debug.Log("load: " + json.ToJson());
			loadAutoAttributes(json);
			loadCustomAttributes(json);
		}

		/// <summary>
		/// 读取自定义属性
		/// </summary>
		/// <param name="json"></param>
		protected virtual void loadCustomAttributes(JsonData json) {
			id = idEnable() ? DataLoader.load(id, json, "id") : -1;
		}

		/// <summary>
		/// 读取自动转换属性
		/// </summary>
		void loadAutoAttributes(JsonData json) {

			ReflectionUtils.processAttribute
				<PropertyInfo, AutoConvertAttribute>
				(GetType(), (p, attr) => {

					if (!attr.autoLoad) return;

					var pType = p.PropertyType; var pName = p.Name;
					var key = attr.keyName ?? DataLoader.hump2Underline(pName);
					var val = p.GetValue(this);
					/*
					var debug = string.Format("Loading {0} {1} {2} in {3} " +
						"(ori:{4})", p, pType, pName, type, val);
					Debug.Log(debug);
					*/
					val = attr.preventCover ? DataLoader.load(
						pType, val, json, key, attr.ignoreNull) :
						DataLoader.load(pType, json, key);
					p.SetValue(this, val); //, BindingFlags.Public | BindingFlags.NonPublic, null, null, null);
				});
		}

		/// <summary>
		/// 获取JSON数据
		/// </summary>
		/// <returns>JsonData</returns>
		public JsonData toJson() {
			var json = new JsonData();
			json.SetJsonType(JsonType.Object);
			convertAutoAttributes(json);
			convertCustomAttributes(ref json);
			return json;
		}

		/// <summary>
		/// 转换自定义属性
		/// </summary>
		/// <param name="json"></param>
		protected virtual void convertCustomAttributes(ref JsonData json) {
			if (!autoId() && idEnable()) json["id"] = id;
		}

		/// <summary>
		/// 转换自动转换属性
		/// </summary>
		void convertAutoAttributes(JsonData json) {

			ReflectionUtils.processAttribute
				<PropertyInfo, AutoConvertAttribute>
				(GetType(), (p, attr) => {
					if (!attr.autoConvert) return;

					var pType = p.PropertyType; var pName = p.Name;
					var key = attr.keyName ?? DataLoader.hump2Underline(pName);
					var val = p.GetValue(this);

					json[key] = DataLoader.convert(pType, val, attr.format);
					/*
					var debug = string.Format("Converting {0} {1} in {2} (val:{3}) " +
						"to key: {4}, res: {5}", pType, pName, type, val, key, json[key]);
					Debug.Log(debug);
					*/
				});
		}

		/// <summary>
		/// 类型转化（需要读取时候执行，因为 rawData 不会同步改变）
		/// </summary>
		/// <typeparam name="T">目标类型</typeparam>
		/// <returns>目标类型对象</returns>
		public T convert<T>() where T : BaseData, new() {
			return DataLoader.load<T>(rawData);
		}

		/// <summary>
		/// 获取原始数据
		/// </summary>
		/// <returns>JSON字符串</returns>
		public string rawJson() { return rawData.ToJson(); }

		#endregion

		#region 缓存处理

		/// <summary>
		/// 缓存列表
		/// </summary>
		List<CacheAttr> cacheList = new List<CacheAttr>();

		/// <summary>
		/// 配置所有缓存属性
		/// </summary>
		void setupCacheAttrs() {

			var type = GetType();

			ReflectionUtils.processMember
				<FieldInfo, CacheAttr>(GetType(), 
				f => {
					var oriVal = f.GetValue(this) as CacheAttr;

					if (oriVal == null) {

						var flag = ReflectionUtils.DefaultFlag;

						var funcName = "_" + f.Name;
						var funcInfo = type.GetMethod(funcName, flag);

						var fieldType = f.FieldType; // CacheAttr<T>

						// 获取目标函数信息（CacheAttr中的函数）
						var targetFuncInfo = fieldType.GetField("func");
						var targetFuncType = targetFuncInfo.FieldType;

						var objectInfo = fieldType.GetField("object_");

						var bindingFunc = funcInfo.CreateDelegate(targetFuncType, this);

						var val = Activator.CreateInstance(fieldType);
						targetFuncInfo.SetValue(val, bindingFunc);
						objectInfo.SetValue(val, this);

						f.SetValue(this, oriVal = val as CacheAttr);
					}
					cacheList.Add(oriVal);
			});
		}

		/// <summary>
		/// 清除缓存
		/// </summary>
		public void clearCaches() {
			foreach (var cache in cacheList)
				cache.clear();
		}

		#endregion

		#region 其他操作

		/// <summary>
		/// 交换ID
		/// </summary>
		/// <param name="id"></param>
		public void swapId(BaseData data) {
			var tmp = data.id; data.id = id; id = tmp;
		}

		/// <summary>
		/// 获取JSON数据
		/// </summary>
		/// <returns>JsonData</returns>
		public virtual BaseData copy(bool flag = true) {
			if (copied) return null; // 如果为复制对象，无法继续复制
			var res = create(GetType(), toJson());
			if (flag) res.copied = true;
			return res;
		}

		#endregion

		/// <summary>
		/// 创建一个对象
		/// </summary>
		/// <param name="type">对象类型</param>
		/// <param name="data">数据</param>
		public static BaseData create(Type type, JsonData data = null) {
			var res = (BaseData)Activator.CreateInstance(type);
			res.load(data); // res.addToPool();
			return res;
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		public BaseData() {
			setupCacheAttrs();
			addToPool();
		}
	}
}
