---@class ConfigTable
local ConfigTable={}

---@class t_body:ConfigTable
ConfigTable.t_body={
	[10001]={ID= 10001 ,Name= 100 ,UnitType= 1 ,Speed= 1 ,Damage= 1 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 99 ,UnlockType= 1 ,UnlockValue= 0 ,AtlasName="PlaneFactory",SpriteName="10001",PrefabName="body10001",LocalPos={0,0,0},PropertyPlus="1+2",BulletPrefabName="bullet1",BulletName="ZGame.Logic.BulletNormal",SmoothDamp= false ,HasShootAnim= false ,ShootAudioName="shoot1",},
	[20001]={ID= 20001 ,Name= 101 ,UnitType= 1 ,Speed= 1 ,Damage= 2 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 99 ,UnlockType= 1 ,UnlockValue= 0 ,AtlasName="PlaneFactory",SpriteName="20001",PrefabName="body20001",LocalPos={0,0,0},PropertyPlus="1+2",BulletPrefabName="bullet1",BulletName="ZGame.Logic.BulletNormal2",SmoothDamp= false ,HasShootAnim= false ,ShootAudioName="shoot1",},
}
local mt_t_body={}
mt_t_body.__index=function(t,k)
	LogE("can not find item with key:"..k.." in t_body")
end
setmetatable(ConfigTable.t_body,mt_t_body)


---@class t_secondaryGun:ConfigTable
ConfigTable.t_secondaryGun={
	[11001]={ID= 11001 ,Name= 1010 ,UnitType= 2 ,Speed= 1 ,Damage= 1 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 33 ,UnlockType= 1 ,UnlockValue= 1 ,AtlasName="PlaneFactory",SpriteName="11001",PrefabName="gun11001",LocalPos={0.095,0.076,0},PropertyPlus="1+2",BulletPrefabName="bullet5",BulletName="ZGame.Logic.BulletNormal",SmoothDamp= false ,HasShootAnim= true ,ShootAudioName="shoot1",},
	[11011]={ID= 11011 ,Name= 1016 ,UnitType= 2 ,Speed= 1 ,Damage= 1 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 33 ,UnlockType= 1 ,UnlockValue= 2 ,AtlasName="PlaneFactory",SpriteName="11011",PrefabName="gun11011",LocalPos={0.104,-0.005,0},PropertyPlus="1+2",BulletPrefabName="bullet7",BulletName="ZGame.Logic.BulletNormal",SmoothDamp= false ,HasShootAnim= true ,ShootAudioName="shoot1",},
	[11021]={ID= 11021 ,Name= 1017 ,UnitType= 2 ,Speed= 1 ,Damage= 1 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 33 ,UnlockType= 1 ,UnlockValue= 3 ,AtlasName="PlaneFactory",SpriteName="11021",PrefabName="gun11021",LocalPos={0.087,0.005,0},PropertyPlus="1+2",BulletPrefabName="bullet6",BulletName="ZGame.Logic.BulletNormal",SmoothDamp= false ,HasShootAnim= true ,ShootAudioName="shoot1",},
	[11031]={ID= 11031 ,Name= 1018 ,UnitType= 2 ,Speed= 0.2 ,Damage= 1 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 33 ,UnlockType= 1 ,UnlockValue= 4 ,AtlasName="PlaneFactory",SpriteName="11031",PrefabName="gun11031",LocalPos={0.097,0.042,0},PropertyPlus="1+2",BulletPrefabName="bullet8",BulletName="ZGame.Logic.BulletLaser",SmoothDamp= false ,HasShootAnim= false ,ShootAudioName="shoot1",},
	[11041]={ID= 11041 ,Name= 1019 ,UnitType= 2 ,Speed= 0.2 ,Damage= 1 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 33 ,UnlockType= 1 ,UnlockValue= 5 ,AtlasName="PlaneFactory",SpriteName="11041",PrefabName="gun11041",LocalPos={0.06,-0.072,0},PropertyPlus="1+2",BulletPrefabName="bullet9",BulletName="ZGame.Logic.BulletLaser2",SmoothDamp= false ,HasShootAnim= false ,ShootAudioName="shoot1",},
	[21001]={ID= 21001 ,Name= 1011 ,UnitType= 2 ,Speed= 1.2 ,Damage= 1.2 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 33 ,UnlockType= 1 ,UnlockValue= 1 ,AtlasName="PlaneFactory",SpriteName="21001",PrefabName="gun21001",LocalPos={0.089,-0.054,0},PropertyPlus="1+2",BulletPrefabName="bullet5",BulletName="ZGame.Logic.BulletNormal",SmoothDamp= false ,HasShootAnim= true ,ShootAudioName="shoot1",},
	[21011]={ID= 21011 ,Name= 1012 ,UnitType= 2 ,Speed= 1.3 ,Damage= 1.3 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 33 ,UnlockType= 1 ,UnlockValue= 2 ,AtlasName="PlaneFactory",SpriteName="21011",PrefabName="gun21011",LocalPos={0.069,-0.135,0},PropertyPlus="1+2",BulletPrefabName="bullet7",BulletName="ZGame.Logic.BulletNormal",SmoothDamp= false ,HasShootAnim= true ,ShootAudioName="shoot1",},
	[21021]={ID= 21021 ,Name= 1013 ,UnitType= 2 ,Speed= 1.5 ,Damage= 1.5 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 33 ,UnlockType= 1 ,UnlockValue= 3 ,AtlasName="PlaneFactory",SpriteName="21021",PrefabName="gun21021",LocalPos={0.039,-0.096,0},PropertyPlus="1+2",BulletPrefabName="bullet6",BulletName="ZGame.Logic.BulletNormal",SmoothDamp= false ,HasShootAnim= true ,ShootAudioName="shoot1",},
	[21031]={ID= 21031 ,Name= 1014 ,UnitType= 2 ,Speed= 0.2 ,Damage= 2 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 33 ,UnlockType= 1 ,UnlockValue= 4 ,AtlasName="PlaneFactory",SpriteName="21031",PrefabName="gun21031",LocalPos={0.07,-0.11,0},PropertyPlus="1+2",BulletPrefabName="bullet8",BulletName="ZGame.Logic.BulletLaser",SmoothDamp= false ,HasShootAnim= false ,ShootAudioName="shoot1",},
	[21041]={ID= 21041 ,Name= 1015 ,UnitType= 2 ,Speed= 0.2 ,Damage= 3 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 33 ,UnlockType= 1 ,UnlockValue= 5 ,AtlasName="PlaneFactory",SpriteName="21041",PrefabName="gun21041",LocalPos={0.041,-0.104,0},PropertyPlus="1+2",BulletPrefabName="bullet9",BulletName="ZGame.Logic.BulletLaser2",SmoothDamp= false ,HasShootAnim= false ,ShootAudioName="shoot1",},
}
local mt_t_secondaryGun={}
mt_t_secondaryGun.__index=function(t,k)
	LogE("can not find item with key:"..k.." in t_secondaryGun")
