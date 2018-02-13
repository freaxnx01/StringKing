using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringKing.StringFunctionInterface
{
    public class StringFunctionBase : IStringFunction
    {
        #region IStringFunction
        public virtual string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            return string.Empty;
        }

        public virtual Dictionary<string, object> GetListOfArgument()
        {
            return new Dictionary<string, object>();
        }

        public virtual string GetTestString()
        {
            return GetTestData();
        }

        public string GetLoremIpsumString()
        {
            return "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";
        }

        public string GetDisplayName()
        {
            object[] customAttributes = this.GetType().GetCustomAttributes(typeof(StringFunctionAttribute), false);
            if (customAttributes.Length == 1)
            {
                return ((StringFunctionAttribute)customAttributes[0]).DisplayName;
            }
            return string.Empty;
        }

        public string GetCallAsString(Dictionary<string, object> arguments)
        {
            // TODO: Behandlung von ' in strings

            StringBuilder sb = new StringBuilder();
            sb.Append(GetDisplayName());
            sb.Append("(");

            int argCounter = 0;
            foreach (object argObject in arguments.Values)
            {
                if (argObject != null)
                {
                    StringFunctionArgument arg = (StringFunctionArgument)argObject;

                    if (arg.Value != null)
                    {
                        int result;
                        if (int.TryParse(arg.Value.ToString(), out result))
                        {
                            sb.Append(arg.Value);
                        }
                        else
                        {
                            sb.Append(string.Format("\"{0}\"", arg.Value));
                        }
                    }
                }

                if (argCounter + 1 < arguments.Count)
                {
                    sb.Append(", ");
                }
                argCounter++;
            }

            sb.Append(")");

            return sb.ToString();
        }
        #endregion

        #region Helpers
        protected object GetArgumentValue(Dictionary<string, object> arguments, string argumentName)
        {
            if (arguments.ContainsKey(argumentName))
            {
                if (arguments[argumentName] is StringFunctionArgument)
                {
                    return ((StringFunctionArgument)arguments[argumentName]).Value;
                }
            }

            return null;
        }

        protected string ConvertListToString(List<string> list)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string item in list)
            {
                sb.AppendLine(item);
            }

            return sb.ToString();
        }

        protected List<string> SplitByNewLine(string input)
        {
            return input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        protected List<string> SplitByNewLine(string input, bool preserveEmptyLines)
        {
            if (!preserveEmptyLines)
            {
                return SplitByNewLine(input);
            }

            return input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        }
        #endregion

        #region TestData
        protected string GetTestData()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Process proc in Process.GetProcesses())
            {
                sb.AppendLine(proc.ProcessName);
            }
            return sb.ToString();
        }

        protected string GetPathTestData()
        {
            StringBuilder sb = new StringBuilder();
            foreach (FileInfo fileInfo in new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.System)).GetFiles("*.exe"))
            {
                sb.AppendLine(fileInfo.FullName);
            }
            return sb.ToString();
        }
        #endregion
    }
}
