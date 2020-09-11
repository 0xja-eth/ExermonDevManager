using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;

namespace ExermonDevManager.Scripts.Data {
	using LitJson;
	using Utils;
	using CodeGen;

	/// <summary>
	/// 可转化为控件数据的数据
	/// </summary>
	public abstract class CoreData : BaseData {

		/// <summary>
		/// 控件显示字段属性特性
		/// </summary>
		[AttributeUsage(AttributeTargets.Field | 
			AttributeTargets.Property | AttributeTargets.Method)]
		public class ControlFieldAttribute : Attribute, 
			IComparable<ControlFieldAttribute> {

			/// <summary>
			/// 字段名
			/// </summary>
			public string name;

			/// <summary>
			/// 优先级（越低越前）
			/// </summary>
			public int rank;

			/// <summary>
			/// 宽度
			/// </summary>
			public int width;

			/// <summary>
			/// 构造函数
			/// </summary>
			public ControlFieldAttribute(string name, int rank = 0, int width = 128) {
				this.name = name; this.rank = rank; this.width = width;
			}

			/// <summary>
			/// 比较函数
			/// </summary>
			/// <param name="other"></param>
			/// <returns></returns>
			public int CompareTo(ControlFieldAttribute other) {
				return rank.CompareTo(other.rank);
			}
		}

		/// <summary>
		/// 字段数据
		/// </summary>
		public class FieldData : IComparable<FieldData> {

			/// <summary>
			/// 特性
			/// </summary>
			public ControlFieldAttribute attr;

			/// <summary>
			/// 值
			/// </summary>
			public string value;

			/// <summary>
			/// 构造函数
			/// </summary>
			public FieldData(ControlFieldAttribute attr, string value) {
				this.attr = attr; this.value = value;
			}

			/// <summary>
			/// 比较函数
			/// </summary>
			/// <param name="other"></param>
			/// <returns></returns>
			public int CompareTo(FieldData other) {
				return attr.CompareTo(other.attr);
			}
		}

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("名称")]
		public string name { get; set; } = "";
		[AutoConvert]
		[ControlField("描述", 100)]
		public string description { get; set; } = "";

		/// <summary>
		/// 内建数据
		/// </summary>
		public bool buildIn = false;

		/// <summary>
		/// 构造函数
		/// </summary>
		public CoreData() { }
		public CoreData(string name, string description = "", bool buildIn = true) {
			this.name = name; this.description = description;
			this.buildIn = buildIn;
		}

		#region 配置

		/// <summary>
		/// 是否包含在列表控件中
		/// </summary>
		/// <returns></returns>
		public virtual bool isIncluded() {
			return true; // !buildIn;
		}

		/// <summary>
		/// 可以保存到文件
		/// </summary>
		/// <returns></returns>
		protected override bool isSaveEnable() {
			return !buildIn;
		}

		/// <summary>
		/// 下拉列表文本
		/// </summary>
		/// <returns></returns>
		public virtual string comboText() {
			return id + ". " + name;
		}

		/// <summary>
		/// 获取分组名称
		/// </summary>
		/// <returns></returns>
		public virtual string groupText() {
			return name;
		}

		/// <summary>
		/// 获取分组键值
		/// </summary>
		/// <returns></returns>
		public virtual string groupKey() {
			return null;
		}

		#endregion

		#region 列表数据

		/// <summary>
		/// 不显示的字段
		/// </summary>
		/// <returns></returns>
		protected virtual string[] listExclude() {
			return new string[] { };
		}

		/// <summary>
		/// 获取用于显示的字段数据
		/// </summary>
		/// <returns></returns>
		public static List<ControlFieldAttribute> getFieldSettings(Type type) {
			var res = new List<ControlFieldAttribute>();
			//var exclude = type.InvokeMember("listExclude",
			//	ReflectionUtils.DefaultFlag, null, null, new object[0]) as string[];
			//var func = type.GetMethod("listExclude");
			//var exclude = func.Invoke(null, new object[0]) as string[];

			ReflectionUtils.processAttribute
				<MemberInfo, ControlFieldAttribute>(
				type, (m, attr) => {
					//if (!exclude.Contains(attr.name))
						res.Add(attr);
				}
			);

			res.Sort();

			return res;
		}

		/// <summary>
		/// 获取用于显示的字段数据
		/// </summary>
		/// <returns></returns>
		public List<FieldData> getFieldData() {
			var res = new List<FieldData>();
			var exclude = listExclude();

			PropertyInfo p; FieldInfo f; MethodInfo func;

			ReflectionUtils.processAttribute
				<MemberInfo, ControlFieldAttribute>(
				GetType(), (m, attr) => {
					if (exclude.Contains(attr.name)) return;
					string value = "";

					if ((p = m as PropertyInfo) != null)
						value = p.GetValue(this)?.ToString();

					else if ((f = m as FieldInfo) != null)
						value = f.GetValue(this)?.ToString();

					else if ((func = m as MethodInfo) != null)
						value = func.Invoke(this, null)?.ToString();

					res.Add(new FieldData(attr, value));
				});

			res.Sort();

			return res;
		}

		#endregion

		#region 代码生成

		/// <summary>
		/// 生成Python代码
		/// </summary>
		/// <returns></returns>
		public virtual LangElement<Python> genPyBlock() { return null; }
		public B genPyBlock<B>() where B : LangElement<Python> {
			return genPyBlock() as B;
		}

		/// <summary>
		/// 生成C#代码
		/// </summary>
		/// <returns></returns>
		public virtual LangElement<CSharp> genCSBlock() { return null; }
		public B genCSBlock<B>() where B : LangElement<CSharp> {
			return genCSBlock() as B;
		}

		/// <summary>
		/// 生成Python代码
		/// </summary>
		/// <returns></returns>
		public virtual string genPyCode() { return genPyBlock()?.genCode(); }

		/// <summary>
		/// 生成C#代码
		/// </summary>
		/// <returns></returns>
		public virtual string genCSCode() { return genCSBlock()?.genCode(); }

		/// <summary>
		/// 获取代码生成器
		/// </summary>
		/// <returns></returns>
		public CodeGenerator generator(string name) {
			return invokeGenerateManager<CodeGenerator>(
				"generator", new object[] { this, name });
		}

		/// <summary>
		/// 获取指定/所有生成器
		/// </summary>
		/// <returns></returns>
		public List<CodeGenerator> generators(params string[] names) {
			return invokeGenerateManager<List<CodeGenerator>>(
				"generators", new object[] { this, names });
		}

