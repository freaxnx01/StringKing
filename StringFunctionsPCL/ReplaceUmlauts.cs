using System;
using System.Linq;
using StringKing.StringFunctionInterface;
using System.Collections.Generic;
using System.Text;

namespace StringKing.StringFunctions
{
    [StringFunction("ReplaceUmlauts")]
    public class ReplaceUmlauts : StringFunctionBase
    {
        public override string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            var map = new Dictionary<char, string>() {
              { 'ä', "ae" },
              { 'ö', "oe" },
              { 'ü', "ue" },
              { 'Ä', "Ae" },
              { 'Ö', "Oe" },
              { 'Ü', "Ue" },
              { 'ß', "ss" }
            };

            string replaced = input[0];
            foreach (var item in map)
            {
                replaced = replaced.Replace(item.Key.ToString(), item.Value);
            }

            //string replaced = input[0].Aggregate(
            //  new StringBuilder(),
            //  (sb, c) =>
            //  {
            //      string r;
            //      if (map.TryGetValue(c, out r))
            //          return sb.Append(r);
            //      else
            //          return sb.Append(c);
            //  }).ToString();

            return replaced;
        }
    }
}
