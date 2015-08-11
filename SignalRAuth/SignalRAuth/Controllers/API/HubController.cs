using SignalRAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SignalRAuth.Controllers.API
{
    public class HubController : ApiController
    {
        
        [Route("api/Hub/GetPlayers")]
        [HttpGet]
        public IHttpActionResult GetPlayers()
        {
            return Ok();
        }
    }
}
