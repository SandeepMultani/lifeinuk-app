using System;
using HtmlAgilityPack;

namespace LifeInUK.Extractor.Parsers
{
    public class HtmlParser : IParser<HtmlDocument>
    {
        private static HtmlDocument GetParsedHtmlDocument(string htmlContent)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);
            return htmlDoc;
        }

        public HtmlDocument Parse(string content)
        {
            return GetParsedHtmlDocument(content);
        }
    }
}