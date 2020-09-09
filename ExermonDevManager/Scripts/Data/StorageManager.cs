using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using System.Text;

using LitJson;

namespace ExermonDevManager.Scripts.Data {

	/// <summary>
	/// 存储管理类
	/// </summary>
	public static class StorageManager {

		/// <summary>
		/// 是否需要加密
		/// </summary>
		const bool NeedEncode = false;

		/// <summary>
		/// 随机数生成对象
		/// </summary>
		static Random random = new Random();

		/// <summary>
		/// 加密盐
		/// </summary>
		const string DefaultSalt = "aZrY5R0cDc97oCEv3vdDcMz34gwPf9hL8wL3TaAE2Lm1DaxpZAlcgMMALa1EMA";
		const string LastSalt = "R0cDovMzgwLTE2Lm1pZAl";

		#region 文件操作

		/// <summary>
		/// 储存数据到文件（JSON数据）
		/// </summary>
		/// <param name="json">JSON数据</param>
		/// <param name="filePath">文件路径和文件名</param>
		public static void saveObjectIntoFile(BaseData obj, string filePath) {
			saveJsonIntoFile(obj.toJson(), filePath);
		}
		/// <param name="path">文件路径</param>
		/// <param name="name">文件名</param>
		public static void saveObjectIntoFile(BaseData obj, string path, string name) {
			//Debug.Log("Saving " + obj + " into " + path + name);
			saveJsonIntoFile(obj.toJson(), path, name);
		}

		/// <summary>
		/// 储存数据到文件（JSON数据）
		/// </summary>
		/// <param name="json">JSON数据</param>
		/// <param name="filePath">文件路径和文件名</param>
		public static void saveJsonIntoFile(JsonData json, string filePath) {
			saveDataIntoFile(json.ToJson(), filePath);
		}
		/// <param name="path">文件路径</param>
		/// <param name="name">文件名</param>
		public static void saveJsonIntoFile(JsonData json, string path, string name) {
			saveDataIntoFile(json.ToJson(), path, name);
		}

		/// <summary>
		/// 存储数据到指定文件
		/// </summary>
		/// <param name="data">数据（任意字符串）</param>
		/// <param name="filePath">文件路径和文件名</param>
		public static void saveDataIntoFile(string data, string filePath) {
			var index = filePath.LastIndexOf('/') + 1;
			var path = filePath.Substring(0, index);
			var name = filePath.Substring(index);

			saveDataIntoFile(data, path, name);
		}
		/// <param name="path">文件路径</param>
		/// <param name="name">文件名</param>
		public static void saveDataIntoFile(string data, string path, string name) {
			//path = SaveRootPath + path;
			if (!Directory.Exists(path)) Directory.CreateDirectory(path);
			//Debug.Log("saveToFile: " + data);
			StreamWriter streamWriter = new StreamWriter(path + name, false);
			streamWriter.Write(data);
			streamWriter.Close();
			streamWriter.Dispose();
		}

		/// <summary>
		/// 从指定文件读取数据
		/// </summary>
		/// <param name="path">文件路径</param>
		/// <param name="name">文件名</param>
		/// <returns>读取的数据（字符串）</returns>
		public static void loadObjectFromFile<T>(ref T data, string path, string name)
			where T : BaseData, new() {
			loadObjectFromFile(ref data, path + name);
		}
		/// <param name="filePath">文件路径（包括文件名）</param>
		public static void loadObjectFromFile<T>(ref T data, string filePath) 
			where T : BaseData, new() {
			//Debug.Log("Loading " + data + " from " + path);
			var json = loadJsonFromFile(filePath);
			data = DataLoader.load(data, json);
		}

		/// <summary>
		/// 从指定文件读取数据
		/// </summary>
		/// <param name="path">文件路径</param>
		/// <param name="name">文件名</param>
		/// <returns>读取的数据（字符串）</returns>
		public static JsonData loadJsonFromFile(string path, string name) {
			return loadJsonFromFile(path + name);
		}
		/// <param name="filePath">文件路径（包括文件名）</param>
		public static JsonData loadJsonFromFile(string filePath) {
			var data = loadDataFromFile(filePath);
			return JsonMapper.ToObject(data);
		}

		/// <summary>
		/// 从指定文件读取数据
		/// </summary>
		/// <param name="path">文件路径</param>
		/// <param name="name">文件名</param>
		/// <returns>读取的数据（字符串）</returns>
		public static string loadDataFromFile(string path, string name) {
			return loadDataFromFile(path + name);
		}
		/// <param name="filePath">文件路径（包括文件名）</param>
		public static string loadDataFromFile(string filePath) {
			//path = SaveRootPath + path;
			if (!File.Exists(filePath)) return "";
			StreamReader streamReader = new StreamReader(filePath);
			string data = streamReader.ReadToEnd();
			//Debug.Log("loadFromFile: " + data);
			streamReader.Close();
			streamReader.Dispose();
			return data;
		}

		/// <summary>
		/// 删除指定文件
		/// </summary>
		/// <param name="path">文件路径</param>
		/// <param name="name">文件名</param>
		public static void deleteFile(string path, string name) {
			deleteFile(path + name);
		}
		/// <param name="filePath">文件路径（包括文件名）</param>
		public static void deleteFile(string filePath) {
			if (File.Exists(filePath)) File.Delete(filePath);
		}

		#endregion

		#region 编码解码

		/// <summary>
		/// base64编码
		///// </summary>
		/// <param name="ori">源字符串</param>
		/// <param name="salt">盐</param>
		/// <returns>编码后字符串</returns>
		public static string base64Encode(string ori, string salt = DefaultSalt) {
			byte[] bytes = Encoding.UTF8.GetBytes(ori);
			string code = Convert.ToBase64String(bytes, 0, bytes.Length);
			float pos = random.Next(10, 90) / 100.0f;
			code = code.Insert((int)(code.Length * pos), salt);
			code = randString(DefaultSalt.Length) + code;
			return code;
		}

		/// <summary>
		/// base64解码
		/// </summary>
		/// <param name="code">编码后字符串</param>
		/// <param name="salt">盐</param>
		/// <returns>源字符串</returns>
		public static string base64Decode(string code, string salt = DefaultSalt,
			string lastSalt = LastSalt) {
			// 如果存在上一个盐，用上一个盐来解码
			if (lastSalt != "" && code.Contains(LastSalt))
				return base64Decode(code, lastSalt, "");

			code = code.Substring(salt.Length);
			code = code.Replace(salt, "");
			byte[] bytes = Convert.FromBase64String(code);
			return Encoding.UTF8.GetString(bytes);
		}

		/// <summary>
		/// 随机字符串生成
		/// </summary>
		/// <param name="len">长度</param>
		/// <returns>随机字符串</returns>
		static string randString(int len) {
			string s = "";
			for (int i = 0; i < len; i++) {
				char c = (char)random.Next('A', 'Z');
				s += (random.Next(0, 2) >= 1) ? Char.ToLower(c) : c;
			}
			return s;
		}

		#endregion
	}
}
