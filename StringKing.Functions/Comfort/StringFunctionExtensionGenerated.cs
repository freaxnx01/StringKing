namespace StringKing
{
    public static partial class StringFunctionExtension
    {
        public static string MD5Hash(this string input)
        {
            return Functions.Md5Hasher.Execute(input);
        }

        public static string GuidGenerator(this string input)
        {
            return Functions.GuidGenerator.Execute();
        }

        public static string GuidGenerator(this string input, int numberOf)
        {
            return Functions.GuidGenerator.Execute(numberOf, input);
        }
        
        public static string HtmlEncode(this string input)
        {
            return Functions.HtmlEncode.Execute(input);
        }
        
        public static string HtmlDecode(this string input)
        {
            return Functions.HtmlDecode.Execute(input);
        }
       
        public static string Escape(this string input)
        {
            return Functions.Escape.Execute(input);
        }
        
        public static string Unescape(this string input)
        {
            return Functions.Unescape.Execute(input);
        }
    }
}
