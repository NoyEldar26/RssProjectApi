using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.ServiceModel.Syndication;
using RssProjectApi.models;
using System.Xml.Serialization;
using System;
using System.Net;
using System.IO;
using System.Text;
using RssProjectApi.BL;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RssProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RssController : ControllerBase
    {
        List<rssModel> rss = new List<rssModel>();
        RssBL rssBl = new RssBL();

        [HttpGet]
        public List<rssModel> Get()
        { 
            rssBl.GetRssData(rss);
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
