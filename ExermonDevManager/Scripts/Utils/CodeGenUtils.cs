//using System;
//using System.Collections.Generic;
//using System.Text.RegularExpressions;

//namespace ExermonDevManager.Scripts.Utils {

//	using Data;

//	/// <summary>
//	/// 代码生成工具类
//	/// </summary>
//	public static class CodeGenUtils {

//		/// <summary>
//		/// 参数组合
//		/// </summary>
//		public class Params {

//			/// <summary>
//			/// 参数项
//			/// </summary>
//			public class ParamItem {
//				public string value;
//				public string default_ = null;

//				public ParamItem(string value, string default_ = null) {
//					this.value = value; this.default_ = default_;
//				}
//			}

//			/// <summary>
//			/// 参数字典
//			/// </summary>
//			public Dictionary<string, ParamItem> params_ =
//				new Dictionary<string, ParamItem>();

//			/// <summary>
//			/// 是否为空
//			/// </summary>
//			/// <returns></returns>
//			public bool isEmpty() {
//				return params_.Count <= 0;
//			}
//		}

//		#region Python代码生成

//		/// <summary>
//		/// Python参数组合
//		/// </summary>
//		public class PyParams : Params {

//			/// <summary>
//			/// 筛选器
//			/// </summary>
//			public List<string> enables = null;

//			/// <summary>
//			/// 构造函数
//			/// </summary>
//			/// <param name="enables"></param>
//			public PyParams(List<string> enables = null) {
//				this.enables = enables;
//			}

//			/// <summary>
//			/// 添加参数
//			/// </summary>
//			/// <param name="key">参数键</param>
//			/// <param name="val">参数值</param>
//			/// <param name="default_">参数默认值</param>
//			/// <param name="code">代码写入</param>
//			public void addParam(string key, object val, 
//				object default_ = null, bool code = false) {
//				if (enables != null && !enables.Contains(key)) return;

//				var valStr = code ? (string)val : 
//					var2PyCode(val);
//				var defaultStr = code ? (string)default_ : 
//					var2PyCode(default_);

//				params_.Add(key, new ParamItem(valStr, defaultStr));
//			}
//		}

//		#region 参数生成

//		/// <summary>
//		/// 生成Python参数组代码
//		/// </summary>
//		/// <param name="params_">参数键值对</param>
//		/// <param name="ignoreKey">忽略键名条数（为-1则忽略全部）</param>
//		public static string genPyParamsCode(PyParams params_, int ignoreKey = 0) {
//			var paramCodes = new List<string>();

//			foreach (var param in params_.params_) {
//				if (ignoreKey > 0) ignoreKey--;

//				var key = param.Key;
//				var val = param.Value.value;
//				var default_ = param.Value.default_;

//				// 与默认值相等则忽略
//				if (val == default_) continue;

//				paramCodes.Add(genPyParamCode(key, val,
//					ignoreKey > 0 || ignoreKey == -1));
//			}

//			return string.Join(",", paramCodes);
//		}

//		/// <summary>
//		/// 生成Python参数代码
//		/// </summary>
//		/// <param name="key">键</param>
//		/// <param name="val">值</param>
//		/// <param name="ignoreKey">是否忽略键</param>
//		public static string genPyParamCode(string key,
//			string val, bool ignoreKey = false) {
//			return ignoreKey ? val : (key + "=" + val);
//		}

//		#endregion

//		#region 生成模型代码

//		#region 生成转化配置代码

//		/// <summary>
//		/// 生成FieldFilter代码
//		/// </summary>
//		/// <returns></returns>
//		public static string genFieldFilterCode(
//			List<Model.TypeSetting> typeSettings) {
//			var name = "TYPE_FIELD_FILTER_MAP";
//			var valueFormat = "{{\r\n{0}}}";
//			var itemFormat = "'{0}': [{1}], \r\n";
//			var itemsCode = new List<string>();

//			foreach (var setting in typeSettings) {
//				var type = setting.name;
//				var fieldsCode = setting.genFieldsCode();

//				itemsCode.Add(string.Format(
//					itemFormat, type, fieldsCode));
//			}

