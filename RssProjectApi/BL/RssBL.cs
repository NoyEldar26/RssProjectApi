using RssProjectApi.DAL;
using RssProjectApi.models;
using System.ServiceModel.Syndication;

namespace RssProjectApi.BL
{
    public class RssBL
    {
       public RssBL() { }
        public void GetRssData(List<rssModel> rss)
        {
            SyndicationFeed feed = RssRequest.GetXmlData();

            foreach (var item in feed.Items)
            {
                try
                {
                    rssModel rssModel = new rssModel();
                    rssModel.title = item.Title.Text;
                    rssModel.id = item.Id;
                    rssModel.published = item.PublishDate;
                    rssModel.updated = item.LastUpdatedTime;
                    rssModel.link = item.Links[0].Uri;

                    TextSyndicationContent tsc = (TextSyndicationContent)item.Content;
                    rssModel.content = tsc.Text;

                    rss.Add(rssModel);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
