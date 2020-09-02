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
		public LangDjangoField(DjangoFieldType fieldType,
			string name, List<string> enables = null) : base(null, name) {
			paramGroup = new LangParamGroup<Python>(0, enables);
			extendParamGroup = new LangParamGroup<Python>();
			this.fieldType = fieldType;
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
			"# region {0}", "\r\n" + "{1}\r\n" + "# endregion"
		);

		// 通用块格式
		public override string generalBlockFormat => ":\r\n{0}";

		// 表示为空
		public override string nullCode => "null";

		#region 代码生成

		/// <summary>
		/// 配置函数注册
		/// </summary>
		protected override void setupFuncRegister() {
			base.setupFuncRegister();
			registerAdjustFunc<LangDjangoModel>(adjustDjangoModel);
			registerAdjustFunc<LangFunction<Python>>(adjustFunction);

			registerGenCodeFunc<LangClass<Python>>(genClassCode);
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
