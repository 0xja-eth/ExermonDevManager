using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Windows.Forms;

using System.ComponentModel;

using Microsoft.EntityFrameworkCore;

namespace ExermonDevManager.Forms {

	using Scripts.Forms;
	using Scripts.Controls;
	using Scripts.Entities;

	/// <summary>
	/// 测试窗口
	/// </summary>
	//public partial class ModelFieldSubForm : Form {
	public partial class ModelFieldSubForm : SubFormForModelField {

		List<ModelField> tmpList = new List<ModelField>();

		/// <summary>
		/// 构造函数
		/// </summary>
		public ModelFieldSubForm() { InitializeComponent(); }

		private void dataView_UserAddedRow(object sender, DataGridViewRowEventArgs e) {
			Console.WriteLine("UserAddedRow: " + e.Row);

			//db.SaveChanges();
		}

		private void bindingSource_AddingNew(object sender, AddingNewEventArgs e) {

			//var model = root as Model;
			//var no = new ModelField();
			//model.params_.Add(no);

			ModelField field = new ModelField();
			e.NewObject = field;
			tmpList.Add(field);
			db.Add(field);

			Console.WriteLine("AddingNew: " + e.NewObject);
			
		}

		private void bindingSource_ListChanged(object sender, ListChangedEventArgs e) {
			var model = root as Model;

			switch (e.ListChangedType) {
				case ListChangedType.ItemDeleted:
					Console.WriteLine("Deleted: " + e.NewIndex);
					db.Remove(tmpList[e.NewIndex]);
					tmpList.RemoveAt(e.NewIndex);
					break;
				case ListChangedType.ItemAdded:
					Console.WriteLine("Added: " + e.NewIndex);
					db.Add(tmpList[e.NewIndex]);
					break;
			}
		}

		private void dataView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
			
			Console.WriteLine("UserDeletingRow: " + e.Row.DataBoundItem);
		}
	}
}
