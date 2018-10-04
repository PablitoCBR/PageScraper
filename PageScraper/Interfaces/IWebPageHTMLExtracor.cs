using System;
using System.Net;
using PageScraper.Models;

namespace PageScraper.Interfaces
{
    public interface IWebPageHTMLExtracor
    {
        // Returns WebPage HTML code as string
        PageBaseData TryGetWebPageHTML(string stringUrl);
        bool ValidateUrl(string stringUrl);
        String TryToRepairUrl(string stringUrl);
        void ExtractWebPageHTML(string stringUrl);
        String HandleException(WebException ex);
    }
}
