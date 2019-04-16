using System;
using UnityEngine;
using System.Text;

namespace SelfTable{
public class BulletSetting:Setting{
	 /// <summary>
	 /// 子弹名
	 /// 和类名唯一对应
	 /// </summary>
	 public string Name;

	 /// <summary>
	 /// 子弹移动速度
	 /// </summary>
	 public float MoveSpeed;

	 /// <summary>
	 /// 伤害类型
	 /// 0点伤，1范围伤，2持续伤害
	 /// </summary>
	 public int HitType;

	 /// <summary>
	 /// 伤害范围
	 /// HitType为范围伤时有效
	 /// </summary>
	 public float Area;

	 /// <summary>
	 /// 自动销毁类型
	 /// 0出界，1到达一定时间
	 /// </summary>
	 public int AutoDestroyType;

	 /// <summary>
	 /// 子弹生命时间
	 /// 当AutoDestroyType为1时有效
	 /// </summary>
	 public float LifeTime;

	 public static string FileName = "BulletSetting";
}
}