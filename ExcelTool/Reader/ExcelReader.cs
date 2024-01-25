using Excel;
using ExcelTool.Core;
using ExcelTool.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
                /*if (et.tableName.ContainChinese() || !et.tableName.StartsWith("t_"))
                {
                    Debug.LogError("表\"" + et.tableName + "\"未导出,请检查表的命名!");
                    continue;
                }*/
                if (et.tableName.ContainChinese())
                {
                    Debug.LogWarnning("表\"" + et.tableName + "\"未导出,表名是中文!");
                    continue;
                }

                if (Regex.IsMatch(et.tableName, @"Sheet\d$"))
                {
                    Debug.LogWarnning("表文件\"" + filePath + "\"未导出,表名使用了默认命名：" + et.tableName);
                    continue;
                }
                Debug.Log("begin read------>fileName:" + fileName + ",tableName:" + et.tableName);

                et.rowCount = table.Rows.Count;
                if (et.rowCount < FieldRowEnum.DATA_START_ROW)
                {
                    Debug.LogWarnning("fileName:" + fileName + ", tableName:" + et.tableName + ", line count less than " + FieldRowEnum.DATA_START_ROW + ", we will not handle with it");
                    continue;
                }
                Regex regExp = new Regex("[ \\[ \\] \\^ \\-_*×――(^)$%~!＠@＃#$…&%￥—+=<>《》!！??？:：•`·、。，；,.;/\'\"{}（）‘’“”-]");
                if (regExp.IsMatch(et.tableName))
                {
                    Debug.LogWarnning("表\"" + et.tableName + "\"未导出,表名含有特殊字符!");
                    continue;
                }


                for (int i = 0; i < table.Columns.Count; i++)
                {
                    //init ExcelField  字段名
                    string fieldName = table.Rows[FieldRowEnum.FIELD_NAME][i].ToString();
                    if (fieldName.ContainChinese())//中文字段用于注释，不处理
                    {
                        continue;
                    }
                    //处理字段是否导出到客户端
                    string exportModeStr = table.Rows[FieldRowEnum.FIELD_EXPORT_MODE][i].ToString().Trim();
                    exportModeStr = exportModeStr == "" ? "0" : exportModeStr;
                    int exportMode = 0;
                    if (!int.TryParse(exportModeStr, out exportMode))
                    {
                        Debug.LogWarnning($"数值错误，table:{table.TableName},field:{fieldName},cloumn:{i},value:{exportModeStr}");

                    }
                    if (exportMode != 0 && exportMode != 1)
                    {
                        continue;
                    }
                    //字段说明
                    string fieldDes = table.Rows[FieldRowEnum.FIELD_DES][i].ToString();
                    //字段详细说明
                    string fieldDesMore = table.Rows[FieldRowEnum.FIELD_DES_MORE][i].ToString();
                    //数据类型
                    string typeDes = table.Rows[FieldRowEnum.FIELD_TYPE][i].ToString();

                    //字段默认值
                    string defaultValue = "0";
                    if (!TypeDefaultValueDic.keyValuePairs.ContainsKey(typeDes))
                    {
                        Debug.LogError("error,current not support type:" + typeDes);
                    }
                    else
                    {
                        defaultValue = TypeDefaultValueDic.keyValuePairs[typeDes];
                    }

                    ExcelField field = new ExcelField(et.tableName, fieldName, typeDes, defaultValue, fieldDes, fieldDesMore, i == 0 ? true : false);

                    //前5行定义了:字段描述、字段名、字段详细描述、字段类型、导出方式
                    //read Field datas
                    for (int j = FieldRowEnum.DATA_START_ROW; j < et.rowCount; j++)
                    {
                        string tmpValue = table.Rows[j][i].ToString().Trim();
                        field.AddData(tmpValue == "" ? defaultValue : tmpValue);
                    }
                    //把当前字段的基本信息和所属的一整列数据添加进去
                    et.AddExcelField(field);
                }


                excelTables.Add(et);
            }

            return excelTables;
        }
    }
}
