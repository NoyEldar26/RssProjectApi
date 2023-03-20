using Octopus.Client.Extensibility;
using System.Net;
using System.Text.Encodings.Web;
using System.Xml;

namespace RssProjectApi.models
{
    public class rssModel
    {
        public string id { get; set; }
        public string title { get; set; }
        public Uri link { get; set; }
        public DateTimeOffset published { get; set; }
        public DateTimeOffset updated { get; set; }
        public string content { get; set; }
        
        public rssModel(rssModel rss)
        {
            this.id = rss.id;
            this.title = rss.title;
            this.link = rss.link;
            this.published = rss.published;
            this.updated = rss.updated;
            this.content = rss.content;

        }

        public rssModel()
        {
        }

       

    }

 
}