end
setmetatable(ConfigTable.t_secondaryGun,mt_t_secondaryGun)


---@class t_missile:ConfigTable
ConfigTable.t_missile={
	[12001]={ID= 12001 ,Name= 1020 ,UnitType= 3 ,Speed= 0.5 ,Damage= 4 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 49 ,UnlockType= 1 ,UnlockValue= 5 ,AtlasName="PlaneFactory",SpriteName="12001",PrefabName="missile12001",LocalPos={0,0,0},PropertyPlus="1+2",BulletPrefabName="bullet2",BulletName="ZGame.Logic.BulletRestrictDis",SmoothDamp= true ,HasShootAnim= true ,ShootAudioName="shoot1",},
	[12041]={ID= 12041 ,Name= 1032 ,UnitType= 3 ,Speed= 0.2 ,Damage= 5 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 49 ,UnlockType= 1 ,UnlockValue= 6 ,AtlasName="PlaneFactory",SpriteName="12041",PrefabName="missile12041",LocalPos={-0.08,0,0},PropertyPlus="1+2",BulletPrefabName="bullet3",BulletName="ZGame.Logic.BulletTwoFlashBall",SmoothDamp= false ,HasShootAnim= false ,ShootAudioName="shoot1",},
	[22001]={ID= 22001 ,Name= 1021 ,UnitType= 3 ,Speed= 0.2 ,Damage= 5 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 49 ,UnlockType= 1 ,UnlockValue= 5 ,AtlasName="PlaneFactory",SpriteName="22001",PrefabName="missile22001",LocalPos={0,0,0},PropertyPlus="1+2",BulletPrefabName="bulletBianZhi",BulletName="ZGame.Logic.BulletBianZhiPro",SmoothDamp= false ,HasShootAnim= true ,ShootAudioName="shoot1",},
	[22011]={ID= 22011 ,Name= 1022 ,UnitType= 3 ,Speed= 1 ,Damage= 7 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 49 ,UnlockType= 1 ,UnlockValue= 21 ,AtlasName="PlaneFactory",SpriteName="22011",PrefabName="missile22011",LocalPos={-0.31,-0.4,0},PropertyPlus="1+2",BulletPrefabName="bullet2",BulletName="ZGame.Logic.BulletRestrictDis",SmoothDamp= true ,HasShootAnim= true ,ShootAudioName="shoot1",},
	[22021]={ID= 22021 ,Name= 1023 ,UnitType= 3 ,Speed= 1.2 ,Damage= 9 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 49 ,UnlockType= 1 ,UnlockValue= 22 ,AtlasName="PlaneFactory",SpriteName="22021",PrefabName="missile22021",LocalPos={-0.43,-0.23,0},PropertyPlus="1+2",BulletPrefabName="bulletMissile1",BulletName="ZGame.Logic.BulletNormal",SmoothDamp= false ,HasShootAnim= true ,ShootAudioName="shoot1",},
	[22031]={ID= 22031 ,Name= 1024 ,UnitType= 3 ,Speed= 1 ,Damage= 12 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 49 ,UnlockType= 1 ,UnlockValue= 32 ,AtlasName="PlaneFactory",SpriteName="22031",PrefabName="missile22031",LocalPos={-0.37,-0.29,0},PropertyPlus="1+2",BulletPrefabName="bulletMissile1",BulletName="ZGame.Logic.BulletNormal",SmoothDamp= false ,HasShootAnim= true ,ShootAudioName="shoot1",},
	[22041]={ID= 22041 ,Name= 1025 ,UnitType= 3 ,Speed= 0.2 ,Damage= 12 ,Defence= 0 ,CoinReward= 0 ,CoinPrice= 0 ,DefaultLv= 1 ,MaxLv= 49 ,UnlockType= 1 ,UnlockValue= 6 ,AtlasName="PlaneFactory",SpriteName="22041",PrefabName="missile22041",LocalPos={-0.08,0.03,0},PropertyPlus="1+2",BulletPrefabName="bullet3",BulletName="ZGame.Logic.BulletTwoFlashBall",SmoothDamp= false ,HasShootAnim= false ,ShootAudioName="shoot1",},
}
local mt_t_missile={}
mt_t_missile.__index=function(t,k)
	LogE("can not find item with key:"..k.." in t_missile")
