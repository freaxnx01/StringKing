using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using StringKing.FunctionInterface;

namespace StringKing.Core
{
    public class MacroProcessor
    {
        private static readonly Regex commandRegex = new Regex(@"^(?<command>[^\(]+)\((?<arguments>[^\)]*)\)$");
        
        public static string RunMacro(string input, string macroPath)
        {
            return RunMacro(input, Macro.Load(macroPath));
        }

        public static string RunMacro(string input, Macro macro)
        {
            string result = string.Empty;

            foreach (string command in macro.Commands)
            {
                result = RunCommand(input, command);
                input = result;
            }

            return result;
        }

        private static string RunCommand(string input, string command)
        {
            // Sample: InsertAt(0, "guid: ", -1, "")

            Match match = commandRegex.Match(command);
            string commandName = match.Groups["command"].Value;
            string arguments = match.Groups["arguments"].Value;

            Type functionType = Processor.GetTypeByFunctionName(commandName);
            if (functionType == null)
            {
                throw new System.Exception(string.Format("StringFunction '{0}' not found.", commandName));
            }

            // TODO: wird noch nicht behandelt: "abc,def" " x \"y\" z"
            List<string> argumentList = new List<string>(arguments.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            for (int i = 0; i < argumentList.Count; i++)
            {
                argumentList[i] = argumentList[i].Trim();
            }

            Dictionary<string, object> argumentDictionary = ComposeArgumentDictionary(argumentList, Processor.GetArgumentDictionary(functionType));

            return Processor.InvokeStringFunction(functionType, new string[] { input }, argumentDictionary);
        }

        private static Dictionary<string, object> ComposeArgumentDictionary(List<string> argumentList, Dictionary<string, object> argumentDictionary)
        {
            Dictionary<string, object> newArgumentDictionary = new Dictionary<string, object>();

            if (argumentList.Count > 0)
            {
                string[] keyArray = new string[argumentDictionary.Count];
                argumentDictionary.Keys.CopyTo(keyArray, 0);

                for (int i = 0; i < argumentList.Count; i++)
                {
                    string key = keyArray[i];
                    StringFunctionArgument sfa = new StringFunctionArgument(key);

                    string value = argumentList[i];
                    if (value.StartsWith("\"") && value.EndsWith("\""))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }

                    sfa.Value = value;
                    newArgumentDictionary.Add(key, sfa);
                }
            }

            return newArgumentDictionary;
        }
    }
}
