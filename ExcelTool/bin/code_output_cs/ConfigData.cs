using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class ConfigData:Setting{
	 /// <summary>
	 /// 配置编号
	 /// </summary>
	 public int ID;

	 /// <summary>
	 /// 值
	 /// </summary>
	 public string Value;

	 public static string FileName = "tb_ConfigData";
}
}