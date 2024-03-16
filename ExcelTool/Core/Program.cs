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

        static string tmpExcelFileDir;//tmp excel file dir, files copy from excelFileDir
        static string outputTableDir;//the directory for outputing bin files
        static string outputCSCodeDir;//the directory for outputing c# code files
        static string outputLuaCodeDir;//the direcotry for lua code outputs

        static void Main(string[] args)
        {
            Debug.Log("begin handle excel file");
            Debug.Log("--->try get all excel file");

            init(args);

            //do not support 03 excel file,which with postfix of .xls
            excelFiles = Directory.GetFiles(tmpExcelFileDir, "*.xlsx", SearchOption.TopDirectoryOnly);

            List<ExcelTable> allExcelTables = new List<ExcelTable>();
            bool flag = true;
            for (int q = 0; q < excelFiles.Length; q++)
            {
                List<ExcelTable> excelTables = ExcelReader.Read(excelFiles[q]);

                //避免表名重复或者转小写后一样的表名
                for (int j = 0; j < excelTables.Count; j++)
                {
                    string tableName = excelTables[j].tableName.Trim().ToLower();
                    for (int k = 0; k < allExcelTables.Count; k++)
                    {
                        if (allExcelTables[k].tableName.Trim().ToLower() == tableName)
                        {
                            Debug.ThrowException("重复表名:" + tableName + ", file1:" + excelFiles[q] + ", file2:" + allExcelTables[k].originFilePath);
                            flag = false;
                        }
                    }
                }

                allExcelTables.AddRange(excelTables);
            }
            if (allExcelTables.Count > 0 && flag)
            {
                #region  output c# code files and bin files
                for (int i = 0; i < allExcelTables.Count; i++)
                {
                    ExcelWriter.WriteCSCode(outputCSCodeDir, allExcelTables[i]);
                    ExcelWriter.WriteBinaryFile(outputTableDir, allExcelTables[i]);
                }
                #endregion

                ExcelWriter.WriteLuaCode(outputLuaCodeDir, allExcelTables);
            }

            Debug.Log("------------- :-) output finished:" + flag);
            Console.ReadLine();
        }

        private static void init(string[] args)
        {
            string curDir = Environment.CurrentDirectory;
            binDir = curDir.Substring(0, curDir.LastIndexOf(@"\"));
            if (args.Length == 0)//if we not assign params
            {
                Debug.Log("curDir:" + curDir);
                outputTableDir = binDir + @"\table_output";
                outputCSCodeDir = binDir + @"\code_output_cs";
                outputLuaCodeDir = binDir + @"\code_output_lua";

                excelFileDir = binDir + @"\table";
                tmpExcelFileDir = binDir + @"\table_tmp";
                Debug.Log("excelFileDir:" + excelFileDir);
            }
            else
            {
                if (args.Length != 5)
                {
                    Debug.ThrowException("error,if you assign params then args.Length must be 5");
                }
                else
                {
                    excelFileDir = Path.Combine(binDir, args[0]);
                    tmpExcelFileDir = Path.Combine(binDir, args[1]);
                    outputTableDir = Path.Combine(binDir, args[2]);
                    outputCSCodeDir = Path.Combine(binDir, args[3]);
                    outputLuaCodeDir = Path.Combine(binDir, args[4]);
                    Debug.Log("excelFileDir:" + excelFileDir);
                    Debug.Log("tmpExcelFileDir:" + tmpExcelFileDir);
                    Debug.Log("outputTableDir:" + outputTableDir);
                    Debug.Log("outputCSCodeDir:" + outputCSCodeDir);
                    Debug.Log("outputLuaCodeDir:" + outputLuaCodeDir);
                    if (!Directory.Exists(excelFileDir))
                    {
                        Debug.ThrowException("excelFileDir not exist：" + excelFileDir);
                    }
                    if (!Directory.Exists(tmpExcelFileDir))
                    {
                        Directory.CreateDirectory(tmpExcelFileDir);
                    }
                }
            }

            //copy all files from excelFileDir to tmpExcelFileDir
            //to avoid output conflict while .xlsx file is editing.
            //we make tmpExcelFileDir  as the final xlsx files folder.
            var excelFiles = Directory.GetFiles(excelFileDir, "*.xlsx", SearchOption.TopDirectoryOnly);
            if (excelFiles.Length > 0)
            {
                for (int i = 0; i < excelFiles.Length; i++)
                {
                    var info = new FileInfo(excelFiles[i]);
                    if (info.Name.StartsWith("~$"))//skip ~$ files
                    {
                        continue;
                    }
                    var from = excelFiles[i];
                    var to = tmpExcelFileDir + "/" + info.Name;
                    Debug.Log($"copy {from} to {to}");
                    File.Copy(from, to, true);
                }
            }
        }


    }
}
