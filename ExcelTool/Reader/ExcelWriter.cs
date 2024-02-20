using ExcelTool.Core;
using ExcelTool.Obfuscation;
using ExcelTool.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            #region step1:output table class
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

            content += "public class " + et.tableName + "{\r\n";

            for (int l = 0; l < et.fields.Count; l++)
            {
                if (et.fields[l].fieldName.ContainChinese() ||
                    et.fields[l].fieldName == "KeyDes")
                {
                    continue;//key为汉字的时候跳过（汉字作为字段的 用于注释说明）
                }
                content += "\t /// <summary>\r\n";
                content += "\t /// " + et.fields[l].fieldDes + "\r\n";
                if (et.fields[l].fieldDesMore != "")
                {
                    content += "\t /// " + et.fields[l].fieldDesMore.Trim().Replace("\n", "\n\t /// ") + "\r\n";
                }
                content += "\t /// </summary>\r\n";
                content += "\t public " + et.fields[l].typeDes + " " + et.fields[l].fieldName + ";\r\n";
                content += "\r\n";
            }
            content += "\t public static string FileName = " + "\"" + "tb_" + et.tableName.ToLower() + "\";\r\n";
            content += "}\r\n";
            content += "}";

            File.WriteAllText(outputDir + @"\" + et.tableName + ".cs", content.TrimEnd(), Encoding.UTF8);
            #endregion

            #region  step2:output table reader class
            content = "";

            content += "using UnityEngine;\r\n";
            content += "using System;\r\n";
            content += "using System.Text;\r\n";
            content += "using System.Collections.Generic;\r\n";
            content += "\r\n";

            content += "namespace ZGame.ZTable{\r\n";
            content += "\tpublic class " + et.tableName + "Reader{\r\n";

            content += "\t\tprivate Dictionary<" + primaryField.typeDes + "," + et.tableName + "> entityMap = new Dictionary<" + primaryField.typeDes + "," + et.tableName + ">();\r\n";
            content += "\r\n";

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
            content += "\t\t\tAction<string> onTableLoad=(txt)=>{\r\n";
            content += "\t\t\t\t";
            content += @"string[] lines=txt.Split(new string[]{""\r\n""},System.StringSplitOptions.RemoveEmptyEntries);";
            content += "\r\n";
            content += "\t\t\t\tint count=lines.Length;\r\n";
            content += "\t\t\t\tif(count<0){\r\n";
            content += "\t\t\t\t\treturn;\r\n";
            content += "\t\t\t\t}\r\n";
            content += "\t\t\t\tfor(int i=0;i<count;i++){\r\n";
            content += "\t\t\t\t\tstring line=lines[i];\r\n";
            content += "\t\t\t\t\tif(string.IsNullOrEmpty(line)){\r\n";
            content += "\t\t\t\t\t\t";
            content += @"Debug.LogError(""data error, line ""+i+"" is null"");";
            content += "\r\n";
            content += "\t\t\t\t\t\tcontinue;\r\n";
            content += "\t\t\t\t\t}\r\n";
            content += $"\t\t\t\t\tstring[] vals=line.Split(\"{Setting.SeprateStr}\");\r\n";
            content += "\t\t\t\t\tint key=int.Parse(vals[0].Trim());\r\n";
            content += "\t\t\t\t\tif(entityMap.ContainsKey(key)){\r\n";
            content += "\t\t\t\t\t\t";
            content += @"Debug.LogError(""error,already exist key: ""+key+"" in " + et.tableName + @",line content:""+line);";
            content += "\r\n";
            content += "\t\t\t\t\t\tcontinue;\r\n";
            content += "\t\t\t\t\t}\r\n";

            content += "\t\t\t\t\tvar entity=new " + et.tableName + "();\r\n";

            for (int i = 0; i < et.fields.Count; i++)
            {
                string filedName = et.fields[i].fieldName;
                string typeStr = et.fields[i].typeDes;
                if (typeStr == "int" || typeStr == "float" || typeStr == "uint" || typeStr == "long")
                {
                    content += "\t\t\t\t\tentity." + filedName + "=" + typeStr + ".Parse(vals[" + i + "].Trim());\r\n";
                }
                else if (typeStr == "object")
                {
                    content += "\t\t\t\t\tentity." + filedName + "=(" + typeStr + ")(vals[" + i + "].Trim());\r\n";
                }
                else if (typeStr == "bool")
                {
                    content += "\t\t\t\t\tentity." + filedName + "=" + typeStr + ".Parse(vals[" + i + "].Trim());\r\n";
                }
                else if (typeStr == "string")
                {
                    content += "\t\t\t\t\tentity." + filedName + "=" + "vals[" + i + "];\r\n";
                }
                else if (typeStr == "string[]")
                {
                    content += "\t\t\t\t\tentity." + filedName + "=" + "vals[" + i + "].Split(\',\');\r\n";
                }
                else if (typeStr == "int[]")
                {
                    content += "\t\t\t\t\tentity." + filedName + "=" + "vals[" + i + "].Split(\',\').ToIntArray();\r\n";
                }
                else if (typeStr == "uint[]")
                {
                    content += "\t\t\t\t\tentity." + filedName + "=" + "vals[" + i + "].Split(\',\').ToUintArray();\r\n";
                }
                else if (typeStr == "long[]")
                {
                    content += "\t\t\t\t\tentity." + filedName + "=" + "vals[" + i + "].Split(\',\').ToLongArray();\r\n";
                }
                else if (typeStr == "float[]")
                {
                    content += "\t\t\t\t\tentity." + filedName + "=" + "vals[" + i + "].Split(\',\').ToFloatArray();\r\n";
                }
                else if (typeStr == "Vector3")
                {
                    content += "\t\t\t\t\tentity." + filedName + "=" + "new Vector3("
                        + "float.Parse(vals[" + i + "].Trim().Split(\',\')[0]),"
                        + "float.Parse(vals[" + i + "].Trim().Split(\',\')[1]),"
                        + "float.Parse(vals[" + i + "].Trim().Split(\',\')[2])"
                        + ");\r\n";
                }
                //TODO:support more type
            }

            content += "\t\t\t\t\tentityMap[key]=entity;\r\n";
            content += "\t\t\t\t}\r\n";//for
            content += "\t\t\t};\r\n\r\n";//Action
            content += "\t\t\tstring fileName=" + et.tableName + ".FileName;\r\n";
            content += "\t\t\ttry{\r\n";
            content += "\t\t\t\tFileMgr.ReadFile(fileName,onTableLoad);\r\n";
            content += "\t\t\t}\r\n";
            content += "\t\t\tcatch(System.Exception ex){\r\n";
            content += "\t\t\t\t";
            content += @"Debug.LogError(""error while read:""+fileName+ "", ex:"" + ex.ToString());";
            content += "\r\n";
            content += "\t\t\t}\r\n";
            content += "\t\t}\r\n\r\n";//Load()



            content += "\t\t/// <summary>\r\n";
            content += "\t\t/// get data by primary key\r\n";
            content += "\t\t/// </summary>\r\n";
            content += "\t\tpublic " + et.tableName + " GetEntity(" + primaryField.typeDes + " key){\r\n";
            content += "\t\t\t" + et.tableName + " data;\r\n";
            content += "\t\t\tif(entityMap.TryGetValue(key,out data)){\r\n";
            content += "\t\t\t\treturn data;\r\n";
            content += "\t\t\t}\r\n\t\t\telse{\r\n";
            content += "\t\t\t\t";
            content += @"Debug.LogError(""no entity with key:""+key+"" in " + et.tableName + @""");";
            content += "\r\n";
            content += "\t\t\t\treturn default(" + et.tableName + ");\r\n";
            content += "\t\t\t}\r\n";
            content += "\t\t}\r\n";//GetEntityByPrimaryKey


            content += "\t\t/// <summary>\r\n";
            content += "\t\t/// get all datas\r\n";
            content += "\t\t/// </summary>\r\n";
            content += "\t\tpublic Dictionary<" + primaryField.typeDes + "," + et.tableName + "> GetEntityMap(){\r\n";
            content += "\t\t\treturn this.entityMap;\r\n";
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
            for (int j = 0; j < rowCount - FieldRowEnum.DATA_START_ROW; j++)
            {
                for (int k = 0; k < columnCount; k++)
                {
                    ExcelField field = et.fields[k];
                    if (field.fieldName == "KeyDes")  //输出CS对应的.txt文本文件时，不输出KeyDes字段
                        continue;

                    content += (field.datas[j] + Setting.SeprateStr);
                }

                content = content.Remove(content.Length - Setting.SeprateStr.Length);//移除行尾的分割符
                content += "\r\n";
            }

            string finalTableName = "tb_" + et.tableName.ToLower();//输出的二进制表名文件加个前缀tb_,尽量避免和其它资源重名;表名转成小写，是因为有些平台不区分大小写，项目中保证资源名都是小写，避免因为大小写导致文件加载出错。
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

            Debug.Log("write file " + finalTableName + ".bin, originName:" + et.tableName);
        }

        public static void WriteLuaCode(string outputDir, List<ExcelTable> tables)
        {
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            for (int i = 0; i < tables.Count; i++)
            {
                var table = tables[i];
                string outTableName = table.tableName + "Table";
                string outputFile = outputDir + @"\" + outTableName + ".lua";

                ExcelField primaryField = table.GetPrimaryField();
                string luaContentSub = "";
                if (table.isKVT)
                {
                    luaContentSub += "\r\n";
                    luaContentSub += "---@class " + outTableName + "\r\n";
                    luaContentSub += "local " + outTableName + "={\r\n";
                    for (int j = FieldRowEnum.DATA_START_ROW; j < table.rowCount; j++)
                    {
                        var kStr = table.fields[0].datas[j - FieldRowEnum.DATA_START_ROW];
                        var vStr = table.fields[1].datas[j - FieldRowEnum.DATA_START_ROW];
                        //var kStr = table.tableContent[table.primaryKeyName][j];
                        //var vStr = table.tableContent["Value"][j];
                        var commentStr = table.fields[2].datas[j - FieldRowEnum.DATA_START_ROW];

                        if (j == FieldRowEnum.DATA_START_ROW)
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

                    luaContentSub += "---@class " + outTableName + "\r\n";
                    for (int f = 0; f < table.fields.Count; f++)
                    {
                        //string luaFieldType = table.fields[f].typeDes.Replace("uint[]","number[]").Replace;
                        string luaFieldType = "unknow";
                        string typeDes = table.fields[f].typeDes;
                        if (typeDes == "Vector2" || typeDes == "Vector3" || typeDes == "float[]" || typeDes == "int[]" || typeDes == "uint[]" || typeDes == "long[]")
                        {
                            luaFieldType = "number[]";
                        }
                        else if (typeDes == "int" || typeDes == "uint" || typeDes == "long" || typeDes == "float")
                        {
                            luaFieldType = "number";
                        }
                        else
                        {
                            luaFieldType = typeDes;
                        }
                        luaContentSub += "---@field " + table.fields[f].fieldName + " " + luaFieldType + "\r\n";
                    }
                    luaContentSub += "local " + outTableName + "={\r\n";
                    for (int j = FieldRowEnum.DATA_START_ROW; j < table.rowCount; j++)
                    {
                        var typeDes = table.fields[0].typeDes;
                        if (typeDes == "int" || typeDes == "long")
                        {

                            luaContentSub += "\t[" + table.fields[0].datas[j - FieldRowEnum.DATA_START_ROW] + "]={";
                        }
                        else if (typeDes == "string")
                        {

                            luaContentSub += "\t[\"" + table.fields[0].datas[j - FieldRowEnum.DATA_START_ROW] + "\"]={";
                        }
                        else
                        {
                            Debug.LogError("error, primary type only support int、long and string, cur is:" + typeDes);
                        }

                        for (int k = 0; k < table.fields.Count; k++)
                        {
                            var field = table.fields[k];
                            var keyName = field.fieldName;
                            var value = field.datas[j - FieldRowEnum.DATA_START_ROW];
                            if (field.typeDes == "string")
                            {
                                luaContentSub += keyName + "=\"" + value + "\",";
                            }
                            else if (field.typeDes == "Vector2" || field.typeDes == "Vector3" || field.typeDes == "float[]" || field.typeDes == "int[]" || field.typeDes == "uint[]" || field.typeDes == "long[]" || field.typeDes == "string[]")
                            {
                                luaContentSub += keyName + "=";
                                //+ value + ",";
                                luaContentSub += "{";
                                //有的格式配置不统一，带有[]符号，强转了
                                string v = value.Replace("[", "").Replace("]", "");
                                try
                                {
                                    if (v != "")
                                    {

                                        var vs = value.Replace("[", "").Replace("]", "").Split(',');
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
                                            else if (field.typeDes == "uint[]")
                                            {
                                                luaContentSub += uint.Parse(vs[p]);
                                            }
                                            else if (field.typeDes == "long[]")
                                            {
                                                luaContentSub += long.Parse(vs[p]);
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
                                }
                                catch (Exception)
                                {
                                    string src = $" 表：{table.tableName}，字段：{field.fieldName}，行数：{j + 1}";
                                    Debug.ThrowException("field decode error:" + field.typeDes + src);
                                    throw;
                                }



                                luaContentSub.TrimEnd(',');
                                luaContentSub += "},";
                            }
                            else if (field.typeDes != "")
                            {
                                if (value == "" && (field.typeDes == "uint" || field.typeDes == "int" || field.typeDes == "float"))
                                {
                                    value = "0";
                                }
                                luaContentSub += keyName + "= " + value + " ,";

                            }
                            else
                            {
                                string src = $" 表：{table.tableName}，字段：{field.fieldName}";
                                Debug.ThrowException("field typeDes error:" + field.typeDes + src);
                            }
                        }
                        luaContentSub += "},\r\n";
                    }
                    luaContentSub += "}\r\n";



                }



                luaContentSub += "local mt_" + outTableName + "={}\r\n";
                luaContentSub += "mt_" + outTableName + ".__index=function(t,k)\r\n";
                luaContentSub += "\tLogE(\"can not find item with key:\"..k..\" in " + outTableName + "\")\r\n";
                luaContentSub += "end\r\n";
                luaContentSub += "setmetatable(" + outTableName + ",mt_" + outTableName + ")\r\n";
                luaContentSub += "\r\n";
                luaContentSub += "return " + outTableName;
                File.WriteAllText(outputFile, luaContentSub.TrimEnd(), new UTF8Encoding(false));

            }
            Console.WriteLine("*Table.lua输出完毕");

        }
    }
}
