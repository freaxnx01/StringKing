using System;
using System.Linq;
using System.Text;
using StringKing.Core;

namespace StringKing.CodeGenerator
{
    class Program
    {
        // StringFunctionExtensionGenerated.cs
        
        // public static string HtmlEncode(this string input)
        // {
        //     return Functions.HtmlEncode.Execute(input);
        // }
        
        
        static void Main(string[] args)
        {
            Processor.GetListOfFunctions().ForEach(f => Console.WriteLine($"{f.ClassName}\tArgs:{f.HasArguments}"));

            // No arguments
            var sb = new StringBuilder();
            foreach (var stringFunctionItem in Processor.GetListOfFunctions())
            {
                sb.AppendLine(stringFunctionItem.CodeExtensionMethod);
            }
        }
    }
}