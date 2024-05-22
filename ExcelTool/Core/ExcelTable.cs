using ExcelTool.Tools;
using System.Collections.Generic;

namespace ExcelTool.Core
{
    public class ExcelField
    {
        /// <summary>
        /// the name of table
        /// </summary>
        string tableName;

        /// <summary>
        /// the name of a field
        /// </summary>
        public string fieldName;
        /// <summary>
        /// type of a field
        /// </summary>
        public string typeDes;

        /// <summary>
        /// the defaultValue of the field
        /// </summary>
        public string defaultValue;

        /// <summary>
        /// the short des of a field
        /// </summary>
        public string fieldDes;
        /// <summary>
        /// the more des of a field
        /// </summary>
        public string fieldDesMore;

        /// <summary>
        /// whether is primary field
        /// </summary>
        public bool isPrimary;

        public List<string> datas = null;
        public ExcelField(string tableName, string fieldName, string typeDes, string defaultValue, string fieldDes,
            string fieldDesMore, bool isPrimary)
        {
            this.tableName = tableName;
            this.fieldName = fieldName;
            this.typeDes = typeDes;
            this.defaultValue = defaultValue;
            this.fieldDes = fieldDes;
            this.fieldDesMore = fieldDesMore;
            this.isPrimary = isPrimary;
        }

        public void AddData(string data)
        {
            if (datas == null)
            {
                datas = new List<string>();
            }
            if (this.isPrimary)
            {
                if (datas.Contains(data))
                {
                    Debug.ThrowException("tableName:" + tableName + ", primary key " + fieldName + " duplicated" + ", " + fieldName + "=" + data);
                }
            }

            datas.Add(data);

        }

    }


    public class ExcelTable
    {
        public string originFilePath;
        /// <summary>
        /// name of excel table.
        /// also the output cs class will use this name.
        /// </summary>
        public string tableName;

        /// <summary>
        /// total rowCount of this table
        /// </summary>
        public int rowCount;

        /// <summary>
        /// is this table a key-value-pair table
        /// </summary>
        public bool isKVT;

        public List<ExcelField> fields = new List<ExcelField>();


        public ExcelField GetPrimaryField()
        {
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].isPrimary)
                {
                    return fields[i];
                }
            }

            Debug.ThrowException("get primary field failed, table name:" + tableName);
            return null;
        }

        public void AddExcelField(ExcelField field)
        {
            fields.Add(field);
        }
    }

    /// <summary>
    /// 字段对应数据表中行数的枚举(假枚举类，方便调用，不需要做数据转换)
    /// </summary>
    public class FieldRowEnum
    {
        /// <summary>
        /// 第一行为字段说明
        /// </summary>
        public const int FIELD_DES = 0;
        /// <summary>
        /// 第二行为字段名
        /// </summary>
        public const int FIELD_NAME = 1;
        /// <summary>
        /// 第三行字段详细说明
        /// </summary>
        public const int FIELD_DES_MORE = 2;
        /// <summary>
        /// 第四行字段数据类型
        /// </summary>
        public const int FIELD_TYPE = 3;
        /// <summary>
        /// 导出模式：0-客服端和服务器（默认不填），1-仅导出到客户端，2-仅导出到服务器，3-不导出
        /// </summary>
        public const int FIELD_EXPORT_MODE = 4;
        /// <summary>
        /// 数据开始的行数
        /// </summary>
        public const int DATA_START_ROW = 5;
    }


    public class TypeDefaultValueDic
    {
        public static Dictionary<string, string> keyValuePairs = new Dictionary<string, string>()
        {
            { "int","0"},
              { "uint","0"},
              { "long","0"},
                { "float","0"},
                  { "object","0"},
                    { "int[]","0"},
                      { "uint[]","0"},
                      { "long[]","0"},
                        { "float[]","0"},
                          { "string",""},
                            { "string[]",""},
                              { "bool","false"},
                                { "Vector3","0,0,0"},
        };
    }
}
