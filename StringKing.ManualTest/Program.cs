using StringKing.FunctionInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringKing;

namespace StringKing.ManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = string.Empty;

            // MD5Hasher
            var x = new StringKing.Functions.MD5Hasher();
            //result = x.ExecuteFunction(new string[] { "abcd" }, null);
            
            result = StringKing.Functions.MD5Hasher.Execute("abcd");
            result = "abcd".MD5Hash();

            // GuidGenerator
            var y = new StringKing.Functions.GuidGenerator();
            var argx = y.GetListOfArgument();
            ((StringFunctionArgument)argx["numberof"]).Value = 1;
            //result = y.ExecuteFunction(new string[] { "abc" }, argx);

            result = StringKing.Functions.GuidGenerator.Execute();
            result = StringKing.Functions.GuidGenerator.Execute(2);
            result = string.Empty.GuidGenerator();
            result = string.Empty.GuidGenerator(5);
            
            Console.WriteLine(result);
            
            // Unescape, HtmlDecode
            "&quot;Geschlecht. Werte: w=nat\u00fcrliche Person weiblichen Geschlechts; m=nat\u00fcrliche Person m\u00e4nnlichen Geschlechts.&quot;"
                .Unescape().HtmlDecode().Dump();
           
            Console.ReadLine();
        }
    }
}
