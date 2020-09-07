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
	/// 语言
	/// </summary>
	public abstract class Language<T> where T : Language<T>, new() {

		/// <summary>
		/// 多例错误
		/// </summary>
		class MultCaseException : Exception {
			const string ErrorText = "单例模式下不允许多例存在！";
			public MultCaseException() : base(ErrorText) { }
		}

		/// <summary>
		/// 调整语块函数
		/// </summary>
		public delegate void AdjustFunc<B>(B block) where B : LangBlock<T>;

		/// <summary>
		/// 生成代码函数
		/// </summary>
		public delegate string GenCodeFunc<B>(B block) where B : LangBlock<T>;

		/// <summary>
		/// 调整函数列表
		/// </summary>
		Dictionary<Type, AdjustFunc<LangBlock<T>>> adjustFuncs =
			new Dictionary<Type, AdjustFunc<LangBlock<T>>>();

		/// <summary>
		/// 代码生成函数列表
		/// </summary>
		Dictionary<Type, GenCodeFunc<LangBlock<T>>> genCodeFuncs =
			new Dictionary<Type, GenCodeFunc<LangBlock<T>>>();

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
			setupFuncRegister();
		}

		/// <summary>
		/// 语言格式定义
		/// </summary>
		/// <returns></returns>
		public abstract LangFormat blockFormat { get; }

		// 枚举相关
		public abstract LangFormat enumFormat { get; }
		public abstract LangFormat enumItemFormat { get; }

		// 注释相关
		public abstract LangFormat commentFormat { get; }
		public abstract LangFormat regionFormat { get; }

		// 通用块格式
		public abstract string generalBlockFormat { get; }

		// 表示为空
		public abstract string nullCode { get; }

		/// <summary>
		/// 分隔符
		/// </summary>
		public virtual string paramSpliter => ", ";
		public virtual string blockSpliter => "\r\n\r\n";
		public virtual string decoSpliter => "\r\n";

		/// <summary>
		/// 语法
		/// </summary>
		public virtual string arrayBrackets => "{}"; // 数组括号

		#region 代码生成

		#region 函数配置&自动生成

		/// <summary>
		/// 配置函数注册
		/// </summary>
		protected virtual void setupFuncRegister() {
			registerGenCodeFunc<LangClass<T>>(genClassCode);
			registerGenCodeFunc<LangFunction<T>>(genFuncCode);
			registerGenCodeFunc<LangVariable<T>>(genVarCode);
			registerGenCodeFunc<LangConstant<T>>(genConstCode);
		}

		/// <summary>
		/// 注册调整函数
		/// </summary>
		/// <typeparam name="B"></typeparam>
		/// <param name="func"></param>
		public void registerAdjustFunc<B>(AdjustFunc<B> func) where B : LangBlock<T> {
			AdjustFunc<LangBlock<T>> adjustFunc = (block) => func?.Invoke(block as B);
			adjustFuncs.Add(typeof(B), adjustFunc);
		}

		/// <summary>
		/// 注册代码生成函数
		/// </summary>
		/// <typeparam name="B"></typeparam>
		/// <param name="func"></param>
		public void registerGenCodeFunc<B>(GenCodeFunc<B> func) where B : LangBlock<T> {
			GenCodeFunc<LangBlock<T>> genCodeFunc = (block) => func?.Invoke(block as B);
			genCodeFuncs.Add(typeof(B), genCodeFunc);
		}

		/// <summary>
		/// 调整语块（根据语言特点修改内容）
		/// </summary>
		/// <param name="block"></param>
		public void adjustBlock(LangBlock<T> block) {
			generalAdjustBlock(block);

			var type = block.GetType();

			// 第一轮搜索类本身
			foreach (var item in adjustFuncs)
				if (type == item.Key) item.Value.Invoke(block); 

			// 第二轮搜索基类
			foreach (var item in genCodeFuncs)
				if (type.IsSubclassOf(item.Key))
					item.Value.Invoke(block);

		}
		protected virtual void generalAdjustBlock(LangBlock<T> block) { }

		/// <summary>
		/// 生成语块代码（根据语言特点生成代码）
		/// </summary>
		/// <param name="block"></param>
		public string genBlockCode(LangBlock<T> block) {
			var type = block.GetType();// typeof(LangBlock<T>);

			// 第一轮搜索类本身
			foreach (var item in genCodeFuncs)
				if (type == item.Key) return item.Value.Invoke(block);

			// 第二轮搜索基类
			foreach (var item in genCodeFuncs)
				if (type.IsSubclassOf(item.Key))
					return item.Value.Invoke(block);

			return generalGenBlockCode(block);
		}
		protected virtual string generalGenBlockCode(LangBlock<T> block) {
			return block.code;
		}

		#endregion

		#region 自定义生成

		/// <summary>
		/// 生成类代码
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		protected abstract string genClassCode(LangClass<T> b);

		/// <summary>
		/// 生成函数代码
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		protected abstract string genFuncCode(LangFunction<T> b);

		/// <summary>
		/// 生成变量代码
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		protected abstract string genVarCode(LangVariable<T> b);

		/// <summary>
		/// 生成常量代码
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		protected abstract string genConstCode(LangConstant<T> b);

		#endregion

		#region 参数生成

		/// <summary>
		/// 生成参数项代码
		/// </summary>
		public abstract string genParamItemCode(
			LangParamItem<T> item, bool ignoreKey = false);

		#endregion

		#endregion

		#region 工具函数

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
			if (str.Trim() == "") return arrayBrackets;
			var types = str.Split(',');
			for (int i = 0; i < types.Length; ++i)
				types[i] = "'" + types[i].Trim() + "'";

			char lb = arrayBrackets[0], rb = arrayBrackets[1];
			return lb + string.Join(",", types) + rb;
		}

		#endregion
	}

	/// <summary>
	/// 语素
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class LangElement<T> where T : Language<T>, new() {

		/// <summary>
		/// 语言实例
		/// </summary>
		public T language => Language<T>.get();

		//public virtual 

		/// <summary>
		/// 转化为代码
		/// </summary>
		/// <returns></returns>
		public abstract string genCode();
	}

	#region 参数

	/// <summary>
	/// 参数组
	/// </summary>
	public class LangParamGroup<T> : LangElement<T> where T : Language<T>, new() {

		//public Dictionary<string, LangParamItem<T>> params_ =
		//	new Dictionary<string, LangParamItem<T>>();
		/// <summary>
		/// 参数列表
		/// </summary>
		public List<LangParamItem<T>> params_ = new List<LangParamItem<T>>();

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
		public LangParamGroup(int ignoreKey = 0, List<string> enables = null) {
			this.enables = enables; this.ignoreKey = ignoreKey;
		}
		public LangParamGroup(bool declare, List<string> enables = null) {
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

			var defStr = language.var2Code(default_, code);
			var typeOrValStr = language.var2Code(typeOrVal, code || declare);

			params_.Add(new LangParamItem<T>(declare, name, typeOrValStr, defStr));
		}

		/// <summary>
		/// 转化为代码
		/// </summary>
		/// <returns></returns>
		public override string genCode() {
			var paramCodes = new List<string>();

			foreach (var param in params_) {
				if (ignoreKey > 0) ignoreKey--;

				// 与默认值相等则忽略
				if (param.isValueEqule2Default()) continue;

				paramCodes.Add(param.genCode(
					ignoreKey > 0 || ignoreKey == -1));
			}

			return string.Join(language.paramSpliter, paramCodes);
		}

	}

	/// <summary>
	/// 参数项
	/// </summary>
	public class LangParamItem<T> : LangElement<T> where T : Language<T>, new() {

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
		public LangParamItem(bool declare, string name, 
			string typeOrValue = null, string default_ = null) {

			this.name = name; this.default_ = default_;

			if (declare) type = typeOrValue;
			else value = typeOrValue;
		}

		/// <summary>
		/// 值是否与默认值相等
		/// </summary>
		/// <returns></returns>
		public bool isValueEqule2Default() {
			return language.isCodeEqual(value, default_);
		}

		/// <summary>
		/// 转化为代码
		/// </summary>
		/// <returns></returns>
		public override string genCode() {
			return language.genParamItemCode(this);
		}
		public string genCode(bool ignoreKey) {
			return language.genParamItemCode(this, ignoreKey);
		}

	}

	#endregion

	/// <summary>
	/// 代码片段
	/// </summary>
	public class LangCode<T> : LangElement<T> where T : Language<T>, new() {

		/// <summary>
		/// 属性
		/// </summary>
		public string code; // 代码片段

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangCode(string code) { this.code = code; }

		/// <summary>
		/// 转化为代码
		/// </summary>
		/// <returns></returns>
		public override string genCode() {
			return code;
		}
	}

	/// <summary>
	/// 语块
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class LangBlock<T> : LangElement<T> where T : Language<T>, new() {

		/// <summary>
		/// 代码
		/// </summary>
		public virtual string code => string.Format(mainFormat, formatArgs);

		/// <summary>
		/// 是否已经调整过
		/// </summary>
		public bool adjusted = false;

		/// <summary>
		/// 属性
		/// </summary>
		public string name; // 代码名称
		public string description;// 中文名称（注释）

		/// <summary>
		/// 修饰语块
		/// </summary>
		List<LangBlock<T>> decoBlocks = new List<LangBlock<T>>();

		/// <summary>
		/// 子语块
		/// </summary>
		List<LangBlock<T>> subBlocks = new List<LangBlock<T>>();

		/// <summary>
		/// 父语块
		/// </summary>
		public LangBlock<T> parent { get; protected set; } = null;

		/// <summary>
		/// Raw模式
		/// </summary>
		public bool rawMode = false;

		#region 配置

		/// <summary>
		/// 格式
		/// </summary>
		protected virtual LangFormat format => language.blockFormat;
		protected virtual string mainFormat => format?.main ?? "<ERROR>";
		protected virtual string blockFormat => format?.block ?? 
			language.generalBlockFormat;

		/// <summary>
		/// 分隔符
		/// </summary>
		protected virtual string blockSpliter => language.blockSpliter;
		protected virtual string decoSpliter => language.decoSpliter;

		/// <summary>
		/// 注释生成
		/// </summary>
		protected virtual LangComment<T> comment => 
			new LangComment<T>(description);

		/// <summary>
		/// 参数数组
		/// </summary>
		protected virtual object[] formatArgs => new object[] { };

		/// <summary>
		/// 是否为叶子块（没有子块）
		/// </summary>
		public virtual bool isLeaf => false;

		/// <summary>
		/// 是否使用注释
		/// </summary>
		public virtual bool useComment => true;

		/// <summary>
		/// 是否使用注释
		/// </summary>
		public virtual int indentLevel => 1;

		#endregion

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangBlock(string name, string description = null) {
			this.name = name; this.description = description;
		}

		#region 修饰语块/子语块管理

		/// <summary>
		/// 添加子语块
		/// </summary>
		/// <param name="sub"></param>
		public void addSubBlock(LangBlock<T> sub) {
			sub.parent = this; subBlocks.Add(sub);
		}

		/// <summary>
		/// 插入子语块
		/// </summary>
		/// <param name="sub"></param>
		public void insertSubBlock(int index, LangBlock<T> sub) {
			sub.parent = this; subBlocks.Insert(index, sub);
		}

		/// <summary>
		/// 子语块数目
		/// </summary>
		/// <returns></returns>
		public int subBlockCount() { return subBlocks.Count; }

		/// <summary>
		/// 添加修饰语块
		/// </summary>
		/// <param name="deco"></param>
		public void addDecoBlock(LangBlock<T> deco) {
			deco.parent = this; decoBlocks.Add(deco);
		}

		/// <summary>
		/// 插入修饰语块
		/// </summary>
		/// <param name="deco"></param>
		public void insertDecoBlock(int index, LangBlock<T> deco) {
			deco.parent = this; decoBlocks.Insert(index, deco);
		}

		/// <summary>
		/// 修饰语块数目
		/// </summary>
		/// <returns></returns>
		public int decoBlockCount() { return decoBlocks.Count; }

		/// <summary>
		/// 获取自己在父语块中的索引
		/// </summary>
		/// <returns></returns>
		public int getIndexInParentBlock() {
			if (parent == null) return -1;
			var index = parent.subBlocks.IndexOf(this);
			if (index == -1)
				index = parent.decoBlocks.IndexOf(this);
			return index;
		}

		/// <summary>
		/// 添加下一个语块（同级）
		/// </summary>
		public void addNextBlock(LangBlock<T> sub) {
			var index = getIndexInParentBlock();
			if (index < 0) addSubBlock(sub);
			else parent.insertSubBlock(index + 1, sub);
		}

		#endregion

		#region 生调整代码

		/// <summary>
		/// 调整代码
		/// </summary>
		public void adjust() {
			if (adjusted) return;
			autoAdjust(); customAdjust();
			adjusted = true;
		}

		/// <summary>
		/// 自动调整
		/// </summary>
		protected virtual void autoAdjust() {
			if (useComment && !string.IsNullOrEmpty(description))
				setupComment();
		}

		/// <summary>
		/// 自定义调整（通过Language重载实现）
		/// </summary>
		void customAdjust() {
			language.adjustBlock(this);
		}

		/// <summary>
		/// 生成注释
		/// </summary>
		public virtual void setupComment() {
			insertDecoBlock(0, comment);
		}

		#endregion

		#region 生成代码

		/// <summary>
		/// 转化为代码
		/// </summary>
		/// <returns></returns>
		public override string genCode() {
			if (!rawMode) adjust();
			var code = genDecoBlockCode();
			code += language.genBlockCode(this);

			var subCode = genSubBlockCode(!isLeaf);
			if (isLeaf && subCode != "")
				subCode = "\r\n" + subCode;

			return code + (isLeaf ? subCode : 
				string.Format(blockFormat, subCode));
		}

		/// <summary>
		/// 生成子语块代码
		/// </summary>
		/// <returns></returns>
		string genSubBlockCode(bool useIndent = true) {
			var subCodes = new List<string>();
			for (int i = 0; i < subBlocks.Count; ++i)
				subCodes.Add(subBlocks[i].genCode());

			var subCode = string.Join(blockSpliter, subCodes);

			return useIndent ? language.genIndent(subCode, indentLevel) : subCode;
		}

		/// <summary>
		/// 生成修饰语块代码
		/// </summary>
		/// <returns></returns>
		string genDecoBlockCode() {
			var decoCode = "";
			foreach (var block in decoBlocks)
				decoCode += block.genCode() + decoSpliter;

			return decoCode;
		}

		#endregion
	}

	/// <summary>
	/// 文件
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class LangFile<T> : LangBlock<T> where T : Language<T>, new() {

		/// <summary>
		/// 块格式
		/// </summary>
		protected override string blockFormat => "{0}";

		/// <summary>
		/// 代码
		/// </summary>
		public override string code => "";

		/// <summary>
		/// 是否使用注释
		/// </summary>
		public override int indentLevel => 0;

		/// <summary>
		/// 是否使用注释
		/// </summary>
		public override bool useComment => false;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangFile(string name = null, string description = null) :
			base(name, description) { }
	}

	/// <summary>
	/// 类
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class LangClass<T> : LangBlock<T> where T : Language<T>, new() {

		/// <summary>
		/// 属性
		/// </summary>
		public List<string> inherits = new List<string>();
		public bool abstract_ = false;

		/// <summary>
		/// 格式
		/// </summary>
		protected override LangFormat format => null;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangClass(string name, string description = null,
			List<string> inherits = null, bool abstract_ = false) :
			base(name, description) {
			if (inherits != null) this.inherits = inherits;
			this.abstract_ = abstract_;
		}
		public LangClass(string name) : base(name) { }
		public LangClass(string name, string description = null,
			string[] inherits = null, bool abstract_ = false) :
			this(name, description, new List<string>(inherits), abstract_) { }
		public LangClass(string name, string description = null,
			string inherit = null, bool abstract_ = false) :
			base(name, description) {
			if (inherit != null) inherits.Add(inherit);
			this.abstract_ = abstract_;
		}

		/// <summary>
		/// 添加变量
		/// </summary>
		public LangVariable<T> addVar(string type, string name,
			object default_ = null, string description = null, bool isStatic = false,
			LangVariable<T>.Accessibility accessibility = LangVariable<T>.Accessibility.Public,
			bool code = false) {

			var defStr = language.var2Code(default_, code);
			var block = new LangVariable<T>(type, name, defStr,
				description, isStatic, accessibility);

			addSubBlock(block); return block;
		}

		/// <summary>
		/// 添加常量
		/// </summary>
		public LangConstant<T> addConst(string type, string name, object value, string description = null, 
			LangVariable<T>.Accessibility accessibility = LangVariable<T>.Accessibility.Public,
			bool code = false) {

			var defStr = language.var2Code(value, code);
			var block = new LangConstant<T>(type, name, defStr,
				description, accessibility);

			addSubBlock(block); return block;
		}
	}

	/// <summary>
	/// 枚举
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class LangEnum<T> : LangBlock<T> where T : Language<T>, new() {

		/// <summary>
		/// 格式
		/// </summary>
		protected override LangFormat format => language.enumFormat;

		/// <summary>
		/// 格式参数
		/// </summary>
		protected override object[] formatArgs => new object[] { name };

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangEnum(string name, string description = null) :
			base(name, description) { }

	}

	/// <summary>
	/// 枚举项
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class LangEnumItem<T> : LangBlock<T> where T : Language<T>, new() {

		/// <summary>
		/// 属性
		/// </summary>
		public int value;

		/// <summary>
		/// 格式
		/// </summary>
		protected override LangFormat format => language.enumItemFormat;

		/// <summary>
		/// 格式参数
		/// </summary>
		protected override object[] formatArgs =>
			new object[] { name, value, description };

		/// <summary>
		/// 是否为叶子块（没有子块）
		/// </summary>
		public override bool isLeaf => true;

		/// <summary>
		/// 使用注释
		/// </summary>
		public override bool useComment => false;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangEnumItem(string name, int value, string description = null) :
			base(name, description) { this.value = value; }

	}

	/// <summary>
	/// 成员
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class LangMember<T> : LangBlock<T> where T : Language<T>, new() {

		/// <summary>
		/// 可访问性
		/// </summary>
		public enum Accessibility {
			Public, Private, Protected, Default
		}

		/// <summary>
		/// 属性
		/// </summary>
		public Accessibility accessibility;
		public bool isStatic = false;
		public string type;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangMember(string type, string name,
			string description = null, bool isStatic = false,
			Accessibility accessibility = Accessibility.Public) :
			base(name, description) {
			this.type = type; this.isStatic = isStatic;
			this.accessibility = accessibility;
		}
		public LangMember(string name, 
			string description = null, bool isStatic = false,
			Accessibility accessibility = Accessibility.Public) :
			base(name, description) {
			this.isStatic = isStatic;
			this.accessibility = accessibility;
		}
	}

	/// <summary>
	/// 函数
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class LangFunction<T> : LangMember<T> where T : Language<T>, new() {

		/// <summary>
		/// 参数组
		/// </summary>
		public LangParamGroup<T> paramGroup = new LangParamGroup<T>(true);

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangFunction(string type, string name, 
			string description = null, bool isStatic = false,
			Accessibility accessibility = Accessibility.Public) :
			base(type, name, description, isStatic, accessibility) { }
	}

	/// <summary>
	/// 变量
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class LangVariable<T> : LangMember<T> where T : Language<T>, new() {

		/// <summary>
		/// 属性
		/// </summary>
		string defaultVal = null;
		LangElement<T> defaultObj = null;

		/// <summary>
		/// 默认值代码
		/// </summary>
		public string defaultCode => defaultObj?.genCode() ?? defaultVal;

		/// <summary>
		/// 是否为叶子块（没有子块）
		/// </summary>
		public override bool isLeaf => true;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangVariable(string type, string name, string default_ = null,
			string description = null, bool isStatic = false,
			Accessibility accessibility = Accessibility.Public) :
			base(type, name, description, isStatic, accessibility) {

			defaultVal = default_;
		}
		public LangVariable(string type, string name, 
			LangElement<T> default_, string description = null, 
			bool isStatic = false, Accessibility accessibility = Accessibility.Public) :
			base(type, name, description, isStatic, accessibility) {

			defaultObj = default_;
			//this.defaultCode = default_?.genCode();
		}
	}

	/// <summary>
	/// 常量
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class LangConstant<T> : LangVariable<T> where T : Language<T>, new() {

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangConstant(string type, string name,
			string value, string description = null,
			Accessibility accessibility = Accessibility.Public) :
			base(type, name, value, description, false, accessibility) { }
		public LangConstant(string type, string name,
			LangElement<T> value, string description = null,
			Accessibility accessibility = Accessibility.Public) :
			base(type, name, value, description, false, accessibility) { }

	}

	/// <summary>
	/// 注释
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class LangComment<T> : LangBlock<T> where T : Language<T>, new() {

		/// <summary>
		/// 块格式
		/// </summary>
		protected override LangFormat format => language.commentFormat;

		/// <summary>
		/// 格式参数
		/// </summary>
		protected override object[] formatArgs => new object[] { name };

		/// <summary>
		/// 是否为叶子块（没有子块）
		/// </summary>
		public override bool isLeaf => true;

		/// <summary>
		/// 使用注释
		/// </summary>
		public override bool useComment => false;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangComment(string name) : base(name) { }
	}

	/// <summary>
	/// 区域
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class LangRegion<T> : LangBlock<T> where T : Language<T>, new() {

		/// <summary>
		/// 格式
		/// </summary>
		protected override LangFormat format => language.regionFormat;

		/// <summary>
		/// 格式参数
		/// </summary>
		protected override object[] formatArgs => new object[] { name };

		/// <summary>
		/// 缩进等级
		/// </summary>
		public override int indentLevel => 0;

		/// <summary>
		/// 使用注释
		/// </summary>
		public override bool useComment => false;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangRegion(string name) : base(name) { }
	}

}
