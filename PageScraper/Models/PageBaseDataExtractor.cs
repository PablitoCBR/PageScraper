using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace PageScraper.Models
{
    public static class PageBaseDataExtractor
    {
        public static string pageDataStr { get; set; }

        public static void DownloadPageData(string url)
        {
            url = ValidateUrl(url);
            pageDataStr = GetSourceCode(url);
        }
        private static String GetSourceCode(string url)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(url);
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
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse response = (HttpWebResponse)ex.Response;
                    if ((int)response.StatusCode == 404)
                        responseBody = "404 page not found!";
                    else if ((int)response.StatusCode == 403)
                        responseBody = "403 data are forbidden";
                    else if ((int)response.StatusCode == 401)
                        responseBody = "401 Unauthorized request";
                    else responseBody = "Error: " + (int)response.StatusCode;
                }
                else
                {
                    responseBody = ex.Message;
                }

                return responseBody;
            }
        }
        private static string ValidateUrl(string url)
        {
            if (url.StartsWith("http://"))
                return url;
            else
            {
                url = "http://" + url;
                return url;
            }
        }
    }
}
