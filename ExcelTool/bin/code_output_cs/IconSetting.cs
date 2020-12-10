using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class IconSettingKVP{
	/// <summary>
	/// 速度（速率）
	/// </summary>
	public static string[] Speed{
		get{
			return IconSettingReader.Instance.GetEntityByPrimaryKey("Speed").Value;
		}
	}
	/// <summary>
	/// 伤害
	/// </summary>
	public static string[] Damage{
		get{
			return IconSettingReader.Instance.GetEntityByPrimaryKey("Damage").Value;
		}
	}
	/// <summary>
	/// 防御
	/// </summary>
	public static string[] Defence{
		get{
			return IconSettingReader.Instance.GetEntityByPrimaryKey("Defence").Value;
		}
	}
	/// <summary>
	/// 金币价值
	/// </summary>
	public static string[] CoinPrice{
		get{
			return IconSettingReader.Instance.GetEntityByPrimaryKey("CoinPrice").Value;
		}
	}
	/// <summary>
	/// 金币收益
	/// </summary>
	public static string[] CoinGain{
		get{
			return IconSettingReader.Instance.GetEntityByPrimaryKey("CoinGain").Value;
		}
	}
}
public class IconSetting:Setting{
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

	 public static string FileName = "IconSetting";
}
}