using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class t_subgame_vip:Setting{
	 /// <summary>
	 /// ID
	 /// </summary>
	 public int t_id;

	 /// <summary>
	 /// 子游戏id（跟proto中的scene_tmp_id对应）
	 /// </summary>
	 public int subgame_id;

	 /// <summary>
	 /// 游戏名
	 /// </summary>
	 public string name;

	 /// <summary>
	 /// 显示名字
	 /// </summary>
	 public string shown_name;

	 /// <summary>
	 /// 美术工程包
	 /// </summary>
	 public string ui_package_name;

	 /// <summary>
	 /// 窗体名(也是脚本名)
	 /// </summary>
	 public string window_name;

	 /// <summary>
	 /// SPIN请求消息名
	 /// </summary>
	 public string spin_order_name;

	 /// <summary>
	 /// 大厅房间内的图标(包名|资源名)
	 /// </summary>
	 public string hall_room_slot_icon;

	 /// <summary>
	 /// 是否有神秘奖池
	 /// </summary>
	 public bool has_jackpot;

	 /// <summary>
	 /// jackpot使用的图标（包名|资源名）
	 /// </summary>
	 public string jackpot_shown_icon;

	 /// <summary>
	 /// 特效id:大厅内slot图片的外发光
	 /// </summary>
	 public int eff_hall_slot_light;

	 /// <summary>
	 /// 特效id:大厅内slot图片上按钮
	 /// </summary>
	 public int eff_hall_slot_button;

	 /// <summary>
	 /// 特效id:大厅内slot图片上闪光灯效果
	 /// </summary>
	 public int eff_hall_slot_flash;

	 /// <summary>
	 /// 展示图标(包名|资源名)（比如用于个人信息界面最喜欢的SLOTS）
	 /// </summary>
	 public string showcase_icon;

	 /// <summary>
	 /// 转轴轴数
	 /// </summary>
	 public int axes_count;

	 /// <summary>
	 /// 是否正在更新
	 /// </summary>
	 public bool is_updating;

	 /// <summary>
	 /// 说明
	 /// </summary>
	 public string des;

	 public static string FileName = "t_subgame_vip";
}
}