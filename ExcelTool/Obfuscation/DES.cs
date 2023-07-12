using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTool.Obfuscation
{
    public class DES
    {
        public static string EncryptStrToHex(string target, string key)
        {
            if (key.Length < 8)
            {
                Console.WriteLine("key length must not less than 8 chars",ConsoleColor.Red);
                return target;
            }
            key = key.Substring(0, 8);

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] byteContent = Encoding.UTF8.GetBytes(target);

            des.Key = ASCIIEncoding.ASCII.GetBytes(key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(key);


            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(byteContent, 0, byteContent.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);//change to hex with uppercase
            }

            return ret.ToString();
        }

        public static string DecryptStrFromHex(string target, string key)
        {
            if (key.Length < 8)
            {
                Console.WriteLine("key length must not less than 8 chars",ConsoleColor.Red);
                return target;
            }
            key = key.Substring(0, 8);

            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] byteContent = new byte[target.Length / 2];
                for (int x = 0; x < target.Length / 2; x++)
                {
                    int ret = Convert.ToInt32(target.Substring(x * 2, 2), 16);
                    byteContent[x] = (byte)ret;
                }
                des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(key);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(),
                  CryptoStreamMode.Write);
                cs.Write(byteContent, 0, byteContent.Length);
                cs.FlushFinalBlock();
                string result = Encoding.Default.GetString(ms.ToArray());
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DecryptStrFromHex error, content:" + target + ", ex:" + ex.ToString(),ConsoleColor.Red);
                return null;
            }
        }


        public static string EncryptStrToBase64(string target, string key)
        {
            if (key.Length < 8)
            {
                Console.WriteLine("key length must not less than 8 chars",ConsoleColor.Red);
                return target;
            }
            key = key.Substring(0, 8);

            byte[] bKey = Encoding.UTF8.GetBytes(key);
            byte[] bIV = Encoding.UTF8.GetBytes(key);
            byte[] bStr = Encoding.UTF8.GetBytes(target);

            DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
            desc.Padding = PaddingMode.PKCS7;//补位
            desc.Mode = CipherMode.ECB;//CipherMode.CBC

            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, desc.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write))
                {
                    cStream.Write(bStr, 0, bStr.Length);
                    cStream.FlushFinalBlock();
                    byte[] res = mStream.ToArray();
                    return Convert.ToBase64String(res);
                }
            }
        }


        public static string DecryptStrFromBase64(string target, string key)
        {
            if (key.Length < 8)
            {
                Console.WriteLine("key length must not less than 8 chars",ConsoleColor.Red);
                return target;
            }
            key = key.Substring(0, 8);

            byte[] inputByteArray = Convert.FromBase64String(target);
            DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
            desc.Padding = PaddingMode.PKCS7;
            desc.Mode = CipherMode.ECB;

            desc.Key = Encoding.UTF8.GetBytes(key);
            desc.IV = Encoding.UTF8.GetBytes(key);

            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, desc.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        public static byte[] EncryptByte(byte[] target, string key)
        {
            if (key.Length < 8)
            {
                Console.WriteLine("key length must not less than 8 chars",ConsoleColor.Red);
                return target;
            }
            key = key.Substring(0, 8);

            byte[] bKey = Encoding.UTF8.GetBytes(key);
            byte[] bIV = Encoding.UTF8.GetBytes(key);
            byte[] bStr = target;

            DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
            desc.Padding = PaddingMode.PKCS7;//补位
            desc.Mode = CipherMode.ECB;//CipherMode.CBC

            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, desc.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write))
                {
                    cStream.Write(bStr, 0, bStr.Length);
                    cStream.FlushFinalBlock();
                    byte[] res = mStream.ToArray();
                    return res;
                }
            }
        }
        public static byte[] DecryptByte(byte[] target, string key)
        {
            if (key.Length < 8)
            {
                Console.WriteLine("key length must not less than 8 chars",ConsoleColor.Red);
                return target;
            }
            key = key.Substring(0, 8);


            byte[] inputByteArray = target;
            DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
            desc.Padding = PaddingMode.PKCS7;
            desc.Mode = CipherMode.ECB;

            desc.Key = Encoding.UTF8.GetBytes(key);
            desc.IV = Encoding.UTF8.GetBytes(key);

            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, desc.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return ms.ToArray();
        }
    }
}
