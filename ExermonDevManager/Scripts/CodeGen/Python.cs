using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExermonDevManager.Scripts.CodeGen {

	using Data;

	/// <summary>
	/// Django字段类
	/// </summary>
	public class LangClassComment : LangComment<Python> {

		/// <summary>
		/// 块格式
		/// </summary>
		protected override LangFormat format =>
			new LangFormat(
				"# ===================================================\r\n" +
				"# {0}\r\n" +
				"# ===================================================");

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangClassComment(string name) : base(name) { }
	}

	/// <summary>
	/// 修饰器类
	/// </summary>
	public class LangDecorator : LangBlock<Python> {

		/// <summary>
		/// 参数组
		/// </summary>
		public LangParamGroup<Python> paramGroup = new LangParamGroup<Python>();

		/// <summary>
		/// 是否为叶子块（没有子块）
		/// </summary>
		public override bool isLeaf => true;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangDecorator(string name) : base(name) { }
	}

	#region 特殊数据类型

	/// <summary>
	/// Python列表
	/// </summary>
	public class LangPyList : LangElement<Python> {

		/// <summary>
		/// 值
		/// </summary>
		public List<string> value;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangPyList(List<string> value) {
			this.value = value;
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		public override string genCode() {
			return "[" + string.Join(", ", value) + "]";
		}
	}

	/// <summary>
	/// Python泛型列表
	/// </summary>
	public class LangPyList<T> : LangElement<Python> 
		where T : LangElement<Python> {

		/// <summary>
		/// 值
		/// </summary>
		public List<T> value;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangPyList(List<T> value) {
			this.value = value;
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		public override string genCode() {
			var itemCodes = new List<string>(value.Count);

			foreach (var item in value)
				itemCodes.Add(item.genCode());

			return "[" + string.Join(", ", itemCodes) + "]";
		}
	}

	/// <summary>
	/// Python字典
	/// </summary>
	public class LangPyDict : LangElement<Python> {

		/// <summary>
		/// 值
		/// </summary>
		public Dictionary<string, string> value;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangPyDict(Dictionary<string, string> value) {
			this.value = value;
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		public override string genCode() {
			var format = "{{\r\n{0}\r\n}}";
			var itemFormat = "{0}: {1}";

			var itemCodes = new List<string>(value.Count);
			foreach (var item in value) 
				itemCodes.Add(string.Format(itemFormat, item.Key, item.Value));

			var itemCode = string.Join("\r\n", itemCodes);
			itemCode = language.genIndent(itemCode);

			return string.Format(format, itemCode);
		}
	}

	/// <summary>
	/// Python字典
	/// </summary>
	public class LangPyDict<T> : LangElement<Python>
		where T : LangElement<Python> {

		/// <summary>
		/// 值
		/// </summary>
		public Dictionary<string, T> value;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangPyDict(Dictionary<string, T> value) {
			this.value = value;
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		public override string genCode() {
			var format = "{{\r\n{0}\r\n}}";
			var itemFormat = "{0}: {1}";

			var itemCodes = new List<string>(value.Count);
			foreach(var item in value) {
				var code = item.Value.genCode();
				itemCodes.Add(string.Format(itemFormat, item.Key, code));
			}
			var itemCode = string.Join("\r\n", itemCodes);
			itemCode = language.genIndent(itemCode);

			return string.Format(format, itemCode);
		}
	}

	#endregion

	#region 异常相关

	/// <summary>
	/// GameException 类
	/// </summary>
	public class LangErrorTypeEnum : LangEnum<Python> {

		/// <summary>
		/// 常量
		/// </summary>
		const string EnumName = "ErrorType";

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangErrorTypeEnum() : base(EnumName) { }

		/// <summary>
		/// 自动调整代码
		/// </summary>
		protected override void autoAdjust() {
			base.autoAdjust();
			var data = BaseData.poolGet<Exception_>();
			foreach (var e in data) addSubBlock(e.genPyBlock());
		}
	}

	/// <summary>
	/// ErrorDict 字典
	/// </summary>
	public class LangErrorDict : LangPyDict {

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangErrorDict() : base(genErrorDict()) { }

		/// <summary>
		/// 生成字典
		/// </summary>
		/// <returns></returns>
		static Dictionary<string, string> genErrorDict() {

			var res = new Dictionary<string, string>();
			var data = BaseData.poolGet<Exception_>();
			foreach (var e in data)
				res.Add(e.genKeyCode(), e.genAlertTextCode());

			return res;
		}
	}

	/// <summary>
	/// GameException 类
	/// </summary>
	public class LangGameExceptionClass : LangClass<Python> {

		/// <summary>
		/// 常量
		/// </summary>
		const string ClassName = "GameException";
		const string InheritClassName = "Exception";
		const string ErrorDictAttrName = "ERROR_DICT";

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangGameExceptionClass() :
			base(ClassName, null, InheritClassName) { }

		/// <summary>
		/// 自动调整代码
		/// </summary>
		protected override void autoAdjust() {
			base.autoAdjust();
			addVar(ErrorDictAttrName, new LangErrorDict());
		}

		/// <summary>
		/// 添加变量
		/// </summary>
		public void addVar(string name, LangElement<Python> value) {
			addSubBlock(new LangVariable<Python>(null, name, value));
		}
	}

	#endregion

	#region Django模型相关

	/// <summary>
	/// Django字段类
	/// </summary>
	public class LangDjangoModel : LangClass<Python> {

		/// <summary>
		/// 属性
		/// </summary>
		public string verboseName;

		/// <summary>
		/// 注释生成
		/// </summary>
		protected override LangComment<Python> comment =>
			new LangClassComment(description);

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangDjangoModel(string name, string verboseName = null,
			string description = null, List<string> inherits = null,
			bool abstract_ = false) :
			base(name, description ?? verboseName, inherits, abstract_) {
			if (inherits == null || inherits.Count <= 0)
				inherits.Add("models.Model");
			this.verboseName = verboseName;
		}

		/// <summary>
		/// 自动调整代码
		/// </summary>
		protected override void autoAdjust() {
			base.autoAdjust();
			var meta = new LangClass<Python>("Meta");

			if (abstract_) meta.addVar(null, "abstract", true);

			if (!string.IsNullOrEmpty(verboseName))
				meta.addVar(null, "verbose_name = " +
					"verbose_name_plural", verboseName);

			if (meta.subBlockCount() > 0) insertSubBlock(0, meta);
		}
	}

	/// <summary>
	/// Django字段值
	/// </summary>
	public class LangDjangoField : LangElement<Python> {

		/// <summary>
		/// 属性
		/// </summary>
		public DjangoFieldType fieldType; // 域类型

		/// <summary>
		/// 参数组
		/// </summary>
		public LangParamGroup<Python> paramGroup { get; protected set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangDjangoField(DjangoFieldType fieldType,
			List<string> enables = null) {

			this.fieldType = fieldType;
			paramGroup = new LangParamGroup<Python>(0, enables);
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		/// <returns></returns>
		public override string genCode() {
			// {$name} = {$type}({$params})
			// {$extParams}
			var format = "{0}({1})";

			var typeName = fieldType.name;
			var paramsCode = paramGroup.genCode();

			return string.Format(format, typeName, paramsCode);
		}
	}

	/// <summary>
	/// Django字段区块类
	/// </summary>
	public class LangDjangoFieldBlock : LangVariable<Python> {

		/// <summary>
		/// 字段内容
		/// </summary>
		public LangDjangoField field;

		/// <summary>
		/// 参数
		/// </summary>
		public LangParamGroup<Python> paramGroup => field.paramGroup;

		/// <summary>
		/// 额外参数
		/// </summary>
		public LangParamGroup<Python> extendParamGroup { get; protected set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangDjangoFieldBlock(DjangoFieldType fieldType, string name,
			string description = null, List<string> enables = null) :
			this(new LangDjangoField(fieldType, enables), name, description) { }
		public LangDjangoFieldBlock(LangDjangoField field, string name, 
			string description = null) : base(null, name, field, description) {

			this.field = field; 
			extendParamGroup = new LangParamGroup<Python>();
		}

		/// <summary>
		/// 自动调整
		/// </summary>
		protected override void autoAdjust() {
			base.autoAdjust();
			processExtendParams();
		}

		/// <summary>
		/// 处理额外参数
		/// </summary>
		void processExtendParams() {
			var extParamCodes = new List<string>();
			foreach (var param in extendParamGroup.params_) {
				if (param.isValueEqule2Default()) continue;
				addNextBlock(genExtendParam(param));
			}
		}

		/// <summary>
		/// 生成拓展参数代码
		/// </summary>
		/// <returns></returns>
		LangVariable<Python> genExtendParam(LangParamItem<Python> param) {
			var name = this.name + "." + param.name;
			var tmp = new LangVariable<Python>(null, name, param.value);
			return tmp;
		}
	}

	/// <summary>
	/// Django类型配置区域
	/// </summary>
	public class LangDjangoTypeSettingRegion : LangRegion<Python> {

		/// <summary>
		/// 区域名称常量
		/// </summary>
		const string RegionName = "转化/读取配置";

		const string KeyNameAttrName = "KEY_NAME";
		const string FieldFilterAttrName = "TYPE_FIELD_FILTER_MAP";
		const string RelatedFilterAttrName = "TYPE_RELATED_FILTER_MAP";

		/// <summary>
		/// 数据
		/// </summary>
		public List<Model.TypeSetting> typeSettings;
		public string keyName;
		/// <summary>
		/// 构造函数
		/// </summary>
		public LangDjangoTypeSettingRegion(string keyName,
			List<Model.TypeSetting> typeSettings) : base(RegionName) {
			this.keyName = keyName;
			this.typeSettings = typeSettings;
		}

		/// <summary>
		/// 自动调整代码
		/// </summary>
		protected override void autoAdjust() {
			base.autoAdjust();
			processKeyName();
			processSetting("field");
			processSetting("rel");
		}

		/// <summary>
		/// 处理键名代码
		/// </summary>
		/// <returns></returns>
		void processKeyName() {
			if (string.IsNullOrEmpty(keyName)) return;
			addVar(KeyNameAttrName, "'" + keyName + "'");
		}

		/// <summary>
		/// 处理字段配置
		/// </summary>
		void processSetting(string mode) {
			var element = new LangPyDict<LangPyList>(genSettingDict(mode));
			addVar(getSettingAttrName(mode), element);
		}

		/// <summary>
		/// 生成字典
		/// </summary>
		/// <param name="mode"></param>
		/// <returns></returns>
		Dictionary<string, LangPyList> genSettingDict(string mode) {
			var res = new Dictionary<string, LangPyList>();
			foreach(var setting in typeSettings) {
				var value = new LangPyList(
					getSettingCodes(setting, mode));

				res.Add(setting.name, value);
			}
			return res;
		}

		/// <summary>
		/// 生成设置代码
		/// </summary>
		List<string> getSettingCodes(Model.TypeSetting setting, string mode) {
			switch (mode) {
				case "field": return setting.genFieldCodes();
				case "rel": return setting.genRelCodes();
				default: return null;
			}
		}

		/// <summary>
		/// 生成配置属性名
		/// </summary>
		string getSettingAttrName(string mode) {
			switch (mode) {
				case "field": return FieldFilterAttrName;
				case "rel": return RelatedFilterAttrName;
				default: return null;
			}
		}

		///// <summary>
		///// 生成值代码
		///// </summary>
		///// <param name="mode"></param>
		///// <returns></returns>
		//public string genValueCode(string mode) {
		//	var valueFormat = "{{\r\n{0}}}";
		//	var itemFormat = "'{0}': [{1}], \r\n";
		//	var itemCodes = new List<string>();

		//	foreach (var setting in typeSettings) {
		//		var type = setting.name;
		//		var settingCode = getSettingCode(setting, mode);
		//		itemCodes.Add(string.Format(itemFormat, type, settingCode));
		//	}

		//	if (itemCodes.Count <= 0) return "";

		//	var itemsCode = string.Join(",", itemCodes);
		//	itemsCode = language.genIndent(itemsCode);

		//	return string.Format(valueFormat, itemsCode);
		//}

		/// <summary>
		/// 添加变量
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public void addVar(string name, string value) {
			if (string.IsNullOrEmpty(value)) return;
			addSubBlock(new LangVariable<Python>(null, name, value));
		}
		public void addVar(string name, LangElement<Python> value) {
			addSubBlock(new LangVariable<Python>(null, name, value));
		}
	}

	/// <summary>
	/// Django Admin 配置区域
	/// </summary>
	public class LangDjangoAdminSetting : LangRegion<Python> {

		/// <summary>
		/// 区域名称常量
		/// </summary>
		const string RegionName = "Admin配置";

		const string ListDisplayAttrName = "LIST_DISPLAY";
		const string ListEditableAttrName = "LIST_EDITABLE";

		/// <summary>
		/// 数据
		/// </summary>
		public List<ModelField> fields;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangDjangoAdminSetting(List<ModelField> fields) :
			base(RegionName) { this.fields = fields; }
		
		/// <summary>
		/// 自动调整代码
		/// </summary>
		protected override void autoAdjust() {
			base.autoAdjust();
			processSetting("display");
			processSetting("editable");
		}

		/// <summary>
		/// 处理Admin配置
		/// </summary>
		void processSetting(string mode) {
			var element = new LangPyList(genSettingDict(mode));
			addVar(getSettingAttrName(mode), element);
		}

		/// <summary>
		/// 生成字典
		/// </summary>
		/// <param name="mode"></param>
		/// <returns></returns>
		List<string> genSettingDict(string mode) {
			var res = new List<string>();

			foreach (var field in fields)
				if (field.isBackend() && judgeField(field, mode))
					res.Add("'" + field.pyName() + "'");

			return res;
		}

		///// <summary>
		///// 生成值代码
		///// </summary>
		///// <param name="mode"></param>
		///// <returns></returns>
		//public string genValueCode(string mode) {
		//	var valueFormat = "[{0}]";
		//	var fieldsCode = new List<string>();

		//	foreach (var field in fields)
		//		if (field.isBackend() && judgeField(field, mode))
		//			fieldsCode.Add("'" + field.pyName() + "'");

		//	if (fieldsCode.Count <= 0) return "";

		//	return string.Format(valueFormat,
		//		string.Join(",", fieldsCode));
		//}

		/// <summary>
		/// 生成设置代码
		/// </summary>
		bool judgeField(ModelField field, string mode) {
			switch (mode) {
				case "display": return field.listDisplay;
				case "editable":
					return field.listEditable && field.pyName() != "id";
				default: return false;
			}
		}

		/// <summary>
		/// 生成配置属性名
		/// </summary>
		string getSettingAttrName(string mode) {
			switch (mode) {
				case "display": return ListDisplayAttrName;
				case "editable": return ListEditableAttrName;
				default: return null;
			}
		}

		/// <summary>
		/// 添加变量
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public void addVar(string name, string value) {
			if (string.IsNullOrEmpty(value)) return;
			addSubBlock(new LangVariable<Python>(null, name, value));
		}
		public void addVar(string name, LangElement<Python> value) {
			addSubBlock(new LangVariable<Python>(null, name, value));
		}
	}

	#endregion

	/// <summary>
	/// Python
	/// </summary>
	public class Python : Language<Python> {

		/// <summary>
		/// 语言格式设定
		/// </summary>
		public override LangFormat blockFormat => new LangFormat("{0}");

		// 枚举相关
		public override LangFormat enumFormat => new LangFormat("class {0}(enum)");
		public override LangFormat enumItemFormat => new LangFormat("{0} = {1}  # {2}");

		// 注释相关
		public override LangFormat commentFormat => new LangFormat("# {0}");
		public override LangFormat regionFormat => new LangFormat(
			"# region {0}", "\r\n\r\n{0}\r\n\r\n# endregion"
		);

		// 通用块格式
		public override string generalBlockFormat => ":\r\n{0}\r\n";

		// 表示为空
		public override string nullCode => "null";

		// 数组括号
		public override string arrayBrackets => "[]";

		#region 代码生成

		/// <summary>
		/// 配置函数注册
		/// </summary>
		protected override void setupFuncRegister() {
			base.setupFuncRegister();
			//registerAdjustFunc<LangDjangoModel>(adjustDjangoModel);
			registerAdjustFunc<LangFunction<Python>>(adjustFunction);
			//registerAdjustFunc<LangDjangoTypeSettingRegion>(adjustDjangoTypeSetting);
			//registerAdjustFunc<LangDjangoAdminSetting>(adjustDjangoAdmin);

			//registerGenCodeFunc<LangDjangoField>(genDjangoFieldCode);
			registerGenCodeFunc<LangDecorator>(genDecoratorCode);
		}

		#region 自定义生成

		#region 重载内置语块

		/// <summary>
		/// 生成类代码
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		protected override string genClassCode(LangClass<Python> b) {
			// class {$name}({$inherits}) 
			var format = "class {0}({1})";
			var inheritCodes = string.Join(paramSpliter, b.inherits);

			return string.Format(format, b.name, inheritCodes);
		}

		/// <summary>
		/// 生成函数代码
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		protected override string genFuncCode(LangFunction<Python> b) {
			// def {$name}({$firstParam}, {$params}) -> '{$type}'
			var format = string.IsNullOrEmpty(b.type) ?
				"def {0}({1}, {2})" : "def {0}({1}, {2}) -> '{3}'";

			var firstParam = b.isStatic ? "cls" : "self";
			var paramsCode = b.paramGroup.genCode();

			return string.Format(format, b.name,
				firstParam, paramsCode, b.type);
		}

		/// <summary>
		/// 生成变量
		/// </summary>
		protected override string genVarCode(LangVariable<Python> b) {
			// {$name}: '{$type}'[ = {$default}]
			var format = string.IsNullOrEmpty(b.defaultCode) ?
				"{0}{1}" : "{0}{1} = {2}";

			return string.Format(format, b.name,
				genTypeCode(b.type), b.defaultCode);
		}

		/// <summary>
		/// 生成常量
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		protected override string genConstCode(LangConstant<Python> b) {
			return genVarCode(b);
		}

		#endregion

		#region 自定义语块
		
		/// <summary>
		/// 调整函数
		/// </summary>
		/// <param name="b"></param>
		void adjustFunction(LangFunction<Python> b) {
			if (b.isStatic)
				b.addDecoBlock(new LangDecorator("classmethod"));
		}

		/// <summary>
		/// 生成修饰器
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		string genDecoratorCode(LangDecorator b) {
			// @{$name}[({$params)]
			var format = "@{0}{1}";
			var paramsCode = b.paramGroup.genCode();
			if (paramsCode != "")
				paramsCode = "(" + paramsCode + ")";

			return string.Format(format, b.name, paramsCode);
		}
		
		#endregion

		#endregion

		#region 参数生成

		/// <summary>
		/// 生成参数项代码
		/// </summary>
		public override string genParamItemCode(
			LangParamItem<Python> item, bool ignoreKey = false) {

			if (item.type != null) { // 声明
				var format = item.default_ == null ? "{0}{1}" : "{0}{1} = {2}";
				return string.Format(format, genTypeCode(item.type), 
					item.name, item.default_);

			} else if (item.value != null) { // 调用
				var format = ignoreKey ? "{0}" : "{0}={1}";
				return string.Format(format, item.name, item.value);
			}

			return "";
		}

		#endregion

		#endregion

		#region 工具函数

		/// <summary>
		/// 生成类型代码
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		string genTypeCode(string type) {
			if (string.IsNullOrEmpty(type)) return "";
			return ": '" + type + "'";
		}

		/// <summary>
		/// 转化为代码（字符串代码）
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		protected override string bool2Code(bool val) {
			return val ? "True" : "False";
		}

		#endregion

	}
}
