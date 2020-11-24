using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;

namespace ExermonDevManager.Core.CodeGen {

	using Utils;

	#region 代码块结构

	/// <summary>
	/// 代码块
	/// </summary>
	public class Block {

		/// <summary>
		/// 文本常量
		/// </summary>
		protected const string NodeTextFormat = "[{0}]{1}";
		protected const string DetailTextFormat = "[{0}]\r\n{1}";

		/// <summary>
		/// 生成器
		/// </summary>
		protected CodeGenerator generator = null;

		/// <summary>
		/// 子块
		/// </summary>
		protected List<Block> subBlocks = new List<Block>();

		/// <summary>
		/// 缩进
		/// </summary>
		protected int indent = 0; // 原始缩进
		//protected int runtimeIndent = 0; // 实际缩进
		//public int indent => runtimeIndent + indent_;

		/// <summary>
		/// 父块
		/// </summary>
		protected Block parent; // 原始父块
		//protected Block runtimeParent; // 实际父块
		//public Block parent => runtimeParent ?? parent_;

		/// <summary>
		/// 数据
		/// </summary>
		public object data = null;

		#region 配置

		/// <summary>
		/// 能否生成实际代码
		/// </summary>
		//public virtual bool genEnable => true;

		/// <summary>
		/// 是否叶子块
		/// </summary>
		public virtual bool isLeaf => false;

		#endregion

		#region 数据操作

		/// <summary>
		/// 添加参数（子类重载实现）
		/// </summary>
		/// <param name="index">参数索引</param>
		/// <param name="arg">参数内容</param>
		public virtual void addArg(int index, string arg) { }

		/// <summary>
		/// 设置数据
		/// </summary>
		public virtual void setData(object data) {
			this.data = data;
			foreach (var block in subBlocks)
				block.setData(data);
		}
		
		/// <summary>
		/// 获取当前缩进
		/// </summary>
		/// <returns></returns>
		public virtual int getIndent() { return indent; }
		
		/// <summary>
		/// 设置缩进
		/// </summary>
		/// <param name="indent"></param>
		public void setIndent(int indent) {
			this.indent = indent;
			foreach (var block in subBlocks)
				block.setIndent(indent);
		}

		#endregion

		#region 子块操作

		/// <summary>
		/// 增加块
		/// </summary>
		/// <param name="block"></param>
		public void addSubBlock(Block block) {
			if (isLeaf || block == null) return;
			//block.parent_ = this;
			//block.setIndent(getIndent());
			subBlocks.Add(block);
		}

		/// <summary>
		/// 获取块
		/// </summary>
		/// <param name="block"></param>
		public Block getSubBlock(int id) {
			if (isLeaf || subBlocks.Count <= 0) return null;
			return subBlocks[id];
		}

		/// <summary>
		/// 获取所有块（只读）
		/// </summary>
		/// <param name="block"></param>
		public List<Block> getSubBlocks() {
			return new List<Block>(subBlocks);
		}

		/// <summary>
		/// 获取块数目
		/// </summary>
		/// <param name="block"></param>
		public int subBlocksCount() {
			return subBlocks.Count;
		}

		/// <summary>
		/// 获取最后块
		/// </summary>
		/// <param name="block"></param>
		public Block getLastSubBlock() {
			return getSubBlock(subBlocksCount() - 1);
		}

		/// <summary>
		/// 获取最后块
		/// </summary>
		/// <param name="block"></param>
		public int getSubBlockIndex(Block block) {
			return subBlocks.IndexOf(block);
		}

		/// <summary>
		/// 获取前一个纯代码块
		/// </summary>
		/// <returns></returns>
		public CodeBlock getPrevCodeBlock() {
			var blocks = parent?.subBlocks;
			if (blocks != null) {
				var index = blocks.IndexOf(this);

				// 向前查找
				for (int i = index - 1; i >= 0; --i) {
					var res = blocks[i] as CodeBlock;
					if (res != null) return res;
				}
			}
			return parent?.getPrevCodeBlock();
		}