end
setmetatable(ConfigTable.t_missile,mt_t_missile)


---@class t_effects:ConfigTable
ConfigTable.t_effects={
	[1]={ID= 1 ,ResName="effect_shuibowen_daiji_01",ResType="Prefab3D",Time= 0 ,},
	[2]={ID= 2 ,ResName="effect_shuibowen_shuihua",ResType="Prefab3D",Time= 1 ,},
	[3]={ID= 3 ,ResName="effect_shuibowen_qigan",ResType="Prefab3D",Time= 2.2 ,},
	[4]={ID= 4 ,ResName="fish_yinyingyu",ResType="Prefab3D",Time= 0 ,},
	[5]={ID= 5 ,ResName="effect_futoubolang",ResType="Prefab3D",Time= 0 ,},
}
local mt_t_effects={}
mt_t_effects.__index=function(t,k)
	LogE("can not find item with key:"..k.." in t_effects")
end
setmetatable(ConfigTable.t_effects,mt_t_effects)


---@class t_trail:ConfigTable
ConfigTable.t_trail={
	[13001]={ID= 13001 ,Name= 1030 ,UnitType= 4 ,Speed= 0 ,Damage= 0 ,Defence= 0 ,CoinReward= 0.8 ,CoinPrice= 0.8 ,BulletID= 1 ,DefaultLv= 1 ,MaxLv= 199 ,UnlockType= 1 ,UnlockValue= 3 ,AtlasName="PlaneFactory",SpriteName="13001",PrefabName="trail13001",LocalPos={0,-0.5,0},PropertyPlus="4+5",BulletPrefabName="null",BulletName="null",SmoothDamp= false ,HasShootAnim= false ,ShootAudioName="null",},
	[23001]={ID= 23001 ,Name= 1031 ,UnitType= 4 ,Speed= 0 ,Damage= 0 ,Defence= 0 ,CoinReward= 0.8 ,CoinPrice= 0.8 ,BulletID= 1 ,DefaultLv= 1 ,MaxLv= 199 ,UnlockType= 1 ,UnlockValue= 4 ,AtlasName="PlaneFactory",SpriteName="23001",PrefabName="trail23001",LocalPos={0,-0.5,0},PropertyPlus="4+5",BulletPrefabName="null",BulletName="null",SmoothDamp= false ,HasShootAnim= false ,ShootAudioName="null",},
}
local mt_t_trail={}
mt_t_trail.__index=function(t,k)
	LogE("can not find item with key:"..k.." in t_trail")