//			if (itemsCode.Count <= 0) return "";

//			var val = string.Format(valueFormat,
//				string.Join(",", itemsCode));
			
//			return genPyAssignmentCode(name, val);
//		}
		
//		/// <summary>
//		/// 生成RelatedFilter代码
//		/// </summary>
//		/// <returns></returns>
//		public static string genRelatedFilterCode(
//			List<Model.TypeSetting> typeSettings) {

//			var name = "TYPE_RELATED_FILTER_MAP";
//			var valueFormat = "{{\r\n{0}}}";
//			var itemFormat = "'{0}': [{1}], \r\n";
//			var itemsCode = new List<string>();

//			foreach (var setting in typeSettings) {
//				var type = setting.name;
//				var relsCode = setting.genRelsCode();

//				itemsCode.Add(string.Format(
//					itemFormat, type, relsCode));
//			}

//			if (itemsCode.Count <= 0) return "";

//			var val = string.Format(valueFormat,
//				string.Join(",", itemsCode));

//			return genPyAssignmentCode(name, val);
//		}

//		#endregion

//		#region 生成Admin配置代码

//		/// <summary>
//		/// 生成AdminListDisplay代码
//		/// </summary>
//		/// <returns></returns>
//		public static string genListDisplayCode(List<ModelField> fields) {

//			var name = "LIST_DISPLAY";
//			var codeFormat = "[{0}]";
//			var fieldsCode = new List<string>();

//			foreach (var field in fields)
//				if (field.isBackend() && field.listDisplay)
//					fieldsCode.Add("'" + field.pyName() + "'");

//			if (fieldsCode.Count <= 0) return "";

//			var val = string.Format(codeFormat,
//				string.Join(",", fieldsCode));

//			return genPyAssignmentCode(name, val);
//		}

//		/// <summary>
//		/// 生成AdminListEditable代码
//		/// </summary>
//		/// <returns></returns>
//		public static string genListEditableCode(List<ModelField> fields) {

//			var name = "LIST_EDITABLE";
//			var codeFormat = "[{0}]";
//			var fieldsCode = new List<string>();

//			foreach (var field in fields)
//				if (field.isBackend() && field.listEditable)
//					fieldsCode.Add("'" + field.pyName() + "'");

//			if (fieldsCode.Count <= 0) return "";

//			var val = string.Format(codeFormat,
//				string.Join(",", fieldsCode));

//			return genPyAssignmentCode(name, val);
//		}

//		#endregion

//		#region 字段生成

//		/// <summary>
//		/// 生成Python注释文本
//		/// </summary>
//		public static string genPyFieldCommentCode(
//			string desc, string verboseName) {
//			return "# " + (isNullInCS(desc) ? verboseName : desc) + "\r\n";
//		}

//		/// <summary>
//		/// 生成Python字段代码
//		/// </summary>
//		/// <param name="name">字段名</param>
//		/// <param name="type">字段类型</param>
//		/// <param name="params_">参数键值对</param>
//		/// <returns></returns>
//		public static string genPyFieldCode(string name,
//			string type, PyParams params_) {

//			var format = "{0} = {1}({2})\r\n";
//			var paramCode = genPyParamsCode(params_);

//			return string.Format(format, name, type, paramCode);
//		}

//		/// <summary>
//		/// 生成Python字段拓展代码
//		/// </summary>
//		/// <param name="name">字段名</param>
//		/// <param name="attr">属性</param>
//		/// <param name="value">参数键值对</param>
//		/// <returns></returns>
//		public static string genPyFieldExtendCode(string name, PyParams params_) {
//			var res = "";
//			var format = "{0}.{1} = {2}\r\n";

//			foreach (var param in params_.params_) {
//				var key = param.Key;
//				var val = param.Value.value;
//				var default_ = param.Value.default_;

//				// 与默认值相等则忽略
//				if (isPyEqualToDefault(val, default_)) continue;

//				res += string.Format(format, name, key, val);
//			}

//			return res;
//		}

//		#endregion

//		#region Meta类生成

