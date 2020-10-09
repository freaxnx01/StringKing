using System;
using System.Collections.Generic;
using System.Text;

namespace StringKing
{
    public static partial class StringFunctionExtension
    {
        public static void Dump(this string text)
        {
            Console.WriteLine(text);
        }
    }
}