end
setmetatable(ConfigTable.t_trail,mt_t_trail)


---@class t_language:ConfigTable
ConfigTable.t_language={
	[1]={ID= 1 ,EN="",IN="",CH="xxx",},
	[100]={ID= 100 ,EN="",IN="",CH="奥特曼机身，奥特曼一般的感觉",},
	[101]={ID= 101 ,EN="",IN="",CH="我就是地球超人",},
	[102]={ID= 102 ,EN="",IN="",CH="信不信俺老孙教你做人",},
	[103]={ID= 103 ,EN="",IN="",CH="我是宇宙最强机甲，钛合金X元素机身",},
	[104]={ID= 104 ,EN="",IN="",CH="机身5未知",},
	[105]={ID= 105 ,EN="",IN="",CH="谜团、黑洞、主宰",},
	[1010]={ID= 1010 ,EN="",IN="",CH="机枪散射",},
	[1011]={ID= 1011 ,EN="",IN="",CH="闪电机枪",},
	[1012]={ID= 1012 ,EN="",IN="",CH="机枪111",},
	[1013]={ID= 1013 ,EN="",IN="",CH="机枪222",},
	[1014]={ID= 1014 ,EN="",IN="",CH="机枪333",},
	[1015]={ID= 1015 ,EN="",IN="",CH="龙虾钳子",},
	[1016]={ID= 1016 ,EN="",IN="",CH="机枪X",},
	[1017]={ID= 1017 ,EN="",IN="",CH="机枪N",},
	[1018]={ID= 1018 ,EN="",IN="",CH="机枪T",},
	[1019]={ID= 1019 ,EN="",IN="",CH="机枪QQ",},
	[1020]={ID= 1020 ,EN="",IN="",CH="爆破",},
	[1021]={ID= 1021 ,EN="",IN="",CH="粘弹",},
	[1022]={ID= 1022 ,EN="",IN="",CH="响尾蛇",},
	[1023]={ID= 1023 ,EN="",IN="",CH="虎蛇",},
	[1024]={ID= 1024 ,EN="",IN="",CH="东风",},
	[1025]={ID= 1025 ,EN="",IN="",CH="白杨导弹",},
	[1026]={ID= 1026 ,EN="",IN="",CH="核弹",},
	[1030]={ID= 1030 ,EN="",IN="",CH="蓝色尾翼",},
	[1031]={ID= 1031 ,EN="",IN="",CH="红色尾翼",},
	[1032]={ID= 1032 ,EN="",IN="",CH="hehehe",},
	[2000]={ID= 2000 ,EN="",IN="",CH="速度:{0}",},
	[2001]={ID= 2001 ,EN="",IN="",CH="伤害:{0}",},
	[2002]={ID= 2002 ,EN="",IN="",CH="防御:{0}",},
	[2003]={ID= 2003 ,EN="",IN="",CH="金币收益:{0}",},
	[2004]={ID= 2004 ,EN="",IN="",CH="金币价值:{0}",},
	[3000]={ID= 3000 ,EN="",IN="",CH="能量值不足{0}点，无法开始游戏",},
	[3001]={ID= 3001 ,EN="",IN="",CH="没有解锁的尾翼部件",},
	[3002]={ID= 3002 ,EN="",IN="",CH="没有解锁的导弹部件",},
	[3003]={ID= 3003 ,EN="",IN="",CH="没有解锁的副武器部件",},
	[3004]={ID= 3004 ,EN="",IN="",CH="没有解锁的机身部件",},
	[3005]={ID= 3005 ,EN="",IN="",CH="未解锁，请通关关卡{0}",},
	[3006]={ID= 3006 ,EN="",IN="",CH="已满级",},
}
local mt_t_language={}
mt_t_language.__index=function(t,k)
	LogE("can not find item with key:"..k.." in t_language")
end
setmetatable(ConfigTable.t_language,mt_t_language)