//		/// <summary>
//		/// 生成Meta类代码
//		/// </summary>
//		/// <param name="verboseName">名称</param>
//		/// <param name="abstract_">抽象</param>
//		/// <returns></returns>
//		public static string genMetaClassCode(string verboseName, bool abstract_) {

//			string classCode = "", format;
//			if (verboseName != "") {
//				format = "verbose_name = verbose_name_plural = \"{0}\"";
//				classCode += string.Format(format, verboseName);
//			}
//			if (abstract_)
//				classCode += "abstract = True";

//			if (classCode == "") return "";

//			return genPyClassCode("Meta", classCode);
//		}

//		#endregion

//		#endregion

//		#region 类生成

//		/// <summary>
//		/// 生成Python类注释代码
//		/// </summary>
//		/// <param name="desc">注释</param>
//		/// <returns></returns>
//		public static string genPyClassCommentCode(string desc) {
//			if (desc == "") return "";

//			var format = 
//				"# ===================================================\r\n" +
//				"# {0}\r\n" +
//				"# ===================================================\r\n";

//			return string.Format(format, desc);
//		}

//		/// <summary>
//		/// 生成Python类代码
//		/// </summary>
//		/// <param name="name">类名</param>
//		/// <param name="code">类代码</param>
//		/// <param name="inherits">继承类</param>
//		/// <returns></returns>
//		public static string genPyClassCode(string name,
//			string code, List<string> inherits = null) {

//			var codeFormat = "class {0}({1}):\r\n{2}\r\n";
//			var inheritsCode = inherits == null ? "" :
//				string.Join(", ", inherits);

//			if (code == "") code = "pass\r\n";
//			var classCode = genIndent(code);

//			return string.Format(codeFormat,
//				name, inheritsCode, classCode);
//		}

//		#endregion

//		#region 枚举生成

//		/// <summary>
//		/// 生成Python枚举项代码
//		/// </summary>
//		/// <param name="name"></param>
//		/// <param name="code"></param>
//		/// <param name="description"></param>
//		/// <returns></returns>
//		public static string genPyEnumItemCode(string name, 
//			int code, string description) {
//			return string.Format("{0} = {1}  # {2}\r\n", 
//				name, code, description);
//		}

//		#endregion

//		#region 通用生成

//		/// <summary>
//		/// 变量转化为Python代码
//		/// </summary>
//		/// <returns></returns>
//		public static string var2PyCode(object val) {
//			if (val == null) return "None";

//			if (val.GetType() == typeof(string))
//				return "'" + (string)val + "'";

//			return val.ToString();
//		}

//		/// <summary>
//		/// 转化为数组
//		/// </summary>
//		/// <param name="str"></param>
//		/// <returns></returns>
//		public static string str2PyStrList(string str) {
//			if (str.Trim() == "") return "[]";
//			var types = str.Split(',');
//			for (int i = 0; i < types.Length; ++i)
//				types[i] = "'" + types[i].Trim() + "'";

//			return "[" + string.Join(",", types) + "]";
//		}

//		/// <summary>
//		/// 生成Python赋值语句
//		/// </summary>
//		/// <param name="name">区域名</param>
//		/// <param name="code">代码段</param>
//		/// <returns></returns>
//		public static string genPyRegionCode(string name, string code) {
//			return string.Format("# region {0}\r\n\r\n" +
//				"{1}\r\n# endregion\r\n", name, code);
//		}

//		/// <summary>
//		/// 生成Python赋值语句
//		/// </summary>
//		/// <param name="name">变量名</param>
//		/// <param name="val">值</param>
//		/// <returns></returns>
//		public static string genPyAssignmentCode(string name, string val) {
//			return string.Format("{0} = {1}\r\n", name, val);
//		}

//		/// <summary>
//		/// Python是否与默认值相等
//		/// </summary>
//		/// <returns></returns>
//		static bool isPyEqualToDefault(string val, string default_) {
//			if (val == "''" && default_ == "None") return true;
//			return val == default_;
//		}

//		#endregion

//		#endregion

//		#region C#代码生成

//		/// <summary>
//		/// C#参数组合
//		/// </summary>
//		public class CSParams : Params {

