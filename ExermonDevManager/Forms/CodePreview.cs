using System;
using System.Collections.Generic;
using System.IO;

using System.Windows.Forms;

namespace ExermonDevManager.Forms {

	using Core.Data;
	using Core.Entities;
	using Core.Controls;
	using Core.Forms;
	using Core.CodeGen;
	using Core.Managers;

	//public partial class CodePreview : Form {
	public partial class CodePreview : ExerFormForGeneratedCode {

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
			exportCode(currentItem);
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
		public void setup<T>(T item) where T : BaseEntity {
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
		public void setupGenerator<T>(T item, Enum name) where T : BaseEntity {
			setupGenerator(item.getGenerator(name));
		}
		public void setupGenerator<T>() where T : CoreData {
			setupGenerator(GenerateManager<T>.Get().getGlobalGenerator());
		}
		public void setupGenerator(Type type) {
			var generator = BaseEntity.getGenerateManager(type);
			setupGenerator(generator?.getGlobalGenerator());
		}

		/// <summary>
		/// 配置代码生成器（多个）
		/// </summary>
		public void setupGenerators(List<CodeGenerator> generators) {
			this.generators = generators;
			refreshGenerator(); // 最终调用函数
		}
		public void setupGenerators<T>(T item) where T : BaseEntity {
			setupGenerators(item.getGenerators());
		}

		/// <summary>
		/// 添加生成器
		/// </summary>
		public void addGenerator(CodeGenerator generator) {
			generators.Add(generator);
			refreshGenerator(); // 最终调用函数
		}
		public void addGenerator<T>(T item, Enum name) where T : BaseEntity {
			addGenerator(item.getGenerator(name));
		}
		public void addGenerator<T>() where T : BaseEntity {
			addGenerator(GenerateManager<T>.Get().getGlobalGenerator());
		}
		public void addGenerator(Type type) {
			var generator = BaseEntity.getGenerateManager(type);
			addGenerator(generator?.getGlobalGenerator());
		}

		/// <summary>
		/// 添加生成器（多个）
		/// </summary>
		public void addGenerators(List<CodeGenerator> generators) {
			this.generators.AddRange(generators);
			refreshGenerator(); // 最终调用函数
		}
		public void addGenerators<T>(T item) where T : BaseEntity {
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

			setupItems(items);
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
