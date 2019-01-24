---@class SettingTable
local SettingTable={}

---@field public EnviromentGermSetting table
---@class EnviromentGermSetting:SettingTable
SettingTable.EnviromentGermSetting={
	{Level=0,Capacity=40,InvadeNeeded=5,InitCount=28,Size=1.2,},
	{Level=1,Capacity=60,InvadeNeeded=10,InitCount=48,Size=1.2,},
	{Level=2,Capacity=100,InvadeNeeded=20,InitCount=80,Size=1.2,},
	{Level=3,Capacity=150,InvadeNeeded=50,InitCount=120,Size=1.2,},
	{Level=4,Capacity=200,InvadeNeeded=80,InitCount=160,Size=1.2,},
}
SettingTable.GetEnviromentGermByLevel=function(Level)
	for i=1,#SettingTable.EnviromentGermSetting do
		local tmp=SettingTable.EnviromentGermSetting[i]
		if tmp.Level==Level then
			return tmp
		end
	end
	loge("error,get EnviromentGerm By Level:"+Level)
	return nil
end

---@field public LanguageSetting table
---@class LanguageSetting:SettingTable
SettingTable.LanguageSetting={
	{Id=1000,Value="阵营:s%",},
	{Id=1001,Value="细胞数:s%}/s%",},
	{Id=1002,Value="已占领:s%/s%",},
	{Id=1003,Value="分支数:s%/s%",},
	{Id=1004,Value="自己",},
	{Id=1005,Value="敌人",},
	{Id=1006,Value="友军",},
	{Id=1007,Value="野怪",},
}
SettingTable.GetLanguageById=function(Id)
	for i=1,#SettingTable.LanguageSetting do
		local tmp=SettingTable.LanguageSetting[i]
		if tmp.Id==Id then
			return tmp
		end
	end
	loge("error,get Language By Id:"+Id)
	return nil
end

---@field public BattleSceneSetting table
---@class BattleSceneSetting:SettingTable
SettingTable.BattleSceneSetting={
	BuildBridgeSpeed=1.4,--搭桥的速度，即每秒钟桥生长的距离（米）
	BridgeCellSize=0.28,--搭桥细胞的尺寸，单位（米）
	BridgeNeighborCellDis=0.28,--搭桥两相邻细胞之间的距离（中心点距离），单位（米）
	BridgeShootCellMinDuration=600,--桥搭建完成后发射细胞的最短时间间隔，单位（毫秒）
	BrokenBridgeRatio=6,--自己主动拆自己的桥的时候，value=建桥时细胞生成时间间隔/细胞消失时间间隔
}
return SettingTable