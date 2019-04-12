using System;
using UnityEngine;
using System.Text;

namespace SelfTable{
public class GermSetting:Setting{
	 /// <summary>
	 /// 细菌id
	 /// ID唯一标识细菌类型
	 /// </summary>
	 public int ID;

	 /// <summary>
	 /// 细菌名字
	 /// 跟具体细菌的类名字一致
	 /// </summary>
	 public string Name;

	 /// <summary>
	 /// 预制体名字
	 /// </summary>
	 public string PrefabName;

	 /// <summary>
	 /// 细菌半径
	 /// </summary>
	 public float Radius;

	 /// <summary>
	 /// 移动速度
	 /// </summary>
	 public float MoveSpeed;

	 public static string FileName = "GermSetting";
}
}