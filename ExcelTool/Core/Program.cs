using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excel;
using System.Data;
using ExcelTool.Core;
using ExcelTool.Reader;
using ExcelTool.Tools;

/*
 *参考自： http://www.cnblogs.com/fly-100/p/4538975.html
*/
namespace ExcelTool
{
    class Program
    {
        static string binDir;
        static string excelFileDir;
        static string[] excelFiles;

        static string outputTableDir;//excel导出表 目录
        static string outputCSCodeDir;//CS导出代码 目录
        static string outputLuaCodeDir;//Lua导出代码 目录
        static void Main(string[] args)
        {
            Debug.Log("begin handle excel file");
            Debug.Log("--->try get all excel file");


            string curDir = Environment.CurrentDirectory;
            Debug.Log("curDir:" + curDir);
            binDir = curDir.Substring(0, curDir.LastIndexOf(@"\"));
            outputTableDir = binDir + @"\table_output";
            outputCSCodeDir = binDir + @"\code_output_cs";
            outputLuaCodeDir = binDir + @"\code_output_lua";

            excelFileDir = binDir + @"\table";
            Debug.Log("excelFileDir:" + excelFileDir);

            //.xls为03版本excel后缀
            //经测试该库，不支持03版本excel
            excelFiles = Directory.GetFiles(excelFileDir, "*.xlsx", SearchOption.TopDirectoryOnly);

            for (int q = 0; q < excelFiles.Length; q++)
            {
                List<ExcelTable> excelTables = ExcelReader.Read(excelFiles[q]);
                #region  导出C#代码
                for (int i = 0; i < excelTables.Count; i++)
                {
                    ExcelWriter.WriteCSCode(outputCSCodeDir, excelTables[i]);
                    ExcelWriter.WriteBinaryFile(outputTableDir, excelTables[i]);
                }
                #endregion


                //TODO:output Lua code
                //////#region 导出lua代码
                //////outputLuaCode(outputLuaCodeDir, excelTables);
                //////#endregion


            }
            Debug.Log("output finished");
            Console.ReadLine();
        }


        //////static void outputLuaCode(string outputFolderPath, List<ExcelTable> tables)
        //////{
        //////    string outputFile = outputFolderPath + @"\SettingTable.lua";
        //////    string luaContent = "---@class SettingTable\r\n";
        //////    luaContent += "local SettingTable={}\r\n";
        //////    for (int i = 0; i < tables.Count; i++)
        //////    {
        //////        var table = tables[i];
        //////        if (table.isKVPairTable)
        //////        {
        //////            luaContent += "\r\n";
        //////            luaContent += "---@field public " + table.tableName + " table\r\n";
        //////            luaContent += "---@class " + table.tableName + ":SettingTable\r\n";
        //////            luaContent += "SettingTable." + table.tableName + "={\r\n";
        //////            for (int j = 4; j < table.usedRowsCount + 4; j++)
        //////            {
        //////                var kStr = table.tableContent[table.primaryKeyName][j];
        //////                var vStr = table.tableContent["Value"][j];
        //////                var commentStr = table.tableContent["KeyDes"][j];
        //////                if (table.valueKeyType == "string")
        //////                {
        //////                    luaContent += "\t" + kStr + "=\"" + vStr + "\",--" + commentStr + "\r\n";
        //////                }
        //////                else
        //////                {
        //////                    luaContent += "\t" + kStr + "=" + vStr + ",--" + commentStr + "\r\n";
        //////                }
        //////            }
        //////            luaContent += "}\r\n";
        //////        }
        //////        else
        //////        {
        //////            luaContent += "\r\n";
        //////            luaContent += "---@field public " + table.tableName + " table\r\n";
        //////            luaContent += "---@class " + table.tableName + ":SettingTable\r\n";
        //////            luaContent += "SettingTable." + table.tableName + "={\r\n";
        //////            for (int j = 4; j < table.usedRowsCount + 4; j++)
        //////            {
        //////                luaContent += "\t{";
        //////                for (int k = 0; k < table.keys.Count; k++)
        //////                {
        //////                    var keyName = table.keys[k];

        //////                    var value = table.tableContent[keyName][j];
        //////                    if (table.tableContent[keyName][0] == "string")
        //////                    {
        //////                        luaContent += keyName + "=\"" + value + "\",";
        //////                    }
        //////                    else
        //////                    {
        //////                        luaContent += keyName + "=" + value + ",";
        //////                    }
        //////                }
        //////                luaContent += "},\r\n";
        //////            }
        //////            luaContent += "}\r\n";


        //////            luaContent += "SettingTable.Get" + table.tableName.Substring(0, table.tableName.Length - 7) + "By" + table.primaryKeyName + "=function(" + table.primaryKeyName + ")\r\n";
        //////            luaContent += "\tfor i=1,#SettingTable." + table.tableName + " do\r\n";
        //////            luaContent += "\t\tlocal tmp=SettingTable." + table.tableName + "[i]\r\n";
        //////            luaContent += "\t\tif tmp." + table.primaryKeyName + "==" + table.primaryKeyName + " then\r\n";
        //////            luaContent += "\t\t\treturn tmp\r\n";
        //////            luaContent += "\t\tend\r\n";
        //////            luaContent += "\tend\r\n";
        //////            luaContent += "\tloge(\"error,get " + table.tableName.Substring(0, table.tableName.Length - 7) + " By " + table.primaryKeyName + ":\"+" + table.primaryKeyName + ")\r\n";
        //////            luaContent += "\treturn nil\r\n";

        //////            luaContent += "end\r\n";
        //////        }
        //////    }

        //////    luaContent += "return SettingTable";


        //////    File.WriteAllText(outputFile, luaContent.TrimEnd(), new UTF8Encoding(false));
        //////    Console.WriteLine("SettingTable.lua输出完毕");
        //////}







        //http://www.jb51.net/article/58442.htm




        void xxx()
        {
            string a = "0|0|0";
            string[] strs = a.Split('|');
            int[] xx = strs.ToIntArray();
        }
    }
}
