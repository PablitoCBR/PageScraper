using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PageScraper.Models;

namespace PageScraper.Interfaces
{
    public interface IHTMLSerializer
    {
        HtmlDocument ParseStringToHTMLDocument(PageBaseData pageData);
        List<string> FindAllImgs(HtmlDocument htmlDoc);
        List<string> FindAllUrls(HtmlDocument htmlDoc);
    }
}
