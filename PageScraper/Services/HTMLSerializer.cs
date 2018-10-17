using System;
using HtmlAgilityPack;
using PageScraper.Interfaces;
using System.Collections.Generic;
using PageScraper.Models;

namespace PageScraper.Services
{
    public class HTMLSerializer : IHTMLSerializer
    {
        private readonly HtmlDocument _htmlDoc = new HtmlDocument();

        public HtmlDocument ParseStringToHTMLDocument(PageBaseData pageData)
        {
            _htmlDoc.LoadHtml(pageData.pageData);
            return _htmlDoc;
        }
        public List<String> FindAllImgs(HtmlDocument htmlDoc)
        {
            var ImgsList = new List<string>();
            var imgs = htmlDoc.DocumentNode
                .SelectNodes("//img");
            foreach (var node in imgs)
            {
                if (node.Attributes["src"].Value.StartsWith("http"))
                    ImgsList.Add(node.Attributes["src"].Value);
                else ImgsList.Add("main_adress/" + node.Attributes["src"].Value);
            }
            return ImgsList;
        }

        public List<String> FindAllUrls(HtmlDocument htmlDoc)
        {
            var UrlsList = new List<string>();
            var urls = htmlDoc.DocumentNode
                .SelectNodes("//a");
            foreach (var node in urls)
            {
                if(node.Attributes["href"] != null)
                    if(node.Attributes["href"].Value.StartsWith("http"))
                        UrlsList.Add(node.Attributes["href"].Value); //obsługa null do zaimplementowania
            }
            return UrlsList;
        }
    }
}
