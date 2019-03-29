using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excel;
using System.Data;

/*
 *参考至： http://www.cnblogs.com/fly-100/p/4538975.html
     */


namespace ExcelTool
{
    public class ExcelTable
    {
        /// <summary>
        /// 表的名称，后续用来做自动生成的代码的类名
        /// </summary>
        public string tableName;



        /// <summary>
        /// 具体内容行数，为excel数据表第五行开始的数据
        /// </summary>
        public int usedRowsCount;

        /// <summary>
        /// 存储字段名称
        /// </summary>
        public List<string> keys = new List<string>();

        /// <summary>
        /// 具体内容，key为字段名称， value为具体内容
        /// value[0]数据类型，value[1]特殊标识， value[2]中文名称，value[3]详细描述，value[4]及之后才是具体的内容
        /// </summary>
        public Dictionary<string, List<string>> tableContent = new Dictionary<string, List<string>>();


        public string primaryKeyName;
        public string primaryKeyType;
        public bool isKVPairTable = false;
        public string valueKeyType;//当isKVPairTable为true的时候，Value字段的类型

    }


    class Program
    {
        static bool isEncrypt = false;
        static string encryptKey = "hello";

        static string excelFileDir;
        static string[] excelFiles;

        static string outputTableDir;//excel导出表 目录
        static string outputCSCodeDir;//CS导出代码 目录
        static string outputLuaCodeDir;//Lua导出代码 目录
        static void Main(string[] args)
        {
            Console.WriteLine("begin handle excel file");
            Console.WriteLine("--->try get all excel file");

            List<ExcelTable> excelTables = new List<ExcelTable>();


            string curDir = Environment.CurrentDirectory;
            excelFileDir = curDir.Substring(0, curDir.LastIndexOf(@"\"));
            outputTableDir = excelFileDir + @"\table_output";
            outputCSCodeDir = excelFileDir + @"\code_output_cs";
            outputLuaCodeDir = excelFileDir + @"\code_output_lua";

            excelFileDir = excelFileDir + @"\table";
            Console.WriteLine("tableDir:" + excelFileDir);

            //.xls为03版本excel后缀
            //经测试该库，不支持03版本excel
            excelFiles = Directory.GetFiles(excelFileDir, "*.xlsx", SearchOption.TopDirectoryOnly);
            foreach (var item in excelFiles)
            {
                Console.WriteLine("--->Get xlsx file:" + Path.GetFileName(item));
            }

            for (int q = 0; q < excelFiles.Length; q++)
            {
                FileStream fs = File.Open(excelFiles[q], FileMode.Open, FileAccess.Read);
                //Reading from a OpenXml Excel file (2007 format; *.xlsx)
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                DataSet result = excelReader.AsDataSet();
                //获得一个xlsx文件中所有的tables
                DataTableCollection tables = result.Tables;
                fs.Close();

                foreach (DataTable table in tables)
                {
                    ExcelTable et = new ExcelTable();
                    et.tableName = table.TableName;
                    Console.WriteLine("----------------->tableName:" + et.tableName);
                    int rowCount = table.Rows.Count;
                    et.usedRowsCount = rowCount - 5;

                    int columnCount = table.Columns.Count;



                    for (int i = 0; i < rowCount; i++)
                    {
                        if (i == 0)//获得key  
                        {
                            for (int j = 0; j < columnCount; j++)
                            {
                                var key = table.Rows[0][j].ToString();

                                if (j == 0)//主键
                                {
                                    et.primaryKeyName = key;
                                    et.primaryKeyType = table.Rows[1][j].ToString();
                                    if (table.Rows[2][j].ToString().Contains("KVT"))
                                    {
                                        et.isKVPairTable = true;
                                        et.valueKeyType = table.Rows[1][1].ToString();
                                        if (table.Rows[0][1].ToString() != "Value" || table.Rows[0][2].ToString() != "KeyDes")
                                        {
                                            throw new Exception(et.tableName + "表有问题，KVT表，要求第二个字段名为 Value，第三个字段名为 KeyDes");
                                        }

                                    }
                                    else
                                    {
                                        et.isKVPairTable = false;
                                    }
                                }

                                Console.WriteLine("@@初始化map, key:" + key);
                                et.tableContent[key] = new List<string>();

                                if (et.keys.Contains(key))
                                {
                                    throw new Exception("fatal error, table:" + et.tableName + ",有重复的字段:" + key);
                                }
                                else
                                {
                                    if (!CheckStringChinese(key) && key != "KeyDes")//字段非中文才加入,且 KeyDes字段不用加入
                                    {
                                        et.keys.Add(key);
                                    }
                                }

                            }
                            Console.WriteLine("@@初始化map key完毕");
                        }
                        else
                        {
                            for (int k = 0; k < columnCount; k++)
                            {
                                string key = table.Rows[0][k].ToString();
                                string property = table.Rows[i][k].ToString();
                                Console.WriteLine("table:" + et.tableName + " , key: " + key + " , property：" + property);

                                //主键的数据要保持唯一性
                                if (k == 0 && i > 4 && et.tableContent[key].Contains(property))
                                {
                                    throw new Exception("fatal error, table:" + et.tableName + "的主键" + key + "，property:" + property);
                                }
                                else
                                {
                                    et.tableContent[key].Add(property);
                                }

                            }


                        }
                    }

                    excelTables.Add(et);
                }
            }






            #region  导出C#代码
            outputCSCode(outputCSCodeDir, outputTableDir, excelTables);
            #endregion

            #region 导出lua代码
            outputLuaCode(outputLuaCodeDir, excelTables);
            #endregion


            Console.ReadLine();
        }

        static void outputCSCode(string outputCSCodeDir, string outputTableDir, List<ExcelTable> tables)
        {
            //生成CS代码
            if (!Directory.Exists(outputCSCodeDir))
            {
                Directory.CreateDirectory(outputCSCodeDir);
            }
            int tableCount2 = tables.Count;
            for (int jj = 0; jj < tableCount2; jj++)//生成数据类代码(对于需要生成KeyConstStr的，还需要生成对应辅助类)
            {
                string content = string.Empty;
                ExcelTable et = tables[jj];
                int columnCount = et.keys.Count;


                content += "using System;\r\n";
                content += "using System.Text;\r\n";
                content += "\r\n";

                content += "namespace SelfTable{\r\n";

                if (et.isKVPairTable)//生成对应辅助类
                {
                    content += "public class " + et.tableName + "KVP{\r\n";
                    for (int k = 4; k < et.tableContent[et.primaryKeyName].Count; k++)
                    {
                        var tmp = et.tableContent[et.primaryKeyName][k];
                        content += "\t/// <summary>\r\n";
                        content += "\t/// " + et.tableContent["KeyDes"][k].ToString() + "\r\n";//备注文字
                        content += "\t/// </summary>\r\n";
                        content += "\tpublic static " + et.valueKeyType + " " + tmp + "{\r\n";
                        content += "\t\tget{\r\n";
                        content += "\t\t\treturn " + et.tableName + "_table.Instance.GetEntityByPrimaryKey(\"" + tmp + "\").Value;\r\n";
                        content += "\t\t}\r\n";//get
                        content += "\t}\r\n";//属性                         
                    }
                    content += "}\r\n";//class
                }



                content += "public class " + et.tableName + "{\r\n";

                for (int l = 0; l < columnCount; l++)
                {
                    if (CheckStringChinese(et.keys[l]))
                    {
                        continue;//key为汉字的时候跳过（汉字作为字段的 用于注释说明）
                    }
                    content += "\t /// <summary>\r\n";
                    content += "\t /// " + et.tableContent[et.keys[l]][2] + "\r\n";//属性中文名称
                    if (et.tableContent[et.keys[l]][3].ToString() != "")
                    {
                        content += "\t /// " + et.tableContent[et.keys[l]][3] + "\r\n";//属性详细说明
                    }
                    content += "\t /// </summary>\r\n";
                    content += "\t public " + et.tableContent[et.keys[l]][0] + " " + et.keys[l] + ";\r\n";//数据类型 数据名称
                    content += "\r\n";
                }
                content += "\t public static string FileName = " + "\"" + et.tableName + "\";\r\n";
                content += "}\r\n";
                content += "}";


                File.WriteAllText(outputCSCodeDir + @"\" + et.tableName + ".cs", content.TrimEnd(), Encoding.UTF8);
            }

            for (int kk = 0; kk < tableCount2; kk++)//生成文件加载和数据读取代码
            {
                string content = string.Empty;
                ExcelTable et = tables[kk];
                int columnCount = et.keys.Count;

                content += "using UnityEngine;\r\n";
                content += "using System;\r\n";
                content += "using System.Text;\r\n";
                content += "using System.Collections.Generic;\r\n";
                content += "\r\n";

                content += "namespace SelfTable{\r\n";
                content += "\tpublic class " + et.tableName + "_table{\r\n";

                content += "\t\tprivate " + et.tableName + "[] entities;\r\n";
                //content += "\t\tprivate Dictionary<string,int> keyIndexMap = new Dictionary<string,int>();\r\n";
                content += "\t\tprivate Dictionary<" + et.primaryKeyType + ",int> keyIndexMap = new Dictionary<" + et.primaryKeyType + ",int>();\r\n";

                content += "\r\n\t\tprivate int count;\r\n";
                content += "\t\t/// <summary>\r\n";
                content += "\t\t/// 数量\r\n";
                content += "\t\t/// </summary>\r\n";
                content += "\t\t public int Count{\r\n";
                content += "\t\t\tget{ return this.count;}\r\n";
                content += "\t\t}\r\n\r\n";

                content += "\t\tstatic " + et.tableName + "_table instance=null;\r\n";
                content += "\t\tpublic static " + et.tableName + "_table Instance{\r\n";
                content += "\t\t\tget{\r\n";
                content += "\t\t\t\tif(instance==null){\r\n";
                content += "\t\t\t\t\tinstance=new " + et.tableName + "_table();\r\n";
                content += "\t\t\t\t\tinstance.Load();\r\n";
                content += "\t\t\t\t}\r\n";
                content += "\t\t\t\treturn instance;\r\n";
                content += "\t\t\t}\r\n";
                content += "\t\t}\r\n\r\n";

                content += "\t\tvoid Load(){\r\n";
                content += "\t\t\tAction<string> onTableLoad=(text)=>{\r\n";
                content += "\t\t\t\t";
                content += @"string[] lines=text.Split(new string[]{""\r\n""},System.StringSplitOptions.RemoveEmptyEntries);";
                content += "\r\n";
                content += "\t\t\t\tint count=lines.Length;\r\n";
                content += "\t\t\t\tif(count<0){\r\n";
                content += "\t\t\t\t\treturn;\r\n";
                content += "\t\t\t\t}\r\n";
                content += "\t\t\t\tthis.count = count;\r\n";
                content += "\t\t\t\tentities=new " + et.tableName + "[count];\r\n";
                content += "\t\t\t\tfor(int i=0;i<count;i++){\r\n";
                content += "\t\t\t\t\tstring line=lines[i];\r\n";
                content += "\t\t\t\t\tif(string.IsNullOrEmpty(line)){\r\n";
                content += "\t\t\t\t\t\t";
                content += @"Debug.LogError(""data error, line ""+i+"" is null"");";
                content += "\r\n\t\t\t\t\t}\r\n";
                content += "\t\t\t\t\tstring[] vals=line.Split('\\t');\r\n";
                content += "\t\t\t\t\tentities[i]=new " + et.tableName + "();\r\n";

                for (int i = 0; i < et.keys.Count; i++)
                {
                    string typeStr = et.tableContent[et.keys[i]][0];
                    if (typeStr == "int" || typeStr == "float" || typeStr == "bool")
                    {
                        content += "\t\t\t\t\tentities[i]." + et.keys[i] + "=" + typeStr + ".Parse(vals[" + i + "].Trim());\r\n";
                    }
                    else
                    {
                        content += "\t\t\t\t\tentities[i]." + et.keys[i] + "= vals[" + i + "].Trim();\r\n";
                    }
                }

                content += "\t\t\t\t\tkeyIndexMap[entities[i]." + et.keys[0] + "]=i;\r\n";
                content += "\t\t\t\t}\r\n";//for
                content += "\t\t\t};\r\n\r\n";//Action
                content += "\t\t\tstring fileName=" + et.tableName + ".FileName;\r\n";
                content += "\t\t\tFileMgr.ReadFile(fileName,onTableLoad);\r\n";

                content += "\t\t}\r\n\r\n";//Load()

                content += "\t\t/// <summary>\r\n";
                content += "\t\t/// 根据Index获得具体某行数据\r\n";
                content += "\t\t/// index从0开始，对应excel数据中的对应行\r\n";
                content += "\t\t/// </summary>\r\n";
                content += "\t\tpublic " + et.tableName + " GetEntityByRowIndex(int index){\r\n";
                content += "\t\t\tif(index<0||index>count){\r\n";
                content += "\t\t\t\t";
                content += @"Debug.LogError(""index:""+index+"" is not valid"");";
                content += "\r\n";
                content += "\t\t\t\treturn null;\r\n";
                content += "\t\t\t}\r\n\t\t\telse{\r\n";
                content += "\t\t\t\treturn entities[index];\r\n";
                content += "\t\t\t}\r\n";
                content += "\t\t}\r\n";//GetEntityByRowIndex

                content += "\t\t/// <summary>\r\n";
                content += "\t\t/// 根据主键获得具体某行数据\r\n";
                content += "\t\t/// 需要确保主键不重复\r\n";
                content += "\t\t/// </summary>\r\n";
                content += "\t\tpublic " + et.tableName + " GetEntityByPrimaryKey(" + et.primaryKeyType + " key){\r\n";
                content += "\t\t\tint index;\r\n";
                content += "\t\t\tif(keyIndexMap.TryGetValue(key,out index)){\r\n";
                content += "\t\t\t\treturn entities[index];\r\n";
                content += "\t\t\t}\r\n\t\t\telse{\r\n";
                content += "\t\t\t\t";
                content += @"Debug.LogError(""no entity with key:""+key);";
                content += "\r\n";
                content += "\t\t\t\treturn default(" + et.tableName + ");\r\n";
                content += "\t\t\t}\r\n";
                content += "\t\t}\r\n";//GetEntityByPrimaryKey

                content += "\t}\r\n";//class
                content += "}";//namespace


                File.WriteAllText(outputCSCodeDir + @"\" + et.tableName + "_table.cs", content.TrimEnd(), Encoding.UTF8);
            }





            //把数据导出为二进制文件
            //每个表导出一个单独的文件，且文件名为表名，后缀.bin
            if (!Directory.Exists(outputTableDir))
            {
                Directory.CreateDirectory(outputTableDir);
            }

            int tableCount = tables.Count;
            for (int i = 0; i < tableCount; i++)
            {
                string content = string.Empty;
                ExcelTable et = tables[i];

                int columnCount = et.keys.Count;
                int rowCount = et.usedRowsCount;
                for (int j = 4; j < rowCount + 4; j++)
                {
                    for (int k = 0; k < columnCount; k++)
                    {
                        if (et.keys[k].Equals("KeyDes"))  //输出CS对应的.txt文本文件时，不输出KeyDes字段                            
                            continue;

                        if (k == columnCount - 1)
                        {
                            content += (et.tableContent[et.keys[k]][j].Trim() + "\r\n");
                        }
                        else
                        {
                            content += (et.tableContent[et.keys[k]][j].Trim() + "\t");
                        }
                    }
                }

                string path = outputTableDir + @"\" + et.tableName + ".bin";

                if (!isEncrypt)
                {
                    //File.WriteAllText(path, content.TrimEnd(), Encoding.UTF8);
                    File.WriteAllText(path, content.TrimEnd(), new UTF8Encoding(false));//必须用no-bom的格式，否则读取的时候数据头会影响
                }
                else//加密
                {
                    content = TextEncrypt(content.TrimEnd(), encryptKey);

                    //将string转为byte数组
                    byte[] array = Encoding.UTF8.GetBytes(content.TrimEnd());
                    //创建一个文件流
                    FileStream fs = new FileStream(path, FileMode.Create);
                    //将byte数组写入文件中
                    fs.Write(array, 0, array.Length);
                    fs.Close();
                }
            }

            Console.WriteLine("CS导表结束！！！");

        }

        static void outputLuaCode(string outputFolderPath, List<ExcelTable> tables)
        {
            string outputFile = outputFolderPath + @"\SettingTable.lua";
            string luaContent = "---@class SettingTable\r\n";
            luaContent += "local SettingTable={}\r\n";
            for (int i = 0; i < tables.Count; i++)
            {
                var table = tables[i];
                if (table.isKVPairTable)
                {
                    luaContent += "\r\n";
                    luaContent += "---@field public " + table.tableName + " table\r\n";
                    luaContent += "---@class " + table.tableName + ":SettingTable\r\n";
                    luaContent += "SettingTable." + table.tableName + "={\r\n";
                    for (int j = 4; j < table.usedRowsCount + 4; j++)
                    {
                        var kStr = table.tableContent[table.primaryKeyName][j];
                        var vStr = table.tableContent["Value"][j];
                        var commentStr = table.tableContent["KeyDes"][j];
                        if (table.valueKeyType == "string")
                        {
                            luaContent += "\t" + kStr + "=\"" + vStr + "\",--" + commentStr + "\r\n";
                        }
                        else
                        {
                            luaContent += "\t" + kStr + "=" + vStr + ",--" + commentStr + "\r\n";
                        }
                    }
                    luaContent += "}\r\n";
                }
                else
                {
                    luaContent += "\r\n";
                    luaContent += "---@field public " + table.tableName + " table\r\n";
                    luaContent += "---@class " + table.tableName + ":SettingTable\r\n";
                    luaContent += "SettingTable." + table.tableName + "={\r\n";
                    for (int j = 4; j < table.usedRowsCount + 4; j++)
                    {
                        luaContent += "\t{";
                        for (int k = 0; k < table.keys.Count; k++)
                        {
                            var keyName = table.keys[k];

                            var value = table.tableContent[keyName][j];
                            if (table.tableContent[keyName][0] == "string")
                            {
                                luaContent += keyName + "=\"" + value + "\",";
                            }
                            else
                            {
                                luaContent += keyName + "=" + value + ",";
                            }
                        }
                        luaContent += "},\r\n";
                    }
                    luaContent += "}\r\n";


                    luaContent += "SettingTable.Get" + table.tableName.Substring(0, table.tableName.Length - 7) + "By" + table.primaryKeyName + "=function(" + table.primaryKeyName + ")\r\n";
                    luaContent += "\tfor i=1,#SettingTable." + table.tableName + " do\r\n";
                    luaContent += "\t\tlocal tmp=SettingTable." + table.tableName + "[i]\r\n";
                    luaContent += "\t\tif tmp." + table.primaryKeyName + "==" + table.primaryKeyName + " then\r\n";
                    luaContent += "\t\t\treturn tmp\r\n";
                    luaContent += "\t\tend\r\n";
                    luaContent += "\tend\r\n";
                    luaContent += "\tloge(\"error,get " + table.tableName.Substring(0, table.tableName.Length - 7) + " By " + table.primaryKeyName + ":\"+" + table.primaryKeyName + ")\r\n";
                    luaContent += "\treturn nil\r\n";

                    luaContent += "end\r\n";
                }
            }

            luaContent += "return SettingTable";


            File.WriteAllText(outputFile, luaContent.TrimEnd(), new UTF8Encoding(false));
            Console.WriteLine("SettingTable.lua输出完毕");
        }



        /// <summary>
        /// 用 ASCII 码范围判断字符是不是汉字
        /// </summary>
        /// <param name="text">待判断字符或字符串</param>
        /// <returns>真：是汉字；假：不是</returns>
        static bool CheckStringChinese(string text)
        {
            bool res = false;
            foreach (char t in text)
            {
                if ((int)t > 127)
                    res = true;
            }
            return res;
        }



        //http://www.jb51.net/article/58442.htm
        static string TextEncrypt(string content, string secretKey)
        {
            char[] data = content.ToCharArray();
            char[] key = secretKey.ToCharArray();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= key[i % key.Length];
            }
            return new string(data);
        }
        private string TextDecrypt(char[] data, string secretKey)
        {
            char[] key = secretKey.ToCharArray();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= key[i % key.Length];
            }
            return new string(data);
        }
    }
}
