﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace ExermonDevManager.Scripts.CodeGen {

	using Utils;

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
		public void addSubBlock(Block block) {
			if (!isLeaf) subBlocks.Add(block);
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
	/// 注释块
	/// </summary>
	public class CommentBlock : Block {

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
		protected override string doGenCode() { return ""; }
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
		/// 设置模板
		/// </summary>
		/// <param name="template"></param>
		public void setTemplate(CodeTemplate template) {
			this.template = template;
			addSubBlock(template.output());
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
			foreach (var item in dataList)
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

}
