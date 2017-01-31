using Dapper;
using System;
using System.Web.Mvc;
using AlloyDiagram.Core;
using AlloyUiDiagram;

namespace AlloyDiagram.Controllers
{
    public class AlloyController : Controller
    {
        // GET: Alloy
        public ActionResult CreateDiagram()
        {
            return View();
        }

        public ActionResult EditDiagrams()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditDiagrams(Guid id)
        {
            var diagramNodeData = id.LoadFromDb();

            return View(diagramNodeData);
        }

        public ActionResult GetAlloyDiagramsTable()
        {
            var model = Connections.AlloyDb.SqlConn.Query<Diagram>("Select * From Diagrams");

            return PartialView("_AlloyDiagramsTable", model);
        }
    }
}