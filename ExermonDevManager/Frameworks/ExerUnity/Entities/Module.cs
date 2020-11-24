using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

using System.ComponentModel.DataAnnotations.Schema;

namespace ExermonDevManager.Frameworks.ExerUnity.Entities {

	using Core.Data;
	using Core.Utils;
	using Core.CodeGen;
	using Core.Managers;

	/// <summary>
	/// 模块
	/// </summary>
	[TableSetting("模块")]
	public class Module : CoreEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("代码", 10)]
		public string code { get; set; }

		/// <summary>
		/// 关联查询
		/// </summary>
		[ControlField("模型", 101)]
		public List<Model> models { get; } = new List<Model>();
		[ControlField("请求-响应接口", 102)]
		public List<ReqResInterface> reqResInterfaces { get; } 
			= new List<ReqResInterface>();
		[ControlField("发射接口", 103)]
		public List<EmitInterface> emitInterfaces { get; } 
			= new List<EmitInterface>();
		[ControlField("异常", 104)]
		public List<Exception_> exceptions { get; }
			= new List<Exception_>();

		/// <summary>
		/// 构造函数
		/// </summary>
		public Module() { }
		public Module(string name, string code, 
			string description = "", bool buildIn = true) : 
			base(name, description, buildIn) {
			this.code = code;
		}

		/// <summary>
		/// 生成Python代码
		/// </summary>
		/// <returns></returns>
		public string pyCode() {
			return code.ToLower() + "_module";
		}

		/// <summary>
		/// 生成C#代码
		/// </summary>
		/// <returns></returns>
		public string csCode() {
			return code + "Module";
		}

		#region 关联查询
		
		/// <summary>
		/// 前端模型
		/// </summary>
		/// <returns></returns>
		public List<Model> frontendModels() {
			return models?.FindAll(m => m.isFrontend && !m.buildIn);
		}

		/// <summary>
		/// 后台模型
		/// </summary>
		/// <returns></returns>
		public List<Model> backendModels() {
			return models?.FindAll(m => m.isBackend && !m.buildIn);
		}
		
		#endregion

	}

	/// <summary>
	/// 函数类
	/// </summary>
	public class Function : CoreEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("代码", 10)]
		public string code { get; set; } // 函数内容

	}
	
}
