using Dapper;
using System;
using System.Web.Mvc;
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

        public ActionResult GetAlloyDiagramsTable()
        {
            var model = Connections.AlloyDb.SqlConn.Query<Diagram>("Select * From Diagrams");

            return PartialView("_AlloyDiagramsTable", model);
        }
    }
}