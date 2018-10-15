using System;
using HtmlAgilityPack;
using PageScraper.Interfaces;
using System.Collections.Generic;
using PageScraper.Models;

namespace PageScraper.Services
{
    public class HTMLSerializer : IHTMLSerializer
    {
        private HtmlDocument _htmlDoc = new HtmlDocument();

        public HtmlDocument ParseStringToHTMLDocument(PageBaseData pageData)
        {
            _htmlDoc.LoadHtml(pageData.pageData);
            return _htmlDoc;
        }
        public List<String> FindAllImgs(HtmlDocument htmlDoc)
        {
            var ImgsList = new List<string>();
            var urls = htmlDoc.DocumentNode
                .SelectNodes("//img");
            foreach (var node in urls)
            {
                ImgsList.Add(node.Attributes["src"].Value);
            }
            return ImgsList;
        }

        public List<string> FindAllUrls(HtmlDocument htmlDoc)
        {
            throw new NotImplementedException();
        }
    }
}
