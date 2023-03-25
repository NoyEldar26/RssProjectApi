using RssProjectApi.models;
using System;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RssProjectApi.DAL
{
    public class RssRequest
    {
   //     private static string url1 = "https://news.google.com/rss";
        private static string url = "https://www.google.com/alerts/feeds/13583186640397089815/5906306061878099971";
        public static SyndicationFeed GetXmlData()
        {
            SyndicationFeed feed = new SyndicationFeed();

            using (XmlReader xr = XmlReader.Create(url))
            {
                try
                {
                    feed = SyndicationFeed.Load(xr);
                }
                catch (XmlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return feed;
        }
    }
}
