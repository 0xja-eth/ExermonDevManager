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
	/// 请求-响应接口类
	/// </summary>
	public class ReqResInterface : CoreEntity {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("路由", 10)]
		public string route { get; set; } = "";

		[AutoConvert]
		[ControlField("请求参数", 20)]
		[InverseProperty("reqInterface")]
		public List<InterfaceParam> reqParams { get; protected set; } = new List<InterfaceParam>();
		[AutoConvert]
		[ControlField("响应参数", 20)]
		[InverseProperty("resInterface")]
		public List<InterfaceParam> resParams { get; protected set; } = new List<InterfaceParam>();

		//[AutoConvert]
		//public int bModuleId {
		//	get { return bModuleId_; }
		//	set { bModuleId_ = value; bModule_.clear(); }
		//}
		//int bModuleId_ = 0;
		[AutoConvert]
		public int bModuleId { get; set; }
		[ControlField("所属模块", 20)]
		public Module bModule { get; set; }
		[AutoConvert]
		[ControlField("处理函数", 20)]
		public string bFunc { get; set; } = "";
		[AutoConvert]
		public int bTagId { get; set; }
		[ControlField("Channels标志", 20)]
		public ChannelsTag bTag { get; set; }

		[AutoConvert]
		[ControlField("前端名称", 30)]
		public string fName { get; set; } = "";

		/// <summary>
		/// 构造函数
		/// </summary>
		public ReqResInterface() { }

		/// <summary>
		/// 获取分组键值
		/// </summary>
		/// <returns></returns>
		public override string groupKey() {
			return bModuleId.ToString();
		}

		///// <summary>
		///// 获取模块实例
		///// </summary>
		///// <returns></returns>
		//protected CacheAttr<Module> bModule_ = null;
		//protected Module _bModule_() {
		//	return poolGet<Module>(bModuleId);
		//}
		//public Module bModule() {
		//	return bModule_?.value();
		//}

		///// <summary>
		///// 获取标签实例
		///// </summary>
		///// <returns></returns>
		//protected CacheAttr<ChannelsTag> bTag_ = null;
		//protected ChannelsTag _bTag_() {
		//	return poolGet<ChannelsTag>(bTagId);
		//}
		//public ChannelsTag bTag() {
		//	return bTag_?.value();
		//}

		/// <summary>
		/// 处理函数文本
		/// </summary>
		/// <returns></returns>
		[ControlField("处理函数", 20)]
		public string bFuncText() {
			return string.Format("{0}.{1}", bModule.code, bFunc);
		}

		/// <summary>
		/// 处理函数文本
		/// </summary>
		/// <returns></returns>
		public string bTagName() {
			return bTag.name;
		}
		
	}
}
