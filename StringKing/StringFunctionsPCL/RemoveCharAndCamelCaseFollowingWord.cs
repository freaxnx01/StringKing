using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("RemoveCharAndCamelCaseFollowingWord")]
    public class RemoveCharAndCamelCaseFollowingWord  : StringFunctionBase
    {
        private const string ARGUMENT_CHAR_TO_REMOVE = "Char to remove";

        public override Dictionary<string, object> GetListOfArgument()
        {
            Dictionary<string, object> listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ARGUMENT_CHAR_TO_REMOVE);
            arg1.DefaultValue = string.Empty;
            listOfArgument.Add(ARGUMENT_CHAR_TO_REMOVE, arg1);

            return listOfArgument;
        }

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            char charToRemove = char.MinValue;

            if (GetArgumentValue(arguments, ARGUMENT_CHAR_TO_REMOVE) != null)
            {
                charToRemove = GetArgumentValue(arguments, ARGUMENT_CHAR_TO_REMOVE).ToString()[0];
            }

            char[] charArray = input[0].ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == charToRemove && i + 1 < charArray.Length)
                {
                    charArray[i + 1] = char.ToUpper(charArray[i + 1]);
                }
            }

            return new string(charArray).Replace(charToRemove.ToString(), string.Empty);
        }

        public override string GetTestString()
        {
            return @"MATERIAL_TRANSFER
PROD_ORDERS
INCOMING_GOODS
INVENTORY
SALES_ORDER_DELIVERY_NOTE
EXTRAS
ITEM_INFO_SHORT
WAREHOUSE_INFO
LOGOUT";
        }
    }
}
