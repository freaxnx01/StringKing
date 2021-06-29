using System;
using System.Linq;
using StringKing.FunctionInterface;

namespace StringKing.Core
{
    public class StringFunctionItem
    {
        public string AssemblyName { get; set; }

        public string ClassName => FunctionType.Name;
        public string DisplayName { get; set; }
        public Type FunctionType { get; set; }

        public bool HasArguments => Processor.GetArgumentDictionary(FunctionType).Any();

        private string CodeArguments
        {
            get
            {
                // numberOf
                return string.Join(", ", Processor.GetArgumentDictionary(FunctionType).Select(a => a.Key));
            }
        }

        private string CodeArgumentsWithType
        {
            get
            {
                // int numberOf
                return string.Join(", ", Processor.GetArgumentDictionary(FunctionType).Select(a => string.Concat(((StringFunctionArgument)a.Value).TypeAsString, " ", a.Key)));
            }
        }
        
        public string CodeExtensionMethod
        {
            get
            {
                if (!HasArguments)
                {
                    const string codeTemplate = "public static string %name%(this string input) { return %type%.Execute(input); }";
                    
                    return codeTemplate.
                        Replace("%name%", ClassName).
                        Replace("%type%", FunctionType.FullName);
                }
                else
                {
                    const string codeTemplate = "public static string %name%(this string input, %argst%) { return %type%.Execute(%args%, input); }";

                    return codeTemplate.
                        Replace("%name%", ClassName).
                        Replace("%type%", FunctionType.FullName).
                        Replace("%argst%", CodeArgumentsWithType).
                        Replace("%args%", CodeArguments);
                    
                    //public static string Execute(params string[] input)
                    
                    //public static string Execute(int numberOf, params string[] input)
                    // ->
                    // public static string GuidGenerator(this string input, int numberOf)
                    // {
                    //     return Functions.GuidGenerator.Execute(numberOf, input);
                    // }
                }
            }
        }

        
    }
}
