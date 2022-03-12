using System.Text.RegularExpressions;

namespace LifeInUK.Extractor.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex sWhitespace = new Regex(@"\s+");
        public static string ReplaceWhitespace(this string input, string replacement)
        {
            return sWhitespace.Replace(input, replacement);
        }
    }
}