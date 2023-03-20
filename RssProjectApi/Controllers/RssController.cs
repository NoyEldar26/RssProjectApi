using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.ServiceModel.Syndication;
using RssProjectApi.models;
using System.Xml.Serialization;
using System;
using System.Net;
using System.IO;
using System.Text;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RssProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RssController : ControllerBase
    {
        // GET: api/<RssController>
/*        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string Response;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://www.google.com/alerts/feeds/13583186640397089815/5906306061878099971"))
                {
                    Response = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response : ");
                    Console.WriteLine(Response);
                }
            }
            return Ok(Response);
            //return new string[] { "value1", "value2" };
        }
*/


        [HttpGet]
        public List<rssModel> Get()
        {
            var deals = new List<string>();
            List<rssModel> rss = new List<rssModel>(); 

            XmlReader xr = XmlReader.Create("https://www.google.com/alerts/feeds/13583186640397089815/5906306061878099971");
            SyndicationFeed feed = SyndicationFeed.Load(xr);

            List<SyndicationItem> items = new List<SyndicationItem>();
                    
            foreach (var item in feed.Items)
            {
              //  Console.WriteLine(item.Links);
                rssModel rssModel = new rssModel();
                rssModel.title = item.Title.Text;
                rssModel.id = item.Id;
                rssModel.published = item.PublishDate;
                rssModel.updated = item.LastUpdatedTime;
                rssModel.link = item.Links[0].Uri;
     

                TextSyndicationContent tsc = (TextSyndicationContent)item.Content;
                rssModel.content = tsc.Text;

                rss.Add(rssModel);
                     
                Console.WriteLine(item.Links[0].Uri);
   
            }
            return rss;
        }


        // GET api/<RssController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    


    }
}
