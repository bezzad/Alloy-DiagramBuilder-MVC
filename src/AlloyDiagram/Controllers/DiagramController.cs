using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AlloyUiDiagram;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace AlloyDiagram.Controllers
{
    public class DiagramController : ApiController
    {
        public static Diagram DiagramNodeData { get; set; }

        [HttpPost]
        public IHttpActionResult SaveDiagram(Diagram value)
        {
            //DiagramNodeData = JsonConvert.DeserializeObject<Diagram>(value);
            return Ok(value);
        }
        
        [HttpGet]
        public IHttpActionResult GetDiagram()
        {
            if (DiagramNodeData == null) return NotFound();
             
            return Ok(DiagramNodeData);
        }

        [HttpGet]
        public IHttpActionResult GetAvailableFields()
        {
            return Ok(Shape.GetAvailableFields());
        }
    }

    
}
