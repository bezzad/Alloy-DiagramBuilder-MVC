using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlloyDiagram.Controllers
{
    public class DiagramController : ApiController
    {
        [HttpPost]
       // [Route(Name = "SaveDiagram")]
        public IHttpActionResult SaveDiagram([FromBody]string data)
        {
            return Ok("OK");
        }
    }

    
}
