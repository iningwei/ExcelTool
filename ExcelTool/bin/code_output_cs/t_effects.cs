using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class t_effects:Setting{
	 /// <summary>
	 /// 特效编号
	 /// </summary>
	 public int ID;

	 /// <summary>
	 /// 特效名称
	 /// </summary>
	 public string ResName;

	 /// <summary>
	 /// 特效类型
	 /// </summary>
	 public string ResType;

	 /// <summary>
	 /// 播放时长
	 /// 0表示循环播放，>0则需要自动移除
	 /// </summary>
	 public float Time;

	 public static string FileName = "t_effects";
}
}