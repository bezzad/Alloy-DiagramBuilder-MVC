using System;
using System.Web.Http;
using AlloyUiDiagram;
using System.Linq;
using AlloyDiagram.Core;

namespace AlloyDiagram.Controllers
{
    public class DiagramController : ApiController
    {
        //public static Diagram DiagramNodeData { get; set; }

        [HttpPost]
        public IHttpActionResult SaveDiagram(Diagram value)
        {
            if (value == null) return InternalServerError(new ArgumentNullException(nameof(value)));

            value.DiagramName = "TestDiagramName"; // Very important param

            //DiagramNodeData = value;

            //DiagramNodeData.StoreOnDb(0);

            value.StoreOnDb(0);

            return Ok(true);
        }

        [HttpGet]
        public IHttpActionResult GetAvailableFields()
        {
            // todo: must declare user identity for this param about user role shapes
            var userid = 0; 

            return Ok(AlloyHelper.GetAvailableFieldsByUserRole(userid));
        }

        [HttpGet]
        public IHttpActionResult GetSavedData(string id)
        {
            var diagramNodeData = new Guid(id).LoadFromDb();
                
            var nodes =
                diagramNodeData?.Nodes.Select(n => new { name = n.Name, type = n.Type.ToString(), xy = n.XY.ToList() })?.ToList();


            var connections =
                diagramNodeData?.Nodes?.Where(x => x?.Transitions != null)?.SelectMany(x => x.Transitions)?
                    .Select(x => new { connector = new { name = x.Connector.Name }, source = x.Source, target = x.Target })?.ToList();

            return Ok(new { nodes, connections });
        }


    }


}