---@field public PlaneHeadRadius @飞机机头半径
---@field public BattleCostPower @每次游戏消耗的能量点
---@field public LevelMax @最大关卡值
---@field public CoinRewardMax @金币奖励，最大值
---@field public CoinRewardTime @金币奖励，每次奖励时间间隔
---@field public CoinRewardCount @金币奖励，每次奖励量
---@field public DiamondRecoverCount @每次恢复钻石个数
---@field public DiamondRecoverTime @每次恢复钻石耗时，单位(秒)
---@field public PowerRecoverTime @每次恢复能量耗时，单位（秒）
---@field public PowerRecoverCount @每次恢复能量点数
---@field public PowerMax @能量最大值
---@class t_game:ConfigTable
ConfigTable.t_game={
	PowerMax="80",
	PowerRecoverCount="30",
	PowerRecoverTime="5",
	DiamondRecoverTime="4000",
	DiamondRecoverCount="0",
	CoinRewardCount="800",
	CoinRewardTime="8",
	CoinRewardMax="9999",
	LevelMax="9999",
	BattleCostPower="5",
	PlaneHeadRadius="0.27",
}
local mt_t_game={}
mt_t_game.__index=function(t,k)
	LogE("can not find item with key:"..k.." in t_game")
end
setmetatable(ConfigTable.t_game,mt_t_game)


---@class t_germ:ConfigTable
ConfigTable.t_germ={
	[1]={ID= 1 ,Name="ZGame.Logic.GermBounce",PrefabName="guaiwu1",RadiusParams={0.74,1},MoveSpeed= 1 ,HpHitRatio={1,1},IsSplit= true ,SplitGermId= 100 ,ProtectTime= 0 ,},
	[2]={ID= 2 ,Name="ZGame.Logic.GermBoom",PrefabName="guaiwu2",RadiusParams={0.795,1},MoveSpeed= 2 ,HpHitRatio={5,8},IsSplit= false ,SplitGermId= 0 ,ProtectTime= 0 ,},
	[100]={ID= 100 ,Name="ZGame.Logic.GermBounce",PrefabName="guaiwu1",RadiusParams={0.74,0.33},MoveSpeed= 2 ,HpHitRatio={1,1},IsSplit= false ,SplitGermId= 0 ,ProtectTime= 2 ,},
}
local mt_t_germ={}
mt_t_germ.__index=function(t,k)
	LogE("can not find item with key:"..k.." in t_germ")
end
setmetatable(ConfigTable.t_germ,mt_t_germ)

---@field public CoinGain @金币收益
---@field public CoinPrice @金币价值
---@field public Defence @防御
---@field public Damage @伤害
---@field public Speed @速度（速率）
---@class t_icon:ConfigTable
ConfigTable.t_icon={
	Speed="PreparePage|速度",
	Damage="PreparePage|伤害",
	Defence="PreparePage|防御",
	CoinPrice="PreparePage|金币价值",
	CoinGain="PreparePage|金币收益",
}
local mt_t_icon={}
mt_t_icon.__index=function(t,k)
	LogE("can not find item with key:"..k.." in t_icon")
end
setmetatable(ConfigTable.t_icon,mt_t_icon)


