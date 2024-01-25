using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class LanguageData{
	 /// <summary>
	 /// 序号
	 /// 语言表ID
	 /// </summary>
	 public int ID;

	 /// <summary>
	 /// 英文
	 /// </summary>
	 public string EN;

	 /// <summary>
	 /// 中文简体
	 /// </summary>
	 public string CN;

	 /// <summary>
	 /// 中文繁体
	 /// </summary>
	 public string TC;

	 public static string FileName = "tb_languagedata";
}
}