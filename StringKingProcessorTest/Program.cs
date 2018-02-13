using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using StringKingProcessor;

namespace StringKingProcessorTest
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

//namespace StringKingProcessorTest
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Form1 form = new Form1();
//            form.ShowDialog();

//            string commands =
//@"GuidGenerator(115)
//Replace('-', '')
//Upper case()
//Sort()
//ReverseList()
//InsertAt(0, 'guid: ', -1, '')
//SkipEveryNthLine(2)";

//            string input = string.Empty;

//            commands =
//@"Lower case()
//RemoveCharAndCamelCaseFollowingWord('_')
//FirstCharUpperCase()";

//            input =
//@"MATERIAL_TRANSFER
//PROD_ORDERS
//INCOMING_GOODS
//INVENTORY
//SALES_ORDER_DELIVERY_NOTE
//EXTRAS
//ITEM_INFO_SHORT
//WAREHOUSE_INFO
//LOGOUT";

//            commands = commands.Replace("'", "\"");

//            Macro macro = new Macro();
//            macro.Name = "TestMacro";
//            macro.Recorded = DateTime.Now;
//            macro.Commands.AddRange(commands.Split(new string[] { Environment.NewLine }, StringSplitOptions.None));

//            string result = MacroProcessor.RunMacro(input, macro);
//        }
//    }
//}
