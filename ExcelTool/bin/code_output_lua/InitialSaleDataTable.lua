
---@class InitialSaleDataTable
---@field ID number
---@field itemId number
---@field price number
---@field listOnStore bool
---@field storePayCode string
---@field storePrice number
---@field limitDatePart string
---@field limitDayTimePart string
---@field limitNumRole number
local InitialSaleDataTable={
	[3]={ID= 3 ,itemId= 10001 ,price= 0.01 ,listOnStore= true ,storePayCode="com.xingqimetaverse.minecar_1",storePrice= 1 ,limitDatePart="1,2024-04-01,2024-05-30;2,2024-04-01,12",limitDayTimePart="",limitNumRole= 0 ,},
	[4]={ID= 4 ,itemId= 10002 ,price= 0.01 ,listOnStore= true ,storePayCode="com.xingqimetaverse.minecar_2",storePrice= 3 ,limitDatePart="1,2024-04-01,2024-05-30;2,2024-04-01,13",limitDayTimePart="",limitNumRole= 0 ,},
	[5]={ID= 5 ,itemId= 10003 ,price= 0.01 ,listOnStore= true ,storePayCode="com.xingqimetaverse.minecar_3",storePrice= 6 ,limitDatePart="1,2024-04-01,2024-05-30;2,2024-04-01,14",limitDayTimePart="",limitNumRole= 0 ,},
	[6]={ID= 6 ,itemId= 20001 ,price= 0.01 ,listOnStore= true ,storePayCode="com.xingqimetaverse.ship_1",storePrice= 1 ,limitDatePart="1,2024-04-01,2024-05-30;2,2024-04-01,15",limitDayTimePart="",limitNumRole= 0 ,},
	[7]={ID= 7 ,itemId= 20002 ,price= 0.01 ,listOnStore= true ,storePayCode="com.xingqimetaverse.ship_2",storePrice= 3 ,limitDatePart="1,2024-04-01,2024-05-30;2,2024-04-01,16",limitDayTimePart="",limitNumRole= 0 ,},
	[8]={ID= 8 ,itemId= 20003 ,price= 0.01 ,listOnStore= true ,storePayCode="com.xingqimetaverse.ship_3",storePrice= 6 ,limitDatePart="1,2024-04-01,2024-05-30;2,2024-04-01,17",limitDayTimePart="",limitNumRole= 0 ,},
}
local mt_InitialSaleDataTable={}
mt_InitialSaleDataTable.__index=function(t,k)
	LogE("can not find item with key:"..k.." in InitialSaleDataTable")
end
setmetatable(InitialSaleDataTable,mt_InitialSaleDataTable)

return InitialSaleDataTable