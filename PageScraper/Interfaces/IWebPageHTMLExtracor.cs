using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace PageScraper.Interfaces
{
    interface IWebPageHTMLExtracor
    {
        // Returns WebPage HTML code as string
        String TryGetWebPageHTML(string stringUrl);
        bool ValidateUrl(string stringUrl);
        String TryToRepairUrl(string stringUrl);
        String ExtractWebPageHTML(string stringUrl);
        String HandleException(WebException ex);
    }
}
