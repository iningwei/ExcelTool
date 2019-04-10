using ExcelTool.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelTool.Core
{


    public class ExcelField
    {
        /// <summary>
        /// the name of a field
        /// </summary>
        public string Name;
        /// <summary>
        /// type of a field
        /// </summary>
        public string TypeDes;
        /// <summary>
        /// specail tag for a field
        /// </summary>
        public string Tag;
        /// <summary>
        /// the short des of a field
        /// </summary>
        public string FieldDes;
        /// <summary>
        /// the more des of a field
        /// </summary>
        public string FieldDesMore;

        public bool PrimaryField;

        public List<string> datas = null;
        public ExcelField(string name, string typeDes, string tag, string fieldDes,
            string fieldDesMore, bool primaryField)
        {
            this.Name = name;
            this.TypeDes = typeDes;
            this.Tag = tag;
            this.FieldDes = fieldDes;
            this.FieldDesMore = fieldDesMore;
            this.PrimaryField = primaryField;
        }

        public void AddData(string data)
        {
            if (datas == null)
            {
                datas = new List<string>();
            }
            if (this.PrimaryField)
            {
                if (datas.Contains(data))
                {
                    Debug.ThrowException("primary key " + Name + " duplicated");
                }
            }
            else
            {
                datas.Add(data);
            }
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
}
