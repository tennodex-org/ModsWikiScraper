using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ModsWikiScraper.Helper
{
    public static class ModsPageHelper
    {
        public static List<string> GetListOfModTypes(this HtmlDocument doc)
        {
            var nodes = doc.DocumentNode.Descendants("table")
                .Select(x => x.ParentNode.ParentNode)
                .Where(x => x.Attributes["title"] != null)
                .Select(x => x.Attributes["title"].Value)
                .ToList();
            return nodes;
        }

        public static List<string> GetListOfModTypesWithCounts(this HtmlDocument doc)
        {
            var nodes = doc.DocumentNode.Descendants("table")
                .Select(x => x.ParentNode.ParentNode)
                .Where(x => x.Attributes["title"] != null)
                .Select(x => new
                {
                    title = x.Attributes["title"].Value,
                    //count = x.Descendants("tr").Where(tr => tr.Descendants("td").Any()).Count()
                    count = x.Descendants("tr").Where(tr => tr.Descendants("td").Any()).ToList().Count
                })
                .ToList();
            return nodes.Select(n => $"{n.title} {n.count}").ToList();
        }

        public static List<string> GetListOfModTypesNames(this HtmlDocument doc)
        {
            var nodes = doc.DocumentNode.Descendants("table")
                .Select(x => x.ParentNode.ParentNode)
                .Where(x => x.Attributes["title"] != null)
                .SelectMany(x => x.Descendants("tr").Where(tr => tr.Descendants("td").Any()).ToList())
                .Select(x => x.FirstChild?.Attributes["data-param"]?.Value ?? "unknown")
                .ToList();
            return nodes;//.Select(n => $"{n.InnerText}").ToList();
        }

    }
}
