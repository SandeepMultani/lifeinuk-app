using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace LifeInUK.Extractor.Extensions
{
    public static class HtmlDocumentExtensions
    {
        public static HtmlNode GetNode(this HtmlDocument doc, string nodeXPath)
        {
            return doc.DocumentNode.SelectSingleNode(nodeXPath);
        }

        public static HtmlNodeCollection GetNodes(this HtmlDocument doc, string nodeXPath)
        {
            return doc.DocumentNode.SelectNodes(nodeXPath);
        }
    }
}