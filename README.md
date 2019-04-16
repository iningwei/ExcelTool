## Summary
ExcelTool aimed at exporting excel tables to easy-use binary files corresponding with necessary c# files.
**Note that** in these c# files,they sometimes need reference Unity3D 's namespace,as I give support to Vector3 and other Unity3D types.

## Description
There is a demo excel file called "飞机大战数据_程序用.xlsx" under folder bin/table.It shows the structure supported and other details.I suggest you read the following content before you jump into work.

 1. Table name

Make sure make a meaning table name,for the output c# file with use it as class name.
In my project,i will check whether the table name contains Chinese charactor,if that this table will not be including in target tables.
In fact such table is always used as global anotation.

2. Field

Each field at least has 6 lines.The first field is PrimaryField.
 - line 1 is the name of the field.
You would better use a uppercase letter for the first letter.
Also do not use Chinese charactor or it will be treated as annotation. 
 - line 2 is the type of the field.
Now support int、bool、float、string、int[]、float[]、string[]、Vector3.
 - line 3 is the default value.
If you forget fill the cell,it will use the default value
 - line 4 is the tag.
Only primary field use tag.If other field's line 4 is not empty,it will be omitted.
Tag KVT tells you the table is a key-value table.
If a table was tagged with KVT,it has it's own structure.First field must named Key and with a type of string.Second field must named Value,the suggestion type is object(now not supported ┬＿┬).Third field must named KeyDes,you can not assign the type because it only used for annotation.
 - line 5 is a short description of this field.
 - line 6 is a more description of a field.