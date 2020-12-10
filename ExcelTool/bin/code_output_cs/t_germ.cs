using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class t_germ:Setting{
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
	 /// 细菌半径相关参数
	 /// [0]细菌比例为1时候的半径，[1]细菌缩放
	 /// </summary>
	 public float[] RadiusParams;

	 /// <summary>
	 /// 移动速度
	 /// </summary>
	 public float MoveSpeed;

	 /// <summary>
	 /// 血量暴击率
	 /// [0]为最低暴击率，[1]为最高暴击率。最终血量为根据公式算出的血量乘以随机的暴击率
	 /// </summary>
	 public float[] HpHitRatio;

	 /// <summary>
	 /// 是否分裂
	 /// </summary>
	 public bool IsSplit;

	 /// <summary>
	 /// 分裂后的细菌ID
	 /// </summary>
	 public int SplitGermId;

	 /// <summary>
	 /// 保护时间
	 /// 细菌生成后，在该时间段内不会受到伤害，会受到攻击，只是不会产生伤害
	 /// </summary>
	 public float ProtectTime;

	 public static string FileName = "t_germ";
}
}