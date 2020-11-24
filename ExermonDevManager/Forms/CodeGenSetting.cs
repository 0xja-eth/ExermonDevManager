using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ExermonDevManager.Forms {

	using Core.Managers;

	public partial class CodeGenSetting : Form {
		public CodeGenSetting() {
			InitializeComponent();
		}

		#region 默认事件

		private void CodeGenSetting_Load(object sender, EventArgs e) {
			refresh();
		}

		private void browse_Click(object sender, EventArgs e) {
			//browserDialog.RootFolder = Environment.SpecialFolder.;
			browserDialog.SelectedPath = ConfigManager.config.exportPath;
			var res = browserDialog.ShowDialog(this);

			if (res == DialogResult.OK) {
				ConfigManager.config.exportPath = browserDialog.SelectedPath;
				refresh();
			}
		}

		private void open_Click(object sender, EventArgs e) {
			Process.Start("explorer.exe", ConfigManager.config.exportPath);
		}

		#endregion

		/// <summary>
		/// 刷新
		/// </summary>
		void refresh() {
			exportPath.Text = ConfigManager.config.exportPath;
		}
	}
}
