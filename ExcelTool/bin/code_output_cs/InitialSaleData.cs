using System;
using UnityEngine;
using System.Text;

namespace ZGame.ZTable{
public class InitialSaleData{
	 /// <summary>
	 /// 编号
	 /// 备注
	 /// </summary>
	 public long ID;

	 /// <summary>
	 /// 首发物品ID
	 /// </summary>
	 public long itemId;

	 /// <summary>
	 /// 价格/元
	 /// </summary>
	 public float price;

	 /// <summary>
	 /// 是否上架苹果商店
	 /// </summary>
	 public bool listOnStore;

	 /// <summary>
	 /// 苹果商店支付码
	 /// </summary>
	 public string storePayCode;

	 /// <summary>
	 /// 苹果商店价格¥
	 /// </summary>
	 public float storePrice;

	 /// <summary>
	 /// 可购买日期分段
	 /// 时间段类型 1-绝对时间段 2-相对时间段
	 /// 1，绝对时间1，绝对时间2
	 /// 2，起始时间，持续天数
	 /// 以分号间隔多个
	 /// </summary>
	 public string limitDatePart;

	 /// <summary>
	 /// 每日可购买时间分段
	 /// 时间段，以分号分隔
	 /// </summary>
	 public string limitDayTimePart;

	 /// <summary>
	 /// 个人限购数量
	 /// 0-不限购
	 /// </summary>
	 public int limitNumRole;

	 public static string FileName = "tb_initialsaledata";
}
}