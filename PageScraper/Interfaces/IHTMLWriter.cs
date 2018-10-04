namespace PageScraper.Interfaces
{
    interface IHTMLWriter
    {
        void WriteString(string text);
        void WriteStartElement(string prefix, string localName, string ns);


    }
}
