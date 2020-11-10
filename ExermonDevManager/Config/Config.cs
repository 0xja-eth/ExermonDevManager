using System;
using System.Collections.Generic;

namespace ExermonDevManager.Config {

	using Scripts.Entities;
	using Scripts.CodeGen;

	/// <summary>
	/// 配置内容
	/// </summary>
	public static class Config {
		
		/// <summary>
		/// MySQL连接配置
		/// </summary>
		public static class MySQL {

			public const string Host = "127.0.0.1";
			public const string User = "root";
			public const string Password = "123456";
			public const string Database = "exermon_manager";

		}
		
		/// <summary>
		/// 模板配置
		/// </summary>
		public static class Template {

			/// <summary>
			/// 添加模板
			/// </summary>
			public static void addTemplates() {
				TemplateManager.addTemplate<ReqResInterface>();
				TemplateManager.addTemplate<Model>();
				TemplateManager.addTemplate<Exception_>("Exceptions.exer");

				addModelTemplates();
			}

			/// <summary>
			/// 配置模型模板库
			/// </summary>
			static void addModelTemplates() {
				TemplateManager.addTemplate<Model>(
					Model.GenType.DjangoModel, "backend/model/DjangoModel");
				TemplateManager.addTemplate<Model>(
					Model.GenType.ExermonModel, "frontend/model/ExermonModel");

				TemplateManager.addTemplate<Model>(
					Model.GenType.DjangoModelAdminSettings,
					"backend/model/DjangoModelAdminSettings");
				TemplateManager.addTemplate<Model>(
					Model.GenType.DjangoModelTypeSettings,
					"backend/model/DjangoModelTypeSettings");

				TemplateManager.addTemplate<ModelField>(
					Model.GenType.DjangoModelField,
					"backend/model/DjangoModelField");
				TemplateManager.addTemplate<ModelField>(
					Model.GenType.DjangoModelFieldDeclare,
					"backend/model/DjangoModelFieldDeclare");

				TemplateManager.addTemplate<ModelField>(
					Model.GenType.ExermonModelProp,
					"frontend/model/ExermonModelProp");
				TemplateManager.addTemplate<ModelField>(
					Model.GenType.ExermonModelPropDeclare,
					"frontend/model/ExermonModelPropDeclare");
			}

		}

	}
}