//			/// <summary>
//			/// 添加参数
//			/// </summary>
//			/// <param name="key">参数键</param>
//			/// <param name="val">参数值</param>
//			/// <param name="default_">参数默认值</param>
//			/// <param name="code">代码写入</param>
//			public void addParam(string key, object val,
//				object default_ = null, bool code = false) {

//				var valStr = code ? (string)val :
//					var2CSCode(val);
//				var defaultStr = code ? (string)default_ :
//					var2CSCode(default_);

//				params_.Add(key, new ParamItem(valStr, defaultStr));
//			}
//		}

//		#region 特性生成

//		/// <summary>
//		/// 生成特性文本
//		/// </summary>
//		/// <param name="name">特性名</param>
//		/// <param name="params_">参数键值对</param>
//		/// <param name="ignoreKey">忽略键名条数（为-1则忽略全部）</param>
//		public static string genCSAttributeCode(string name,
//			CSParams params_, int ignoreKey = 0) {

//			// 无参数情况
//			var paramsText = genCSParamsCode(params_, ignoreKey);
//			if (paramsText == "") return "[" + name + "]";

//			var attrFormat = "[" + name + "({0})]";
//			return string.Format(attrFormat, paramsText);
//		}

//		#endregion

//		#region 参数生成

//		/// <summary>
//		/// 生成C#参数组代码
//		/// </summary>
//		/// <param name="params_">参数键值对</param>
//		/// <param name="ignoreKey">忽略键名条数（为-1则忽略全部）</param>
//		public static string genCSParamsCode(CSParams params_, int ignoreKey = 0) {
//			var paramCodes = new List<string>();

//			foreach (var param in params_.params_) {
//				if (ignoreKey > 0) ignoreKey--;

//				var key = param.Key;
//				var val = param.Value.value;
//				var default_ = param.Value.default_;

//				// 与默认值相等则忽略
//				if (isCSEqualToDefault(val, default_)) continue;

//				paramCodes.Add(genCSParamCode(key, val,
//					ignoreKey > 0 || ignoreKey == -1));
//			}

//			return string.Join(",", paramCodes);
//		}

//		/// <summary>
//		/// 生成C#参数代码
//		/// </summary>
//		/// <param name="key">键</param>
//		/// <param name="val">值</param>
//		/// <param name="ignoreKey">是否忽略键</param>
//		public static string genCSParamCode(string key,
//			string val, bool ignoreKey = false) {
//			return ignoreKey ? val : (key + ": " + val);
//		}

//		#endregion

//		#region 属性生成

//		/// <summary>
//		/// 生成C#属性代码
//		/// </summary>
//		/// <param name="name">属性名</param>
//		/// <param name="type">属性类型</param>
//		/// <param name="default_">默认值</param>
//		/// <param name="defaultNew">默认创建实例</param>
//		/// <param name="protectedSet">protected set函数</param>
//		/// <returns></returns>
//		public static string genCSPropertyCode(string name,
//			string type, int dimension, bool useList = false,
//			string default_ = null, bool defaultNew = false,
//			bool protectedSet = false) {

//			var format = protectedSet ?
//				"public {0} {1} {{ get; protected set; }}" :
//				"public {0} {1} {{ get; set; }}";

//			type = genCSTypeCode(type, dimension, useList);
//			var res = string.Format(format, type, name);

//			// 如果没有设置默认值
//			if (isNullInCS(default_) && !defaultNew) return res + "\r\n";

//			string defaultCode = "";
//			if (defaultNew) // 如果创建实例
//				defaultCode = string.Format("new {0}()", type);
//			else // 否则设置了具体的默认值
//				defaultCode = var2CSCode(default_);

//			return res + string.Format(" = {0};\r\n", defaultCode);
//		}

//		/// <summary>
//		/// 生成C#类型代码（处理数组）
//		/// </summary>
//		/// <param name="type">类型</param>
//		/// <param name="dimension">维度</param>
//		/// <param name="useList">使用List<></param>
//		/// <returns></returns>
//		static string genCSTypeCode(string type, int dimension, bool useList) {
//			if (!useList)
//				for (int i = 0; i < dimension; ++i) type += "[]";
//			else
//				for (int i = 0; i < dimension; ++i) type = "List<" + type + ">";
//			return type;
//		}

