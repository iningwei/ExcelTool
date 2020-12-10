using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class TrailSetting:Setting{
	 /// <summary>
	 /// 装备编号
	 /// 装备序号
	 /// </summary>
	 public int ID;

	 /// <summary>
	 /// 装备名称
	 /// 使用语言表
	 /// </summary>
	 public int Name;

	 /// <summary>
	 /// 装备类型
	 /// </summary>
	 public int UnitType;

	 /// <summary>
	 /// 频率
	 /// </summary>
	 public float Speed;

	 /// <summary>
	 /// 伤害
	 /// </summary>
	 public float Damage;

	 /// <summary>
	 /// 防御
	 /// </summary>
	 public float Defence;

	 /// <summary>
	 /// 金币收益
	 /// </summary>
	 public float CoinReward;

	 /// <summary>
	 /// 金币价值
	 /// </summary>
	 public float CoinPrice;

	 /// <summary>
	 /// 默认子弹ID
	 /// </summary>
	 public int BulletID;

	 /// <summary>
	 /// 初始等级
	 /// </summary>
	 public int DefaultLv;

	 /// <summary>
	 /// 最大等级
	 /// </summary>
	 public int MaxLv;

	 /// <summary>
	 /// 解锁类型
	 /// </summary>
	 public int UnlockType;

	 /// <summary>
	 /// 解锁值
	 /// </summary>
	 public int UnlockValue;

	 /// <summary>
	 /// 图标所在图集名
	 /// </summary>
	 public string AtlasName;

	 /// <summary>
	 /// 图标名
	 /// </summary>
	 public string SpriteName;

	 /// <summary>
	 /// 预制件名称
	 /// </summary>
	 public string PrefabName;

	 /// <summary>
	 /// 预制件的坐标
	 /// </summary>
	 public Vector3 LocalPos;

	 /// <summary>
	 /// 属性加成
	 /// 每种部件属性加成均为2种，用+分割
	 /// </summary>
	 public string PropertyPlus;

	 /// <summary>
	 /// 子弹使用的预制件名称
	 /// </summary>
	 public string BulletPrefabName;

	 /// <summary>
	 /// 子弹名称
	 /// </summary>
	 public string BulletName;

	 /// <summary>
	 /// 是否具有Damp跟随功能
	 /// </summary>
	 public bool SmoothDamp;

	 /// <summary>
	 /// 装备在发射时是否有发射动作
	 /// </summary>
	 public bool HasShootAnim;

	 /// <summary>
	 /// 发射的声音
	 /// </summary>
	 public string ShootAudioName;

	 public static string FileName = "TrailSetting";
}
}