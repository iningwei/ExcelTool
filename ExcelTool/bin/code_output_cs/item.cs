using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class item:Setting{
	 /// <summary>
	 /// 道具ID
	 /// 101932222  大类0+子类00+要预留类0+稀有度0+序号0000
	 /// </summary>
	 public int ID;

	 /// <summary>
	 /// 耐久度
	 /// n耐久度，显示为n（当前值）/m(满值)
	 /// </summary>
	 public uint durable;

	 /// <summary>
	 /// 大类型
	 /// 1货币
	 /// 2宝箱
	 /// 3装备
	 /// 4普通
	 /// 5功能
	 /// 6卡牌
	 /// </summary>
	 public int type;

	 /// <summary>
	 /// 子类型
	 /// 101钻石 
	 /// 102金币 
	 /// 103Ai晶体 
	 /// 104热度
	 /// 105裁决票
	 /// 106竞技积分
	 /// 107门票 
	 /// 108一般积分
	 /// 109特殊积分
	 /// 110设计图
	 /// 111宝箱材料
	 /// 112体力
	 /// 201竞技宝箱 
	 /// 202普通宝箱 
	 /// 203盲盒宝箱 
	 /// 384帽子 
	 /// 360上衣
	 /// 349裤子 
	 /// 350鞋子 
	 /// 344手表 
	 /// 381包包
	 /// </summary>
	 public int kind;

	 /// <summary>
	 /// 孙类型
	 /// 见section表
	 /// 0标识无
	 /// </summary>
	 public int list;

	 /// <summary>
	 /// 是否可升级
	 /// 0.不可升级
	 /// 1.可升级
	 /// </summary>
	 public int update;

	 /// <summary>
	 /// 基础系数下限
	 /// 数值1：数值2
	 /// 在范围之内完全随机
	 /// 均为0标识无
	 /// </summary>
	 public int[] down;

	 /// <summary>
	 /// 基础系数上限
	 /// 数值1：数值2
	 /// 在范围之内完全随机
	 /// </summary>
	 public int[] up;

	 /// <summary>
	 /// 基础等级
	 /// </summary>
	 public int level;

	 /// <summary>
	 /// 基础星级
	 /// </summary>
	 public int star;

	 /// <summary>
	 /// 是否nft类型
	 /// 0.非nft
	 /// 1.nft
	 /// </summary>
	 public int NFT;

	 /// <summary>
	 /// 时效性
	 /// 0.无
	 /// 1.赛季
	 /// n.秒数
	 /// </summary>
	 public int time;

	 /// <summary>
	 /// 掉落的组id
	 /// 0.无掉落
	 /// n.指定掉落id
	 /// </summary>
	 public int drop;

	 /// <summary>
	 /// 合成的组id
	 /// 0.无合成
	 /// n.指定合成组d
	 /// </summary>
	 public int merge;

	 /// <summary>
	 /// 堆叠方式
	 /// 0.不堆叠
	 /// 1.堆叠且精确显示
	 /// 2.堆叠且模糊显示
	 /// </summary>
	 public int quanitityType;

	 /// <summary>
	 /// 叠加上限
	 /// 0.无上限
	 /// n.上限
	 /// </summary>
	 public int quanititylimit;

	 public static string FileName = "item";
}
}