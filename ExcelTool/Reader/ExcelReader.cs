﻿using Excel;
using ExcelTool.Core;
using ExcelTool.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace ExcelTool.Reader
{
    class ExcelReader
    {
        /// <summary>
        /// 只支持.xlsx格式，不支持03版本excel(.xls)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<ExcelTable> Read(string filePath)
        {
            Debug.Log("read file:" + filePath);

            List<ExcelTable> excelTables = new List<ExcelTable>();
            string fileName = Path.GetFileName(filePath);

            FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
            DataSet result = excelReader.AsDataSet();
            //获得一个xlsx文件中所有的tables
            DataTableCollection tables = result.Tables;
            fs.Close();

            foreach (DataTable table in tables)
            {
                ExcelTable et = new ExcelTable();
                et.tableName = table.TableName;
                ////中文表不读，用于整体性的说明、注释作用
                ////要导出的表需要以t_开头
                if (et.tableName.ContainChinese() || !et.tableName.StartsWith("t_"))
                {
                    continue;
                }
                Debug.Log("begin read------>fileName:" + fileName + ",tableName:" + et.tableName);

                et.rowCount = table.Rows.Count;
                if (et.rowCount < 6)
                {
                    Debug.LogWarnning("fileName:" + fileName + ", tableName:" + et.tableName + ", line count less than 6, we will not handle with it");
                    continue;
                }


                for (int i = 0; i < table.Columns.Count; i++)
                {
                    //init ExcelField
                    string name = table.Rows[0][i].ToString();
                    if (name.ContainChinese())//中文字段用于注释，不处理
                    {
                        continue;
                    }

                    string typeDes = table.Rows[1][i].ToString();
                    string tag = table.Rows[3][i].ToString();
                    if (i == 0 && tag == "KVT")//check KVT format whether correct
                    {
                        et.isKVT = true;
                        if (table.Rows[0][0].ToString() != "Key"
                            || table.Rows[0][1].ToString() != "Value"
                            || table.Rows[0][2].ToString() != "KeyDes")
                        {
                            Debug.ThrowException("table:" + et.tableName + "is KVT,but field name is not correct!");
                        }

                        if (table.Rows[1][0].ToString()!="string")
                        {
                            Debug.ThrowException("table:" + et.tableName + "is KVT,but key's type is not string");
                        }
                    }
                    string defaultValue = table.Rows[2][i].ToString();
                    string fieldDes = table.Rows[4][i].ToString();
                    string fieldDesMore = table.Rows[5][i].ToString();
                    ExcelField field = new ExcelField(et.tableName, name, typeDes, defaultValue, tag, fieldDes, fieldDesMore, i == 0 ? true : false);

                    //read Field datas
                    for (int j = 6; j < et.rowCount; j++)
                    {
                        string tmpValue = table.Rows[j][i].ToString().Trim();
                        field.AddData(tmpValue == "" ? defaultValue : tmpValue);
                    }

                    et.AddExcelField(field);
                }





                #region old
                //////for (int i = 0; i < et.rowCount; i++)
                //////{
                //////    if (i == 0)//获得key  
                //////    {
                //////        for (int j = 0; j < et.columnCount; j++)
                //////        {
                //////            var key = table.Rows[0][j].ToString();

                //////            if (j == 0)//主键
                //////            {
                //////                et.primaryKeyName = key;
                //////                et.primaryKeyType = table.Rows[1][j].ToString();
                //////                if (table.Rows[2][j].ToString().Contains("KVT"))
                //////                {
                //////                    et.isKVPairTable = true;
                //////                    et.valueKeyType = table.Rows[1][1].ToString();
                //////                    if (table.Rows[0][1].ToString() != "Value" || table.Rows[0][2].ToString() != "KeyDes")
                //////                    {
                //////                        throw new Exception(et.tableName + "表有问题，KVT表，要求第二个字段名为 Value，第三个字段名为 KeyDes");
                //////                    }
                //////                }
                //////                else
                //////                {
                //////                    et.isKVPairTable = false;
                //////                }
                //////            }

                //////            Console.WriteLine("@@初始化map, key:" + key);
                //////            et.tableContent[key] = new List<string>();

                //////            if (et.keys.Contains(key))
                //////            {
                //////                throw new Exception("fatal error, table:" + et.tableName + ",有重复的字段:" + key);
                //////            }
                //////            else
                //////            {
                //////                if (!key.ContainChinese() && key != "KeyDes")//字段非中文才加入,且 KeyDes字段不用加入
                //////                {
                //////                    et.keys.Add(key);
                //////                }
                //////            }

                //////        }
                //////        Console.WriteLine("@@初始化map key完毕");
                //////    }
                //////    else
                //////    {
                //////        for (int k = 0; k < et.columnCount; k++)
                //////        {
                //////            string key = table.Rows[0][k].ToString();
                //////            string property = table.Rows[i][k].ToString();
                //////            Console.WriteLine("table:" + et.tableName + " , key: " + key + " , property：" + property);

                //////            //主键的数据要保持唯一性
                //////            if (k == 0 && i > 4 && et.tableContent[key].Contains(property))
                //////            {
                //////                throw new Exception("fatal error, table:" + et.tableName + "的主键" + key + "，property:" + property);
                //////            }
                //////            else
                //////            {
                //////                if (property == "")
                //////                {
                //////                    property = "囧";//对于数据表中，用户没有填写的空格，默认赋值为 囧 ，读取的时候需要特殊处理
                //////                }
                //////                et.tableContent[key].Add(property);
                //////            }

                //////        }


                //////    }
                //////}
                #endregion

                excelTables.Add(et);
            }

            return excelTables;
        }
    }
}
