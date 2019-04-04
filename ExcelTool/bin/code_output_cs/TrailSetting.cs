using System;
using System.Text;

namespace SelfTable{
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
	 /// 囧
	 /// </summary>
	 public int UnitType;

	 /// <summary>
	 /// 频率
	 /// 囧
	 /// </summary>
	 public float Speed;

	 /// <summary>
	 /// 伤害
	 /// 囧
	 /// </summary>
	 public float Damage;

	 /// <summary>
	 /// 防御
	 /// 囧
	 /// </summary>
	 public float Defence;

	 /// <summary>
	 /// 金币收益
	 /// 囧
	 /// </summary>
	 public float CoinReward;

	 /// <summary>
	 /// 金币价值
	 /// 囧
	 /// </summary>
	 public float CoinPrice;

	 /// <summary>
	 /// 默认子弹ID
	 /// 囧
	 /// </summary>
	 public int BulletID;

	 /// <summary>
	 /// 初始等级
	 /// 囧
	 /// </summary>
	 public int DefaultLv;

	 /// <summary>
	 /// 最大等级
	 /// 囧
	 /// </summary>
	 public int MaxLv;

	 /// <summary>
	 /// 解锁类型
	 /// 囧
	 /// </summary>
	 public int UnlockType;

	 /// <summary>
	 /// 解锁值
	 /// 囧
	 /// </summary>
	 public int UnlockValue;

	 /// <summary>
	 /// 图标所在图集名
	 /// 囧
	 /// </summary>
	 public string AtlasName;

	 /// <summary>
	 /// 图标名
	 /// 囧
	 /// </summary>
	 public string SpriteName;

	 /// <summary>
	 /// 属性加成
	 /// 每种部件属性加成均为2种，用+分割
	 /// </summary>
	 public string PropertyPlus;

	 /// <summary>
	 /// 子弹使用的预制件名称
	 /// 囧
	 /// </summary>
	 public string BulletPrefabName;

	 /// <summary>
	 /// 子弹名称
	 /// 囧
	 /// </summary>
	 public string BulletName;

	 public static string FileName = "TrailSetting";
}
}