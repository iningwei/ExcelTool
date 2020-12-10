using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelTool.Tools
{
    class Debug
    {
        public static void Log(string content, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(content);
        }
        public static void LogWarnning(string content, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(content);
        }
        public static void LogError(string content, ConsoleColor color = ConsoleColor.Red)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(content);
        }

        public static void ThrowException(string exStr)
        {
            throw new Exception(exStr);


            


            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine(new Exception(exStr).StackTrace.ToString());//StackTrace是null

        }
    }
}
