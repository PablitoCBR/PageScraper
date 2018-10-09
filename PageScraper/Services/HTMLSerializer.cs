using System;
using HtmlAgilityPack;
using PageScraper.Interfaces;

namespace PageScraper.Services
{
    public class HTMLSerializer : IHTMLSerializer
    {
        private HtmlDocument _htmlDoc = new HtmlDocument();

        public HtmlDocument ParseStringToHTMLDocument(string pageData)
        {
            _htmlDoc.LoadHtml(pageData);
            return _htmlDoc;
        }
        public string FindAllImgsUrls(HtmlDocument htmlDoc)
        {
            string urlsString = "";
            var urls = htmlDoc.DocumentNode
                .SelectNodes("//img");
            foreach (var node in urls)
            {
                urlsString += node.Attributes["src"].Value;
            }
            return urlsString;
        }
        public void RemoveComments(HtmlDocument htmlDoc)
        {
            throw new NotImplementedException();
        }
    }
}
