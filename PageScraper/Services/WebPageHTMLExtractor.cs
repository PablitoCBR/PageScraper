using System;
using System.Net;
using PageScraper.Interfaces;
using System.IO;
using PageScraper.Models;

namespace PageScraper.Services
{
    public class WebPageHTMLExtractor : IWebPageHTMLExtracor
    {
        private PageBaseData _pageBaseData { get; set; }

        public WebPageHTMLExtractor()
        {
            _pageBaseData = new PageBaseData();
        }
        public PageBaseData TryGetWebPageHTML(string stringUrl)
        {
            _pageBaseData.url = stringUrl;
            if (ValidateUrl(_pageBaseData.url))
            {
                ExtractWebPageHTML(_pageBaseData.url);
                return _pageBaseData;
            }         
            else
            {
                Console.WriteLine("Nieprawdiłowy format adresu");
                _pageBaseData.url = "Nieprawidłowy format adresu!";
                return _pageBaseData;
            }

        }
        public bool ValidateUrl(string stringUrl)
        {
            Uri uriResult;
            if (Uri.TryCreate(stringUrl, UriKind.Absolute, out uriResult) && 
                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)) 
                return true;
            else
            {
                if (Uri.TryCreate(TryToRepairUrl(stringUrl), UriKind.Absolute, out uriResult) && 
                    (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                {
                    _pageBaseData.url = TryToRepairUrl(stringUrl);
                    return true;
                }
                else return false;
            }
        }

        public string TryToRepairUrl(string stringUrl)
        {
            return "http://" + stringUrl;
        }
        public void ExtractWebPageHTML(string stringUrl)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(stringUrl);
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        _pageBaseData.pageData = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                _pageBaseData.url = HandleException(ex);
            }
        }

        public string HandleException(WebException ex)
        {
            if (ex.Status == WebExceptionStatus.ProtocolError)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;
                if ((int)response.StatusCode == 404)
                    return "Error 404: Page not found!";
                else return response.StatusCode.ToString();
            }
            else return ex.Message;
        }
    }
}
