using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExermonDevManager.Scripts.CodeGen {

	using Utils;
	using Data;

	#region 代码块结构

	/// <summary>
	/// 代码块
	/// </summary>
	public class Block {

		/// <summary>
		/// 生成器
		/// </summary>
		protected CodeGenerator generator = null;

		/// <summary>
		/// 子块
		/// </summary>
		protected List<Block> subBlocks = new List<Block>();

		/// <summary>
		/// 是否叶子块
		/// </summary>
		public virtual bool isLeaf => false;

		/// <summary>
		/// 是否为空
		/// </summary>
		/// <returns></returns>
		public bool isEmpty() { return string.IsNullOrEmpty(doGenCode()); }

		/// <summary>
		/// 添加参数（子类重载实现）
		/// </summary>
		/// <param name="index">参数索引</param>
		/// <param name="arg">参数内容</param>
		public virtual void addArg(int index, string arg) { }

		/// <summary>
		/// 增加块
		/// </summary>
		/// <param name="block"></param>
		public void addBlock(Block block) {
			if (!isLeaf) subBlocks.Add(block);
		}

		/// <summary>
		/// 配置生成器
		/// </summary>
		/// <param name="generator"></param>
		public void setupGenerator(CodeGenerator generator) {
			this.generator = generator;
			foreach (var block in subBlocks)
				block.setupGenerator(generator);
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		/// <returns></returns>
		protected virtual string doGenCode() { return genSubCode(); }

		/// <summary>
		/// 生成代码并同步到生成器
		/// </summary>
		/// <param name="sync">是否同步到生成器</param>
		/// <returns></returns>
		public string genCode(bool sync = true) {
			var code = doGenCode();
			if (sync && isLeaf) generator.addCode(code);
			return code;
		}

		/// <summary>
		/// 生成子块代码
		/// </summary>
		/// <returns></returns>
		protected string genSubCode() {
			var code = "";
			if (isLeaf) return code;

			foreach (var block in subBlocks)
				code += block.genCode();

			return code;
		}
	}

	/// <summary>
	/// 纯代码块
	/// </summary>
	public class CodeBlock : Block {

		/// <summary>
		/// 代码
		/// </summary>
		public string code = "";

		/// <summary>
		/// 是否叶子块
		/// </summary>
		public override bool isLeaf => true;

		/// <summary>
		/// 构造函数
		/// </summary>
		public CodeBlock() { }
		public CodeBlock(string code) { this.code = code; }

		/// <summary>
		/// 生成代码
		/// </summary>
		/// <returns></returns>
		protected override string doGenCode() { return code; }
	}

	/// <summary>
	/// 对象块
	/// </summary>
	public abstract class ObjectBlock : Block {

		/// <summary>
		/// 属性
		/// </summary>
		protected List<string> attrs = new List<string>();

		/// <summary>
		/// 数据
		/// </summary>
		public object data = null;

		/// <summary>
		/// 增加属性
		/// </summary>
		/// <param name="attr"></param>
		public void addAttr(string attr) {
			attrs.Add(attr);
		}

		/// <summary>
		/// 获取值
		/// </summary>
		/// <returns></returns>
		protected object getValue(int index = 0) {
			if (data == null) data = generator.data;
			if (data == null) return null;

			var attr = attrs[index];
			var type = data.GetType();
			var member = type.GetMember(attr, ReflectionUtils.DefaultFlag)[0];

			switch (member.MemberType) {
				case MemberTypes.Property:
					return (member as PropertyInfo).GetValue(data);
				case MemberTypes.Field:
					return (member as FieldInfo).GetValue(data);
				case MemberTypes.Method:
					return (member as MethodInfo).Invoke(data,
						ReflectionUtils.DefaultFlag, null, null, null);
				default:
					return generator.getData(attr);
			}
		}
	}

	/// <summary>
	/// 变量块
	/// </summary>
	public class VarBlock : ObjectBlock {

		/// <summary>
		/// 是否叶子块
		/// </summary>
		public override bool isLeaf => true;

		/// <summary>
		/// 构造函数
		/// </summary>
		public VarBlock() { addAttr(""); }

		/// <summary>
		/// 获取属性
		/// </summary>
		/// <returns></returns>
		public string getAttr() {
			return attrs[0];
		}

		/// <summary>
		/// 设置属性
		/// </summary>
		/// <param name="attr"></param>
		public void setAttr(string attr) {
			attrs[0] = attr;
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		/// <returns></returns>
		protected override string doGenCode() {
			return getValue()?.ToString();
		}
	}

	/// <summary>
	/// 条件块
	/// </summary>
	public class CondBlock : ObjectBlock {

		/// <summary>
		/// 是否存在Else块
		/// </summary>
		public bool hasElse = false;

		/// <summary>
		/// 添加分支块
		/// </summary>
		/// <param name="block"></param>
		public void addCondition(string attr) {
			addBlock(new Block()); addAttr(attr);
		}

		/// <summary>
		/// 添加Else块
		/// </summary>
		public void addElse() {
			addBlock(new Block()); hasElse = true;
		}

		/// <summary>
		/// 添加条件块（往最后的条件）
		/// </summary>
		/// <param name="block"></param>
		public void addCondBlock(Block block) {
			subBlocks[subBlocks.Count - 1].addBlock(block);
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		/// <returns></returns>
		protected override string doGenCode() {
			for (int i = 0; i < attrs.Count; ++i)
				if (isPositive(i)) return getCondCode(i);

			return getElseCode();
		}

		/// <summary>
		/// 获取条件代码
		/// </summary>
		/// <returns></returns>
		string getCondCode(int index = 0) {
			return subBlocks[index].genCode();
		}

		/// <summary>
		/// 获取Else代码
		/// </summary>
		/// <returns></returns>
		string getElseCode() {
			if (!hasElse) return "";
			return subBlocks[subBlocks.Count - 1].genCode();
		}

		/// <summary>
		/// 条件是否满足
		/// </summary>
		/// <returns></returns>
		bool isPositive(int index) {
			var cond = getValue(index);
			var type = cond?.GetType();

			if (type == typeof(bool)) return (bool)cond;
			if (type == typeof(string))
				return !string.IsNullOrEmpty((string)cond);

			return Convert.ToBoolean(cond);
		}
	}
	
	/// <summary>
	/// 标签块
	/// </summary>
	public class TagBlock : Block {

		/// <summary>
		/// 构造函数
		/// </summary>
		public TagBlock() {
			subBlocks.Add(new Block());
			subBlocks.Add(new Block());
		}

		/// <summary>
		/// 添加键块
		/// </summary>
		/// <param name="block"></param>
		public void addKeyBlock(Block block) {
			var kBlock = subBlocks[0] as Block;
			kBlock.addBlock(block);
		}

		/// <summary>
		/// 添加值块
		/// </summary>
		/// <param name="block"></param>
		public void addValueBlock(Block block) {
			var kBlock = subBlocks[1] as Block;
			kBlock.addBlock(block);
		}

		/// <summary>
		/// 获取键值
		/// </summary>
		/// <returns></returns>
		public string getKey() {
			return subBlocks[0].genCode(false);
		}

		/// <summary>
		/// 获取值值
		/// </summary>
		/// <returns></returns>
		public string getValue() {
			return subBlocks[1].genCode(false);
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		protected override string doGenCode() {
			generator?.setConfig(getKey(), getValue());
			return "";
		}
	}

	/// <summary>
	/// 循环块
	/// </summary>
	public class LoopBlock : VarBlock {
		
		/// <summary>
		/// 数据列表
		/// </summary>
		public ICollection dataList = null;

		/// <summary>
		/// 分隔符
		/// </summary>
		public string spliter = "";

		/// <summary>
		/// 添加参数
		/// </summary>
		public override void addArg(int index, string arg) {
			spliter = arg;
		}

		/// <summary>
		/// 获取数据列表
		/// </summary>
		void getDataList() {
			dataList = getValue() as ICollection;
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		/// <returns></returns>
		protected override string doGenCode() {
			if (dataList == null) getDataList();
			if (dataList == null) return null;

			var codes = new List<string>();
			foreach(var item in dataList) 
				codes.Add(genSingleCode(item));

			return string.Join(spliter, codes);
		}

		/// <summary>
		/// 生成单个块的代码
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		string genSingleCode(object item) {
			var code = "";
			foreach (var block in subBlocks) {
				var bType = block.GetType();
				var objBlock = (block as ObjectBlock);

				if (objBlock != null) objBlock.data = item;

				code += block.genCode();
			}
			return code;
		}
	}

	#endregion

	#region 分析器

	/// <summary>
	/// 分析器基类
	/// </summary>
	public abstract class Parser {

		/// <summary>
		/// 模板分析器
		/// </summary>
		protected CodeTemplate template;

		/// <summary>
		/// 输出的块
		/// </summary>
		/// <returns></returns>
		public abstract Block output();

		/// <summary>
		/// 配置模板对象
		/// </summary>
		/// <param name="template"></param>
		public void setup(CodeTemplate template) {
			this.template = template;
		}

		/// <summary>
		/// 分析
		/// </summary>
		/// <param name="template"></param>
		public void parse(CodeTemplate template) {
			setup(template); parse();
		}

		/// <summary>
		/// 获得当前字符
		/// </summary>
		/// <returns></returns>
		public char getChar() { return template.getChar(); }
		public string getChar(int cnt) {
			var res = getChar().ToString();
			for (int i = 1; i < cnt; ++i)
				res += nextChar();
			return res;
		}

		/// <summary>
		/// 切换并获取下一字符
		/// </summary>
		/// <returns></returns>
		public char nextChar() { return template.nextChar(); }
		public string nextChar(int cnt) {
			nextChar(); return getChar(cnt);
		}

		/// <summary>
		/// 是否内容结束
		/// </summary>
		/// <returns></returns>
		public bool isContentEnd() { return template.isEnd(); }

		/// <summary>
		/// 是否块的结束
		/// </summary>
		/// <returns></returns>
		public virtual bool isEnd() { return isContentEnd(); }
		
		/// <summary>
		/// 分析
		/// </summary>
		public void parse() {
			while (!isEnd()) {
				parseChar(getChar());
				nextChar();
			}
			onParseEnd();
		}

		/// <summary>
		/// 分析单个字符
		/// </summary>
		/// <param name="c"></param>
		public abstract void parseChar(char c);

		/// <summary>
		/// 分析结束回调
		/// </summary>
		protected virtual void onParseEnd() { }
	}

	/// <summary>
	/// 分析器
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class Parser<T> : Parser where T : Block, new() {

		/// <summary>
		/// 输出的块
		/// </summary>
		public T block = new T();

		/// <summary>
		/// 临时代码
		/// </summary>
		protected string tmpCode = "";

		/// <summary>
		/// 添加纯代码
		/// </summary>
		/// <param name="c"></param>
		protected virtual void appendCode(char c) { tmpCode += c; }
		protected virtual void appendCode(string str) { tmpCode += str; }

		/// <summary>
		/// 输出
		/// </summary>
		/// <returns></returns>
		public override Block output() { return block; }

		/// <summary>
		/// 分析单个字符
		/// </summary>
		public override void parseChar(char c) {
			switch (c) {
				case '\\': nextChar(); parseCode(); break;
				case '$': nextChar(); parseBlock(); break;
				default: parseCode(); break;
			}
		}

		/// <summary>
		/// 分析特殊功能块
		/// </summary>
		protected virtual void parseBlock() {
			char c = getChar();
			switch (c) {
				case '[': // TagBlock
					parseBlock<TagParser>(); break;
				case '{': // VarBlock
					parseBlock<VarParser>(); break;
				case '|': // CondBlock
					parseBlock<CondParser>(); break;
				case '<': // LoopBlock
					parseBlock<LoopParser>(); break;
				case '(': // Param
					break;
				default: parseCode(); break;
			}
		}

		/// <summary>
		/// 分析块
		/// </summary>
		/// <typeparam name="B"></typeparam>
		protected void parseBlock<P>() where P : Parser, new() {
			var parser = new P();
			parser.parse(template);
			addBlock(parser.output());
		}

		/// <summary>
		/// 分析纯代码
		/// </summary>
		protected virtual void parseCode() {
			parseBlock<CodeParser>();
		}

		/// <summary>
		/// 添加代码块
		/// </summary>
		/// <param name="code"></param>
		protected virtual void addBlock(Block block) {
			this.block.addBlock(block);
		}

	}

	/// <summary>
	/// 根分析器
	/// </summary>
	public class RootParser : Parser<Block> { }

	/// <summary>
	/// 纯代码分析器
	/// </summary>
	public class CodeParser : Parser<CodeBlock> {

		/// <summary>
		/// 结束字符
		/// </summary>
		char endChar = '$';

		/// <summary>
		/// 构造函数
		/// </summary>
		public CodeParser() { }
		public CodeParser(char endChar) { this.endChar = endChar; }

		/// <summary>
		/// 是否块结束
		/// </summary>
		/// <returns></returns>
		public override bool isEnd() {
			return getChar() == endChar;
		}

		/// <summary>
		/// 分析单个字符
		/// </summary>
		public override void parseChar(char c) {
			appendCode(c);
		}

		/// <summary>
		/// 分析结束回调
		/// </summary>
		protected override void onParseEnd() {
			block.code = tmpCode;
		}
	}

	/// <summary>
	/// 支持Wrapper的分析器
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class WrapperParser<T> : Parser<T> where T: Block, new() {

		/// <summary>
		/// 包装字符
		/// </summary>
		protected abstract string wrapperStr { get; }
		protected char lWChar => wrapperStr[0]; // left wrapper char
		protected char rWChar => wrapperStr[1]; // right wrapper char
		
		/// <summary>
		/// 深度
		/// </summary>
		int depth = 0;

		/// <summary>
		/// 是否块结束
		/// </summary>
		/// <returns></returns>
		public override bool isEnd() {
			return getChar() == rWChar && depth <= 0;
		}

		/// <summary>
		/// 处理纯代码
		/// </summary>
		/// <param name="c"></param>
		protected override void parseCode() {
			if (getChar() == lWChar) depth++;
			if (getChar() == rWChar) depth--;
			base.parseCode();
		}

	}

	/// <summary>
	/// 变量块分析器
	/// </summary>
	public class VarParser : WrapperParser<VarBlock> {

		/// <summary>
		/// 包装字符
		/// </summary>
		protected override string wrapperStr => "{}";
		
		/// <summary>
		/// 分析单个字符
		/// </summary>
		public override void parseChar(char c) {
			appendCode(c);
		}

		/// <summary>
		/// 分析结束回调
		/// </summary>
		protected override void onParseEnd() {
			block.setAttr(tmpCode);
		}
	}

	/// <summary>
	/// 条件块分析器
	/// </summary>
	public class CondParser : WrapperParser<CondBlock> {

		/// <summary>
		/// 包装字符
		/// </summary>
		protected override string wrapperStr => "||";
		
		/// <summary>
		/// 处理字符
		/// </summary>
		/// <param name="c"></param>
		public override void parseChar(char c) {
			parseCond();
			switch (c) {
				case '$': parseCond(); break;
				default: base.parseChar(c); break;
			}
		}

		/// <summary>
		/// 分析条件
		/// </summary>
		void parseCond() {
			if (getChar(2) == "$:") // else
				block.addElse();
			else {
				var parser = new CodeParser('?');
				parser.parse(template);

				var attr = parser.block.genCode(false);
				block.addCondition(attr);
			}
		}

		/// <summary>
		/// 添加代码块
		/// </summary>
		/// <param name="code"></param>
		protected override void addBlock(Block block) {
			this.block.addCondBlock(block);
		}
	}

	/// <summary>
	/// 纯代码分析器
	/// </summary>
	public class TagParser : WrapperParser<TagBlock> {

		/// <summary>
		/// 包装字符
		/// </summary>
		protected override string wrapperStr => "[]";

		/// <summary>
		/// 等号标志
		/// </summary>
		bool flag = false;
		
		/// <summary>
		/// 处理字符
		/// </summary>
		/// <param name="c"></param>
		public override void parseChar(char c) {
			switch (c) {
				case '=': flag = true; break;
				default: base.parseChar(c); break;
			}
		}

		/// <summary>
		/// 添加代码块
		/// </summary>
		/// <param name="code"></param>
		protected override void addBlock(Block block) {
			if (flag) this.block.addValueBlock(block);
			else this.block.addKeyBlock(block);
		}
	}

	/// <summary>
	/// 循环分析器
	/// </summary>
	public class LoopParser : WrapperParser<LoopBlock> {

		/// <summary>
		/// 包装字符
		/// </summary>
		protected override string wrapperStr => "<>";

		/// <summary>
		/// 等号标志
		/// </summary>
		bool flag = false;
		
		/// <summary>
		/// 处理字符
		/// </summary>
		/// <param name="c"></param>
		public override void parseChar(char c) {
			parseVar(); base.parseChar(c);
		}

		/// <summary>
		/// 分析条件
		/// </summary>
		void parseVar() {
			var parser = new CodeParser(':');
			parser.parse(template);

			block.setAttr(parser.block.genCode(false));
		}

	}

	#endregion

	/// <summary>
	/// 代码模板类
	/// </summary>
	public class CodeTemplate {

		/// <summary>
		/// 属性
		/// </summary>
		string path; // 路径
		string content; // 内容

		int pointer = 0; // 指针

		/// <summary>
		/// 是否分析过
		/// </summary>
		public bool isParsed = false;

		/// <summary>
		/// 分析器
		/// </summary>
		RootParser parser = new RootParser();

		/// <summary>
		/// 构造函数
		/// </summary>
		public CodeTemplate(string name) {
			path = TemplateSystem.RootPath + name; load();
		}

		/// <summary>
		/// 读取文本
		/// </summary>
		void load() {
			content = StorageManager.loadDataFromFile(path);
		}

		/// <summary>
		/// 获得当前字符
		/// </summary>
		/// <returns></returns>
		public char getChar() {
			if (content == null) return '\0';
			if (pointer >= content.Length) return '\0';
			return content[pointer];
		}

		/// <summary>
		/// 切换并获取下一个字符
		/// </summary>
		/// <returns></returns>
		public char nextChar() {
			pointer++; return getChar();
		}

		/// <summary>
		/// 指针到达内容末尾
		/// </summary>
		/// <returns></returns>
		public bool isEnd() {
			return pointer >= content.Length;
		}

		/// <summary>
		/// 分析
		/// </summary>
		public void parse() {
			if (isParsed) return;
			parser.parse(this);
			isParsed = true;
		}

		/// <summary>
		/// 结果
		/// </summary>
		public Block output() {
			return parser.output();
		}

	}

	/// <summary>
	/// 代码生成器
	/// </summary>
	public class CodeGenerator {

		/// <summary>
		/// 生成配置
		/// </summary>
		Dictionary<string, string> config = new Dictionary<string, string>();

		/// <summary>
		/// 模板
		/// </summary>
		CodeTemplate template;

		/// <summary>
		/// 原始数据
		/// </summary>
		public object data = null;

		/// <summary>
		/// 全局数据字典（对原始数据的补充）
		/// </summary>
		Dictionary<string, object> globalData = new Dictionary<string, object>();

		/// <summary>
		/// 当前生成代码
		/// </summary>
		string code = "";

		/// <summary>
		/// 构造函数
		/// </summary>
		public CodeGenerator(CodeTemplate template, object data = null) {
			this.template = template; this.data = data;
		}

		#region 数据相关

		/// <summary>
		/// 添加数据
		/// </summary>
		/// <param name="key"></param>
		/// <param name="data"></param>
		public void addData(string key, object data) {
			globalData[key] = data;
		}

		/// <summary>
		/// 获取数据
		/// </summary>
		/// <param name="key"></param>
		/// <param name="data"></param>
		public object getData(string key) {
			return globalData.ContainsKey(key) ? 
				globalData[key] : null;
		}

		#endregion

		#region 配置相关

		/// <summary>
		/// 获取配置内容
		/// </summary>
		/// <param name="key">键</param>
		/// <param name="default_">默认值</param>
		/// <returns></returns>
		public string getConfig(string key, string default_ = "") {
			if (config.ContainsKey(key)) return config[key];
			return default_;
		}

		/// <summary>
		/// 获取配置内容
		/// </summary>
		/// <param name="key">键</param>
		/// <param name="value">设定值</param>
		/// <returns></returns>
		public void setConfig(string key, string value) {
			//var oldVal = getConfig(key);
			config[key] = value;
			//if (callbacks.ContainsKey(key))
			//	callbacks[key]?.Invoke(oldVal, value);
		}

		/// <summary>
		/// 语言
		/// </summary>
		/// <returns></returns>
		public string language() { return getConfig("language"); }

		/// <summary>
		/// 生成路径
		/// </summary>
		/// <returns></returns>
		public string genPath() { return getConfig("gen_path"); }

		//#region 配置监听

		///// <summary>
		///// 配置改变回调字典
		///// </summary>
		//Dictionary<string, Action<string, string>> callbacks =
		//	new Dictionary<string, Action<string, string>>();

		///// <summary>
		///// 生成路径改变回调
		///// </summary>
		//void onGenPathChanged(string old, string new_) {
		//	if (!string.IsNullOrEmpty(old) && !string.IsNullOrEmpty(new_)) {
		//		StorageManager.saveDataIntoFile(code, old);
		//		code = "";
		//	}
		//}

		//#endregion

		#endregion

		#region 生成相关

		/// <summary>
		/// 代码字典（文件路径-代码映射）
		/// </summary>
		public Dictionary<string, string> codes = new Dictionary<string, string>();

		/// <summary>
		/// 添加生成的代码
		/// </summary>
		/// <param name="code"></param>
		public void addCode(string code) {
			var path = genPath();
			if (string.IsNullOrEmpty(path)) return;
			if (codes.ContainsKey(path))
				codes[path] += code;
			else
				codes[path] = code;
		}

		/// <summary>
		/// 生成
		/// </summary>
		public void generate() {
			var block = template.output();
			block.setupGenerator(this);
			block.genCode();
		}

		/// <summary>
		/// 保存到文件
		/// </summary>
		public void save() {
			foreach(var item in codes) {
				string path = item.Key, code = item.Value;
				StorageManager.saveDataIntoFile(code, path);
			}
		}

		#endregion

	}

	/// <summary>
	/// 模板系统
	/// </summary>
	public static class TemplateSystem {

		/// <summary>
		/// 路径常量定义
		/// </summary>
		public static readonly string RootPath = "./templates/";

		/// <summary>
		/// 文件名格式
		/// </summary>
		static readonly string FileNameFormat = "{0}s.txt";

		/// <summary>
		/// 类型模板映射
		/// </summary>
		static Dictionary<Type, CodeTemplate> dataTemplates = 
			new Dictionary<Type, CodeTemplate>();

		/// <summary>
		/// 初始化
		/// </summary>
		public static void initialize() {
			addTemplate<ReqResInterface>();
		}

		/// <summary>
		/// 添加模板
		/// </summary>
		/// <typeparam name="T">对应类型</typeparam>
		/// <param name="name">模板名称</param>
		public static void addTemplate<T>(string name = null) where T : BaseData {
			addTemplate(typeof(T), name);
		}
		/// <param name="type">类型</param>
		public static void addTemplate(Type type, string name = null) {
			if (string.IsNullOrEmpty(name)) 
				name = string.Format(FileNameFormat, type.Name);
			dataTemplates.Add(type, new CodeTemplate(name));
		}

		/// <summary>
		/// 获取代码模板
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static CodeTemplate getTemplate<T>() where T : ControlData {
			return getTemplate(typeof(T));
		}
		public static CodeTemplate getTemplate(Type type) {
			if (dataTemplates.ContainsKey(type))
				return dataTemplates[type];
			return null;
		}

		///// <summary>
		///// 创建生成器
		///// </summary>
		///// <returns></returns>
		//public static CodeGenerator createGenerator<T>() where T : ControlData {
		//	return new CodeGenerator(getTemplate<T>());
		//}
		//public static CodeGenerator createGenerator(Type type) {
		//	return new CodeGenerator(getTemplate(type));
		//}
	}
}