---@class t_bullet:ConfigTable
ConfigTable.t_bullet={
	["ZGame.Logic.BulletNormal"]={Name="ZGame.Logic.BulletNormal",MoveSpeed= 10 ,HitType= 0 ,Area= 0 ,AutoDestroyType= 0 ,LifeTime= 0 ,Ylength= 0 ,HarmInterval= 0 ,UniqueParams={0,0},RestrictPos= false ,HasPrepareAnim= false ,HasVanishAnim= false ,HasHitEffect= false ,HitEffectName="",BoomAudioName="shoot1",},
	["ZGame.Logic.BulletNormal2"]={Name="ZGame.Logic.BulletNormal2",MoveSpeed= 10 ,HitType= 0 ,Area= 0 ,AutoDestroyType= 0 ,LifeTime= 0 ,Ylength= 0 ,HarmInterval= 0 ,UniqueParams={0,0},RestrictPos= false ,HasPrepareAnim= false ,HasVanishAnim= false ,HasHitEffect= false ,HitEffectName="",BoomAudioName="shoot2",},
	["ZGame.Logic.BulletRestrictDis"]={Name="ZGame.Logic.BulletRestrictDis",MoveSpeed= 8 ,HitType= 1 ,Area= 2.282 ,AutoDestroyType= 0 ,LifeTime= 0 ,Ylength= 0 ,HarmInterval= 0 ,UniqueParams={0,0},RestrictPos= false ,HasPrepareAnim= false ,HasVanishAnim= false ,HasHitEffect= false ,HitEffectName="",BoomAudioName="shoot1",},
	["ZGame.Logic.BulletBasicTrace"]={Name="ZGame.Logic.BulletBasicTrace",MoveSpeed= 8 ,HitType= 0 ,Area= 0 ,AutoDestroyType= 0 ,LifeTime= 0 ,Ylength= 0 ,HarmInterval= 0 ,UniqueParams={0,0},RestrictPos= false ,HasPrepareAnim= false ,HasVanishAnim= false ,HasHitEffect= false ,HitEffectName="",BoomAudioName="shoot1",},
	["ZGame.Logic.BulletDirectionTrace"]={Name="ZGame.Logic.BulletDirectionTrace",MoveSpeed= 8 ,HitType= 0 ,Area= 0 ,AutoDestroyType= 0 ,LifeTime= 0 ,Ylength= 0 ,HarmInterval= 0 ,UniqueParams={0,0},RestrictPos= false ,HasPrepareAnim= false ,HasVanishAnim= false ,HasHitEffect= false ,HitEffectName="",BoomAudioName="shoot1",},
	["ZGame.Logic.BulletForce"]={Name="ZGame.Logic.BulletForce",MoveSpeed= 10 ,HitType= 0 ,Area= 0 ,AutoDestroyType= 0 ,LifeTime= 0 ,Ylength= 0 ,HarmInterval= 0 ,UniqueParams={0,0},RestrictPos= false ,HasPrepareAnim= false ,HasVanishAnim= false ,HasHitEffect= false ,HitEffectName="",BoomAudioName="shoot1",},
	["ZGame.Logic.BulletBianZhi"]={Name="ZGame.Logic.BulletBianZhi",MoveSpeed= 10 ,HitType= 2 ,Area= 0 ,AutoDestroyType= 1 ,LifeTime= 9 ,Ylength= 5 ,HarmInterval= 0.2 ,UniqueParams={8,60},RestrictPos= false ,HasPrepareAnim= false ,HasVanishAnim= false ,HasHitEffect= false ,HitEffectName="",BoomAudioName="shoot1",},
	["ZGame.Logic.BulletBianZhiPro"]={Name="ZGame.Logic.BulletBianZhiPro",MoveSpeed= 3 ,HitType= 2 ,Area= 0 ,AutoDestroyType= 1 ,LifeTime= 9 ,Ylength= 8 ,HarmInterval= 0.2 ,UniqueParams={5,60},RestrictPos= false ,HasPrepareAnim= false ,HasVanishAnim= false ,HasHitEffect= false ,HitEffectName="",BoomAudioName="shoot1",},
	["ZGame.Logic.BulletTwoFlashBall"]={Name="ZGame.Logic.BulletTwoFlashBall",MoveSpeed= 2 ,HitType= 2 ,Area= 0 ,AutoDestroyType= 0 ,LifeTime= 0 ,Ylength= 0 ,HarmInterval= 0.2 ,UniqueParams={0,0},RestrictPos= false ,HasPrepareAnim= true ,HasVanishAnim= false ,HasHitEffect= true ,HitEffectName="linklightinghit",BoomAudioName="shoot1",},
	["ZGame.Logic.BulletLaser"]={Name="ZGame.Logic.BulletLaser",MoveSpeed= 0 ,HitType= 2 ,Area= 0 ,AutoDestroyType= 1 ,LifeTime= 2 ,Ylength= 0 ,HarmInterval= 0.2 ,UniqueParams={0.2},RestrictPos= true ,HasPrepareAnim= true ,HasVanishAnim= true ,HasHitEffect= true ,HitEffectName="bullet8hit",BoomAudioName="shoot1",},
	["ZGame.Logic.BulletLaser2"]={Name="ZGame.Logic.BulletLaser2",MoveSpeed= 0 ,HitType= 2 ,Area= 0 ,AutoDestroyType= 1 ,LifeTime= 2 ,Ylength= 0 ,HarmInterval= 0.2 ,UniqueParams={0.25},RestrictPos= true ,HasPrepareAnim= true ,HasVanishAnim= true ,HasHitEffect= true ,HitEffectName="bullet9hit",BoomAudioName="shoot1",},
}
local mt_t_bullet={}
mt_t_bullet.__index=function(t,k)
	LogE("can not find item with key:"..k.." in t_bullet")
end
setmetatable(ConfigTable.t_bullet,mt_t_bullet)

return ConfigTable