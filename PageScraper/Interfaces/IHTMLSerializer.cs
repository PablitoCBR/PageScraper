using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace PageScraper.Interfaces
{
    public interface IHTMLSerializer
    {
        HtmlDocument ParseStringToHTMLDocument(string pageData);
        void RemoveComments(HtmlDocument htmlDoc);
        string FindAllImgsUrls(HtmlDocument htmlDoc);
    }
}
