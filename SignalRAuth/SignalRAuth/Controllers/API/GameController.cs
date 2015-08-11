using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SignalRAuth.Controllers.API
{
    public class GameController : ApiController
    {
        [Route("api/Game/AddPlayer")]
        [HttpPost]
        public IHttpActionResult AddPlayer()
        {
            String test = "TestString";
            Debug.WriteLine(test);
            return Ok(test);
        }
    }
}
