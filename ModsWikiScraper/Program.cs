using System;
using System.Linq;
using HtmlAgilityPack;
using ModsWikiScraper.Helper;

namespace ModsWikiScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var url = "https://warframe.fandom.com/wiki/Mods";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var modTypes = doc.GetListOfModTypes();
            foreach (string modType in modTypes)
            {
                Console.WriteLine(modType);
            }

            Console.WriteLine("---------------------------------");

            var modTypesWithCount = doc.GetListOfModTypesWithCounts();
            foreach (string modTypeWithCount in modTypesWithCount)
            {
                Console.WriteLine(modTypeWithCount);
            }
        }
    }
}
