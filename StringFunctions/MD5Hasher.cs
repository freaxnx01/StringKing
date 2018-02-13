using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("MD5Hasher")]
    public class MD5Hasher : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] byteArray = Encoding.Default.GetBytes(input[0]);
            byteArray = md5.ComputeHash(byteArray);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < byteArray.Length; i++)
            {
                sb.Append(byteArray[i].ToString("x2").ToLower());
            }

            return sb.ToString();
        }
    }
}
