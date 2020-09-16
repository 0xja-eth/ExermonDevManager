using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExermonDevManager.Scripts.CodeGen {

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
		/// 父分析器
		/// </summary>
		protected Parser parent;

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
		public void parse(Parser parent) {
			this.parent = parent;
			parse(parent.template);
		}
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
		/// 切换并获取上一字符
		/// </summary>
		/// <returns></returns>
		public char prevChar() { return template.prevChar(); }

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
			onParseStart();
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
		/// 分析开始回调
		/// </summary>
		protected virtual void onParseStart() { }

		/// <summary>
		/// 分析结束回调
		/// </summary>
		protected virtual void onParseEnd() { }

		/// <summary>
		/// 添加代码块
		/// </summary>
		/// <param name="code"></param>
		public abstract void addBlock(Block block);
		public void addBlock<T>() where T : Block, new() {
			addBlock(new T());
		}
	}

	/// <summary>
	/// 分析器
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class Parser<T> : Parser where T : Block {

		/// <summary>
		/// 输出的块
		/// </summary>
		public T block;

		/// <summary>
		/// 参数索引
		/// </summary>
		int argIndex = 0;

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
		/// 默认块
		/// </summary>
		/// <returns></returns>
		protected virtual T defaultBlock() {
			var type = typeof(T);
			if (type.IsAbstract) return null;
			return Activator.CreateInstance(type) as T;
		}

		/// <summary>
		/// 分析开始回调
		/// </summary>
		protected override void onParseStart() {
			setBlock(defaultBlock());
		}

		/// <summary>
		/// 设置块
		/// </summary>
		/// <param name="block"></param>
		protected void setBlock(T block) {
			this.block = block;
			if (block != null) parent?.addBlock(block);
		}

		/// <summary>
		/// 分析单个字符
		/// </summary>
		public override void parseChar(char c) {
			switch (c) {
				case '\\': processBackslash(); break;
				case '$': nextChar(); parseBlock(); break;
				default: parseCode(); break;
			}
		}

		/// <summary>
		/// 处理反斜杠
		/// </summary>
		void processBackslash() {
			//if (nextChar() == '\r' && nextChar() == '\n')
			// 忽略之后的所有空白字符
			while (char.IsWhiteSpace(nextChar())) ;
			parseCode();
		}

		/// <summary>
		/// 分析特殊功能块
		/// </summary>
		void parseBlock() {
			char c = getChar(); nextChar();
			switch (c) {
				case '[': // TagBlock
					parseBlock<TagParser>(); break;
				case '{': // ObjectBlock
					parseBlock<ObjectParser>(); break;
				case '<': // LoopBlock
					parseBlock<LoopParser>(); break;
				case '$': // 注释
					parseBlock<CommentParser>(); break;
				case '%': // 嵌入
					parseBlock<EmbedParser>(); break;
				case '!': // 取消该块
					addBlock<CancelFlag>(); break;
				case '(': // Param
					processParam(); break;
				default:
					parseSpecialBlock(c); break;
			}
		}

		/// <summary>
		/// 分析特殊块（子类重载）
		/// </summary>
		protected virtual void parseSpecialBlock(char c) {
			parseCode(true);
		}

		/// <summary>
		/// 处理参数
		/// </summary>
		void processParam() {
			var parser = new CodeParser(')');
			parser.parse(template); 

			var lastBlock = block.getLastSubBlock();
			var attr = parser.block.genCode(false);
			lastBlock.addArg(argIndex++, attr);
		}

		/// <summary>
		/// 分析块
		/// </summary>
		/// <typeparam name="B"></typeparam>
		protected void parseBlock<P>() where P : Parser, new() {
			parseBlock(new P());
		}
		protected void parseBlock(Parser parser) {
			argIndex = 0; parser.parse(this);

			//var block = parser.output();
			//if (block != null) addBlock(block);
		}

		/// <summary>
		/// 分析纯代码
		/// </summary>
		protected virtual void parseCode(bool dollar = false) {
			parseBlock<CodeParser>();
		}

		/// <summary>
		/// 添加代码块
		/// </summary>
		/// <param name="code"></param>
		public override void addBlock(Block block) {
			this.block.addSubBlock(block);
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
		string endChars = "$";

		/// <summary>
		/// 包装字符
		/// </summary>
		string wrapperStr = "";
		//char lWChar => wrapperStr[0]; // left wrapper char
		//char rWChar => wrapperStr[1]; // right wrapper char

		///// <summary>
		///// 深度
		///// </summary>
		//int depth = 0;

		/// <summary>
		/// 属性模式
		/// </summary>
		bool attrMode = false;

		/// <summary>
		/// 构造函数
		/// </summary>
		public CodeParser() { }
		public CodeParser(char endChar) {
			endChars += endChar; attrMode = true;
		}
		public CodeParser(string endChars, string wrapperStr = "") {
			this.endChars += endChars + wrapperStr[1];
			this.wrapperStr = wrapperStr;
			//if (!string.IsNullOrEmpty(wrapperStr)) depth = 1;
		}

		/// <summary>
		/// 是否块结束
		/// </summary>
		/// <returns></returns>
		public override bool isEnd() {
			return base.isEnd() || endChars.Contains(getChar()); 
				//(getChar() == rWChar && depth <= 0);
		}

		/// <summary>
		/// 分析单个字符
		/// </summary>
		public override void parseChar(char c) {
			switch (c) {
				case '\\': appendCode(nextChar()); break;
				default: appendCode(c); break;
			}
		}

		///// <summary>
		///// 添加字符
		///// </summary>
		///// <param name="c"></param>
		//protected override void appendCode(char c) {
		//	if (!string.IsNullOrEmpty(wrapperStr)) {
		//		if (c == lWChar) depth++;
		//		if (c == rWChar) depth--;
		//	}

		//	base.appendCode(c);
		//}

		/// <summary>
		/// 分析结束回调
		/// </summary>
		protected override void onParseEnd() {
			block.code = tmpCode;
			if (!attrMode) prevChar();
		}
	}

	/// <summary>
	/// 纯代码分析器
	/// </summary>
	public class CommentParser : Parser<CommentBlock> {

		/// <summary>
		/// 构造函数
		/// </summary>
		public CommentParser() { }

		/// <summary>
		/// 是否块结束
		/// </summary>
		/// <returns></returns>
		public override bool isEnd() {
			return base.isEnd() || getChar() == '\r';
		}

		/// <summary>
		/// 分析单个字符
		/// </summary>
		public override void parseChar(char c) { }

		/// <summary>
		/// 分析结束回调
		/// </summary>
		protected override void onParseEnd() {
			nextChar();
		}
	}

	/// <summary>
	/// 支持Wrapper的分析器
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class WrapperParser<T> : Parser<T> where T : Block {

		/// <summary>
		/// 包装字符
		/// </summary>
		protected abstract string wrapperStr { get; }
		protected char lWChar => wrapperStr[0]; // left wrapper char
		protected char rWChar => wrapperStr[1]; // right wrapper char

		/// <summary>
		/// 关键字
		/// </summary>
		protected virtual string keyWord => "";

		/// <summary>
		/// 深度
		/// </summary>
		//int depth = 0;

		/// <summary>
		/// 是否块结束
		/// </summary>
		/// <returns></returns>
		public override bool isEnd() {
			return base.isEnd() || getChar() == rWChar; // && depth <= 0;
		}

		/// <summary>
		/// 处理纯代码
		/// </summary>
		/// <param name="c"></param>
		protected override void parseCode(bool dollar = false) {
			//if (getChar() == lWChar) depth++;
			//if (getChar() == rWChar) depth--;
			parseBlock(new CodeParser(keyWord, wrapperStr));
			//base.parseCode();
		}
		
	}

	/// <summary>
	/// 变量块分析器
	/// </summary>
	public class ObjectParser : WrapperParser<ObjectBlock> {

		/// <summary>
		/// 包装字符
		/// </summary>
		protected override string wrapperStr => "{}";

		/// <summary>
		/// 关键字
		/// </summary>
		//protected override string keyWord => "?:";

		/// <summary>
		/// 是否为条件块
		/// </summary>
		bool isCond = false;

		/// <summary>
		/// 变量块
		/// </summary>
		/// <returns></returns>
		VarBlock varBlock() { return block as VarBlock; }

		/// <summary>
		/// 条件块
		/// </summary>
		/// <returns></returns>
		CondBlock condBlock() { return block as CondBlock; }

		/// <summary>
		/// 分析单个字符
		/// </summary>
		public override void parseChar(char c) {
			if (isCond)
				base.parseChar(c);
			else if (c == '?') // 条件块
				switchCond();
			else
				appendCode(c);
		}

		/// <summary>
		/// 切换到分析条件块
		/// </summary>
		void switchCond() {
			isCond = true;
			var block = new CondBlock();
			block.addCondition(tmpCode);
			setBlock(block);
		}

		/// <summary>
		/// 分析代码
		/// </summary>
		protected override void parseCode(bool dollar = false) {
			if (isCond && dollar) parseCond();
			else base.parseCode(dollar);
		}

		/// <summary>
		/// 分析条件
		/// </summary>
		void parseCond() {
			prevChar(); // 默认在 parseBlock 之后会有 nextChar
			if (getChar() == ':') // else
				condBlock()?.addElse();
			else {
				var parser = new CodeParser('?');
				parser.parse(template); 

				var attr = parser.block.genCode(false);
				condBlock()?.addCondition(attr);
			}
		}

		/// <summary>
		/// 添加代码块
		/// </summary>
		/// <param name="code"></param>
		public override void addBlock(Block block) {
			condBlock()?.addCondBlock(block);
		}

		/// <summary>
		/// 分析结束回调
		/// </summary>
		protected override void onParseEnd() {
			if (isCond) return;
			var block = new VarBlock();
			block.setAttr(tmpCode); // 处理 VarBlock
			setBlock(block);
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
		/// 关键字
		/// </summary>
		protected override string keyWord => "=";

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
		public override void addBlock(Block block) {
			if (flag) this.block.addValueBlock(block);
			else this.block.addKeyBlock(block);
		}
	}

	/// <summary>
	/// 纯代码分析器
	/// </summary>
	public class EmbedParser : WrapperParser<EmbedBlock> {

		/// <summary>
		/// 包装字符
		/// </summary>
		protected override string wrapperStr => "%%";
		
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
			var template = TemplateManager.getTemplate(
				this.template.getDir(), tmpCode);
			block.setTemplate(template);
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
		/// 分析开始回调
		/// </summary>
		protected override void onParseStart() {
			base.onParseStart();
			parseVar();
		}

		/// <summary>
		/// 分析变量
		/// </summary>
		void parseVar() {
			var parser = new CodeParser(':');
			parser.parse(template); nextChar();

			block.setAttr(parser.block.genCode(false));
		}

		/// <summary>
		/// 分析特殊功能块
		/// </summary>
		//protected override void parseSpecialBlock(char c) {
		//	switch (c) {
		//		default:
		//			base.parseSpecialBlock(c); break;
		//	}
		//}

	}

	#endregion

}
