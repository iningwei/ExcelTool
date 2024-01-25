using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelTool.Core
{
    class Setting
    {
        public static bool IsEncrypt = false;//文件是否加密
        public static string EncryptKey = "goodluck";//文件加密密钥
        public static bool IsFileNameEncrypt = false;//最终导出的bin文件名是否加密
        public static string FileNameEncryptKey = "hijack88";//文件名加密密钥
        public static string SeprateStr = "@~ExcelTool!@";//输出txt时分割符
    }
}
