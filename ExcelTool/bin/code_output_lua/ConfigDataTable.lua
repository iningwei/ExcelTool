
---@class ConfigDataTable
---@field ID number
---@field Value string
local ConfigDataTable={
	[1]={ID= 1 ,Value="1200",},
	[2]={ID= 2 ,Value="8",},
	[3]={ID= 3 ,Value="5",},
	[5]={ID= 5 ,Value="100",},
	[6]={ID= 6 ,Value="101",},
	[8]={ID= 8 ,Value="2",},
	[9]={ID= 9 ,Value="180",},
	[12]={ID= 12 ,Value="100",},
	[20]={ID= 20 ,Value="10",},
	[25]={ID= 25 ,Value="5",},
	[201]={ID= 201 ,Value="1.2",},
	[202]={ID= 202 ,Value="0.5",},
	[203]={ID= 203 ,Value="40",},
	[210]={ID= 210 ,Value="0.3",},
	[211]={ID= 211 ,Value="0.3",},
	[212]={ID= 212 ,Value="0.5",},
	[1001]={ID= 1001 ,Value="danmu.qiyoogame.com",},
	[1002]={ID= 1002 ,Value="8088",},
	[1010]={ID= 1010 ,Value="http://log.qiyoogame.com/Gm/save-file/auto",},
	[1100]={ID= 1100 ,Value="30",},
	[1101]={ID= 1101 ,Value="5",},
	[1102]={ID= 1102 ,Value="5",},
	[1103]={ID= 1103 ,Value="40",},
	[1104]={ID= 1104 ,Value="20",},
	[2000]={ID= 2000 ,Value="http://172.16.10.45:10000/login_dy_live",},
	[2001]={ID= 2001 ,Value="http://47.108.161.219:10000/login_dy_live",},
	[2010]={ID= 2010 ,Value="1",},
	[10000]={ID= 10000 ,Value="3",},
	[10001]={ID= 10001 ,Value="3",},
	[10002]={ID= 10002 ,Value="5",},
	[10003]={ID= 10003 ,Value="1000,1001,1002,1003,1004,1005,1006,1010",},
	[10004]={ID= 10004 ,Value="100,100,0,10003",},
	[10005]={ID= 10005 ,Value="10,100,10",},
	[10006]={ID= 10006 ,Value="1,0.1",},
	[10007]={ID= 10007 ,Value="2.5",},
	[10008]={ID= 10008 ,Value="10",},
	[10009]={ID= 10009 ,Value="0.2",},
	[10010]={ID= 10010 ,Value="300",},
	[10011]={ID= 10011 ,Value="0.2",},
	[10012]={ID= 10012 ,Value="10001,6",},
	[20000]={ID= 20000 ,Value="20000",},
	[20001]={ID= 20001 ,Value="1006,1000,1003",},
	[20002]={ID= 20002 ,Value="1005,1004,1010",},
	[20010]={ID= 20010 ,Value="300",},
	[20011]={ID= 20011 ,Value="1",},
	[30001]={ID= 30001 ,Value="3,0.1,0.1,5,5,10,5",},
	[30002]={ID= 30002 ,Value="-4.74,0.28,-21.72,948.5",},
	[30003]={ID= 30003 ,Value="1,1,2,5,-2,-5,2,0",},
	[30004]={ID= 30004 ,Value="-9.5,4.3,10,20",},
	[30005]={ID= 30005 ,Value="-4,0.6,4.3,-25,-2,4.48,-5",},
	[30006]={ID= 30006 ,Value="6,7,-20.8,-3.6,0.6,0.6,4.48",},
	[30007]={ID= 30007 ,Value="10",},
	[100000]={ID= 100000 ,Value="false",},
	[100001]={ID= 100001 ,Value="false",},
	[100002]={ID= 100002 ,Value="true",},
}
local mt_ConfigDataTable={}
mt_ConfigDataTable.__index=function(t,k)
	LogE("can not find item with key:"..k.." in ConfigDataTable")
end
setmetatable(ConfigDataTable,mt_ConfigDataTable)

return ConfigDataTable