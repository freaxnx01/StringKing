namespace StringKing
{
    public static partial class StringFunctionExtension
    {
public static string Base64ConverterFrom(this string input) { return StringKing.Functions.Base64ConverterFrom.Execute(input); }
public static string Base64ConverterTo(this string input) { return StringKing.Functions.Base64ConverterTo.Execute(input); }
public static string CompareWithWinMerge(this string input) { return StringKing.Functions.CompareWithWinMerge.Execute(input); }
public static string CopyToClipboard(this string input) { return StringKing.Functions.CopyToClipboard.Execute(input); }
public static string DuplicateFinder(this string input) { return StringKing.Functions.DuplicateFinder.Execute(input); }
public static string DuplicateRemover(this string input) { return StringKing.Functions.DuplicateRemover.Execute(input); }
public static string ExtractDigits(this string input) { return StringFunctionsDnpExtensions.ExtractDigits.Execute(input); }
public static string ExtractGuids(this string input) { return StringKing.Functions.ExtractGuids.Execute(input); }
public static string ExtractLowerCaseWords(this string input) { return StringKing.Functions.ExtractLowerCaseWords.Execute(input); }
public static string ExtractUpperCaseWords(this string input) { return StringKing.Functions.ExtractUpperCaseWords.Execute(input); }
public static string FileDescriptionTableCsvToXml(this string input) { return StringKing.Functions.FileDescriptionTableCsvToXml.Execute(input); }
public static string FileDescriptionTableFixedLengthToXml(this string input) { return StringKing.Functions.FileDescriptionTableFixedLengthToXml.Execute(input); }
public static string FirstCharUpperCase(this string input) { return StringKing.Functions.FirstCharUpperCase.Execute(input); }
public static string FormatJson(this string input) { return StringKing.Functions.FormatJson.Execute(input); }
public static string FormatXml(this string input) { return StringKing.Functions.FormatXml.Execute(input); }
public static string GetWords(this string input) { return StringFunctionsDnpExtensions.GetWords.Execute(input); }
public static string HexConverterFrom(this string input) { return StringKing.Functions.HexConverterFrom.Execute(input); }
public static string HexConverterTo(this string input) { return StringKing.Functions.HexConverterTo.Execute(input); }
public static string HtmlDecode(this string input) { return StringKing.Functions.HtmlDecode.Execute(input); }
public static string HtmlEncode(this string input) { return StringKing.Functions.HtmlEncode.Execute(input); }
public static string LowerCase(this string input) { return StringKing.Functions.LowerCase.Execute(input); }
public static string LowerCaseGuids(this string input) { return StringKing.Functions.LowerCaseGuids.Execute(input); }
public static string Md5Hasher(this string input) { return StringKing.Functions.Md5Hasher.Execute(input); }
public static string MergeLines(this string input) { return StringKing.Functions.MergeLines.Execute(input); }
public static string PasteFromClipboard(this string input) { return StringKing.Functions.PasteFromClipboard.Execute(input); }
public static string PathGetDirectoryName(this string input) { return StringKing.Functions.PathGetDirectoryName.Execute(input); }
public static string PathGetExtension(this string input) { return StringKing.Functions.PathGetExtension.Execute(input); }
public static string PathGetFileName(this string input) { return StringKing.Functions.PathGetFileName.Execute(input); }
public static string PathGetFileNameWithoutExtension(this string input) { return StringKing.Functions.PathGetFileNameWithoutExtension.Execute(input); }
public static string PathGetFullPath(this string input) { return StringKing.Functions.PathGetFullPath.Execute(input); }
public static string PathGetPathRoot(this string input) { return StringKing.Functions.PathGetPathRoot.Execute(input); }
public static string PrettifyXml(this string input) { return StringKing.Functions.PrettifyXml.Execute(input); }
public static string RandomizeElementOrder(this string input) { return StringKing.Functions.RandomizeElementOrder.Execute(input); }
public static string RegexEscape(this string input) { return StringKing.Functions.RegexEscape.Execute(input); }
public static string RemoveAllSpecialCharacters(this string input) { return StringFunctionsDnpExtensions.RemoveAllSpecialCharacters.Execute(input); }
public static string RemoveDigits(this string input) { return StringKing.Functions.RemoveDigits.Execute(input); }
public static string RemoveEmptyLines(this string input) { return StringKing.Functions.RemoveEmptyLines.Execute(input); }
public static string RemoveLineBreaks(this string input) { return StringKing.Functions.RemoveLineBreaks.Execute(input); }
public static string RemoveUnneededClosingXmlTag(this string input) { return StringKing.Functions.RemoveUnneededClosingXmlTag.Execute(input); }
public static string Reverse(this string input) { return StringKing.Functions.Reverse.Execute(input); }
public static string ReverseList(this string input) { return StringKing.Functions.ReverseList.Execute(input); }
public static string Sort(this string input) { return StringKing.Functions.Sort.Execute(input); }
public static string TitleCase(this string input) { return StringKing.Functions.TitleCase.Execute(input); }
public static string ToPlural(this string input) { return StringFunctionsDnpExtensions.ToPlural.Execute(input); }
public static string ToUpperFirstLetter(this string input) { return StringKing.Functions.ToUpperFirstLetter.Execute(input); }
public static string Trim(this string input) { return StringKing.Functions.Trim.Execute(input); }
public static string TrimEnd(this string input) { return StringKing.Functions.TrimEnd.Execute(input); }
public static string TrimStart(this string input) { return StringKing.Functions.TrimStart.Execute(input); }
public static string Unescape(this string input) { return StringKing.Functions.Unescape.Execute(input); }
public static string UnformatXml(this string input) { return StringKing.Functions.UnformatXml.Execute(input); }
public static string UpperCase(this string input) { return StringKing.Functions.UpperCase.Execute(input); }
public static string UpperCaseGuids(this string input) { return StringKing.Functions.UpperCaseGuids.Execute(input); }
public static string UrlDecode(this string input) { return StringKing.Functions.UrlDecode.Execute(input); }
public static string UrlEncode(this string input) { return StringKing.Functions.UrlEncode.Execute(input); }
public static string UrlPathEncode(this string input) { return StringKing.Functions.UrlPathEncode.Execute(input); }
        
        
        // public static string Md5Hash(this string input)
        // {
        //     return Functions.Md5Hasher.Execute(input);
        // }
        //
        // public static string GuidGenerator(this string input)
        // {
        //     return Functions.GuidGenerator.Execute();
        // }
        //
        // public static string GuidGenerator(this string input, int numberOf)
        // {
        //     return Functions.GuidGenerator.Execute(numberOf, input);
        // }
        //
        // public static string HtmlEncode(this string input)
        // {
        //     return Functions.HtmlEncode.Execute(input);
        // }
        //
        // public static string HtmlDecode(this string input)
        // {
        //     return Functions.HtmlDecode.Execute(input);
        // }
        //
        // public static string Escape(this string input)
        // {
        //     return Functions.RegexEscape.Execute(input);
        // }
        //
        // public static string Unescape(this string input)
        // {
        //     return Functions.Unescape.Execute(input);
        // }
    }
}
