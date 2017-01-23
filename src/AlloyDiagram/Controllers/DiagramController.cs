using System;
using System.Web.Http;
using AlloyUiDiagram;
using System.Linq;

namespace AlloyDiagram.Controllers
{
    public class DiagramController : ApiController
    {
        public static Diagram DiagramNodeData { get; set; }

        [HttpPost]
        public IHttpActionResult SaveDiagram(Diagram value)
        {
            if (value == null) return InternalServerError(new ArgumentNullException(nameof(value)));

            DiagramNodeData = value;

            return Ok(true);
        }

        [HttpGet]
        public IHttpActionResult GetAvailableFields()
        {
            return Ok(Shape.GetAvailableFields());
        }

        [HttpGet]
        public IHttpActionResult GetSavedData()
        {
            var nodes =
                DiagramNodeData?.Nodes.Select(n => new { name = n.Name, type = n.Type.ToString(), xy = n.XY.ToList() })?.ToList();


            var connections =
                DiagramNodeData?.Nodes?.Where(x => x?.Transitions != null)?.SelectMany(x => x.Transitions)?
                    .Select(x => new { connector = new { name = x.Connector.Name }, source = x.Source, target = x.Target })?.ToList();

            return Ok(new { nodes, connections });
        }
    }


}
