using System.IO;
using System.Xml;

namespace PageScraper.Interfaces
{
    interface IHTMLReader 
    {
        XmlDocument XMLFromHTML(TextReader reader);
        // do przemyślenia 
        // można zastocować HTML Agility Pack i stworzyć obiekt HTML
    }
}
