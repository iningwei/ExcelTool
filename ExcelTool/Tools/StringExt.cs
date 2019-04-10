using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelTool.Tools
{
    static class StringExt
    {
        /// <summary>
        /// 用 ASCII 码范围判断字符是不是汉字
        /// </summary>
        /// <param name="text">待判断字符或字符串</param>
        /// <returns>真：是汉字；假：不是</returns>
        public static bool ContainChinese(this string text)
        {
            bool res = false;
            foreach (char t in text)
            {
                if ((int)t > 127)
                    res = true;
            }
            return res;
        }
    }
}
