using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringKing.FunctionInterface;

namespace StringKing.Functions
{
    [StringFunction("TakeLinesWhichContainsX")]
    public class TakeLinesWhichContainsX  : StringFunctionBase
    {
        private const string ArgumentSearchString = "searchstring";

        public override Dictionary<string, object> GetListOfArgument()
        {
            Dictionary<string, object> listOfArgument = new Dictionary<string, object>();

            StringFunctionArgument arg1 = new StringFunctionArgument(ArgumentSearchString);
            arg1.DefaultValue = string.Empty;
            listOfArgument.Add(ArgumentSearchString, arg1);

            return listOfArgument;
        }

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            List<string> lines = SplitByNewLine(input[0]);

            string searchString = GetArgumentValue(arguments, ArgumentSearchString).ToString();

            StringBuilder sb = new StringBuilder();
            foreach (string line in lines)
            {
                if (line.Contains(searchString))
                {
                    sb.AppendLine(line);
                }
            }

            return sb.ToString();
        }

        public override string GetTestString()
        {
            return @"this.logÖffnenToolStripMenuItem.Name = 'logÖffnenToolStripMenuItem';
            this.logÖffnenToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.logÖffnenToolStripMenuItem.Text = 'Svc TraceViewer öffnen';
            this.logÖffnenToolStripMenuItem.Click += new System.EventHandler(this.logÖffnenToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hilfeToolStripMenuItem1,
            this.toolStripMenuItem1});
            this.hilfeToolStripMenuItem.Name = 'hilfeToolStripMenuItem';
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.hilfeToolStripMenuItem.Text = 'Hilfe';
            // 
            // hilfeToolStripMenuItem1
            // 
            this.hilfeToolStripMenuItem1.Name = 'hilfeToolStripMenuItem1';
            this.hilfeToolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
            this.hilfeToolStripMenuItem1.Text = 'Hilfe';
            this.hilfeToolStripMenuItem1.Click += new System.EventHandler(this.hilfeToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = 'toolStripMenuItem1';
            this.toolStripMenuItem1.Size = new System.Drawing.Size(103, 6);";
        }
    }
}