		/// <summary>
		/// 子块是否存在某种类型的块
		/// </summary>
		/// <returns></returns>
		public virtual bool hasBlock<T>() where T: Block {
			if (isLeaf) return false;
			foreach (var block in subBlocks)
				if ((block as T) != null) return true;
			return false;
		}
		
		/// <summary>
		/// 当前的子块是否存在取消标志
		/// </summary>
		/// <returns></returns>
		public bool hasCancelFlag() {
			return hasBlock<CancelFlag>();
		}

		#endregion

		#region 生成相关

		/// <summary>
		/// 是否为空
		/// </summary>
		/// <returns></returns>
		public bool isEmpty() { return string.IsNullOrEmpty(doGenCode()); }

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
		protected virtual string doGenCode(bool sync = true) { return genSubCode(sync); }

		/// <summary>
		/// 生成代码并同步到生成器
		/// </summary>
		/// <param name="sync">是否同步到生成器</param>
		/// <returns></returns>
		public string genCode(bool sync = true) {
			onGenerateStart();

			var code = doGenCode(sync);
			if (sync && isLeaf) code = syncCode(code);
			//else Console.WriteLine("code: " + code + " (" + this + ")");

			//if (generator == null) return code;
			//var lastEnable = generator.genTagCode;
			//if (!genEnable) generator.genTagCode = false;
			//generator.genTagCode = lastEnable;

			onGenerateEnd();

			return code;
		}

		/// <summary>
		/// 生成开始回调
		/// </summary>
		protected virtual void onGenerateStart() {
			setupParents(); setupIndents();
		}

		/// <summary>
		/// 配置子块的父类
		/// </summary>
		void setupParents() {
			foreach (var block in subBlocks) block.parent = this;
		}

