using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class t_subgame_slot_icon:Setting{
	 /// <summary>
	 /// ID
	 /// </summary>
	 public int t_id;

	 /// <summary>
	 /// 子游戏id（跟proto中的scene_tmp_id对应）
	 /// </summary>
	 public int subgame_id;

	 /// <summary>
	 /// 图标ID
	 /// </summary>
	 public int icon_id;

	 /// <summary>
	 /// 所在包名
	 /// </summary>
	 public string package_name;

	 /// <summary>
	 /// 资源名
	 /// </summary>
	 public string res_name;

	 /// <summary>
	 /// 对应的特效ID（-1表示没有特效）
	 /// </summary>
	 public int effect_id;

	 /// <summary>
	 /// 说明
	 /// </summary>
	 public string des;

	 public static string FileName = "t_subgame_slot_icon";
}
}