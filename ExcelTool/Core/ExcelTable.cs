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
        public string name;
        /// <summary>
        /// type of a field
        /// </summary>
        public string typeDes;

        /// <summary>
        /// the defaultValue of the field
        /// </summary>
        public string defaultValue;

        /// <summary>
        /// specail tag for a field
        /// </summary>
        public string tag;
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
        public ExcelField(string tableName, string name, string typeDes, string defaultValue, string tag, string fieldDes,
            string fieldDesMore, bool isPrimary)
        {
            this.tableName = tableName;
            this.name = name;
            this.typeDes = typeDes;
            this.defaultValue = defaultValue;
            this.tag = tag;
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
                    Debug.ThrowException("tableName:" + tableName + ", primary key " + name + " duplicated");
                }
            }

            datas.Add(data);

        }

    }


    public class ExcelTable
    {
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
}
