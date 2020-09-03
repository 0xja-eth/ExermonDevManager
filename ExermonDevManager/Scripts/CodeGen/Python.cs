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
	}

	/// <summary>
	/// Django字段类
	/// </summary>
	public class LangDjangoField : LangVariable<Python> {

		/// <summary>
		/// 属性
		/// </summary>
		public DjangoFieldType fieldType; // 域类型

		/// <summary>
		/// 参数组
		/// </summary>
		public LangParamGroup<Python> paramGroup;

		/// <summary>
		/// 额外参数
		/// </summary>
		public LangParamGroup<Python> extendParamGroup;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangDjangoField(DjangoFieldType fieldType, string name,
			string description = null, List<string> enables = null) :
			base(null, name, null, description) {

			paramGroup = new LangParamGroup<Python>(0, enables);
			extendParamGroup = new LangParamGroup<Python>();
			this.fieldType = fieldType;
		}
	}

	/// <summary>
	/// Django类型配置区域
	/// </summary>
	public class LangDjangoTypeSetting : LangRegion<Python> {

		/// <summary>
		/// 区域名称常量
		/// </summary>
		const string RegionName = "转化/读取配置";

		/// <summary>
		/// 数据
		/// </summary>
		public List<Model.TypeSetting> typeSettings;
		public string keyName;
		/// <summary>
		/// 构造函数
		/// </summary>
		public LangDjangoTypeSetting(string keyName,
			List<Model.TypeSetting> typeSettings) : base(RegionName) {
			this.keyName = keyName;
			this.typeSettings = typeSettings;
		}

		/// <summary>
		/// 生成键名代码
		/// </summary>
		/// <returns></returns>
		public string genKeyNameCode() {
			if (string.IsNullOrEmpty(keyName)) return "";
			return "'" + keyName + "'";
		}

		/// <summary>
		/// 生成值代码
		/// </summary>
		/// <param name="mode"></param>
		/// <returns></returns>
		public string genValueCode(string mode) {
			var valueFormat = "{{\r\n{0}}}";
			var itemFormat = "'{0}': [{1}], \r\n";
			var itemsCode = new List<string>();

			foreach (var setting in typeSettings) {
				var type = setting.name;
				var settingCode = getSettingCode(setting, mode);
				itemsCode.Add(string.Format(itemFormat, type, settingCode));
			}

			if (itemsCode.Count <= 0) return "";

			return string.Format(valueFormat,
				string.Join(",", itemsCode));
		}

		/// <summary>
		/// 生成设置代码
		/// </summary>
		string getSettingCode(Model.TypeSetting setting, string mode) {
			switch (mode) {
				case "field": return setting.genFieldsCode();
				case "rel": return setting.genRelsCode();
				default: return "";
			}
		}

		/// <summary>
		/// 添加变量
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public void addVar(string name, string value) {
			if (string.IsNullOrEmpty(value)) return;
			subBlocks.Add(new LangVariable<Python>(null, name, value));
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
		/// 生成值代码
		/// </summary>
		/// <param name="mode"></param>
		/// <returns></returns>
		public string genValueCode(string mode) {
			var valueFormat = "[{0}]";
			var fieldsCode = new List<string>();

			foreach (var field in fields)
				if (field.isBackend() && judgeField(field, mode))
					fieldsCode.Add("'" + field.pyName() + "'");

			if (fieldsCode.Count <= 0) return "";

			return string.Format(valueFormat,
				string.Join(",", fieldsCode));
		}

		/// <summary>
		/// 生成设置代码
		/// </summary>
		bool judgeField(ModelField field, string mode) {
			switch (mode) {
				case "display":
					return field.listDisplay;
				case "editable":
					return field.listEditable && field.pyName() != "id";
				default: return false;
			}
		}

		/// <summary>
		/// 添加变量
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public void addVar(string name, string value) {
			if (string.IsNullOrEmpty(value)) return;
			subBlocks.Add(new LangVariable<Python>(null, name, value));
		}
	}

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
			"# region {0}", "\r\n\r\n{0}\r\n# endregion"
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
			registerAdjustFunc<LangDjangoModel>(adjustDjangoModel);
			registerAdjustFunc<LangFunction<Python>>(adjustFunction);
			registerAdjustFunc<LangDjangoTypeSetting>(adjustDjangoTypeSetting);
			registerAdjustFunc<LangDjangoAdminSetting>(adjustDjangoAdmin);

			registerGenCodeFunc<LangDjangoField>(genDjangoFieldCode);
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
			var format = string.IsNullOrEmpty(b.default_) ?
				"{0}{1}" : "{0}{1} = {2}";

			return string.Format(format, b.name,
				genTypeCode(b.type), b.default_);
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
		/// 调整类
		/// </summary>
		/// <param name="b"></param>
		void adjustDjangoModel(LangDjangoModel b) {
			var meta = new LangClass<Python>("Meta");

			if (b.abstract_)
				meta.addVar(null, "abstract", true);

			if (!string.IsNullOrEmpty(b.verboseName))
				meta.addVar(null, "verbose_name = " +
					"verbose_name_plural", b.verboseName);

			if (meta.subBlocks.Count > 0) b.subBlocks.Insert(0, meta);
		}

		/// <summary>
		/// 调整函数
		/// </summary>
		/// <param name="b"></param>
		void adjustFunction(LangFunction<Python> b) {
			if (b.isStatic)
				b.decoBlocks.Add(new LangDecorator("classmethod"));
		}

		/// <summary>
		/// 调整Django类型设定
		/// </summary>
		/// <param name="b"></param>
		void adjustDjangoTypeSetting(LangDjangoTypeSetting b) {
			var keyName = b.genKeyNameCode();
			var fieldsCode = b.genValueCode("field");
			var relsCode = b.genValueCode("rel");

			b.addVar("KEY_NAME", keyName);
			b.addVar("TYPE_FIELD_FILTER_MAP", fieldsCode);
			b.addVar("TYPE_RELATED_FILTER_MAP", relsCode);
		}

		/// <summary>
		/// 调整Django Admin 配置
		/// </summary>
		/// <param name="b"></param>
		void adjustDjangoAdmin(LangDjangoAdminSetting b) {
			var fieldsCode = b.genValueCode("display");
			var relsCode = b.genValueCode("editable");

			b.addVar("LIST_DISPLAY", fieldsCode);
			b.addVar("LIST_EDITABLE", relsCode);
		}

		/// <summary>
		/// 生成字段
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		string genDjangoFieldCode(LangDjangoField b) {
			// {$name} = {$type}({$params})
			// {$extParams}
			var format = "{0} = {1}({2})\r\n{3}";

			var typeName = b.fieldType.name;
			var paramsCode = b.paramGroup.genCode();

			var extParamCodes = new List<string>();
			foreach(var param in b.extendParamGroup.params_) {
				if (param.isValueEqule2Default()) continue;
				extParamCodes.Add(genExtendParam(b.name, param));
			}
			var extParamsCode = string.Join("\r\n", extParamCodes);

			return string.Format(format, b.name, 
				typeName, paramsCode, extParamsCode);
		}

		/// <summary>
		/// 生成拓展参数代码
		/// </summary>
		/// <returns></returns>
		string genExtendParam(string objName, 
			LangParamItem<Python> param) {
			var name = objName + "." + param.name;
			var tmp = new LangVariable<Python>(null, name, param.value);
			return tmp.genCode();
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
