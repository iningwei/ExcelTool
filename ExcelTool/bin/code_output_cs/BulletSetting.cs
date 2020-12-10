using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
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

	 /// <summary>
	 /// 子弹在Y方向上长度
	 /// 对于鞭子子弹，其会生成从发射点到终点的鞭子，该值限定鞭子的Y方向总长度
	 /// </summary>
	 public float Ylength;

	 /// <summary>
	 /// 伤害时间间隔
	 /// 对于HitType为2的子弹有效，每隔设定的时间计算一次伤害
	 /// </summary>
	 public float HarmInterval;

	 /// <summary>
	 /// 子弹自己的独特参数
	 /// 1：对于鞭子子弹：[0]为一个鞭子最多串联的细菌数，该值要大于等于1；    [1]为鞭子搜索细菌限定夹角，该夹角为发射点的up方向和细菌之间的角度，范围(0,90]          2：对于雷射子弹：[0]为子弹的宽度
	 /// </summary>
	 public float[] UniqueParams;

	 /// <summary>
	 /// 是否限制坐标
	 /// 若限制了坐标，那么射出的子弹将不会移动，且在生命周期内，永远跟生产它的位置保持一致。
	 /// </summary>
	 public bool RestrictPos;

	 /// <summary>
	 /// 子弹是否有准备动作
	 /// 有的话需要先播放准备动作
	 /// </summary>
	 public bool HasPrepareAnim;

	 /// <summary>
	 /// 子弹是否有消失的动作
	 /// 有的话，需要先播放消失动作，然后才能销毁。
	 /// </summary>
	 public bool HasVanishAnim;

	 /// <summary>
	 /// 子弹击中怪物，子弹是否具有受击特效
	 /// </summary>
	 public bool HasHitEffect;

	 /// <summary>
	 /// 子弹击中怪物后，要显示的特效名称
	 /// </summary>
	 public string HitEffectName;

	 /// <summary>
	 /// 子弹爆炸音效名字
	 /// </summary>
	 public string BoomAudioName;

	 public static string FileName = "BulletSetting";
}
}