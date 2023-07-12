using ExcelTool.Core;
using ExcelTool.Reader;
using ExcelTool.Tools;
using System;
using System.Collections.Generic;
using System.IO;

/*
 *参考自： http://www.cnblogs.com/fly-100/p/4538975.html
*/
namespace ExcelTool
{
    class Program
    {
        static string binDir;
        static string excelFileDir;
        static string[] excelFiles;

        static string outputTableDir;//the directory for outputing bin files
        static string outputCSCodeDir;//the directory for outputing c# code files
        static string outputLuaCodeDir;//the direcotry for lua code outputs
        static void Main(string[] args)
        {
            Debug.Log("begin handle excel file");
            Debug.Log("--->try get all excel file");

            init(args);



            //do not support 03 excel file,which with postfix of .xls
            excelFiles = Directory.GetFiles(excelFileDir, "*.xlsx", SearchOption.TopDirectoryOnly);

            List<ExcelTable> allExcelTables = new List<ExcelTable>();
            for (int q = 0; q < excelFiles.Length; q++)
            {
                List<ExcelTable> excelTables = ExcelReader.Read(excelFiles[q]);

                allExcelTables.AddRange(excelTables);
                #region  output c# code files and bin files
                for (int i = 0; i < excelTables.Count; i++)
                {
                    ExcelWriter.WriteCSCode(outputCSCodeDir, excelTables[i]);
                    ExcelWriter.WriteBinaryFile(outputTableDir, excelTables[i]);


                }
                #endregion
            }
            if (allExcelTables.Count > 0)
            {
                ExcelWriter.WriteLuaCode(outputLuaCodeDir, allExcelTables);
            }

            Debug.Log("------------- :-) output finished");
            Console.ReadLine();
        }

        private static void init(string[] args)
        {
            if (args.Length == 0)//if we not assign params
            {
                string curDir = Environment.CurrentDirectory;
                Debug.Log("curDir:" + curDir);
                binDir = curDir.Substring(0, curDir.LastIndexOf(@"\"));
                outputTableDir = binDir + @"\table_output";
                outputCSCodeDir = binDir + @"\code_output_cs";
                outputLuaCodeDir = binDir + @"\code_output_lua";

                excelFileDir = binDir + @"\table";
                Debug.Log("excelFileDir:" + excelFileDir);
            }
            else
            {
                if (args.Length != 4)
                {
                    Debug.ThrowException("error,if you assign params then args.Length must be 4");
                }
                else
                {
                    excelFileDir = args[0];
                    outputTableDir = args[1];
                    outputCSCodeDir = args[2];
                    outputLuaCodeDir = args[3];
                    Debug.Log("excelFileDir:" + excelFileDir);
                    Debug.Log("outputTableDir:" + outputTableDir);
                    Debug.Log("outputCSCodeDir:" + outputCSCodeDir);
                    Debug.Log("outputLuaCodeDir:" + outputLuaCodeDir);
                    if (!Directory.Exists(excelFileDir)
                        || !Directory.Exists(outputTableDir)
                        || !Directory.Exists(outputCSCodeDir)
                        || !Directory.Exists(outputLuaCodeDir))
                    {
                        Debug.ThrowException("directory has error,please check");
                    }

                }
            }
        }


    }
}
