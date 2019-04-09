using System;
using UnityEngine;
using System.Text;

namespace SelfTable{
public class GameSettingKVP{
	/// <summary>
	/// 能量最大值
	/// </summary>
	public static float PowerMax{
		get{
			return GameSetting_table.Instance.GetEntityByPrimaryKey("PowerMax").Value;
		}
	}
	/// <summary>
	/// 每次恢复能量点数
	/// </summary>
	public static float PowerRecoverCount{
		get{
			return GameSetting_table.Instance.GetEntityByPrimaryKey("PowerRecoverCount").Value;
		}
	}
	/// <summary>
	/// 每次恢复能量耗时，单位（秒）
	/// </summary>
	public static float PowerRecoverTime{
		get{
			return GameSetting_table.Instance.GetEntityByPrimaryKey("PowerRecoverTime").Value;
		}
	}
	/// <summary>
	/// 每次恢复钻石耗时，单位(秒)
	/// </summary>
	public static float DiamondRecoverTime{
		get{
			return GameSetting_table.Instance.GetEntityByPrimaryKey("DiamondRecoverTime").Value;
		}
	}
	/// <summary>
	/// 每次恢复钻石个数
	/// </summary>
	public static float DiamondRecoverCount{
		get{
			return GameSetting_table.Instance.GetEntityByPrimaryKey("DiamondRecoverCount").Value;
		}
	}
	/// <summary>
	/// 金币奖励，每次奖励量
	/// </summary>
	public static float CoinRewardCount{
		get{
			return GameSetting_table.Instance.GetEntityByPrimaryKey("CoinRewardCount").Value;
		}
	}
	/// <summary>
	/// 金币奖励，每次奖励时间间隔
	/// </summary>
	public static float CoinRewardTime{
		get{
			return GameSetting_table.Instance.GetEntityByPrimaryKey("CoinRewardTime").Value;
		}
	}
	/// <summary>
	/// 金币奖励，最大值
	/// </summary>
	public static float CoinRewardMax{
		get{
			return GameSetting_table.Instance.GetEntityByPrimaryKey("CoinRewardMax").Value;
		}
	}
	/// <summary>
	/// 最大关卡值
	/// </summary>
	public static float LevelMax{
		get{
			return GameSetting_table.Instance.GetEntityByPrimaryKey("LevelMax").Value;
		}
	}
	/// <summary>
	/// 每次游戏消耗的能量点
	/// </summary>
	public static float BattleCostPower{
		get{
			return GameSetting_table.Instance.GetEntityByPrimaryKey("BattleCostPower").Value;
		}
	}
}
public class GameSetting:Setting{
	 /// <summary>
	 /// 囧
	 /// 囧
	 /// </summary>
	 public string Key;

	 /// <summary>
	 /// 囧
	 /// 囧
	 /// </summary>
	 public float Value;

	 public static string FileName = "GameSetting";
}
}