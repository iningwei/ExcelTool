using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class GameSettingKVP{
	/// <summary>
	/// 能量最大值
	/// </summary>
	public static object PowerMax{
		get{
			return GameSettingReader.Instance.GetEntityByPrimaryKey("PowerMax").Value;
		}
	}
	/// <summary>
	/// 每次恢复能量点数
	/// </summary>
	public static object PowerRecoverCount{
		get{
			return GameSettingReader.Instance.GetEntityByPrimaryKey("PowerRecoverCount").Value;
		}
	}
	/// <summary>
	/// 每次恢复能量耗时，单位（秒）
	/// </summary>
	public static object PowerRecoverTime{
		get{
			return GameSettingReader.Instance.GetEntityByPrimaryKey("PowerRecoverTime").Value;
		}
	}
	/// <summary>
	/// 每次恢复钻石耗时，单位(秒)
	/// </summary>
	public static object DiamondRecoverTime{
		get{
			return GameSettingReader.Instance.GetEntityByPrimaryKey("DiamondRecoverTime").Value;
		}
	}
	/// <summary>
	/// 每次恢复钻石个数
	/// </summary>
	public static object DiamondRecoverCount{
		get{
			return GameSettingReader.Instance.GetEntityByPrimaryKey("DiamondRecoverCount").Value;
		}
	}
	/// <summary>
	/// 金币奖励，每次奖励量
	/// </summary>
	public static object CoinRewardCount{
		get{
			return GameSettingReader.Instance.GetEntityByPrimaryKey("CoinRewardCount").Value;
		}
	}
	/// <summary>
	/// 金币奖励，每次奖励时间间隔
	/// </summary>
	public static object CoinRewardTime{
		get{
			return GameSettingReader.Instance.GetEntityByPrimaryKey("CoinRewardTime").Value;
		}
	}
	/// <summary>
	/// 金币奖励，最大值
	/// </summary>
	public static object CoinRewardMax{
		get{
			return GameSettingReader.Instance.GetEntityByPrimaryKey("CoinRewardMax").Value;
		}
	}
	/// <summary>
	/// 最大关卡值
	/// </summary>
	public static object LevelMax{
		get{
			return GameSettingReader.Instance.GetEntityByPrimaryKey("LevelMax").Value;
		}
	}
	/// <summary>
	/// 每次游戏消耗的能量点
	/// </summary>
	public static object BattleCostPower{
		get{
			return GameSettingReader.Instance.GetEntityByPrimaryKey("BattleCostPower").Value;
		}
	}
	/// <summary>
	/// 飞机机头半径
	/// </summary>
	public static object PlaneHeadRadius{
		get{
			return GameSettingReader.Instance.GetEntityByPrimaryKey("PlaneHeadRadius").Value;
		}
	}
}
public class GameSetting:Setting{
	 /// <summary>
	 /// 
	 /// </summary>
	 public string Key;

	 /// <summary>
	 /// 
	 /// </summary>
	 public object Value;

	 public static string FileName = "GameSetting";
}
}