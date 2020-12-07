using System;
using System.Collections.Generic;

namespace ExermonDevManager.Core.Managers {

	using CodeGen;

	/// <summary>
	/// 语言管理类
	/// </summary>
	public static class LanguageManager {

		#region 语言管理

		/// <summary>
		/// 语言字典
		/// </summary>
		static Dictionary<string, ILanguage> languages =
			new Dictionary<string, ILanguage>();

		/// <summary>
		/// 获取语言对象
		/// </summary>
		/// <param name="language"></param>
		/// <returns></returns>
		public static ILanguage getLanguage(string language) {
			language = language.ToLower();
			if (languages.ContainsKey(language))
				return languages[language];
			return null;
		}

		/// <summary>
		/// 初始化
		/// </summary>
		public static void initialize() {
			registerLanguage<CSharp>();
			registerLanguage<Python>();
		}

		/// <summary>
		/// 注册语言
		/// </summary>
		static void registerLanguage<T>() where T : Language<T>, new() {
			var lang = Language<T>.Get();
			languages.Add(lang.langName.ToLower(), lang);
		}

		#endregion

	}
}
