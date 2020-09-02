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
	using ExermonDevManager.Scripts.Controls;

	public partial class CodePreview : Form {
		public CodePreview() {
			InitializeComponent();
		}

		/// <summary>
		/// 配置代码生成对象
		/// </summary>
		/// <param name="gen"></param>
		public void setupGenerator(ICodeGenerator gen) {
			fCode.DataBindings.Clear();
			fCode.DataBindings.Add("Text", gen, "fCode",
				false, DataSourceUpdateMode.Never);

			bCode.DataBindings.Clear();
			bCode.DataBindings.Add("Text", gen, "bCode",
				false, DataSourceUpdateMode.Never);
		}
	}
}
