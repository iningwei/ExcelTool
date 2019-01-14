using System;
using System.Text;

namespace SelfTable{
public class EnviromentGermSetting{
	 /// <summary>
	 /// 编号
	 ///  细菌的等级
	 /// </summary>
	 public int Level;

	 /// <summary>
	 /// 容量
	 /// 细菌最大承载细胞数
	 /// </summary>
	 public int Capacity;

	 /// <summary>
	 /// 野怪细菌被占领需要的细胞数
	 /// </summary>
	 public int InvadeNeeded;

	 /// <summary>
	 /// 初始数量
	 /// 细菌被占领后的初始数量
	 /// </summary>
	 public int InitCount;

	 /// <summary>
	 /// 细菌直径
	 /// 单位 米
	 /// </summary>
	 public float Size;

	 public static string FileName = "EnviromentGermSetting";
}
}