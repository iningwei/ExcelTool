
---@class ConfigDataTable
---@field ID number
---@field des string
---@field Value string
local ConfigDataTable={
	[1]={ID= 1 ,des="单局战斗时长 s",Value="1200",},
	[2]={ID= 2 ,des="虫族基础单位出生间隔 秒 （暂时未使用该参数）",Value="8",},
	[3]={ID= 3 ,des="玩家主角色死亡复活时间（game01和game02通用）",Value="5",},
	[5]={ID= 5 ,des="基地蓝编号",Value="100",},
	[6]={ID= 6 ,des="基地红编号",Value="101",},
	[8]={ID= 8 ,des="战斗结束表演动画时长 秒",Value="2",},
	[9]={ID= 9 ,des="玩家多久没有任何交互会被强制下线 秒",Value="180",},
	[12]={ID= 12 ,des="游戏内玩家数上限",Value="100",},
	[20]={ID= 20 ,des="玩家换路，CD时间间隔s",Value="0",},
	[25]={ID= 25 ,des="玩家查询自己信息CD时间间隔s",Value="5",},
	[201]={ID= 201 ,des="胜方，分数加成系数",Value="1.2",},
	[202]={ID= 202 ,des="弹幕兵打礼物兵的伤害得分系数",Value="0.5",},
	[203]={ID= 203 ,des="刷礼物的积分系数",Value="40",},
	[210]={ID= 210 ,des="礼物兵打基地，最终伤害系数",Value="0.3",},
	[211]={ID= 211 ,des="普通兵打礼物兵，最终伤害系数",Value="0.3",},
	[212]={ID= 212 ,des="普通兵打普通兵，最终伤害系数",Value="0.5",},
	[1001]={ID= 1001 ,des="服务器地址",Value="danmu.qiyoogame.com",},
	[1002]={ID= 1002 ,des="服务器端口号",Value="8088",},
	[1010]={ID= 1010 ,des="上传debug到server的url",Value="http://log.qiyoogame.com/Gm/save-file/auto",},
	[1100]={ID= 1100 ,des="击败其它玩家播放Happy Emoji的百分概率",Value="30",},
	[1101]={ID= 1101 ,des="被攻击时，播放Angry Emoji的百分概率",Value="5",},
	[1102]={ID= 1102 ,des="攻击别人时，播放Laugh Emoji的百分概率",Value="5",},
	[1103]={ID= 1103 ,des="加入游戏时，播放Hello Emoji的百分概率",Value="40",},
	[1104]={ID= 1104 ,des="移动过程中，播放Love Emoji的百分概率",Value="20",},
	[2000]={ID= 2000 ,des="内网Login Url",Value="http://172.16.10.45:10000/login_dy_live",},
	[2001]={ID= 2001 ,des="外网Login Url",Value="http://47.108.161.219:10000/login_dy_live",},
	[2010]={ID= 2010 ,des="login type, 1内网,2 外网",Value="1",},
	[10000]={ID= 10000 ,des="Game01，超过此时间没受到攻击，就把攻击者从仇恨列表移除",Value="3",},
	[10001]={ID= 10001 ,des="Game01，反击仇恨目标的最低持续时间（此时间内不会重新反击其他目标）",Value="3",},
	[10002]={ID= 10002 ,des="Game01，移动超时时间，超时后重新找一个最近敌人",Value="5",},
	[10003]={ID= 10003 ,des="Game01，玩家角色列表",Value="1000,1001,1002,1003,1004,1005,1006,1010",},
	[10004]={ID= 10004 ,des="Game01，玩家吃披萨回血BUFF参数(回血值，护盾值，回血特效ID，护盾特效ID)",Value="100,100,0,10003",},
	[10005]={ID= 10005 ,des="Game01，士气值参数（点赞上限，送礼上限，持续时间）",Value="10,100,10",},
	[10006]={ID= 10006 ,des="Game01，士气值加成（攻击，移动速度）",Value="1,0.1",},
	[10007]={ID= 10007 ,des="Game01，角色切换行走和跑步动作的速度界限值",Value="2.5",},
	[10008]={ID= 10008 ,des="Game01，角色死亡后复活时间（暂时不用该字段）",Value="10",},
	[10009]={ID= 10009 ,des="Game01，每次点赞减少的复活时间（暂时不用该字段）",Value="0.2",},
	[10010]={ID= 10010 ,des="Game01，对局时长（秒）",Value="300",},
	[10011]={ID= 10011 ,des="Game01，触发角色逃跑的生命比例（生命值比例低于此就会逃跑，一次生命周期内只会触发一次）",Value="0.2",},
	[10012]={ID= 10012 ,des="Game01，暴击添加的buff（分别为：击退buff的id、击退参数-水平力）",Value="10001,6",},
	[20000]={ID= 20000 ,des="Game02，推的目标的角色ID",Value="20000",},
	[20001]={ID= 20001 ,des="Game02，蓝色方玩家角色列表",Value="1006,1000,1003",},
	[20002]={ID= 20002 ,des="Game02，红色方玩家角色列表",Value="1005,1004,1010",},
	[20010]={ID= 20010 ,des="Game02，对局时长（秒）",Value="300",},
	[20011]={ID= 20011 ,des="Game02，每个仙女棒增加的推力值",Value="1",},
	[30001]={ID= 30001 ,des="Game03, 速度参数(默认速度,点赞buff每存在n秒提升速度n值,点赞速度上限,礼物1速度定值,礼物2速度定值,>=n值出现烟尘特效)",Value="3,0.1,0.1,5,5,10,5",},
	[30002]={ID= 30002 ,des="Game03,地图左右边界,起点和终点",Value="-4.74,0.28,-21.72,948.5",},
	[30003]={ID= 30003 ,des="Game03, 南瓜生成随机参数(x-range,z-front-range,z-back-range,y-front-height,y-back-height)x-range,暂时用地图边界去随机",Value="1,1,2,5,-2,-5,2,0",},
	[30004]={ID= 30004 ,des="Game03,牛生成的位置(x,y,相对于玩家的Z,持续的时间)",Value="-9.5,4.3,10,20",},
	[30005]={ID= 30005 ,des="Game03,重生 超出左x,超出右x,超出下y,超出后z进行重生,重生之后的x,重生后y的高度,根据当前位置进行重生向后让他位置偏移",Value="-4,0.6,4.3,-25,-2,4.48,-5",},
	[30006]={ID= 30006 ,des="Game03,出生点行列(n行n列,第一行的位置Z,第一列的位置X,每行间隔,每列间隔,出生高度)",Value="6,7,-20.8,-3.6,0.6,0.6,4.48",},
	[30007]={ID= 30007 ,des="Game03游戏结束倒计时",Value="10",},
	[100000]={ID= 100000 ,des="p键 debugwindow是否开启",Value="false",},
	[100001]={ID= 100001 ,des="shotcut快捷键是否开启",Value="false",},
	[100002]={ID= 100002 ,des="xxx test",Value="true",},
}
local mt_ConfigDataTable={}
mt_ConfigDataTable.__index=function(t,k)
	LogE("can not find item with key:"..k.." in ConfigDataTable")
end
setmetatable(ConfigDataTable,mt_ConfigDataTable)

return ConfigDataTable