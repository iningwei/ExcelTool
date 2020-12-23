using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class t_subgame_server_scroll_axis:Setting{
	 /// <summary>
	 /// ID
	 /// </summary>
	 public int t_id;

	 /// <summary>
	 /// 子游戏id（跟proto中的scene_tmp_id对应）
	 /// </summary>
	 public int subgame_id;

	 /// <summary>
	 /// 组编号
	 /// </summary>
	 public int axis_group_id;

	 /// <summary>
	 /// 组中的索引
	 /// </summary>
	 public int axis_index;

	 /// <summary>
	 /// 
	 /// </summary>
	 public int[] publish_axis_item_array;

	 /// <summary>
	 /// 
	 /// </summary>
	 public int[] axis_item_array;

	 /// <summary>
	 /// 
	 /// </summary>
	 public  ;

	 public static string FileName = "t_subgame_server_scroll_axis";
}
}