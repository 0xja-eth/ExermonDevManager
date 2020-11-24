using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExermonDevManager {

	using Forms;
	using Core;

	static class Program {

		/// <summary>
		/// 初始化
		/// </summary>
		static bool initialized = false;

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() {
			initialize();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm2());
		}

		/// <summary>
		/// 初始化
		/// </summary>
		public static void initialize() {
			if (initialized) return;
			initialized = true;

			FrameworkManager.initialize();
		}
	}
}
