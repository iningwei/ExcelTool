
---@class ConfigDataTable
---@field ID number
---@field Value string
local ConfigDataTable={
	[1]={ID= 1 ,Value="1200",},
	[2]={ID= 2 ,Value="8",},
	[3]={ID= 3 ,Value="2000",},
	[4]={ID= 4 ,Value="1000",},
	[5]={ID= 5 ,Value="101",},
	[6]={ID= 6 ,Value="102",},
	[7]={ID= 7 ,Value="9998",},
	[8]={ID= 8 ,Value="10",},
	[9]={ID= 9 ,Value="180",},
	[10]={ID= 10 ,Value="30",},
	[11]={ID= 11 ,Value="30",},
	[12]={ID= 12 ,Value="103",},
	[20]={ID= 20 ,Value="10",},
	[21]={ID= 21 ,Value="2000;2001;2002;2003",},
	[22]={ID= 22 ,Value="1000;1001;1002;1003",},
	[30]={ID= 30 ,Value="1",},
	[31]={ID= 31 ,Value="2010;100",},
	[32]={ID= 32 ,Value="1009;100",},
	[33]={ID= 33 ,Value="2010",},
	[1001]={ID= 1001 ,Value="danmu.qiyouentertainment.com",},
	[1002]={ID= 1002 ,Value="8088",},
	[10000]={ID= 10000 ,Value="true",},
	[10001]={ID= 10001 ,Value="false",},
}
local mt_ConfigDataTable={}
mt_ConfigDataTable.__index=function(t,k)
	LogE("can not find item with key:"..k.." in ConfigDataTable")
end
setmetatable(ConfigDataTable,mt_ConfigDataTable)

return ConfigDataTable