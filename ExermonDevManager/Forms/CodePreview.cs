using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExermonDevManager.Forms {

	using Scripts.Data;
	using Scripts.Controls;
	using Scripts.Forms;
	using Scripts.CodeGen;

	public partial class CodePreview : ExerFormForExportedCode {

		/// <summary>
		/// 对应的列表
		/// </summary>
		public override ExerListView listView => itemList;

		/// <summary>
		/// 生成器
		/// </summary>
		List<CodeGenerator> generators = new List<CodeGenerator>();

		/// <summary>
		/// 构造函数
		/// </summary>
		public CodePreview() {
			InitializeComponent();
		}

		#region 数据配置

		/// <summary>
		/// 一键配置
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="item"></param>
		public void setup<T>(T item) where T : CoreData {
			setupGenerator<T>();
			addGenerators(item);
		}

		/// <summary>
		/// 配置代码生成器
		/// </summary>
		public void setupGenerator(CodeGenerator generator) {
			var generators = new List<CodeGenerator>();
			generators.Add(generator);
			setupGenerators(generators);
		}
		public void setupGenerator<T>(T item, string name) where T : CoreData {
			setupGenerator(item.generator(name));
		}
		public void setupGenerator<T>() where T : CoreData {
			setupGenerator(GenerateManager<T>.globalGenerator());
		}

		/// <summary>
		/// 配置代码生成器（多个）
		/// </summary>
		public void setupGenerators(List<CodeGenerator> generators) {
			this.generators = generators;
			refreshGenerator();
		}
		public void setupGenerators<T>(T item) where T : CoreData {
			setupGenerators(item.generators());
		}

		/// <summary>
		/// 添加生成器
		/// </summary>
		public void addGenerator(CodeGenerator generator) {
			generators.Add(generator);
			refreshGenerator();
		}
		public void addGenerator<T>(T item, string name) where T : CoreData {
			addGenerator(item.generator(name));
		}
		public void addGenerator<T>() where T : CoreData {
			addGenerator(GenerateManager<T>.globalGenerator());
		}

		/// <summary>
		/// 添加生成器（多个）
		/// </summary>
		public void addGenerators(List<CodeGenerator> generators) {
			this.generators.AddRange(generators);
			refreshGenerator();
		}
		public void addGenerators<T>(T item) where T : CoreData {
			addGenerators(item.generators());
		}

		/// <summary>
		/// 刷新代码生成器
		/// </summary>
		public void refreshGenerator() {
			var items = new List<GeneratedCode>();
			foreach (var generator in generators) {
				generator.generate();
				items.AddRange(generator.codes);
			}

			this.items = items;
		}

		#endregion

		#region 控件配置

		/// <summary>
		/// 配置列表
		/// </summary>
		protected override void setupItemList() {
			base.setupItemList();
			itemList.setupGroups<CodeTemplate>();
		}

		#endregion
	}
}
