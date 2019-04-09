using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelTool.Core
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
}
