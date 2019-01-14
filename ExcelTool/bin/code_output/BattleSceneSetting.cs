using System;
using System.Text;

namespace SelfTable{
public class BattleSceneSettingKVP{
	/// <summary>
	/// 搭桥的速度，即每秒钟桥生长的距离（米）
	/// </summary>
	public static float BuildBridgeSpeed{
		get{
			return BattleSceneSetting_table.Instance.GetEntityByPrimaryKey("BuildBridgeSpeed").Value;
		}
	}
	/// <summary>
	/// 搭桥细胞的尺寸，单位（米）
	/// </summary>
	public static float BridgeCellSize{
		get{
			return BattleSceneSetting_table.Instance.GetEntityByPrimaryKey("BridgeCellSize").Value;
		}
	}
	/// <summary>
	/// 搭桥两相邻细胞之间的距离（中心点距离），单位（米）
	/// </summary>
	public static float BridgeNeighborCellDis{
		get{
			return BattleSceneSetting_table.Instance.GetEntityByPrimaryKey("BridgeNeighborCellDis").Value;
		}
	}
	/// <summary>
	/// 桥搭建完成后发射细胞的最短时间间隔，单位（毫秒）
	/// </summary>
	public static float BridgeShootCellMinDuration{
		get{
			return BattleSceneSetting_table.Instance.GetEntityByPrimaryKey("BridgeShootCellMinDuration").Value;
		}
	}
	/// <summary>
	/// 自己主动拆自己的桥的时候，value=建桥时细胞生成时间间隔/细胞消失时间间隔
	/// </summary>
	public static float BrokenBridgeRatio{
		get{
			return BattleSceneSetting_table.Instance.GetEntityByPrimaryKey("BrokenBridgeRatio").Value;
		}
	}
}
public class BattleSceneSetting{
	 /// <summary>
	 /// 
	 /// </summary>
	 public string Key;

	 /// <summary>
	 /// 
	 /// </summary>
	 public float Value;

	 public static string FileName = "BattleSceneSetting";
}
}