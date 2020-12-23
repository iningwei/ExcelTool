using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class t_subgame_client_scroll_axis:Setting{
	 /// <summary>
	 /// ID
	 /// </summary>
	 public int t_id;

	 /// <summary>
	 /// 子游戏id（跟proto中的scene_tmp_id对应）
	 /// </summary>
	 public int subgame_id;

	 /// <summary>
	 /// 轴索引
	 /// </summary>
	 public int axis_index;

	 /// <summary>
	 /// 
	 /// </summary>
	 public int[] axis_item_array;

	 public static string FileName = "t_subgame_client_scroll_axis";
}
}