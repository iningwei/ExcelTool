
---@class LanguageDataTable
---@field ID number
---@field EN string
---@field CN string
---@field TC string
local LanguageDataTable={
	[100]={ID= 100 ,EN="test {0}{1} hi:{2}",CN="0",TC="0",},
	[101]={ID= 101 ,EN="0",CN="登录",TC="0",},
	[102]={ID= 102 ,EN="0",CN="UID",TC="0",},
	[103]={ID= 103 ,EN="0",CN="直播间",TC="0",},
	[104]={ID= 104 ,EN="0",CN="开始游戏",TC="0",},
	[105]={ID= 105 ,EN="0",CN="分辨率",TC="0",},
	[106]={ID= 106 ,EN="0",CN="比赛即将开始…",TC="0",},
	[107]={ID= 107 ,EN="0",CN="准备中",TC="0",},
	[108]={ID= 108 ,EN="0",CN="开始",TC="0",},
	[109]={ID= 109 ,EN="0",CN="参赛人数:{0}/{1}",TC="0",},
	[110]={ID= 110 ,EN="0",CN="{0}加入比赛",TC="0",},
	[111]={ID= 111 ,EN="0",CN="{0}复活",TC="0",},
	[112]={ID= 112 ,EN="0",CN="周榜{0}名",TC="0",},
	[113]={ID= 113 ,EN="0",CN="击败",TC="0",},
	[114]={ID= 114 ,EN="0",CN="关卡排行",TC="0",},
	[115]={ID= 115 ,EN="0",CN="排行",TC="0",},
	[116]={ID= 116 ,EN="0",CN="玩家",TC="0",},
	[117]={ID= 117 ,EN="0",CN="积分",TC="0",},
	[118]={ID= 118 ,EN="0",CN="周榜",TC="0",},
	[119]={ID= 119 ,EN="0",CN="进入下一关",TC="0",},
	[120]={ID= 120 ,EN="0",CN="周排行榜",TC="0",},
	[121]={ID= 121 ,EN="0",CN="关卡周排行",TC="0",},
	[122]={ID= 122 ,EN="0",CN="关卡排行",TC="0",},
	[20001]={ID= 20001 ,EN="0",CN="获得<color=#FF0000>1</color>点推力",TC="0",},
	[20002]={ID= 20002 ,EN="0",CN="召唤了<color=#FF0000>【欧迪】</color>",TC="0",},
	[20003]={ID= 20003 ,EN="0",CN="召唤了<color=#FF0000>【Roland】</color>",TC="0",},
	[20004]={ID= 20004 ,EN="0",CN="召唤了<color=#FF0000>【维克】</color>",TC="0",},
	[20005]={ID= 20005 ,EN="0",CN="召唤了<color=#FF0000>【Noland】</color>",TC="0",},
	[20006]={ID= 20006 ,EN="0",CN="召唤了<color=#FF0000>【南瓜炸弹】</color>",TC="0",},
	[20007]={ID= 20007 ,EN="0",CN="召唤了<color=#FF0000>【公牛/母牛】</color>",TC="0",},
	[20008]={ID= 20008 ,EN="0",CN="召唤了<color=#FF0000>【捕狗大队】</color>",TC="0",},
	[20009]={ID= 20009 ,EN="0",CN="召唤了<color=#FF0000>【捕猫大队】</color>",TC="0",},
	[100000]={ID= 100000 ,EN="0",CN="当前版本错误,local:{0},canRunMin:{1},curMax:{2}",TC="0",},
}
local mt_LanguageDataTable={}
mt_LanguageDataTable.__index=function(t,k)
	LogE("can not find item with key:"..k.." in LanguageDataTable")
end
setmetatable(LanguageDataTable,mt_LanguageDataTable)

return LanguageDataTable