//		#endregion

//		#region 类生成

//		/// <summary>
//		/// 生成C#类代码
//		/// </summary>
//		/// <param name="name">类名</param>
//		/// <param name="code">类代码</param>
//		/// <param name="inherit">继承类</param>
//		/// <param name="abstract_">是否抽象</param>
//		/// <returns></returns>
//		public static string genCSClassCode(string name,
//			string code, string inherit = null, bool abstract_ = false) {

//			var format = abstract_ ?
//				"public abstract class {0} {{\r\n{1}\r\n}}\r\n" :
//				"public class {0} {{\r\n{1}\r\n}}\r\n";

//			var isInherit = inherit == "" || inherit == null;
//			var nameFormat = isInherit ? "{0} : {1}" : "{0}";

//			name = string.Format(nameFormat, name, inherit);

//			var classCode = genIndent(code);

//			return string.Format(format, name, classCode);
//		}

//		#endregion

//		#region 枚举生成

//		/// <summary>
//		/// 生成C#枚举项代码
//		/// </summary>
//		/// <param name="name"></param>
//		/// <param name="code"></param>
//		/// <param name="description"></param>
//		/// <returns></returns>
//		public static string genCSEnumItemCode(string name,
//			int code, string description) {
//			return string.Format("{0} = {1}, // {2}\r\n",
//				name, code, description);
//		}

//		#endregion

//		#region 通用生成

//		/// <summary>
//		/// 变量转化为C#代码
//		/// </summary>
//		/// <returns></returns>
//		public static string var2CSCode(object val) {
//			if (val == null) return "null";

//			if (val.GetType() == typeof(string))
//				return "\"" + (string)val + "\"";
//			if (val.GetType() == typeof(bool))
//				return (bool)val ? "true" : "false";

//			return val.ToString();
//		}

//		/// <summary>
//		/// C#中是否可视为null
//		/// </summary>
//		/// <returns></returns>
//		public static bool isNullInCS(string code) {
//			return code == null || code == "";
//		}

//		/// <summary>
//		/// 生成Python赋值语句
//		/// </summary>
//		/// <param name="name">区域名</param>
//		/// <param name="code">代码段</param>
//		/// <returns></returns>
//		public static string genCSRegionCode(string name, string code) {
//			return string.Format("#region {0}\r\n\r\n" +
//				"{1}\r\n#endregion\r\n", name, code);
//		}

//		/// <summary>
//		/// 生成Python赋值语句
//		/// </summary>
//		/// <param name="name">变量名</param>
//		/// <param name="val">值</param>
//		/// <returns></returns>
//		public static string genCSAssignmentCode(string name, string val) {
//			return string.Format("{0} = {1};\r\n", name, val);
//		}

//		/// <summary>
//		/// 生成C#注释文本
//		/// </summary>
//		public static string genCSCommentCode(string desc) {
//			if (isNullInCS(desc)) return "";

//			var format =
//				"/// <summary>\r\n" +
//				"/// {0}\r\n" +
//				"/// </summary>\r\n";

//			return string.Format(format, desc);
//		}

//		/// <summary>
//		/// C#是否与默认值相等
//		/// </summary>
//		/// <returns></returns>
//		static bool isCSEqualToDefault(string val, string default_) {
//			if (val == "\"\"" && default_ == "null") return true;
//			return val == default_;
//		}

//		#endregion

//		#endregion

//		/// <summary>
//		/// 添加缩进
//		/// </summary>
//		/// <param name="code">代码</param>
//		/// <param name="indent">缩进</param>
//		/// <returns></returns>
//		public static string genIndent(string code, int indent = 1) {
//			var lines = Regex.Split(code, "\r\n");
//			var indentStr = "";
//			for (int i = 0; i < indent; ++i)
//				indentStr += "\t";

//			for(int i=0;i<lines.Length;++i)
//				lines[i] = indentStr + lines[i];

//			return string.Join("\r\n", lines);
//		}
//	}
//}
