
---@class itemTable
---@field ID number
---@field durable number
---@field type number
---@field kind number
---@field list number
---@field update number
---@field down number[]
---@field up number[]
---@field level number
---@field star number
---@field NFT number
---@field time number
---@field drop number
---@field merge number
---@field quanitityType number
---@field quanititylimit number
local itemTable={
	[101020000]={ID= 101020000 ,durable= 0 ,type= 1 ,kind= 101 ,list= 0 ,update= 0 ,down={},up={},level= 0 ,star= 0 ,NFT= 0 ,time= 0 ,drop= 0 ,merge= 0 ,quanitityType= 2 ,quanititylimit= 0 ,},
	[102010000]={ID= 102010000 ,durable= 0 ,type= 1 ,kind= 102 ,list= 0 ,update= 0 ,down={},up={},level= 0 ,star= 0 ,NFT= 0 ,time= 0 ,drop= 0 ,merge= 0 ,quanitityType= 2 ,quanititylimit= 0 ,},
	[103030000]={ID= 103030000 ,durable= 0 ,type= 1 ,kind= 103 ,list= 0 ,update= 0 ,down={},up={},level= 0 ,star= 0 ,NFT= 0 ,time= 0 ,drop= 0 ,merge= 0 ,quanitityType= 2 ,quanititylimit= 0 ,},
	[104040000]={ID= 104040000 ,durable= 0 ,type= 1 ,kind= 104 ,list= 0 ,update= 0 ,down={},up={},level= 0 ,star= 0 ,NFT= 0 ,time= 1 ,drop= 0 ,merge= 0 ,quanitityType= 2 ,quanititylimit= 0 ,},
	[105040000]={ID= 105040000 ,durable= 0 ,type= 1 ,kind= 105 ,list= 0 ,update= 0 ,down={},up={},level= 0 ,star= 0 ,NFT= 0 ,time= 1 ,drop= 0 ,merge= 0 ,quanitityType= 1 ,quanititylimit= 0 ,},
	[106030000]={ID= 106030000 ,durable= 0 ,type= 1 ,kind= 106 ,list= 0 ,update= 0 ,down={},up={},level= 0 ,star= 0 ,NFT= 0 ,time= 1 ,drop= 0 ,merge= 0 ,quanitityType= 1 ,quanititylimit= 0 ,},
	[107020000]={ID= 107020000 ,durable= 0 ,type= 1 ,kind= 107 ,list= 0 ,update= 0 ,down={},up={},level= 0 ,star= 0 ,NFT= 0 ,time= 0 ,drop= 0 ,merge= 0 ,quanitityType= 1 ,quanititylimit= 0 ,},
	[108040000]={ID= 108040000 ,durable= 0 ,type= 1 ,kind= 108 ,list= 0 ,update= 0 ,down={},up={},level= 0 ,star= 0 ,NFT= 0 ,time= 1 ,drop= 0 ,merge= 0 ,quanitityType= 1 ,quanititylimit= 0 ,},
	[109040000]={ID= 109040000 ,durable= 0 ,type= 1 ,kind= 109 ,list= 0 ,update= 0 ,down={},up={},level= 0 ,star= 0 ,NFT= 0 ,time= 1 ,drop= 0 ,merge= 0 ,quanitityType= 1 ,quanititylimit= 0 ,},
	[110030010]={ID= 110030010 ,durable= 0 ,type= 1 ,kind= 110 ,list= 0 ,update= 0 ,down={},up={},level= 0 ,star= 0 ,NFT= 0 ,time= 0 ,drop= 0 ,merge= 0 ,quanitityType= 1 ,quanititylimit= 0 ,},
	[111030010]={ID= 111030010 ,durable= 0 ,type= 1 ,kind= 111 ,list= 0 ,update= 0 ,down={},up={},level= 0 ,star= 0 ,NFT= 0 ,time= 0 ,drop= 0 ,merge= 0 ,quanitityType= 1 ,quanititylimit= 0 ,},
	[112020000]={ID= 112020000 ,durable= 0 ,type= 1 ,kind= 112 ,list= 0 ,update= 0 ,down={},up={},level= 0 ,star= 0 ,NFT= 0 ,time= 0 ,drop= 0 ,merge= 0 ,quanitityType= 1 ,quanititylimit= 0 ,},
	[384130001]={ID= 384130001 ,durable= 0 ,type= 3 ,kind= 384 ,list= 1 ,update= 1 ,down={10,15},up={15,25},level= 0 ,star= 0 ,NFT= 1 ,time= 0 ,drop= 0 ,merge= 0 ,quanitityType= 1 ,quanititylimit= 0 ,},
	[384230002]={ID= 384230002 ,durable= 0 ,type= 3 ,kind= 384 ,list= 2 ,update= 1 ,down={10,15},up={15,25},level= 0 ,star= 0 ,NFT= 1 ,time= 0 ,drop= 0 ,merge= 0 ,quanitityType= 1 ,quanititylimit= 0 ,},
	[360110001]={ID= 360110001 ,durable= 0 ,type= 3 ,kind= 360 ,list= 1 ,update= 1 ,down={10,15},up={15,25},level= 0 ,star= 0 ,NFT= 0 ,time= 0 ,drop= 0 ,merge= 0 ,quanitityType= 1 ,quanititylimit= 0 ,},
	[349110001]={ID= 349110001 ,durable= 0 ,type= 3 ,kind= 349 ,list= 1 ,update= 1 ,down={10,15},up={15,25},level= 0 ,star= 0 ,NFT= 0 ,time= 0 ,drop= 0 ,merge= 0 ,quanitityType= 1 ,quanititylimit= 0 ,},
}
local mt_itemTable={}
mt_itemTable.__index=function(t,k)
	LogE("can not find item with key:"..k.." in itemTable")
end
setmetatable(itemTable,mt_itemTable)

return itemTable