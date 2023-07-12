using ExcelTool.Core;
using ExcelTool.Obfuscation;
using ExcelTool.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExcelTool.Reader
{
    class ExcelWriter
    {
        public static void WriteCSCode(string outputDir, ExcelTable et)
        {
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            ExcelField primaryField = et.GetPrimaryField();

            #region step1:output Setting.cs base class
            string setting = "namespace ZGame.ZTable{\r\n";
            setting += "\tpublic class Setting{\r\n";
            setting += "\t}\r\n";
            setting += "}";
            File.WriteAllText(outputDir + @"\" + "Setting.cs", setting.TrimEnd(), Encoding.UTF8);
            #endregion

            #region step2:output table class
            string content = ""; ;
            content += "using System;\r\n";
            content += "using UnityEngine;\r\n";
            content += "using System.Text;\r\n";
            content += "\r\n";
            content += "namespace ZGame.ZTable{\r\n";
            if (et.isKVT)//if KVT,we should output addition class,which can direct get value by key
            {
                content += "public class " + et.tableName + "KVP{\r\n";

                for (int i = 0; i < primaryField.datas.Count; i++)
                {
                    string keyName = primaryField.datas[i].ToString();
                    content += "\t/// <summary>\r\n";
                    content += "\t/// " + et.fields[2].datas[i].ToString() + "\r\n";//KeyDes
                    content += "\t/// </summary>\r\n";
                    content += "\tpublic static " + et.fields[1].typeDes + " " + keyName + "{\r\n";
                    content += "\t\tget{\r\n";
                    content += "\t\t\treturn " + et.tableName + "Reader.Instance.GetEntityByPrimaryKey(\"" + keyName + "\").Value;\r\n";
                    content += "\t\t}\r\n";//get
                    content += "\t}\r\n";//attribute       
                }
                content += "}\r\n";//class                
            }

            content += "public class " + et.tableName + ":Setting{\r\n";

            for (int l = 0; l < et.fields.Count; l++)
            {
                if (et.fields[l].name.ContainChinese() ||
                    et.fields[l].name == "KeyDes")
                {
                    continue;//key为汉字的时候跳过（汉字作为字段的 用于注释说明）
                }
                content += "\t /// <summary>\r\n";
                content += "\t /// " + et.fields[l].fieldDes + "\r\n";
                if (et.fields[l].fieldDesMore != "")
                {
                    content += "\t /// " + et.fields[l].fieldDesMore + "\r\n";
                }
                content += "\t /// </summary>\r\n";
                content += "\t public " + et.fields[l].typeDes + " " + et.fields[l].name + ";\r\n";
                content += "\r\n";
            }
            content += "\t public static string FileName = " + "\"" + et.tableName + "\";\r\n";
            content += "}\r\n";
            content += "}";

            File.WriteAllText(outputDir + @"\" + et.tableName + ".cs", content.TrimEnd(), Encoding.UTF8);
            #endregion

            #region  step3:output table reader class
            content = "";

            content += "using UnityEngine;\r\n";
            content += "using System;\r\n";
            content += "using System.Text;\r\n";
            content += "using System.Collections.Generic;\r\n";
            content += "\r\n";

            content += "namespace ZGame.ZTable{\r\n";
            content += "\tpublic class " + et.tableName + "Reader{\r\n";

            content += "\t\tprivate " + et.tableName + "[] entities;\r\n";
            content += "\t\tprivate Dictionary<" + primaryField.typeDes + ",int> keyIndexMap = new Dictionary<" + primaryField.typeDes + ",int>();\r\n";

            content += "\r\n\t\tprivate int count;\r\n";
            content += "\t\t public int Count{\r\n";
            content += "\t\t\tget{ return this.count;}\r\n";
            content += "\t\t}\r\n\r\n";

            content += "\t\tstatic " + et.tableName + "Reader instance=null;\r\n";
            content += "\t\tpublic static " + et.tableName + "Reader Instance{\r\n";
            content += "\t\t\tget{\r\n";
            content += "\t\t\t\tif(instance==null){\r\n";
            content += "\t\t\t\t\tinstance=new " + et.tableName + "Reader();\r\n";
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

            for (int i = 0; i < et.fields.Count; i++)
            {
                string filedName = et.fields[i].name;
                string typeStr = et.fields[i].typeDes;
                if (typeStr == "int" || typeStr == "float")
                {
                    content += "\t\t\t\t\tentities[i]." + filedName + "=" + typeStr + ".Parse(vals[" + i + "].Trim());\r\n";
                }
                else if (typeStr == "object")
                {
                    content += "\t\t\t\t\tentities[i]." + filedName + "=(" + typeStr + ")(vals[" + i + "].Trim());\r\n";
                }
                else if (typeStr == "bool")
                {
                    content += "\t\t\t\t\tentities[i]." + filedName + "=" + typeStr + ".Parse(vals[" + i + "].Trim());\r\n";
                }
                else if (typeStr == "string")
                {
                    content += "\t\t\t\t\tentities[i]." + filedName + "=" + "vals[" + i + "];\r\n";
                }
                else if (typeStr == "string[]")
                {
                    content += "\t\t\t\t\tentities[i]." + filedName + "=" + "vals[" + i + "].Split(\'|\');\r\n";
                }
                else if (typeStr == "int[]")
                {
                    content += "\t\t\t\t\tentities[i]." + filedName + "=" + "vals[" + i + "].Split(\'|\').ToIntArray();\r\n";
                }
                else if (typeStr == "float[]")
                {
                    content += "\t\t\t\t\tentities[i]." + filedName + "=" + "vals[" + i + "].Split(\'|\').ToFloatArray();\r\n";
                }
                else if (typeStr == "Vector3")
                {
                    content += "\t\t\t\t\tentities[i]." + filedName + "=" + "new Vector3("
                        + "float.Parse(vals[" + i + "].Trim().Split(\'|\')[0]),"
                        + "float.Parse(vals[" + i + "].Trim().Split(\'|\')[1]),"
                        + "float.Parse(vals[" + i + "].Trim().Split(\'|\')[2])"
                        + ");\r\n";
                }
                //TODO:support more type
            }

            content += "\t\t\t\t\tkeyIndexMap[entities[i]." + primaryField.name + "]=i;\r\n";
            content += "\t\t\t\t}\r\n";//for
            content += "\t\t\t};\r\n\r\n";//Action
            content += "\t\t\tstring fileName=" + et.tableName + ".FileName;\r\n";
            content += "\t\t\tFileMgr.ReadFile(fileName,onTableLoad);\r\n";
            content += "\t\t}\r\n\r\n";//Load()

            content += "\t\t/// <summary>\r\n";
            content += "\t\t/// get datas of a row by Index\r\n";
            content += "\t\t/// index starts form 0,which marching the line 7 of excel table\r\n";
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
            content += "\t\t/// get datas of a row by primary key\r\n";
            content += "\t\t/// </summary>\r\n";
            content += "\t\tpublic " + et.tableName + " GetEntityByPrimaryKey(" + primaryField.typeDes + " key){\r\n";
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


            content += "\t\t/// <summary>\r\n";
            content += "\t\t/// get all row datas\r\n";
            content += "\t\t/// </summary>\r\n";
            content += "\t\tpublic " + et.tableName + "[]" + " AllItems(){\r\n";
            content += "\t\t\treturn this.entities;\r\n";
            content += "\t\t}\r\n";//AllItems


            content += "\t}\r\n";//class
            content += "}";//namespace

            File.WriteAllText(outputDir + @"\" + et.tableName + "Reader.cs", content.TrimEnd(), Encoding.UTF8);
            #endregion
            Debug.Log("write file " + et.tableName + ".cs");
        }

        public static void WriteBinaryFile(string outputDir, ExcelTable et)
        {
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            ExcelField primaryField = et.GetPrimaryField();


            string content = string.Empty;
            int rowCount = et.rowCount;
            int columnCount = et.fields.Count;
            for (int j = 0; j < rowCount - 6; j++)
            {
                for (int k = 0; k < columnCount; k++)
                {
                    ExcelField field = et.fields[k];
                    if (field.name == "KeyDes")  //输出CS对应的.txt文本文件时，不输出KeyDes字段
                        continue;

                    content += (field.datas[j] + "\t");
                }

                content = content.Remove(content.Length - 1);//移除行尾的\t字符//注意\t在串里，只有1个字符长度
                content += "\r\n";
            }

            string finalTableName = "tb_" + et.tableName.ToLower();//表名前加前缀tb_，尽量减低和其它资源同名的可能性
            if (Setting.IsFileNameEncrypt)
            {
                finalTableName = DES.EncryptStrToHex(finalTableName, Setting.FileNameEncryptKey);
            }
            string path = outputDir + @"\" + finalTableName + ".bin";

            if (!Setting.IsEncrypt)
            {
                //File.WriteAllText(path, content.TrimEnd(), Encoding.UTF8);
                File.WriteAllText(path, content.TrimEnd(), new UTF8Encoding(false));//必须用no-bom的格式，否则读取的时候数据头会影响
            }
            else
            {
                content = Encrypt.TextEncrypt(content.TrimEnd(), Setting.EncryptKey);
                byte[] array = Encoding.UTF8.GetBytes(content.TrimEnd());
                FileStream fs = new FileStream(path, FileMode.Create);
                fs.Write(array, 0, array.Length);
                fs.Close();
            }

            Debug.Log("write file " + et.tableName + ".bin");
        }

        public static void WriteLuaCode(string outputDir, List<ExcelTable> tables)
        {
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }


            string outputFile = outputDir + @"\ConfigTable.lua";
            string luaContent = "---@class ConfigTable\r\n";
            luaContent += "local ConfigTable={}\r\n";
            for (int i = 0; i < tables.Count; i++)
            {
                var table = tables[i];
                ExcelField primaryField = table.GetPrimaryField();
                string luaContentSub = "";
                if (table.isKVT)
                {
                    luaContentSub += "\r\n";


                    luaContentSub += "---@class " + table.tableName + ":ConfigTable\r\n";
                    luaContentSub += "ConfigTable." + table.tableName + "={\r\n";
                    for (int j = 6; j < table.rowCount; j++)
                    {
                        var kStr = table.fields[0].datas[j - 6];
                        var vStr = table.fields[1].datas[j - 6];
                        //var kStr = table.tableContent[table.primaryKeyName][j];
                        //var vStr = table.tableContent["Value"][j];
                        var commentStr = table.fields[2].datas[j - 6];

                        if (j == 6)
                        {
                            luaContentSub = "---@field public " + kStr + " @" + commentStr + luaContentSub;
                        }
                        else
                        {
                            luaContentSub = "---@field public " + kStr + " @" + commentStr + "\r\n" + luaContentSub;
                        }

                        luaContentSub += "\t" + kStr + "=\"" + vStr + "\",\r\n";

                    }
                    luaContentSub += "}\r\n";
                }
                else
                {
                    luaContentSub += "\r\n";

                    luaContentSub += "---@class " + table.tableName + ":ConfigTable\r\n";
                    luaContentSub += "ConfigTable." + table.tableName + "={\r\n";
                    for (int j = 6; j < table.rowCount; j++)
                    {
                        var typeDes = table.fields[0].typeDes;
                        if (typeDes == "int")
                        {

                            luaContentSub += "\t[" + table.fields[0].datas[j - 6] + "]={";
                        }
                        else if (typeDes == "string")
                        {

                            luaContentSub += "\t[\"" + table.fields[0].datas[j - 6] + "\"]={";
                        }
                        else
                        {
                            Debug.LogError("error, primary type only support int and string, cur is:" + typeDes);
                        }


                        for (int k = 0; k < table.fields.Count; k++)
                        {
                            var field = table.fields[k];
                            var keyName = field.name;
                            var value = field.datas[j - 6];
                            if (field.typeDes == "string")
                            {
                                luaContentSub += keyName + "=\"" + value + "\",";
                            }

                            else if (field.typeDes == "Vector3" || field.typeDes == "float[]" || field.typeDes == "int[]" || field.typeDes == "string[]")
                            {
                                luaContentSub += keyName + "=";
                                //+ value + ",";
                                luaContentSub += "{";
                                if (value != "")
                                {
                                    var vs = value.Split('|');
                                    for (int p = 0; p < vs.Length; p++)
                                    {
                                        if (field.typeDes == "float[]" || field.typeDes == "Vector3")
                                        {
                                            luaContentSub += float.Parse(vs[p]);
                                        }
                                        else if (field.typeDes == "int[]")
                                        {
                                            luaContentSub += int.Parse(vs[p]);
                                        }
                                        else if (field.typeDes == "string[]")
                                        {
                                            luaContentSub += "\"" + vs[p] + "\"";
                                        }
                                        if (p < vs.Length - 1)
                                        {
                                            luaContentSub += ",";
                                        }
                                    }
                                }


                                luaContentSub.TrimEnd(',');
                                luaContentSub += "},";
                            }
                            else if (field.typeDes != "")
                            {
                                luaContentSub += keyName + "= " + value + " ,";
                            }
                        }
                        luaContentSub += "},\r\n";
                    }
                    luaContentSub += "}\r\n";



                }



                luaContentSub += "local mt_" + table.tableName + "={}\r\n";
                luaContentSub += "mt_" + table.tableName + ".__index=function(t,k)\r\n";
                luaContentSub += "\tLogE(\"can not find item with key:\"..k..\" in " + table.tableName + "\")\r\n";
                luaContentSub += "end\r\n";
                luaContentSub += "setmetatable(ConfigTable." + table.tableName + ",mt_" + table.tableName + ")\r\n";
                luaContentSub += "\r\n";

                luaContent += luaContentSub;


            }

            luaContent += "return ConfigTable";


            File.WriteAllText(outputFile, luaContent.TrimEnd(), new UTF8Encoding(false));
            Console.WriteLine("ConfigTable.lua输出完毕");

        }
    }
}
