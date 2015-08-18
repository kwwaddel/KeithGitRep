using NewsAggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsAggregator.Controllers
{
    public class BingController : ApiController
    {
        private BingModel _search;

        public BingController()
        {
            _search = new BingModel();
        }
        [Route("Bing/Get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_search.GetResults());
        }
    }
}
