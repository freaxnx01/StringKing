using System;
using System.Collections.Generic;
using System.Text;

namespace StringKing
{
    public static class StringFunctionExtension
    {
        public static string MD5Hash(this string input)
        {
            return StringKing.Functions.MD5Hasher.Execute(input);
        }

        public static string GuidGenerator(this string input)
        {
            return StringKing.Functions.GuidGenerator.Execute();
        }

        public static string GuidGenerator(this string input, int numberOf)
        {
            return StringKing.Functions.GuidGenerator.Execute(numberOf, input);
        }
    }
}
