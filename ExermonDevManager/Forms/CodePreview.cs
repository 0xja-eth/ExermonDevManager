using System;
using System.Collections.Generic;
using System.IO;

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

		#region 默认事件

		private void refresh_Click(object sender, EventArgs e) {
			refreshGenerator();
		}

		private void exportAll_Click(object sender, EventArgs e) {
			exportCodes();
		}

		private void exportCurrent_Click(object sender, EventArgs e) {
			exportCode(item);
		}

		private void setting_Click(object sender, EventArgs e) {
			var form = new CodeGenSetting();
			form.ShowDialog(this);
		}

		#endregion

		#region 数据配置

		/// <summary>
		/// 一键配置
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="item"></param>
		[Obsolete("使用 setupGenerator 系列函数代替")]
		public void setup<T>(T item) where T : CoreData {
			setupGenerator<T>();
			addGenerators(item);
		}

		/// <summary>
		/// 配置代码生成器
		/// </summary>
		public void setupGenerator(CodeGenerator generator) {
			var generators = new List<CodeGenerator>();
			if (generator != null) generators.Add(generator);

			setupGenerators(generators);
		}
		public void setupGenerator<T>(T item, Enum name) where T : CoreData {
			setupGenerator(item.getGenerator(name));
		}
		public void setupGenerator<T>() where T : CoreData {
			setupGenerator(GenerateManager<T>.Get().getGlobalGenerator());
		}
		public void setupGenerator(Type type) {
			var generator = CoreData.getGenerateManager(type);
			setupGenerator(generator?.getGlobalGenerator());
		}

		/// <summary>
		/// 配置代码生成器（多个）
		/// </summary>
		public void setupGenerators(List<CodeGenerator> generators) {
			this.generators = generators;
			refreshGenerator();
		}
		public void setupGenerators<T>(T item) where T : CoreData {
			setupGenerators(item.getGenerators());
		}

		/// <summary>
		/// 添加生成器
		/// </summary>
		public void addGenerator(CodeGenerator generator) {
			generators.Add(generator);
			refreshGenerator();
		}
		public void addGenerator<T>(T item, Enum name) where T : CoreData {
			addGenerator(item.getGenerator(name));
		}
		public void addGenerator<T>() where T : CoreData {
			addGenerator(GenerateManager<T>.Get().getGlobalGenerator());
		}
		public void addGenerator(Type type) {
			var generator = CoreData.getGenerateManager(type);
			addGenerator(generator?.getGlobalGenerator());
		}

		/// <summary>
		/// 添加生成器（多个）
		/// </summary>
		public void addGenerators(List<CodeGenerator> generators) {
			this.generators.AddRange(generators);
			refreshGenerator();
		}
		public void addGenerators<T>(T item) where T : CoreData {
			addGenerators(item.getGenerators());
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

		#region 导出

		/// <summary>
		/// 导出全部
		/// </summary>
		/// <param name="code"></param>
		public void exportCodes() {
			foreach (var code in items) exportCode(code);
		}

		/// <summary>
		/// 导出单项
		/// </summary>
		/// <param name="code"></param>
		public void exportCode(GeneratedCode code) {
			var path = ConfigManager.config.exportPath;
			path = Path.Combine(path, code.path);
			StorageManager.saveDataIntoFile(code.code, path);
		}

		#endregion
	}
}
