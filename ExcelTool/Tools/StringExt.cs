using System;

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

        public static int[] ToIntArray(this string[] strArray)
        {
            if (strArray == null || strArray.Length == 0)
            {
                Debug.LogError("error, input stringArray is null or length=0");
            }
            int[] result = new int[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                try
                {
                    result[i] = int.Parse(strArray[i]);
                }
                catch (Exception ex)
                {

                    Debug.ThrowException("StringArrayToIntArray exception:" + ex.Message);
                }

            }
            return result;
        }


        public static float[] ToFloatArray(this string[] strArray)
        {
            if (strArray == null || strArray.Length == 0)
            {
                Debug.LogError("error, input stringArray is null or length=0");
            }
            float[] result = new float[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                try
                {
                    result[i] = float.Parse(strArray[i]);
                }
                catch (Exception ex)
                {

                    Debug.ThrowException("StringArrayToFloatArray exception:" + ex.Message);
                }

            }
            return result;
        }

    }
}