		/// <summary>
		/// 配置子块的缩进
		/// </summary>
		void setupIndents() {
			foreach (var block in subBlocks) block.indent = getIndent();
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		/// <param name="code"></param>
		protected virtual string syncCode(string code) {
			return generator?.addCode(code, getIndent());
		}

		/// <summary>
		/// 生成结束回调
		/// </summary>
		protected virtual void onGenerateEnd() { }

		/// <summary>
		/// 生成子块代码
		/// </summary>
		/// <returns></returns>
		protected string genSubCode(bool sync = true) {
			var code = "";
			if (isLeaf) return code;

			foreach (var block in subBlocks)
				code += block.genCode(sync);

			return code;
		}

		#endregion

		#region 显示相关

		/// <summary>
		/// 自定义内容
		/// </summary>
		public string customContent;

		/// <summary>
		/// 块名称
		/// </summary>
		public virtual string blockName => "组合块";

		/// <summary>
		/// 显示结点文本
		/// </summary>
		/// <returns></returns>
		public string nodeText() {
			return string.Format(NodeTextFormat, blockName, nodeContent());
		}

		/// <summary>
		/// 结点内容
		/// </summary>
		/// <returns></returns>
		protected virtual string nodeContent() { return customContent; }

		/// <summary>
		/// 显示详细文本
		/// </summary>
		/// <returns></returns>
		public string detailText() {
			return string.Format(DetailTextFormat, blockName, detailContent());
		}

		/// <summary>
		/// 结点内容
		/// </summary>
		/// <returns></returns>
		protected virtual string detailContent() { return nodeContent(); }

		#endregion
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
		/// 获取每一行内容
		/// </summary>
		/// <returns></returns>
		public string[] getLines() {
			return Regex.Split(code, "\\r\n");
		}

		/// <summary>
		/// 末位缩进
		/// </summary>
		/// <returns></returns>
		public int lastIndent() {
			var lines = getLines(); int cnt = 0;
			var str = lines[lines.Length - 1]; 
			foreach (var c in str)
				if (c == '\t') cnt++;
			return cnt;
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		/// <returns></returns>
		protected override string doGenCode(bool sync = true) { return code; }

		/// <summary>
		/// 块名称
		/// </summary>
		public override string blockName => "代码块";

		/// <summary>
		/// 结点内容
		/// </summary>
		/// <returns></returns>
		protected override string nodeContent() {
			var lines = getLines();
			if (lines.Length <= 0) return "";
			if (lines.Length == 1) return getLines()[0];

			return getLines()[0] + "...";
		}

		/// <summary>
		/// 详细内容
		/// </summary>
		/// <returns></returns>
		protected override string detailContent() {
			return code;
		}

	}

	/// <summary>
	/// 注释块
	/// </summary>
	public class CommentBlock : Block {
		
		/// <summary>
		/// 能否生成实际代码
		/// </summary>
		//public override bool genEnable => false;

		/// <summary>
		/// 是否叶子块
		/// </summary>
		public override bool isLeaf => true;

		/// <summary>
		/// 构造函数
		/// </summary>
		public CommentBlock() { }

		/// <summary>
		/// 生成代码
		/// </summary>
		/// <returns></returns>
		protected override string doGenCode(bool sync = true) { return ""; }

		/// <summary>
		/// 块名称
		/// </summary>
		public override string blockName => "注释块";

	}

	/// <summary>
	/// 注释块
	/// </summary>
	public class EmbedBlock : Block {

		/// <summary>
		/// 代码模板
		/// </summary>
		CodeTemplate template;

		/// <summary>
		/// 构造函数
		/// </summary>
		public EmbedBlock() { }

		/// <summary>
		/// 获取当前缩进
		/// </summary>
		/// <returns></returns>
		public override int getIndent() {
			var codeBlock = getPrevCodeBlock();
			int codeIndent = codeBlock == null ? 0 : codeBlock.lastIndent();
			return indent + codeIndent;
		}

		/// <summary>
		/// 设置模板
		/// </summary>
		/// <param name="template"></param>
		public void setTemplate(CodeTemplate template) {
			this.template = template;
			addSubBlock(template.output());
		}

		/// <summary>
		/// 块名称
		/// </summary>
		public override string blockName => "嵌入块";

		/// <summary>
		/// 结点内容
		/// </summary>
		/// <returns></returns>
		protected override string nodeContent() {
			return template.path;
		}
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
			var attr = attrs[index];

			if (data == null) data = generator?.data;

			var type = data?.GetType();
			var members = type?.GetMember(attr, ReflectionUtils.DefaultFlag);
			var member = (members != null && members.Length > 0) ? members[0] : null;

			if (member == null) return generator?.getData(attr);

			switch (member.MemberType) {
				case MemberTypes.Property:
					return (member as PropertyInfo).GetValue(data);
				case MemberTypes.Field:
					return (member as FieldInfo).GetValue(data);
				case MemberTypes.Method:
					return (member as MethodInfo).Invoke(data,
						ReflectionUtils.DefaultFlag, null, null, null);
				default:
					return generator?.getData(attr);
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
		protected override string doGenCode(bool sync = true) {
			return getValue()?.ToString() ?? "";
		}

		/// <summary>
		/// 块名称
		/// </summary>
		public override string blockName => "变量块";

		/// <summary>
		/// 结点内容
		/// </summary>
		/// <returns></returns>
		protected override string nodeContent() {
			return getAttr();
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
			addSubBlock(new Block()); addAttr(attr);
		}

		/// <summary>
		/// 添加Else块
		/// </summary>
		public void addElse() {
			addSubBlock(new Block()); hasElse = true;
		}

		/// <summary>
		/// 添加条件块（往最后的条件）
		/// </summary>
		/// <param name="block"></param>
		public void addCondBlock(Block block) {
			subBlocks[subBlocks.Count - 1].addSubBlock(block);
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		/// <returns></returns>
		protected override string doGenCode(bool sync = true) {
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

		/// <summary>
		/// 块名称
		/// </summary>
		public override string blockName => "条件块";

		/// <summary>
		/// 结点内容
		/// </summary>
		/// <returns></returns>
		protected override string nodeContent() {
			for (int i = 0; i < attrs.Count; ++i)
				subBlocks[i].customContent = "if " + attrs[i];

			if (hasElse)
				subBlocks[subBlocks.Count - 1].customContent = "else";

			return base.nodeContent();
		}

		/// <summary>
		/// 结点内容
		/// </summary>
		/// <returns></returns>
		protected override string detailContent() {
			return "";
		}

	}

	/// <summary>
	/// 标签块
	/// </summary>
	public class TagBlock : Block {

		/// <summary>
		/// 能否生成实际代码
		/// </summary>
		//public override bool genEnable => false;

		/// <summary>
		/// 键值
		/// </summary>
		public string key => subBlocks[0].genCode(false);
		public string value => subBlocks[1].genCode(false);

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
			kBlock.addSubBlock(block);
		}

		/// <summary>
		/// 添加值块
		/// </summary>
		/// <param name="block"></param>
		public void addValueBlock(Block block) {
			var kBlock = subBlocks[1] as Block;
			kBlock.addSubBlock(block);
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		protected override string doGenCode(bool sync = true) {
			generator?.setConfig(key, value);
			return "";
		}

		/// <summary>
		/// 生成代码开始回调
		/// </summary>
		protected override void onGenerateStart() {
			base.onGenerateStart();
			if (generator == null) return;
			generator.genTagCode = true;
		}

		/// <summary>
		/// 生成代码结束回调
		/// </summary>
		protected override void onGenerateEnd() {
			base.onGenerateEnd();
			if (generator == null) return;
			generator.genTagCode = false;
		}

		/// <summary>
		/// 块名称
		/// </summary>
		public override string blockName => "标签块";

		/// <summary>
		/// 结点内容
		/// </summary>
		/// <returns></returns>
		protected override string nodeContent() {
			subBlocks[0].customContent = "key";
			subBlocks[1].customContent = "value";

			return base.nodeContent();
		}

		/// <summary>
		/// 结点内容
		/// </summary>
		/// <returns></returns>
		protected override string detailContent() {
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
		/// 是否叶子块
		/// </summary>
		public override bool isLeaf => false;

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
		protected override string doGenCode(bool sync = true) {
			getDataList();
			if (dataList == null) return "";

			var code = ""; int i = 0;
			foreach (var item in dataList) 
				code += genSingleCode(item, ref i);

			return code;
			// spliter 无法生成的问题是只有 Leaf 块同步代码
			//return string.Join(spliter, codes);
		}

		/// <summary>
		/// 生成单个块的代码
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		string genSingleCode(object item, ref int index) {
			var code = "";
			if (index > 0)
				code += generator?.addCode(spliter);

			foreach (var block in subBlocks) {
				block.setData(item);
				code += block.genCode();
			}

			processLoopBreak(ref code, ref index);

			return code;
		}

		/// <summary>
		/// 是否退出循环
		/// </summary>
		/// <returns></returns>
		bool isLoopBreak() {
			if (generator == null) return false;
			return generator.loopBreak;
		}

		/// <summary>
		/// 是否退出循环
		/// </summary>
		/// <returns></returns>
		void resetLoopBreak() {
			if (generator == null) return;
			generator.loopBreak = false;
		}

		/// <summary>
		/// 处理循环中断
		/// </summary>
		void processLoopBreak(ref string code, ref int index) {
			if (!isLoopBreak()) {
				++index; return;
			}
			// 移除本次循环已生成的代码（只适用于单文件）
			generator?.removeCode(code.Length);
			resetLoopBreak(); code = "";
		}

		/// <summary>
		/// 块名称
		/// </summary>
		public override string blockName => "循环块";

		/// <summary>
		/// 结点内容
		/// </summary>
		/// <returns></returns>
		protected override string detailContent() {
			var spliter = string.IsNullOrEmpty(this.spliter) ? "无" : this.spliter;
			return base.detailContent() + "\r\n分隔符：" + spliter;
		}
	}

	/// <summary>
	/// 取消标志
	/// </summary>
	public class CancelFlag : Block {

		/// <summary>
		/// 是否叶子块
		/// </summary>
		public override bool isLeaf => true;

		/// <summary>
		/// 生成代码
		/// </summary>
		/// <returns></returns>
		protected override string doGenCode(bool sync = true) { return ""; }

		/// <summary>
		/// 生成代码开始回调
		/// </summary>
		protected override void onGenerateStart() {
			base.onGenerateStart();
			if (generator == null) return;
			generator.loopBreak = true;
		}

		/// <summary>
		/// 块名称
		/// </summary>
		public override string blockName => "跳出循环";

	}

	#endregion

}
