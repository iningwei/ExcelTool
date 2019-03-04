---@class SettingTable
local SettingTable={}

---@field public GunNormalDamageSetting table
---@class GunNormalDamageSetting:SettingTable
SettingTable.GunNormalDamageSetting={
	{Level=0,Damage=1,Price=10,},
	{Level=1,Damage=2,Price=20,},
	{Level=2,Damage=4,Price=40,},
	{Level=3,Damage=5,Price=100,},
	{Level=4,Damage=7,Price=200,},
	{Level=5,Damage=8,Price=500,},
	{Level=6,Damage=10,Price=1200,},
	{Level=7,Damage=12,Price=2500,},
	{Level=8,Damage=13,Price=5000,},
	{Level=9,Damage=15,Price=12000,},
	{Level=10,Damage=18,Price=,},
}
SettingTable.GetGunNormalDamageByLevel=function(Level)
	for i=1,#SettingTable.GunNormalDamageSetting do
		local tmp=SettingTable.GunNormalDamageSetting[i]
		if tmp.Level==Level then
			return tmp
		end
	end
	loge("error,get GunNormalDamage By Level:"+Level)
	return nil
end

---@field public GunNormalSpeedSetting table
---@class GunNormalSpeedSetting:SettingTable
SettingTable.GunNormalSpeedSetting={
	{Level=0,Speed=1,Price=5,},
	{Level=1,Speed=2,Price=10,},
	{Level=2,Speed=4,Price=20,},
	{Level=3,Speed=5,Price=40,},
	{Level=4,Speed=7,Price=100,},
	{Level=5,Speed=8,Price=200,},
	{Level=6,Speed=10,Price=500,},
	{Level=7,Speed=12,Price=1000,},
	{Level=8,Speed=13,Price=2000,},
	{Level=9,Speed=15,Price=5000,},
	{Level=10,Speed=18,Price=,},
}
SettingTable.GetGunNormalSpeedByLevel=function(Level)
	for i=1,#SettingTable.GunNormalSpeedSetting do
		local tmp=SettingTable.GunNormalSpeedSetting[i]
		if tmp.Level==Level then
			return tmp
		end
	end
	loge("error,get GunNormalSpeed By Level:"+Level)
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