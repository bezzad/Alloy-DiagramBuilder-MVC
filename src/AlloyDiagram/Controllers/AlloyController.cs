using Dapper;
using System;
using System.Web.Mvc;
using AlloyDiagram.Core;
using AlloyUiDiagram;
using Newtonsoft.Json;

namespace AlloyDiagram.Controllers
{
    public class AlloyController : Controller
    {
        // GET: Alloy
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDiaramView()
        {
            return PartialView("_AlloyDiagram");
        }

        [HttpPost]
        public ActionResult GetDiaramView(Guid alloyDiagramId)
        {
            //var diagramNodeData = alloyDiagramId.LoadFromDb();

            //var data = diagramNodeData.GetDiagramDrawableData();

            return PartialView("_AlloyDiagram");
        }

        public ActionResult GetAlloyDiagramsTable()
        {
            var model = Connections.AlloyDb.SqlConn.Query<Diagram>("Select * From Diagrams");

            return PartialView("_AlloyDiagramsTable", model);
        }
    }
}