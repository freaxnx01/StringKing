using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using StringKing.StringFunctionInterface;

namespace StringKingProcessor
{
    public class Processor
    {
        public static string InvokeStringFunction(Type type, string[] input, Dictionary<string, object> arguments)
        {
            IStringFunction stringFunctionInstance = GetStringFunctionInstance(type);
            return InvokeStringFunction(stringFunctionInstance, input, arguments);
        }

        public static string InvokeStringFunction(IStringFunction stringFunctionInstance, string[] input, Dictionary<string, object> arguments)
        {
            return stringFunctionInstance.ExecuteFunction(input, arguments);
        }

        public static Dictionary<string, object> GetArgumentDictionary(Type type)
        {
            IStringFunction stringFunctionInstance = GetStringFunctionInstance(type);
            return stringFunctionInstance.GetListOfArgument();
        }

        public static string GetTestString(Type type)
        {
            IStringFunction stringFunctionInstance = GetStringFunctionInstance(type);
            return stringFunctionInstance.GetTestString();
        }

        public static IStringFunction GetStringFunctionInstance(Type type)
        {
            return (IStringFunction)Activator.CreateInstance(type);
        }

        public static string GetStringFunctionCallAsString(IStringFunction stringFunction, Dictionary<string, object> arguments)
        {
            return stringFunction.GetCallAsString(arguments);
        }

        public static List<Assembly> GetListOfStringFunctionAssemblies()
        {
            var listOfAssembly = new List<Assembly>();

            //DirectoryInfo dirInfo = new DirectoryInfo(Environment.CurrentDirectory);
            //foreach (FileInfo fileInfo in dirInfo.GetFiles("StringFunctions*.dll"))
            //{
            //    Assembly asm = null;

            //    try
            //    {
            //        asm = Assembly.LoadFrom(fileInfo.FullName);
            //    }
            //    catch {}

            //    if (asm != null && asm.GetCustomAttributes(typeof(StringFunctionAssemblyAttribute), false).Length > 0)
            //    {
            //        listOfAssembly.Add(asm);
            //    }
            //}

            listOfAssembly.Add(typeof(StringKing.StringFunctions.AutoIncrementNumber).Assembly);
            listOfAssembly.Add(typeof(StringFunctionsDnpExtensions.EnsureEndsWith).Assembly);

            return listOfAssembly;
        }

        public static List<StringFunctionItem> GetListOfFunctions()
        {
            List<StringFunctionItem> listOfFunctions = new List<StringFunctionItem>();

            foreach (Assembly asm in GetListOfStringFunctionAssemblies())
            {
                var stringFunctionTypes = from type in asm.GetTypes()
                                          where type.IsPublic && typeof(IStringFunction).IsAssignableFrom(type)
                                          orderby type.Name
                                          select type;

                foreach (Type type in stringFunctionTypes)
                {
                    try
                    {
                        var functionAttribute = (from attribute in type.GetCustomAttributes(typeof(StringFunctionAttribute), false)
                                                 select attribute).First();

                        listOfFunctions.Add(new StringFunctionItem()
                        {
                            //AssemblyName = asm.GetName().Name,
                            DisplayName = ((StringFunctionAttribute)functionAttribute).DisplayName,
                            FunctionType = type
                        });
                    }
                    catch { }
                }
            }

            return listOfFunctions;
        }

        public static Type GetTypeByFunctionName(string functionName)
        {
            Type type = (from f in GetListOfFunctions()
                         where f.DisplayName == functionName
                         select f.FunctionType).SingleOrDefault();

            return type;
        }
    }
}
