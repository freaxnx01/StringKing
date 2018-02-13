using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
//using System.Windows.Forms;
using StringKing.StringFunctionInterface;

namespace StringKing.StringFunctions
{
    [StringFunction("CompareWithWinMerge")]
    public class CompareWithWinMerge : StringFunctionBase
    {
        private const string WinMergeExePath = @"C:\Program Files (x86)\WinMerge\WinMergeU.exe";

        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            //TODO PCL
            throw new NotImplementedException("PCL");

            //if (input == null || input.Length < 2)
            //{
            //    return string.Empty;
            //}

            //if (!File.Exists(WinMergeExePath))
            //{
            //    return string.Empty;
            //}

            //string tempFile1 = SaveTextInTempFile(input[0], "LEFT");
            //string tempFile2 = SaveTextInTempFile(input[1], "RIGHT");

            //Process process = new Process();
            //process.StartInfo.FileName = WinMergeExePath;
            //process.StartInfo.Arguments = string.Format("{0} {1}", EncloseInQuotes(tempFile1), EncloseInQuotes(tempFile2));
            //process.Start();

            //return string.Empty;
        }

        //private string SaveTextInTempFile(string text, string postfix)
        //{
        //    string tempFile = Path.GetTempFileName() + "_" + postfix;
        //    File.WriteAllText(tempFile, text);
        //    return tempFile;
        //}

        private string EncloseInQuotes(string path)
        {
            return string.Format("\"{0}\"", path);
        }
    }
}
