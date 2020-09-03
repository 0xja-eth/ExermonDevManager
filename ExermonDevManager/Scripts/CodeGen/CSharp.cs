using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExermonDevManager.Scripts.CodeGen {

	/// <summary>
	/// 属性类
	/// </summary>
	public class LangProperty : LangVariable<CSharp> {

		/// <summary>
		/// get, set 函数代码
		/// 为null则不生成对应函数
		/// 为空字符串则不生成函数内容（即 get; set; 格式）
		/// </summary>
		public string getCode, setCode;

		/// <summary>
		/// get, set 函数可访问性
		/// </summary>
		public Accessibility getAccess, setAccess;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangProperty(string type, string name, 
			string default_ = null, string description = null, 
			Accessibility accessibility = Accessibility.Public,

			string getCode = "", string setCode = "",
			Accessibility getAccess = Accessibility.Default,
			Accessibility setAccess = Accessibility.Default) :
			
			base(type, name, default_, description, false, accessibility) {

			this.getCode = getCode; this.getAccess = getAccess;
			this.setCode = setCode; this.setAccess = setAccess;
		}
	}

	/// <summary>
	/// 属性类
	/// </summary>
	public class LangAttribute : LangBlock<CSharp> {

		/// <summary>
		/// 参数组
		/// </summary>
		public LangParamGroup<CSharp> paramGroup = new LangParamGroup<CSharp>();

		/// <summary>
		/// 是否为叶子块（没有子块）
		/// </summary>
		public override bool isLeaf => true;

		/// <summary>
		/// 构造函数
		/// </summary>
		public LangAttribute(string name) : base(name) { }
	}

	/// <summary>
	/// C#
	/// </summary>
	public class CSharp : Language<CSharp> {

		/// <summary>
		/// 语言格式设定
		/// </summary>
		public override LangFormat blockFormat => new LangFormat("{0}");

		// 枚举相关
		public override LangFormat enumFormat => new LangFormat("public enum {0} ");
		public override LangFormat enumItemFormat => new LangFormat("{0} = {1}, // {2}");

		// 注释相关
		public override LangFormat commentFormat => new LangFormat(
			"/// <summary>\r\n" + 
			"/// {0}\r\n" + 
			"/// </summary>"
		);
		public override LangFormat regionFormat => new LangFormat(
			"#region {0}", "\r\n\r\n{0}\r\n\r\n#endregion"
		);

		// 通用块格式
		public override string generalBlockFormat => "{{\r\n{0}\r\n}}";

		// 表示为空
		public override string nullCode => "null";

		#region 代码生成

		/// <summary>
		/// 配置函数注册
		/// </summary>
		protected override void setupFuncRegister() {
			base.setupFuncRegister();
			registerGenCodeFunc<LangProperty>(genPropertyCode);
			registerGenCodeFunc<LangAttribute>(genAttributeCode);
		}

		#region 自定义生成

		#region 重载内置语块

		/// <summary>
		/// 生成类代码
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		protected override string genClassCode(LangClass<CSharp> b) {
			// public [abstract ]class {$name}[ : {$inherits}] 
			var format = b.abstract_ ?
				"public abstract class {0} " : "public class {0} ";
			var code0 = b.name; // 第 0 处的代码

			var inheritCodes = string.Join(paramSpliter, b.inherits);
			if (inheritCodes != "") code0 += " : " + inheritCodes;

			return string.Format(format, code0);
		}

		/// <summary>
		/// 生成成员描述符代码
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		string genMemberDescriptorCode(
			LangMember<CSharp> b, params string[] appends) {

			var descs = new List<string>();

			descs.Add(genAccessCode(b.accessibility));

			if (b.isStatic) descs.Add("static");

			descs.AddRange(appends);
			descs.Add(b.type); descs.Add(b.name);

			return genMemberDescriptorCode(descs.ToArray());
		}
		string genMemberDescriptorCode(params string[] descriptors) {
			var descs = new List<string>();
			foreach (var desc in descriptors) 
				if (!string.IsNullOrEmpty(desc)) descs.Add(desc);

			return string.Join(" ", descs);
		}

		/// <summary>
		/// 生成函数代码
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		protected override string genFuncCode(LangFunction<CSharp> b) {
			// {$access} {$type} {$name}({$params}) 
			var format = "{0}({1}) ";

			var descCode = genMemberDescriptorCode(b);
			var paramsCode = b.paramGroup.genCode();

			return string.Format(format, descCode, paramsCode);
		}

		/// <summary>
		/// 生成变量
		/// </summary>
		protected override string genVarCode(LangVariable<CSharp> b) {
			// {$access} {$type} {$name}[ = {$default}]; 
			var format = string.IsNullOrEmpty
				(b.default_) ? "{0};" : "{0} = {1};";

			var descCode = genMemberDescriptorCode(b);

			return string.Format(format, descCode, b.default_);
		}

		/// <summary>
		/// 生成常量
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		protected override string genConstCode(LangConstant<CSharp> b) {
			// {$access} const {$type} {$name} = {$value}; 
			var format = "{0} = {1};";

			var descCode = genMemberDescriptorCode(b, "const");

			return string.Format(format, descCode, b.default_);
		}

		#endregion

		#region 自定义语块

		/// <summary>
		/// 生成属性
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		string genPropertyCode(LangProperty b) {
			// {$access} {$type} {$name} { 
			//      [{$getAccess} get[{{$getCode}}][;]]
			//      [{$setAccess} set[{{$setCode}}][;]]
			// }[ = {$value};] 
			var format = "{0} {{ {1}}}";
			if (!string.IsNullOrEmpty(b.default_))
				format += " = {2};";
		
			var descCode = genMemberDescriptorCode(b);

			var getCode = genPropertyInnerCode(b.getAccess, b.getCode, "get");
			var setCode = genPropertyInnerCode(b.setAccess, b.setCode, "set");
			var innerCode = getCode + setCode;

			return string.Format(format, descCode, innerCode, b.default_);
		}

		/// <summary>
		/// 生成属性内置函数
		/// </summary>
		string genPropertyInnerCode(LangMember<CSharp>.Accessibility access, 
			string code, string method) {
			if (code == null) return "";

			string format = code == "" ? "{0}; " : 
				"{0} {{\r\n{1}\r\n}}\r\n";

			var accessCode = genAccessCode(access);
			var descCode = genMemberDescriptorCode(accessCode, method);

			return string.Format(format, descCode, code);
		}

		/// <summary>
		/// 生成属性
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		string genAttributeCode(LangAttribute b) {
			// \[{$name}[({$params)]\] 
			var format = "[{0}{1}]";
			var paramsCode = b.paramGroup.genCode();
			if (paramsCode != "")
				paramsCode = "(" + paramsCode + ")";

			return string.Format(format, b.name, paramsCode);
		}

		#endregion

		/// <summary>
		/// 生成访问控制代码
		/// </summary>
		/// <param name="accessibility"></param>
		/// <returns></returns>
		string genAccessCode(LangMember<CSharp>.Accessibility accessibility) {
			switch (accessibility) {
				case LangMember<CSharp>.Accessibility.Private:
					return "private";
				case LangMember<CSharp>.Accessibility.Protected:
					return "protected";
				case LangMember<CSharp>.Accessibility.Public:
					return "public";
				default:
					return "";
			}
		}

		#endregion

		#region 参数生成

		/// <summary>
		/// 生成参数项代码
		/// </summary>
		public override string genParamItemCode(
			LangParamItem<CSharp> item, bool ignoreKey = false) {

			if (item.type != null) { // 声明
				var format = item.default_ == null ? "{0} {1}" : "{0} {1} = {2}";
				return string.Format(format, item.type, item.name, item.default_);

			} else if (item.value != null) { // 调用
				var format = ignoreKey ? "{0}" : "{0}: {1}";
				return string.Format(format, item.name, item.value);
			}

			return "";
		}

		#endregion

		#endregion

		#region 工具函数

		/// <summary>
		/// 转化为代码（字符串代码）
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		protected override string bool2Code(bool val) {
			return val ? "true" : "false";
		}

		#endregion

	}
}
