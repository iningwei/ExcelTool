---@class SettingTable
local SettingTable={}

---@field public BodySetting table
---@class BodySetting:SettingTable
SettingTable.BodySetting={
	{ID=1001,Name=100,UnitType=1,Speed=0.8,Damage=0.8,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=1,MaxLv=99,UnlockType=1,UnlockValue=0,AtlasName="PreparePage",SpriteName="组5拷贝2@2x-1001",PropertyPlus="1+2",},
	{ID=1011,Name=101,UnitType=1,Speed=1,Damage=1,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=1,MaxLv=99,UnlockType=1,UnlockValue=2,AtlasName="PreparePage",SpriteName="组5拷贝2@2x-1011",PropertyPlus="1+2",},
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
	{ID=2001,Name=1010,UnitType=2,Speed=1,Damage=1,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=1,MaxLv=19,UnlockType=1,UnlockValue=5,AtlasName="PreparePage",SpriteName="机枪1",PropertyPlus="1+2",},
	{ID=2011,Name=1011,UnitType=2,Speed=1.2,Damage=1.2,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=1,MaxLv=19,UnlockType=1,UnlockValue=6,AtlasName="PreparePage",SpriteName="机枪2",PropertyPlus="1+2",},
	{ID=2021,Name=1012,UnitType=2,Speed=1.3,Damage=1.3,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=1,MaxLv=19,UnlockType=1,UnlockValue=8,AtlasName="PreparePage",SpriteName="机枪3",PropertyPlus="1+2",},
	{ID=2031,Name=1013,UnitType=2,Speed=1.5,Damage=1.5,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=1,MaxLv=19,UnlockType=1,UnlockValue=12,AtlasName="PreparePage",SpriteName="机枪4",PropertyPlus="1+2",},
	{ID=2041,Name=1014,UnitType=2,Speed=2,Damage=2,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=1,MaxLv=19,UnlockType=1,UnlockValue=24,AtlasName="PreparePage",SpriteName="机枪5",PropertyPlus="1+2",},
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
	{ID=3001,Name=1020,UnitType=3,Speed=1,Damage=4,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=1,MaxLv=49,UnlockType=1,UnlockValue=11,AtlasName="PreparePage",SpriteName="导弹1",PropertyPlus="1+2",},
	{ID=3011,Name=1021,UnitType=3,Speed=1.1,Damage=5,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=1,MaxLv=49,UnlockType=1,UnlockValue=13,AtlasName="PreparePage",SpriteName="导弹2",PropertyPlus="1+2",},
	{ID=3021,Name=1022,UnitType=3,Speed=1,Damage=7,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=1,MaxLv=49,UnlockType=1,UnlockValue=21,AtlasName="PreparePage",SpriteName="导弹3",PropertyPlus="1+2",},
	{ID=3031,Name=1023,UnitType=3,Speed=1.2,Damage=9,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=1,MaxLv=49,UnlockType=1,UnlockValue=22,AtlasName="PreparePage",SpriteName="导弹4",PropertyPlus="1+2",},
	{ID=3041,Name=1024,UnitType=3,Speed=1,Damage=12,Defence=0,CoinReward=0,CoinMultiply=0,BulletID=1,DefaultLv=1,MaxLv=49,UnlockType=1,UnlockValue=32,AtlasName="PreparePage",SpriteName="导弹5",PropertyPlus="1+2",},
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
	{ID=4001,Name=1030,UnitType=4,Speed=0,Damage=0,Defence=0,CoinReward=0.8,CoinMultiply=0.8,BulletID=1,DefaultLv=1,MaxLv=199,UnlockType=1,UnlockValue=2222,AtlasName="PreparePage",SpriteName="拖尾1",PropertyPlus="4+5",},
	{ID=4011,Name=1031,UnitType=4,Speed=0,Damage=0,Defence=0,CoinReward=0.8,CoinMultiply=0.8,BulletID=1,DefaultLv=1,MaxLv=199,UnlockType=1,UnlockValue=3333,AtlasName="PreparePage",SpriteName="拖尾2",PropertyPlus="4+5",},
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
	{Id=1,Value="lv:{0}",},
	{Id=100,Value="奥特曼机身，奥特曼一般的感觉",},
	{Id=101,Value="我就是地球超人",},
	{Id=102,Value="信不信俺老孙教你做人",},
	{Id=103,Value="我是宇宙最强机甲，钛合金X元素机身",},
	{Id=104,Value="机身5未知",},
	{Id=105,Value="谜团、黑洞、主宰",},
	{Id=1010,Value="机枪散射",},
	{Id=1011,Value="闪电机枪",},
	{Id=1012,Value="机枪111",},
	{Id=1013,Value="机枪222",},
	{Id=1014,Value="机枪333",},
	{Id=1020,Value="爆破",},
	{Id=1021,Value="粘弹",},
	{Id=1022,Value="响尾蛇",},
	{Id=1023,Value="虎蛇",},
	{Id=1024,Value="东风",},
	{Id=1030,Value="蓝色尾翼",},
	{Id=1031,Value="红色尾翼",},
	{Id=2000,Value="速度:{0}",},
	{Id=2001,Value="伤害:{0}",},
	{Id=2002,Value="防御:{0}",},
	{Id=2003,Value="金币收益:{0}",},
	{Id=2004,Value="金币价值:{0}",},
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
	PowerRecoverCount=10,--每次恢复能量点数
	PowerRecoverTime=10,--每次恢复能量耗时，单位（秒）
	DiamondRecoverTime=4000,--每次恢复钻石耗时，单位(秒)
	DiamondRecoverCount=0,--每次恢复钻石个数
	CoinRewardCount=800,--金币奖励，每次奖励量
	CoinRewardTime=8,--金币奖励，每次奖励时间间隔
	CoinRewardMax=9999,--金币奖励，最大值
	LevelMax=9999,--最大关卡值
	BattleCostPower=5,--每次游戏消耗的能量点
}

---@field public IconSetting table
---@class IconSetting:SettingTable
SettingTable.IconSetting={
	Speed=PreparePage|速度,--速度（速率）
	Damage=PreparePage|伤害,--伤害
	Defence=PreparePage|防御,--防御
	CoinPrice=PreparePage|金币价值,--金币价值
	CoinGain=PreparePage|金币收益,--金币收益
}
return SettingTable