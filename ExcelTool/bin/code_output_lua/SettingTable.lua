---@class SettingTable
local SettingTable={}

---@field public BodySetting table
---@class BodySetting:SettingTable
SettingTable.BodySetting={
	{ID=1001,Name=1008,EquipmentType=,Speed=0.8,Damage=0.8,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=1,MaxLv=999,UnlockType=1,UnlockValue=0,},
	{ID=1011,Name=1009,EquipmentType=,Speed=1,Damage=1,Defence=0,CoinReward=1.2,CoinMultiply=1.2,BulletID=1,DefaultLv=1,MaxLv=999,UnlockType=,UnlockValue=,},
}
SettingTable.GetBodyByID=function(ID)
	for i=1,#SettingTable.BodySetting do
		local tmp=SettingTable.BodySetting[i]
		if tmp.ID==ID then
			return tmp
		end
	end
	loge("error,get Body By ID:"+ID)
	return nil
end

---@field public SecondaryGunSetting table
---@class SecondaryGunSetting:SettingTable
SettingTable.SecondaryGunSetting={
	{ID=2001,Name=1010,EquipmentType=,Speed=1,Damage=1,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=,MaxLv=,UnlockType=,UnlockValue=,=,},
	{ID=2011,Name=1011,EquipmentType=,Speed=1.2,Damage=1.2,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=,MaxLv=,UnlockType=,UnlockValue=,=,},
}
SettingTable.GetSecondaryGunByID=function(ID)
	for i=1,#SettingTable.SecondaryGunSetting do
		local tmp=SettingTable.SecondaryGunSetting[i]
		if tmp.ID==ID then
			return tmp
		end
	end
	loge("error,get SecondaryGun By ID:"+ID)
	return nil
end

---@field public MissileSetting table
---@class MissileSetting:SettingTable
SettingTable.MissileSetting={
	{ID=3001,Name=1012,EquipmentType=,Speed=1,Damage=1,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=,MaxLv=,UnlockType=,UnlockValue=,=,},
	{ID=3011,Name=1013,EquipmentType=,Speed=1.2,Damage=1.2,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=,MaxLv=,UnlockType=,UnlockValue=,=,},
}
SettingTable.GetMissileByID=function(ID)
	for i=1,#SettingTable.MissileSetting do
		local tmp=SettingTable.MissileSetting[i]
		if tmp.ID==ID then
			return tmp
		end
	end
	loge("error,get Missile By ID:"+ID)
	return nil
end

---@field public TrailSetting table
---@class TrailSetting:SettingTable
SettingTable.TrailSetting={
	{ID=4001,Name=1014,EquipmentType=,Speed=0,Damage=0,Defence=0,CoinReward=0.8,CoinMultiply=0.8,BulletID=1,DefaultLv=,MaxLv=,UnlockType=,UnlockValue=,=,},
	{ID=4011,Name=1015,EquipmentType=,Speed=0,Damage=0,Defence=0,CoinReward=0.8,CoinMultiply=0.8,BulletID=1,DefaultLv=,MaxLv=,UnlockType=,UnlockValue=,=,},
}
SettingTable.GetTrailByID=function(ID)
	for i=1,#SettingTable.TrailSetting do
		local tmp=SettingTable.TrailSetting[i]
		if tmp.ID==ID then
			return tmp
		end
	end
	loge("error,get Trail By ID:"+ID)
	return nil
end

---@field public LanguageSetting table
---@class LanguageSetting:SettingTable
SettingTable.LanguageSetting={
	{Id=1000,Value="阵营:s%",},
	{Id=1001,Value="细胞数:{s%}/s%",},
	{Id=1002,Value="已占领:s%/s%",},
	{Id=1003,Value="分支数:s%/s%",},
	{Id=1004,Value="自己",},
	{Id=1005,Value="敌人",},
	{Id=1006,Value="友军",},
	{Id=1007,Value="野怪",},
	{Id=1008,Value="蓝色机身",},
	{Id=1009,Value="红色机身",},
	{Id=1010,Value="机枪散射",},
	{Id=1011,Value="闪电机枪",},
	{Id=1012,Value="爆破",},
	{Id=1013,Value="粘弹",},
	{Id=1014,Value="蓝色尾翼",},
	{Id=1015,Value="红色尾翼",},
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

---@field public GameSetting table
---@class GameSetting:SettingTable
SettingTable.GameSetting={
	PowerMax=80,--能量最大值
	PowerRecoverCount=1,--每次恢复能量点数
	PowerRecoverTime=300,--每次恢复能量耗时，单位（秒）
	DiamondRecoverTime=4000,--每次恢复钻石耗时，单位(秒)
	DiamondRecoverCount=0,--每次恢复钻石个数
	CoinRewardCount=10,--金币奖励，每次奖励量
	CoinRewardTime=10,--金币奖励，每次奖励时间间隔
	CoinRewardMax=100,--金币奖励，最大值
}
return SettingTable