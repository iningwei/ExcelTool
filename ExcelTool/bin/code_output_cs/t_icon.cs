using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class t_iconKVP{
	/// <summary>
	/// 速度（速率）
	/// </summary>
	public static string[] Speed{
		get{
			return t_iconReader.Instance.GetEntityByPrimaryKey("Speed").Value;
		}
	}
	/// <summary>
	/// 伤害
	/// </summary>
	public static string[] Damage{
		get{
			return t_iconReader.Instance.GetEntityByPrimaryKey("Damage").Value;
		}
	}
	/// <summary>
	/// 防御
	/// </summary>
	public static string[] Defence{
		get{
			return t_iconReader.Instance.GetEntityByPrimaryKey("Defence").Value;
		}
	}
	/// <summary>
	/// 金币价值
	/// </summary>
	public static string[] CoinPrice{
		get{
			return t_iconReader.Instance.GetEntityByPrimaryKey("CoinPrice").Value;
		}
	}
	/// <summary>
	/// 金币收益
	/// </summary>
	public static string[] CoinGain{
		get{
			return t_iconReader.Instance.GetEntityByPrimaryKey("CoinGain").Value;
		}
	}
}
public class t_icon:Setting{
	 /// <summary>
	 /// 
	 ///  
	 /// </summary>
	 public string Key;

	 /// <summary>
	 /// 
	 /// [0]为图集名，[1]为精灵名
	 /// </summary>
	 public string[] Value;

	 public static string FileName = "t_icon";
}
}