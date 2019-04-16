using ExcelTool.Core;
using ExcelTool.Reader;
using ExcelTool.Tools;
using System;
using System.Collections.Generic;
using System.IO;

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

        static string outputTableDir;//the directory for outputing bin files
        static string outputCSCodeDir;//the directory for outputing c# code files
        static string outputLuaCodeDir;//the direcotry for lua code outputs
        static void Main(string[] args)
        {
            Debug.Log("begin handle excel file");
            Debug.Log("--->try get all excel file");

            init(args);



            //do not support 03 excel file,which with postfix of .xls
            excelFiles = Directory.GetFiles(excelFileDir, "*.xlsx", SearchOption.TopDirectoryOnly);

            for (int q = 0; q < excelFiles.Length; q++)
            {
                List<ExcelTable> excelTables = ExcelReader.Read(excelFiles[q]);
                #region  output c# code files and bin files
                for (int i = 0; i < excelTables.Count; i++)
                {
                    ExcelWriter.WriteCSCode(outputCSCodeDir, excelTables[i]);
                    ExcelWriter.WriteBinaryFile(outputTableDir, excelTables[i]);
                }
                #endregion


                //TODO:output Lua code                
                //////outputLuaCode(outputLuaCodeDir, excelTables);


            }
            Debug.Log("------------- :-) output finished");
            Console.ReadLine();
        }

        private static void init(string[] args)
        {
            if (args.Length == 0)//if we not assign params
            {
                string curDir = Environment.CurrentDirectory;
                Debug.Log("curDir:" + curDir);
                binDir = curDir.Substring(0, curDir.LastIndexOf(@"\"));
                outputTableDir = binDir + @"\table_output";
                outputCSCodeDir = binDir + @"\code_output_cs";
                outputLuaCodeDir = binDir + @"\code_output_lua";

                excelFileDir = binDir + @"\table";
                Debug.Log("excelFileDir:" + excelFileDir);
            }
            else
            {
                if (args.Length != 4)
                {
                    Debug.ThrowException("error,if you assign params then args.Length must be 4");
                }
                else
                {
                    excelFileDir = args[0];
                    outputTableDir = args[1];
                    outputCSCodeDir = args[2];
                    outputLuaCodeDir = args[3];
                    Debug.Log("excelFileDir:" + excelFileDir);
                    Debug.Log("outputTableDir:" + outputTableDir);
                    Debug.Log("outputCSCodeDir:" + outputCSCodeDir);
                    Debug.Log("outputLuaCodeDir:" + outputLuaCodeDir);
                    if (!Directory.Exists(excelFileDir)
                        || !Directory.Exists(outputTableDir)
                        || !Directory.Exists(outputCSCodeDir)
                        || !Directory.Exists(outputLuaCodeDir))
                    {
                        Debug.ThrowException("directory has error,please check");

                    }

                }
            }
        }


        //here is some old code,which not suit current table format and data structure
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
    }
}
