using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class LanguageSetting:Setting{
	 /// <summary>
	 /// 语言表id
	 /// </summary>
	 public int Id;

	 /// <summary>
	 /// 具体内容
	 /// </summary>
	 public string Value;

	 public static string FileName = "LanguageSetting";
}
}