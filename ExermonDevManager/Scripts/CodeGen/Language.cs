using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExermonDevManager.Scripts.CodeGen {

	/// <summary>
	/// 语言格式
	/// </summary>
	public class LangFormat {

		public string main; // 主体格式
		public string block; // 块格式

		public LangFormat(string main, string block = null) {
			this.main = main; this.block = block;
		}
	}

	/// <summary>
	/// 语言基类
	/// </summary>
	public abstract class Language {

		#region 语言管理

		/// <summary>
		/// 语言字典
		/// </summary>
		protected static Dictionary<string, Language> languages = 
			new Dictionary<string, Language>();

		/// <summary>
		/// 获取语言对象
		/// </summary>
		/// <param name="language"></param>
		/// <returns></returns>
		public static Language getLanguage(string language) {
			return languages[language.ToLower()];
		}

		#endregion

		/// <summary>
		/// 语言名称
		/// </summary>
		public virtual string langName => GetType().Name;

		/// <summary>
		/// 语言格式定义
		/// </summary>
		/// <returns></returns>
		// 表示为空
		public abstract string nullCode { get; }

		#region 代码生成

		/// <summary>
		/// 添加缩进
		/// </summary>
		/// <param name="code">代码</param>
		/// <param name="indent">缩进</param>
		/// <returns></returns>
		public virtual string genIndent(string code, int indent = 1) {
			if (indent <= 0) return code;

			var lines = Regex.Split(code, "\r\n");
			var indentStr = "";
			for (int i = 0; i < indent; ++i)
				indentStr += "\t";

			for (int i = 0; i < lines.Length; ++i)
				lines[i] = indentStr + lines[i];

			return string.Join("\r\n", lines);
		}

		/// <summary>
		/// 变量转化为代码
		/// </summary>
		/// <returns></returns>
		public virtual string var2Code(object val, bool code = false) {
			if (code) return (string)val;
			if (val == null) return nullCode;

			if (val.GetType() == typeof(string))
				return str2Code((string)val);
			if (val.GetType() == typeof(bool))
				return bool2Code((bool)val);

			return val.ToString();
		}

		/// <summary>
		/// 字符串转化为代码（字符串代码）
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		protected virtual string str2Code(string val) {
			return "\"" + val + "\"";
		}
		protected virtual string bool2Code(bool val) {
			return val.ToString();
		}

		/// <summary>
		/// 判断代码是否相等
		/// </summary>
		/// <returns></returns>
		public virtual bool isCodeEqual(string str1, string str2) {
			if (str1 == "\"\"" && str2 == nullCode) return true;
			return str1 == str2;
		}

		/// <summary>
		/// 转化为数组
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public virtual string str2StrList(string str) {
			if (str.Trim() == "") return "";
			var types = str.Split(',');
			for (int i = 0; i < types.Length; ++i)
				types[i] = "'" + types[i].Trim() + "'";

			return string.Join(",", types);
		}

		#endregion
	}

	/// <summary>
	/// 语言
	/// </summary>
	public abstract class Language<T> : Language where T : Language<T>, new() {

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
		public static T get() {
			if (_self == null) _self = new T();
			return _self;
		}

		/// <summary>
		/// 初始化
		/// </summary>
		protected Language() {
			if (_self != null) throw new MultCaseException();

			languages.Add(langName.ToLower(), this);
		}
	}

	/// <summary>
	/// 语素适配对象
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class LangAdapter {

		/// <summary>
		/// 语言实例
		/// </summary>
		public Language language => CodeGenerator.current?.language();
		
	}

	#region 参数

	/// <summary>
	/// 参数组
	/// </summary>
	public class ParamGroup : LangAdapter {

		//public Dictionary<string, LangParamItem<T>> params_ =
		//	new Dictionary<string, LangParamItem<T>>();
		/// <summary>
		/// 参数列表
		/// </summary>
		public List<ParamItem> params_ = new List<ParamItem>();

		/// <summary>
		/// 属性
		/// </summary>
		public int ignoreKey = 0; // 忽略键名条数（为 -1 则忽略全部）
		public bool declare = false; // 是否为声明参数

		/// <summary>
		/// 筛选器
		/// </summary>
		public List<string> enables = null;

		/// <summary>
		/// 构造函数
		/// </summary>
		public ParamGroup(int ignoreKey = 0, List<string> enables = null) {
			this.enables = enables; this.ignoreKey = ignoreKey;
		}
		public ParamGroup(bool declare, List<string> enables = null) {
			this.declare = declare; this.enables = enables;
		}

		/// <summary>
		/// 是否为空
		/// </summary>
		/// <returns></returns>
		public bool isEmpty() {
			return params_.Count <= 0;
		}

		/// <summary>
		/// 添加参数
		/// </summary>
		/// <param name="name">参数键</param>
		/// <param name="typeOrVal">类型或参数值</param>
		/// <param name="default_">参数默认值</param>
		/// <param name="code">代码写入</param>
		public void addParam(string name, object typeOrVal,
			object default_ = null, bool code = false) {
			if (enables != null && !enables.Contains(name)) return;

			var defStr = language?.var2Code(default_, code);
			var typeOrValStr = language?.var2Code(typeOrVal, code || declare);

			params_.Add(new ParamItem(declare, name, typeOrValStr, defStr));
		}

	}

	/// <summary>
	/// 参数项
	/// </summary>
	public class ParamItem : LangAdapter {

		/// <summary>
		/// 属性
		/// </summary>
		public string name; // 声明/调用
		public string type = null; // 声明
		public string value = null; // 调用
		public string default_ = null; // 声明/调用/可选

		/// <summary>
		/// 构造函数
		/// </summary>
		public ParamItem(bool declare, string name,
			string typeOrValue = null, string default_ = null) {

			this.name = name; this.default_ = default_;

			if (declare) type = typeOrValue;
			else value = typeOrValue;
		}

		/// <summary>
		/// 值是否与默认值相等
		/// </summary>
		/// <returns></returns>
		public bool isDefault() {
			if (language == null) return true;
			return language.isCodeEqual(value, default_);
		}

	}

	#endregion

}