		/// <summary>
		/// 获取自身对应的生成管理类
		/// </summary>
		/// <returns></returns>
		Type getGenerateManagerType() {
			return typeof(GenerateManager<>).MakeGenericType(GetType());
		}

		/// <summary>
		/// 调用生成管理类的函数
		/// </summary>
		/// <param name="name"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		T invokeGenerateManager<T>(string name, object[] args) {
			var type = getGenerateManagerType();
			var types = new Type[args.Length];
			for (int i = 0; i < args.Length; ++i)
				types[i] = args[i].GetType();
			var func = type.GetMethod(name, types);

			return (T)func.Invoke(null, args);
		}

		#endregion

	}

	/// <summary>
	/// 模型
	/// </summary>
	public class Module : CoreData {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("代码", 10)]
		public string code { get; set; }

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
		public override string genPyCode() {
			return code.ToLower() + "_module";
		}

		/// <summary>
		/// 生成C#代码
		/// </summary>
		/// <returns></returns>
		public override string genCSCode() {
			return code + "Module";
		}

		/// <summary>
		/// 获取所有的请求-响应接口
		/// </summary>
		/// <returns></returns>
		public List<ReqResInterface> reqResInterfaces() {
			var res = new List<ReqResInterface>();
			var interfaces = poolGet<ReqResInterface>();

			foreach (var interface_ in interfaces)
				if (interface_.bModuleId == id)
					res.Add(interface_);

			return res;
		}

		/// <summary>
		/// 获取所有的发射接口
		/// </summary>
		/// <returns></returns>
		public List<EmitInterface> emitInterfaces() {
			var res = new List<EmitInterface>();
			var interfaces = poolGet<EmitInterface>();

			foreach (var interface_ in interfaces)
				if (interface_.bModuleId == id)
					res.Add(interface_);

			return res;
		}
	}

	/// <summary>
	/// 函数类
	/// </summary>
	public class Function : CoreData {

		/// <summary>
		/// 是否需要ID
		/// </summary>
		protected override bool idEnable() { return false; }

	}

	#region 类型相关


	/// <summary>
	/// 类型类
	/// </summary>
	public class Type_ : CoreData {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("代码", 10)]
		public string code { get; set; } = "";
		[AutoConvert]
		[ControlField("可继承", 20)]
		public bool derivable { get; set; } = true;

		/// <summary>
		/// 继承的类型
		/// </summary>
		[AutoConvert]
		public List<int> inherits { get; protected set; } = new List<int>();

		/// <summary>
		/// 构造函数
		/// </summary>
		public Type_() { }
		public Type_(string name, string code = null,
			string description = "", bool buildIn = true) :
			base(name, description, buildIn) {
			this.code = code ?? name; derivable = !buildIn;
		}
		
		/// <summary>
		/// 继承的类型
		/// </summary>
		/// <returns></returns>
		public virtual List<T> inheritTypes<T>() where T : Type_ {
			var res = new List<T>(inherits.Count);
			foreach (var id in inherits)
				res.Add(poolGet<T>(id));
			return res;
		}

		/// <summary>
		/// 派生的类型
		/// </summary>
		/// <returns></returns>
		public virtual List<T> deriveTypes<T>() where T : Type_ {
			var res = new List<T>();
			var types = poolGet<T>();

			foreach (var type in types) {
				var inherits = type.inheritTypes<T>();
				if (inherits != null && inherits.Contains(this as T))
					res.Add(type);
			}

			return res;
		}
	}

	/// <summary>
	/// 类型类
	/// </summary>
	public abstract class Type_<P> : Type_ where P : Param {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public List<P> params_ { get; protected set; } = new List<P>();

		/// <summary>
		/// 构造函数
		/// </summary>
		public Type_() { }
		public Type_(string name, string code = null,
			string description = "", bool buildIn = true) :
			base(name, code, description, buildIn) { }
	}

	/// <summary>
	/// 类型类
	/// </summary>
	public abstract class Type_<T, P> : Type_<P> 
		where T: Type_<T, P> where P : Param {

		/// <summary>
		/// 构造函数
		/// </summary>
		public Type_() { }
		public Type_(string name, string code = null,
			string description = "", bool buildIn = true) :
			base(name, code, description, buildIn) { }

		/// <summary>
		/// 总属性
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<List<P>> totalParams_ = null;
		protected List<P> _totalParams_() {
			var res = new List<P>(params_);
			var baseTypes = inheritTypes();

			foreach (var type in baseTypes)
				res.AddRange(type.totalParams());

			return res;
		}
		public List<P> totalParams() {
			return totalParams_?.value();
		}

		/// <summary>
		/// 继承的类型
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<List<T>> inheritTypes_ = null;
		protected List<T> _inheritTypes_() {
			var res = new List<T>(inherits.Count);
			foreach (var id in inherits)
				res.Add(poolGet<T>(id));
			return res;
		}
		public List<T> inheritTypes() {
			return inheritTypes_?.value();
		}
		public override List<T2> inheritTypes<T2>() {
			if (typeof(T2) == typeof(T))
				return inheritTypes() as List<T2>;
			return base.inheritTypes<T2>();
		}

		/// <summary>
		/// 派生的类型
		/// </summary>
		/// <returns></returns>
		public List<T> deriveTypes() {
			var res = new List<T>();
			var types = poolGet<T>();

			foreach (var type in types) {
				var inherits = type.inheritTypes();
				if (inherits != null && inherits.Contains(this as T))
					res.Add(type);
			}

			return res;
		}
		public override List<T2> deriveTypes<T2>() {
			if (typeof(T2) == typeof(T))
				return deriveTypes() as List<T2>;
			return base.deriveTypes<T2>();
		}
	}

	/// <summary>
	/// 参数类
	/// </summary>
	public abstract class Param : CoreData {

		/// <summary>
		/// 属性
		/// </summary>

		/// <summary>
		/// 是否需要ID
		/// </summary>
		protected override bool idEnable() { return false; }
		
		/// <summary>
		/// 获取分组键值
		/// </summary>
		/// <returns></returns>
		public override string groupKey() {
			return ownerType()?.id.ToString();
		}

		/// <summary>
		/// Python格式名称
		/// </summary>
		/// <returns></returns>
		public string pyName() {
			return DataLoader.hump2Underline(name);
		}

		/// <summary>
		/// C#格式名称
		/// </summary>
		/// <returns></returns>
		public string csName() {
			return DataLoader.underline2LowerHump(name);
		}

		/// <summary>
		/// 所属类型
		/// </summary>
		/// <returns></returns>
		public abstract Type_ ownerType();
	}

	#endregion

	#region 模型相关

	/// <summary>
	/// 模型类
	/// </summary>
	public class Model : Type_<Model, ModelField> {

		/// <summary>
		/// 类型设定
		/// </summary>
		public class TypeSetting : CoreData {

			/// <summary>
			/// 属性
			/// </summary>
			[AutoConvert]
			public List<int> fieldIds { get; set; } = new List<int>();
			[AutoConvert]
			public List<int> relModelIds { get; set; } = new List<int>();

			/// <summary>
			/// 所属模型
			/// </summary>
			public Model model = null;

			/// <summary>
			/// 是否需要ID
			/// </summary>
			protected override bool idEnable() { return false; }

			/// <summary>
			/// 字段
			/// </summary>
			/// <returns></returns>
			public List<ModelField> fields() {
				var res = new List<ModelField>();
				if (model == null) return res;
				foreach (var id in fieldIds) 
					if (id < model.params_.Count)
						res.Add(model.params_[id]);
				return res;
			}

			/// <summary>
			/// 关系模型
			/// </summary>
			/// <returns></returns>
			public List<Model> relModels() {
				var res = new List<Model>();
				foreach (var id in relModelIds)
					res.Add(poolGet<Model>(id));
				return res;
			}
			
			/// <summary>
			/// 生成字段代码
			/// </summary>
			/// <returns></returns>
			public List<string> genFieldCodes() {
				var fields = this.fields();
				var names = new List<string>(fields.Count);

				foreach (var field in fields)
					names.Add("'" + field?.pyName() + "'");

				return names;
			}

			/// <summary>
			/// 生成关系代码
			/// </summary>
			/// <returns></returns>
			public List<string> genRelCodes() {
				var rels = relModels();
				var names = new List<string>(rels.Count);

				foreach (var rel in rels)
					names.Add("'" + rel?.code + "'");

				return names;
			}
		}

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public int moduleId { get; set; }
		
		[AutoConvert]
		public bool isBackend { get; set; } = true; // 是否后端属性
		[AutoConvert]
		public bool isFrontend { get; set; } = true; // 是否前端属性

		[AutoConvert]
		public bool abstract_ { get; set; } = false; // 抽象类

		[AutoConvert]
		public string keyName { get; set; } = ""; // 关系的键名（用于后台）

		/// <summary>
		/// 转化设定
		/// </summary>
		[AutoConvert]
		public List<TypeSetting> typeSettings { get; set; } = new List<TypeSetting>();

		/// <summary>
		/// 读取自定义属性
		/// </summary>
		/// <param name="json"></param>
		protected override void loadCustomAttributes(JsonData json) {
			base.loadCustomAttributes(json);
			foreach (var setting in typeSettings)
				setting.model = this;
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		public Model() { }
		public Model(string name, string code = null,
			string description = "", bool buildIn = true) :
			base(name, code, description, buildIn) { 
			isBackend = !buildIn;
		}

		/// <summary>
		/// 获取分组键值
		/// </summary>
		/// <returns></returns>
		public override string groupKey() {
			return moduleId.ToString();
		}

		/// <summary>
		/// 获取模块实例
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<Module> module_ = null;
		protected Module _module_() {
			return poolGet<Module>(moduleId);
		}
		public Module module() {
			return module_?.value();
		}

		/// <summary>
		/// 使用方式文本
		/// </summary>
		/// <returns></returns>
		[ControlField("可用性", 15)]
		public string usageText() {
			if (isFrontend && isBackend) return "皆可";
			if (isFrontend) return "前端";
			if (isBackend) return "后端";
			return "无";
		}

		/// <summary>
		/// 获取相关的模型
		/// </summary>
		/// <returns></returns>
		public List<Model> getRelatedModels() {
			var res = new List<Model>();
			if (!isBackend) return res;

			var models = poolGet<Model>();

			foreach(var model in models) 
				foreach (var param in model.params_)
					if (param.isBackend_ && param.isRelated() 
						&& param.toModel() == this && 
						!res.Contains(model)) res.Add(model);

			return res;
		}

		/// <summary>
		/// 获取类型设置实例
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public TypeSetting getTypeSetting(string type) {
			return typeSettings.Find(t => t.name == type);
		}

		#region 代码生成

		/// <summary>
		/// 生成继承代码
		/// </summary>
		/// <returns></returns>
		List<string> genInheritCodes() {
			var inherits = inheritTypes();
			var res = new List<string>(inherits.Count);
			foreach (var inherit in inherits)
				res.Add(inherit.code);
			return res;
		}

		/// <summary>
		/// 生成注释描述
		/// </summary>
		/// <returns></returns>
		string genDescription() {
			var format = string.IsNullOrEmpty(description) ? "{0}" : "{0}：{1}";
			return string.Format(format, name, description);
		}

		#region Python生成

		/// <summary>
		/// 生成类型设置语块
		/// </summary>
		/// <returns></returns>
		LangDjangoTypeSettingRegion genTypeSettingsBlock() {
			return new LangDjangoTypeSettingRegion(keyName, typeSettings);
		}

		/// <summary>
		/// 生成Admin配置语块
		/// </summary>
		/// <returns></returns>
		LangDjangoAdminSetting genAdminSettingBlock() {
			return new LangDjangoAdminSetting(params_);
		}

		/// <summary>
		/// 生成Python语块
		/// </summary>
		/// <returns></returns>
		public override LangElement<Python> genPyBlock() {
			if (!isBackend) return null;

			var typeSetting = genTypeSettingsBlock();
			var adminSetting = genAdminSettingBlock();
			var inherits = genInheritCodes();

			var block = new LangDjangoModel(code, name,
				genDescription(), inherits, abstract_);

			block.addSubBlock(typeSetting);
			block.addSubBlock(adminSetting);

			processPyFieldBlocks(block);

			return block;
		}

		/// <summary>
		/// 处理Python字段语块
		/// </summary>
		/// <param name="b"></param>
		void processPyFieldBlocks(LangClass<Python> b) {
			foreach (var param in params_) {
				var subBlock = param.genPyBlock<LangBlock<Python>>();
				if (subBlock != null) b.addSubBlock(subBlock);
			}
		}

		/// <summary>
		/// 生成类型设置语块
		/// </summary>
		/// <returns></returns>
		public string genTypeSettingsCode() {
			return genTypeSettingsBlock().genCode();
		}

		#endregion

		#region C#生成

		/// <summary>
		/// 生成C#类代码
		/// </summary>
		/// <returns></returns>
		public override LangElement<CSharp> genCSBlock() {
			if (!isFrontend) return null;

			var inherits = genInheritCodes();

			var block = new LangClass<CSharp>(code,
				genDescription(), inherits, abstract_);

			processCSPropBlocks(block);

			return block;
		}

		/// <summary>
		/// 处理C#属性语块
		/// </summary>
		/// <param name="b"></param>
		void processCSPropBlocks(LangClass<CSharp> b) {
			foreach (var param in params_) {
				var subBlock = param.genCSBlock<LangBlock<CSharp>>();
				if (subBlock != null) b.addSubBlock(subBlock);
			}
		}

		#endregion

		#endregion
	}

	/// <summary>
	/// 模型属性类
	/// </summary>
	public class ModelField : Param {

		/// <summary>
		/// 后端属性标记
		/// </summary>
		[AttributeUsage(AttributeTargets.Property)]
		public class FrontendFieldAttribute : Attribute { }

		/// <summary>
		/// 后端属性标记
		/// </summary>
		[AttributeUsage(AttributeTargets.Property)]
		public class BackendFieldAttribute : Attribute {

			/// <summary>
			/// 属性名
			/// </summary>
			public string paramName;

			/// <summary>
			/// 构造函数
			/// </summary>
			public BackendFieldAttribute(string paramName = null) {
				this.paramName = paramName;
			}
		}

		/// <summary>
		/// 通用属性标记
		/// </summary>
		[AttributeUsage(AttributeTargets.Property)]
		public class GeneralFieldAttribute : Attribute { }

		/// <summary>
		/// 属性设置
		/// </summary>
		[AttributeUsage(AttributeTargets.Property)]
		public class BFieldSettingAttribute : BackendFieldAttribute {

			/// <summary>
			/// 接受类型
			/// </summary>
			public List<FieldEnum> acceptTypes;

			/// <summary>
			/// 构造函数
			/// </summary>
			public BFieldSettingAttribute(string paramName, 
				params FieldEnum[] types) : base(paramName) {
				acceptTypes = new List<FieldEnum>(types);
			}
		}

		/// <summary>
		/// 基本配置
		/// </summary>
		[AutoConvert]
		[GeneralField]
		public bool isBackend_ { get; set; } = true; // 是否后端属性
		[AutoConvert]
		[GeneralField]
		public bool isFrontend_ { get; set; } = true; // 是否前端属性
		[AutoConvert]
		[GeneralField]
		public string keyName { get; set; } // 键值

		#region 前端属性

		/// <summary>
		/// 前端属性
		/// </summary>
		[AutoConvert]
		[FrontendField]
		public int fTypeId { get; set; } // 前端类型ID

		[AutoConvert]
		[FrontendField]
		public int dimension { get; set; }
		[AutoConvert]
		[FrontendField]
		public bool useList { get; set; } = false; // 是否使用 List<T>
		[AutoConvert]
		[FrontendField]
		public bool protectedSet { get; set; } = true; // 是否为 protected set
		[AutoConvert]
		[FrontendField]
		public string format { get; set; } = "";
		[AutoConvert]
		[FrontendField]
		public bool autoLoad { get; set; } = true;
		[AutoConvert]
		[FrontendField]
		public bool autoConvert { get; set; } = true;
		[AutoConvert]
		[FrontendField]
		public string fDefault { get; set; } = "";
		[AutoConvert]
		[FrontendField]
		public bool defaultNew { get; set; } = false;

		#endregion

		#region 后端属性

		/// <summary>
		/// 后端属性
		/// </summary>
		[AutoConvert]
		[BackendField]
		public int bTypeId { get; set; }

		[AutoConvert]
		[BackendField("default")]
		public string bDefault { get; set; } = ""; // 代码
		[AutoConvert]
		[BFieldSetting(null, FieldEnum.Str, FieldEnum.File, FieldEnum.Bin)]
		public int maxLength { get; set; }
		[AutoConvert]
		[BackendField("null")]
		public bool null_ { get; set; } = false;
		[AutoConvert]
		[BackendField]
		public bool blank { get; set; } = false;
		[AutoConvert]
		[BackendField]
		public bool unique { get; set; } = false;
		[AutoConvert]
		[BackendField]
		public string verboseName { get; set; }

		/// <summary>
		/// Int
		/// </summary>
		[AutoConvert]
		[BFieldSetting("choices", FieldEnum.Int)]
		public int choicesId { get; set; } = -1;

		/// <summary>
		/// Time
		/// </summary>
		[AutoConvert]
		[BFieldSetting(null, FieldEnum.Time)]
		public bool autoNow { get; set; } = false;
		[AutoConvert]
		[BFieldSetting(null, FieldEnum.Time)]
		public bool autoNowAdd { get; set; } = false;

		/// <summary>
		/// File
		/// </summary>
		[AutoConvert]
		[BFieldSetting(null, FieldEnum.File)]
		public string uploadTo { get; set; } = "";

		/// <summary>
		/// Relate
		/// </summary>
		[AutoConvert]
		[BFieldSetting("to", FieldEnum.Rel)]
		public int toModelId { get; set; } = -1;
		[AutoConvert]
		[BFieldSetting("on_delete", FieldEnum.Rel)]
		public int onDeleteId { get; set; } = -1;

		/// <summary>
		/// Admin 配置
		/// </summary>
		[AutoConvert]
		[BackendField]
		public bool listDisplay { get; set; } = true;
		[AutoConvert]
		[BackendField]
		public bool listEditable { get; set; } = true;

		/// <summary>
		/// 读取转化配置
		/// </summary>
		[AutoConvert]
		[BackendField]
		public string typeFilter { get; set; } = "any";
		[AutoConvert]
		[BackendField]
		public string typeExclude { get; set; } = "";

		[AutoConvert]
		[BackendField]
		public string convertFunc { get; set; } = "None"; // 转化函数代码

		#endregion

		#region 显示文本计算

		/// <summary>
		/// 后端声明代码
		/// </summary>
		/// <returns></returns>
		[ControlField("后端声明", 10)]
		public string bTypeText() {
			return genPyFieldCode();
		}

		/// <summary>
		/// 前端声明代码
		/// </summary>
		/// <returns></returns>
		[ControlField("前端声明", 10)]
		public string fTypeText() {
			return genCSPropertyCode();
		}

		#endregion

		#region 代码生成

		/// <summary>
		/// to参数代码
		/// </summary>
		/// <returns></returns>
		string toModelCode() {
			var model = toModel();
			var module = model?.module();
			if (module == null) return null;
			return module.genPyCode() + "." + model.code;
		}

		/// <summary>
		/// 前端类型代码
		/// </summary>
		/// <returns></returns>
		string fTypeCode() {
			var type = fType().code;
			if (!useList)
				for (int i = 0; i < dimension; ++i) type += "[]";
			else
				for (int i = 0; i < dimension; ++i) type = "List<" + type + ">";
			return type;
		}

		/// <summary>
		/// 前端默认值代码
		/// </summary>
		/// <returns></returns>
		string fDefaultCode(string type) {
			return defaultNew ? string.Format("new {0}()", type) : fDefault;
		}

		/// <summary>
		/// 处理字段参数
		/// </summary>
		/// <param name="params_"></param>
		void processPyFieldParams(LangParamGroup<Python> params_) {

			var onDelete = this.onDelete()?.name;
			var choices = this.choices()?.name;

			params_.addParam("to", toModelCode());
			params_.addParam("on_delete", onDelete, null, true);
			params_.addParam("default", bDefault, "", true);
			params_.addParam("null", null_, false);
			params_.addParam("blank", blank, false);
			params_.addParam("unique", unique, false);
			params_.addParam("max_length", maxLength, 0);
			params_.addParam("choices", choices, null, true);
			params_.addParam("auto_new", autoNow, false);
			params_.addParam("auto_new_add", autoNowAdd, false);
			params_.addParam("upload_to", uploadTo, "", true);
			params_.addParam("verbose_name", verboseName);
		}

		/// <summary>
		/// 处理字段拓展参数
		/// </summary>
		/// <param name="params_"></param>
		void processPyFieldExtParams(LangParamGroup<Python> params_) {

			var typeFilter = Python.get().str2StrList(this.typeFilter);
			var typeExclude = Python.get().str2StrList(this.typeExclude);

			params_.addParam("type_filter", typeFilter, "['any']", true);
			params_.addParam("type_exclude", typeExclude, "[]", true);
			params_.addParam("convert", convertFunc, "None", true);
		}

		/// <summary>
		/// 生成Python代码
		/// </summary>
		/// <returns></returns>
		public override LangElement<Python> genPyBlock() {
			if (!isBackend()) return null;

			var enables = getBackendParamNames();

			var field = new LangDjangoFieldBlock(bType(), 
				pyName(), description ?? verboseName, enables);

			processPyFieldParams(field.paramGroup);
			processPyFieldExtParams(field.extendParamGroup);

			return field;
		}

		/// <summary>
		/// 生成字段声明代码
		/// </summary>
		/// <returns></returns>
		public string genPyFieldCode() {
			if (!isBackend()) return "-";

			var enables = getBackendParamNames();
			var field = new LangDjangoFieldBlock(
				bType(), pyName(), null, enables);

			processPyFieldParams(field.paramGroup);

			field.rawMode = true;

			return field.genCode();
		}

		/// <summary>
		/// 生成代码
		/// </summary>
		/// <returns></returns>
		public override LangElement<CSharp> genCSBlock() {
			if (!isFrontend()) return null;

			var setAccess = protectedSet ? LangProperty.Accessibility.Protected
				: LangProperty.Accessibility.Default;

			var typeCode = fTypeCode();
			var defaultCode = fDefaultCode(typeCode);

			var block = new LangProperty(typeCode, csName(),
				defaultCode, description, setAccess: setAccess);

			block.addDecoBlock(genCSPropAttrBlock());

			return block; 
		}

		/// <summary>
		/// 生成C#属性属性特性语块
		/// </summary>
		/// <returns></returns>
		LangAttribute genCSPropAttrBlock() {

			var block = new LangAttribute("AutoConvert");
			var params_ = block.paramGroup;

			params_.addParam("keyName", keyName);
			params_.addParam("autoLoad", autoLoad, true);
			params_.addParam("autoConvert", autoConvert, true);
			params_.addParam("format", format, "");

			return block;
		}

		/// <summary>
		/// 生成C#属性属性代码
		/// </summary>
		/// <returns></returns>
		string genCSPropertyCode() {
			if (!isFrontend()) return "-";

			var setAccess = protectedSet ? LangProperty.Accessibility.Protected
				: LangProperty.Accessibility.Default;

			var typeCode = fTypeCode();
			var defaultCode = fDefaultCode(typeCode);

			var block = new LangProperty(typeCode, csName(),
				defaultCode, description, setAccess: setAccess);
			block.rawMode = true;

			return block.genCode();
		}

		#endregion

		#region 反射相关计算

		/// <summary>
		/// 获取可用字段名称
		/// </summary>
		/// <returns></returns>
		public List<string> getEnableFieldNames() {

			var res = getGeneralFieldNames();

			if (isBackend()) getBackendFieldNames(res);
			if (isFrontend()) getFrontendFieldNames(res);

			return res;
		}

		/// <summary>
		/// 获取一般字段名称
		/// </summary>
		/// <param name="list"></param>
		List<string> getGeneralFieldNames(List<string> list = null) {
			list = list ?? new List<string>();

			ReflectionUtils.processAttribute<PropertyInfo, AutoConvertAttribute>
				(GetType().BaseType, (p, attr) => list.Add(p.Name));
			ReflectionUtils.processAttribute<PropertyInfo, GeneralFieldAttribute>
				(GetType(), (p, attr) => list.Add(p.Name));

			return list;
		}

		/// <summary>
		/// 获取后台字段名称
		/// </summary>
		/// <param name="list"></param>
		List<string> getBackendFieldNames(List<string> list = null) {
			var fieldEnum = bType().type;

			list = list ?? new List<string>();

			ReflectionUtils.processAttribute<PropertyInfo, BackendFieldAttribute>
				(GetType(), (p, a) => {
					var attr = a as BFieldSettingAttribute;
					if (attr == null || attr.acceptTypes.Contains(fieldEnum))
						list.Add(p.Name);
				});
			return list;
		}

		/// <summary>
		/// 获取后台字段名称
		/// </summary>
		/// <param name="list"></param>
		List<string> getFrontendFieldNames(List<string> list = null) {
			list = list ?? new List<string>();

			ReflectionUtils.processAttribute<PropertyInfo, FrontendFieldAttribute>
				(GetType(), (p, attr) => list.Add(p.Name));

			return list;
		}

		/// <summary>
		/// 获取后台字段名称
		/// </summary>
		/// <param name="list"></param>
		List<string> getBackendParamNames() {
			var fieldEnum = bType().type;

			var list = new List<string>();

			ReflectionUtils.processAttribute<PropertyInfo, BackendFieldAttribute>
				(GetType(), (p, a) => {
					var attr = a as BFieldSettingAttribute;
					if (attr == null || attr.acceptTypes.Contains(fieldEnum)) 
						list.Add(a.paramName ?? DataLoader.
							hump2Underline(p.Name));
				});
			return list;
		}

		#endregion

		#region 相关数据获取

		/// <summary>
		/// 前后台判断
		/// </summary>
		/// <returns></returns>
		public bool isBackend() {
			var model = ownerModel();
			if (model == null) return isBackend_;
			return model.isBackend && isBackend_;
		}
		public bool isFrontend() {
			var model = ownerModel();
			if (model == null) return isFrontend_;
			return model.isFrontend && isFrontend_;
		}

		/// <summary>
		/// 获取所属模型
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<Model> ownerType_ = null;
		protected Model _ownerType_() {
			var types = poolGet<Model>();
			foreach (var type in types)
				if (type.params_.Contains(this))
					return type;
			return null;
		}
		public sealed override Type_ ownerType() {
			return ownerType_?.value();
		}
		public Model ownerModel() {
			return ownerType() as Model;
		}

		/// <summary>
		/// 获取类型实例
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<DjangoFieldType> bType_ = null;
		protected DjangoFieldType _bType_() {
			return poolGet<DjangoFieldType>(bTypeId);
		}
		public DjangoFieldType bType() {
			return bType_?.value();
		}

		/// <summary>
		/// 是否关系字段
		/// </summary>
		/// <returns></returns>
		public bool isRelated() {
			var type = bType();
			if (type == null) return false;
			return type.type == FieldEnum.Rel;
		}

		/// <summary>
		/// 获取指向模型
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<Model> toModel_ = null;
		protected Model _toModel_() {
			return poolGet<Model>(toModelId);
		}
		public Model toModel() {
			return toModel_?.value();
		}

		/// <summary>
		/// 获取选择项枚举
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<CustomEnumGroup> choices_ = null;
		protected CustomEnumGroup _choices_() {
			return poolGet<CustomEnumGroup>(choicesId);
		}
		public CustomEnumGroup choices() {
			return choices_?.value();
		}

		/// <summary>
		/// 获取选择项枚举
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<DjangoOnDeleteChoice> onDelete_ = null;
		protected DjangoOnDeleteChoice _onDelete_() {
			return poolGet<DjangoOnDeleteChoice>(onDeleteId);
		}
		public DjangoOnDeleteChoice onDelete() {
			return onDelete_?.value();
		}

		/// <summary>
		/// 获取模块实例
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<Model> fType_ = null;
		protected Model _fType_() {
			return poolGet<Model>(fTypeId);
		}
		public Model fType() {
			return fType_?.value();
		}

		#endregion

	}

	/// <summary>
	/// 类型
	/// </summary>
	public enum FieldEnum {
		None, Int, Float, Bool, Str, Time, Bin, File, Rel,
	}

	/// <summary>
	/// Django字段类型
	/// </summary>
	public class DjangoFieldType : CoreData {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public FieldEnum type { get; set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		public DjangoFieldType() { }
		public DjangoFieldType(string name,
			FieldEnum type = FieldEnum.Int, string description = "") {
			this.name = name; this.type = type;
			this.description = description;
		}

		/// <summary>
		/// 下拉框文本
		/// </summary>
		/// <returns></returns>
		public override string comboText() {
			return name;
		}
	}
	
	/// <summary>
	/// OnDelete选项
	/// </summary>
	public class DjangoOnDeleteChoice : CoreData {

		/// <summary>
		/// 构造函数
		/// </summary>
		public DjangoOnDeleteChoice() { }
		public DjangoOnDeleteChoice(string name, string description = "") {
			this.name = name; 
			this.description = description;
		}
	}

	#endregion

	#region 接口相关

	/// <summary>
	/// 请求-响应接口类
	/// </summary>
	public class ReqResInterface : CoreData {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("路由", 10)]
		public string route { get; set; } = "";

		[AutoConvert]
		public List<InterfaceParam> reqParams { get; protected set; } = new List<InterfaceParam>();
		[AutoConvert]
		public List<InterfaceParam> resParams { get; protected set; } = new List<InterfaceParam>();

		//[AutoConvert]
		//public int bModuleId {
		//	get { return bModuleId_; }
		//	set { bModuleId_ = value; bModule_.clear(); }
		//}
		//int bModuleId_ = 0;
		[AutoConvert]
		public int bModuleId { get; set; }
		[AutoConvert]
		public string bFunc { get; set; } = "";
		[AutoConvert]
		public int bTagId { get; set; }

		[AutoConvert]
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

		/// <summary>
		/// 获取模块实例
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<Module> bModule_ = null;
		protected Module _bModule_() {
			return poolGet<Module>(bModuleId);
		}
		public Module bModule() {
			return bModule_?.value();
		}

		/// <summary>
		/// 获取标签实例
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<ChannelsTag> bTag_ = null;
		protected ChannelsTag _bTag_() {
			return poolGet<ChannelsTag>(bTagId);
		}
		public ChannelsTag bTag() {
			return bTag_?.value();
		}

		/// <summary>
		/// 处理函数文本
		/// </summary>
		/// <returns></returns>
		[ControlField("处理函数", 20)]
		public string bFuncText() {
			return string.Format("{0}.{1}", bModule().code, bFunc);
		}

		/// <summary>
		/// 处理函数文本
		/// </summary>
		/// <returns></returns>
		public string bTagName() {
			return bTag().name;
		}

		/// <summary>
		/// 生成Python语块
		/// </summary>
		/// <returns></returns>
		public override LangElement<Python> genPyBlock() {
			return new LangReqResInterface(this);
		}

		///// <summary>
		///// 生成C#语块
		///// </summary>
		///// <returns></returns>
		//public override LangElement<CSharp> genCSBlock() {
		//	return base.genCSBlock();
		//}
	}

	/// <summary>
	/// 发射接口类
	/// </summary>
	public class EmitInterface : CoreData {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("类型", 10)]
		public string type { get; set; } = "";
		[AutoConvert]
		public List<InterfaceParam> params_ { get; protected set; } = new List<InterfaceParam>();

		[AutoConvert]
		public int bModuleId { get; set; }

		/// <summary>
		/// 获取分组键值
		/// </summary>
		/// <returns></returns>
		public override string groupKey() {
			return bModuleId.ToString();
		}

		/// <summary>
		/// 获取模块实例
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<Module> bModule_ = null;
		protected Module _bModule_() {
			return poolGet<Module>(bModuleId);
		}
		public Module bModule() {
			return bModule_?.value();
		}
	}

	/// <summary>
	/// 组合数据
	/// </summary>
	public class GroupData : Type_<GroupData, InterfaceParam> {

		/// <summary>
		/// 属性
		/// </summary>
		//[AutoConvert]
		//[ControlField("可继承", 20)]
		//public bool baseData { get; set; } = false;

		/// <summary>
		/// 构造函数
		/// </summary>
		public GroupData() { }
		public GroupData(string name, string code = null,
			string description = "", bool buildIn = true) :
			base (name, code, description, buildIn) { }
	}

	/// <summary>
	/// 接口参数类
	/// </summary>
	public class InterfaceParam : Param {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public int typeId { get; set; }
		[AutoConvert]
		public int dimension { get; set; }

		/// <summary>
		/// 获取所属类型
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<GroupData> ownerType_ = null;
		protected GroupData _ownerType_() {
			var types = poolGet<GroupData>();
			foreach (var type in types)
				if (type.params_.Contains(this))
					return type;
			return null;
		}
		public sealed override Type_ ownerType() {
			return ownerType_?.value();
		}

		/// <summary>
		/// 获取类型实例
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<GroupData> type_ = null;
		protected GroupData _type_() {
			return poolGet<GroupData>(typeId);
		}
		public GroupData type() {
			return type_?.value();
		}

		/// <summary>
		/// 实际显示的类型名称
		/// </summary>
		/// <returns></returns>
		public string typeName() {
			var type = this.type();
			var res = type.name;
			if (dimension == 0) return res;
			if (dimension == 1) return res + "（数组）";

			var format = res + "（{0}维数组）";
			return string.Format(format, dimension);
		}

		/// <summary>
		/// 实际显示的类型代码
		/// </summary>
		/// <returns></returns>
		[ControlField("类型", 10)]
		public string typeCode() {
			var type = this.type();
			var res = type.code;
			for (int i = 0; i < dimension; ++i)
				res += "[]";
			return res;
		}

		/// <summary>
		/// 是否为用ID名参数
		/// </summary>
		/// <returns></returns>
		public bool isUid() { return name == "uid"; }

		/// <summary>
		/// 生成Python语块
		/// </summary>
		/// <returns></returns>
		public override LangElement<Python> genPyBlock() {
			var value = new List<string>();
			value.Add("'" + name + "'");
			value.Add("'" + typeCode() + "'");

			return new LangPyList(value);
		}
	}

	#endregion

	#region 枚举相关

	/// <summary>
	/// 枚举数据类型基类
	/// </summary>
	public abstract class Enum_ : CoreData {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("枚举值", 10)]
		public int code { get; set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		public Enum_() { }
		public Enum_(int code, string name, string description = "") {
			this.code = code; this.name = name;
			this.description = description;
		}

		/// <summary>
		/// 下拉框文本
		/// </summary>
		/// <returns></returns>
		public override string comboText() {
			return code + ". " + name;
		}

		/// <summary>
		/// 生成Python代码块
		/// </summary>
		/// <returns></returns>
		public override LangElement<Python> genPyBlock() {
			return new LangEnumItem<Python>(name, code, description);
		}

		/// <summary>
		/// 生成C#代码块
		/// </summary>
		/// <returns></returns>
		public override LangElement<CSharp> genCSBlock() {
			return new LangEnumItem<CSharp>(name, code, description);
		}
	}

	/// <summary>
	/// Channels标签
	/// </summary>
	public class ChannelsTag : Enum_ {

		/// <summary>
		/// 构造函数
		/// </summary>
		public ChannelsTag() { }
		public ChannelsTag(int code, string name, string description = "") :
			base(code, name, description) { }
	}

	/// <summary>
	/// 异常
	/// </summary>
	public class Exception_ : Enum_ {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		[ControlField("警告文本", 110)]
		public string alertText { get; set; } = "";
		[AutoConvert]
		public int bModuleId { get; set; }

		/// <summary>
		/// 获取分组键值
		/// </summary>
		/// <returns></returns>
		public override string groupKey() {
			return bModuleId.ToString();
		}

		/// <summary>
		/// 获取模块实例
		/// </summary>
		/// <returns></returns>
		protected CacheAttr<Module> bModule_ = null;
		protected Module _bModule_() {
			return poolGet<Module>(bModuleId);
		}
		public Module bModule() {
			return bModule_?.value();
		}

		/// <summary>
		/// 生成键代码
		/// </summary>
		/// <returns></returns>
		public string genKeyCode() {
			return "ErrorType." + name;
		}

		/// <summary>
		/// 生成前端提示文本设定代码
		/// </summary>
		/// <returns></returns>
		public string genAlertTextCode() {
			return "\"" + alertText + "\"";
		}

		/// <summary>
		/// 生成异常管理代码
		/// </summary>
		/// <returns></returns>
		public static string genPyExceptionCode() {
			var file = new LangFile<Python>();
			file.addSubBlock(new LangErrorTypeEnum());
			file.addSubBlock(new LangGameExceptionClass());
			return file.genCode();
		}
		
	}

	/// <summary>
	/// 自定义枚举
	/// </summary>
	public class CustomEnumGroup : CoreData {

		/// <summary>
		/// 属性
		/// </summary>
		[AutoConvert]
		public bool isFrontend { get; set; } = true;
		[AutoConvert]
		public bool isBackend { get; set; } = true;

		[AutoConvert]
		public List<CustomEnum> values { get; set; }

		/// <summary>
		/// 生成Python代码块
		/// </summary>
		/// <returns></returns>
		public override LangElement<Python> genPyBlock() {
			if (!isBackend) return null;
			var block = new LangEnum<Python>(name, description);

			foreach (var value in values) {
				var subBlock = value.genPyBlock<LangBlock<Python>>();
				if (subBlock != null) block.addSubBlock(subBlock);
			}

			return block;
		}

		/// <summary>
		/// 生成C#代码块
		/// </summary>
		/// <returns></returns>
		public override LangElement<CSharp> genCSBlock() {
			if (!isFrontend) return null;
			var block = new LangEnum<CSharp>(name, description);

			foreach (var value in values) {
				var subBlock = value.genCSBlock<LangBlock<CSharp>>();
				if (subBlock != null) block.addSubBlock(subBlock);
			}

			return block;
		}
	}

	/// <summary>
	/// 自定义枚举
	/// </summary>
	public class CustomEnum : Enum_ {

		/// <summary>
		/// ID是否可用
		/// </summary>
		/// <returns></returns>
		protected override bool idEnable() { return false; }
	}

	#endregion

	/// <summary>
	/// 默认/内置数据
	/// </summary>
	public static class Default {
		
		/// <summary>
		/// 默认数据类型
		/// </summary>
		public static class Types {
			public static readonly GroupData Int = new GroupData("int");
			public static readonly GroupData Double = new GroupData("double");
			public static readonly GroupData Str = new GroupData("str");
			public static readonly GroupData Bool = new GroupData("bool");
			public static readonly GroupData Date_ = new GroupData("date");
			public static readonly GroupData DateTime_ = new GroupData("datetime");
			public static readonly GroupData DataTuple_ = new GroupData("[int, str]"); // 数据元组
			public static readonly GroupData Dict = new GroupData("dict");
			public static readonly GroupData Var = new GroupData("var");

			/// <summary>
			/// 初始化
			/// </summary>
			public static void initialize() { }
		}

		/// <summary>
		/// 默认Channels标签
		/// </summary>
		public static class ChannelsTags {
			public static readonly ChannelsTag Self = new ChannelsTag(0, "Self");
			public static readonly ChannelsTag NoLayer = new ChannelsTag(-1, "NoLayer");

			/// <summary>
			/// 初始化
			/// </summary>
			public static void initialize() {}
		}

		/// <summary>
		/// Django默认配置
		/// </summary>
		public static class Django {

			/// <summary>
			/// 默认字段类型
			/// </summary>
			public static class FieldTypes {
				public static readonly DjangoFieldType Auto = new DjangoFieldType("models.AutoField");

				public static readonly DjangoFieldType Char = new DjangoFieldType(
					"models.CharField", FieldEnum.Str);
				public static readonly DjangoFieldType Text = new DjangoFieldType(
					"models.TextField", FieldEnum.Str);

				public static readonly DjangoFieldType Boolean = new DjangoFieldType(
					"models.BooleanField", FieldEnum.Bool);

				public static readonly DjangoFieldType Integer = new DjangoFieldType("models.IntegerField");
				public static readonly DjangoFieldType Float = new DjangoFieldType("models.FloatField");
				public static readonly DjangoFieldType BInteger = new DjangoFieldType("models.BigIntegerField");
				public static readonly DjangoFieldType SInteger = new DjangoFieldType("models.SmallIntegerField");
				public static readonly DjangoFieldType PInteger = new DjangoFieldType("models.PositiveIntegerField");
				//public static readonly DjangoFieldType PBInteger = new DjangoFieldType("models.PositiveBigIntegerField");
				public static readonly DjangoFieldType PSInteger = new DjangoFieldType("models.PositiveSmallIntegerField");

				public static readonly DjangoFieldType Date_ = new DjangoFieldType(
					"models.DateField", FieldEnum.Time);
				public static readonly DjangoFieldType Time = new DjangoFieldType(
					"models.TimeField", FieldEnum.Time);
				public static readonly DjangoFieldType DateTime_ = new DjangoFieldType(
					"models.DateTimeField", FieldEnum.Time);

				public static readonly DjangoFieldType Email = new DjangoFieldType(
					"models.EmailField", FieldEnum.Str);

				public static readonly DjangoFieldType File = new DjangoFieldType(
					"models.FileField", FieldEnum.File);
				public static readonly DjangoFieldType Image = new DjangoFieldType(
					"models.ImageField", FieldEnum.File);

				public static readonly DjangoFieldType Binary = new DjangoFieldType(
					"models.BinaryField", FieldEnum.Bin);

				public static readonly DjangoFieldType IPAddr = new DjangoFieldType(
					"models.IPAddressField", FieldEnum.Str);
				public static readonly DjangoFieldType GenericIPAddr = new DjangoFieldType(
					"models.GenericIPAddressField", FieldEnum.Str);

				public static readonly DjangoFieldType JSON = new DjangoFieldType(
					"jsonfield.JSONField", FieldEnum.Str);

				public static readonly DjangoFieldType Foreign = new DjangoFieldType(
					"models.ForeignKey", FieldEnum.Rel);
				public static readonly DjangoFieldType OneToOne = new DjangoFieldType(
					"models.OneToOneField", FieldEnum.Rel);
				public static readonly DjangoFieldType ManyToMany = new DjangoFieldType(
					"models.ManyToManyField", FieldEnum.Rel);

				/// <summary>
				/// 初始化
				/// </summary>
				public static void initialize() { }
			}

			/// <summary>
			/// 删除选项
			/// </summary>
			public static class OnDeleteChoices {

				public static readonly DjangoOnDeleteChoice CASCADE =
					new DjangoOnDeleteChoice("models.CASCADE");
				public static readonly DjangoOnDeleteChoice PROTECT =
					new DjangoOnDeleteChoice("models.PROTECT");
				public static readonly DjangoOnDeleteChoice SET_NULL =
					new DjangoOnDeleteChoice("models.SET_NULL");
				public static readonly DjangoOnDeleteChoice SET_DEFAULT =
					new DjangoOnDeleteChoice("models.SET_DEFAULT");
				public static readonly DjangoOnDeleteChoice DO_NOTHING =
					new DjangoOnDeleteChoice("models.DO_NOTHING");

				/// <summary>
				/// 初始化
				/// </summary>
				public static void initialize() { }
			}

			/// <summary>
			/// 初始化
			/// </summary>
			public static void initialize() {
				FieldTypes.initialize();
				OnDeleteChoices.initialize();
			}
		}

		/// <summary>
		/// Unity默认配置
		/// </summary>
		public static class Unity {

			/// <summary>
			/// 默认字段类型
			/// </summary>
			public static class Models {
				public static readonly Model Int = new Model("int");
				public static readonly Model Double = new Model("double");
				public static readonly Model String = new Model("string");
				public static readonly Model Bool = new Model("bool");
				public static readonly Model Date_ = new Model("Date");
				public static readonly Model DateTime_ = new Model("DateTime");
				public static readonly Model Tuple_ = new Model("Tuple<int, string>");

				/// <summary>
				/// 初始化
				/// </summary>
				public static void initialize() { }
			}

			/// <summary>
			/// 初始化
			/// </summary>
			public static void initialize() {
				Models.initialize();
			}
		}

		/// <summary>
		/// 初始化
		/// </summary>
		public static void initialize() {
			Types.initialize();
			ChannelsTags.initialize();
			Django.initialize();
			Unity.initialize();
		}
	}

}
