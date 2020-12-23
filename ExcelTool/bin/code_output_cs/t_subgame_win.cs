using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class t_subgame_win:Setting{
	 /// <summary>
	 /// ID
	 /// </summary>
	 public int t_id;

	 /// <summary>
	 /// 子游戏id（跟proto中的scene_tmp_id对应）
	 /// </summary>
	 public int subgame_id;

	 /// <summary>
	 /// 中奖类型（1,bigwin; 2,megawin; 3,supermegawin; 4,jackpot）
	 /// </summary>
	 public int win_type;

	 /// <summary>
	 /// 触发条件，最小倍数
	 /// </summary>
	 public int trig_min_mul;

	 /// <summary>
	 /// 触发条件，最高倍数
	 /// </summary>
	 public int trig_max_mul;

	 /// <summary>
	 /// 是否有特效
	 /// </summary>
	 public bool has_eff;

	 /// <summary>
	 /// 入场特效id
	 /// </summary>
	 public int in_eff_id;

	 /// <summary>
	 /// 出场特效id(-1代表无对应特效)
	 /// </summary>
	 public int out_eff_id;

	 /// <summary>
	 /// 展示特效期间，是否展示赢得的金币数
	 /// </summary>
	 public bool present_with_wincount;

	 public static string FileName = "t_subgame_win";
}
}