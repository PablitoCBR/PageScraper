using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PageScraper.Interfaces;
using System.IO;

namespace PageScraper.Services
{
    public class WebPageHTMLExtractor : IWebPageHTMLExtracor
    {
        private string _url { get; set; }
        public string TryGetWebPageHTML(string stringUrl)
        {
            _url = stringUrl;
            if (ValidateUrl(_url))
                return ExtractWebPageHTML(_url);
            else return String.Empty; // zaimplementować zwrot informacji o błędzie

        }
        public bool ValidateUrl(string stringUrl)
        {
            if (Uri.IsWellFormedUriString(stringUrl, UriKind.RelativeOrAbsolute))
                return true;
            else
            {
                if (Uri.IsWellFormedUriString(TryToRepairUrl(stringUrl), UriKind.RelativeOrAbsolute))
                {
                    _url = TryToRepairUrl(stringUrl);
                    return true;
                }
                else return false;
            }
        }

        public string TryToRepairUrl(string stringUrl)
        {
            return "http://" + stringUrl;
        }
        public string ExtractWebPageHTML(string stringUrl)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(stringUrl);
            string responseBody;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }
                return responseBody;
            }
            catch (WebException ex)
            {
                return HandleException(ex);
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
