using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("InsertAt")]
    public class InsertAt  : StringFunctionBase
    {
        private const string ARGUMENT_INSERT_POS_1 = "insertpos1";
        private const string ARGUMENT_INSERT_TEXT_1 = "inserttext1";
        private const string ARGUMENT_INSERT_POS_2 = "insertpos2";
        private const string ARGUMENT_INSERT_TEXT_2 = "inserttext2";

        public override Dictionary<string, object> GetListOfArgument()
        {
            Dictionary<string, object> listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ARGUMENT_INSERT_POS_1);
            arg1.DefaultValue = "0";
            listOfArgument.Add(ARGUMENT_INSERT_POS_1, arg1);

            StringFunctionArgument arg2 = new StringFunctionArgument(ARGUMENT_INSERT_TEXT_1);
            arg2.DefaultValue = string.Empty;
            listOfArgument.Add(ARGUMENT_INSERT_TEXT_1, arg2);

            StringFunctionArgument arg3 = new StringFunctionArgument(ARGUMENT_INSERT_POS_2);
            arg3.DefaultValue = "-1";
            listOfArgument.Add(ARGUMENT_INSERT_POS_2, arg3);

            StringFunctionArgument arg4 = new StringFunctionArgument(ARGUMENT_INSERT_TEXT_2);
            arg4.DefaultValue = string.Empty;
            listOfArgument.Add(ARGUMENT_INSERT_TEXT_2, arg4);

            return listOfArgument;
        }

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            // insertPos 0 = vor erstem Zeichen
            // insertPos -1 = nach letztem Zeichen

            int insertPos1 = 0;
            string insertText1 = string.Empty;
            
            int insertPos2 = 0;
            string insertText2 = string.Empty;

            if (int.TryParse(GetArgumentValue(arguments, ARGUMENT_INSERT_POS_1).ToString(), out insertPos1))
            {
                insertText1 = GetArgumentValue(arguments, ARGUMENT_INSERT_TEXT_1).ToString();
            }
            else
            {
                throw new StringFunctionException(string.Format("Argument {0} not numeric.", ARGUMENT_INSERT_POS_1));
            }

            if (int.TryParse(GetArgumentValue(arguments, ARGUMENT_INSERT_POS_2).ToString(), out insertPos2))
            {
                insertText2 = GetArgumentValue(arguments, ARGUMENT_INSERT_TEXT_2).ToString();
            }
            else
            {
                throw new StringFunctionException(string.Format("Argument {0} not numeric.", ARGUMENT_INSERT_POS_2));
            }

            List<string> lines = SplitByNewLine(input[0]);

            StringBuilder sb = new StringBuilder();

            int definitivePos = 0;
            string workLine = string.Empty;

            foreach (string line in lines)
            {
                workLine = line;

                if (!string.IsNullOrEmpty(insertText1))
                {
                    definitivePos = GetDefinitivePosition(insertPos1, workLine);
                    workLine = workLine.Insert(definitivePos, insertText1);                    
                }

                if (!string.IsNullOrEmpty(insertText2))
                {
                    definitivePos = GetDefinitivePosition(insertPos2, workLine);
                    workLine = workLine.Insert(definitivePos, insertText2);
                }

                sb.AppendLine(workLine);
            }

            return sb.ToString();
        }

        private int GetDefinitivePosition(int initPos, string text)
        {
            if (initPos == -1)
            {
                initPos = text.Length;
            }

            return initPos;
        }
    }
}
