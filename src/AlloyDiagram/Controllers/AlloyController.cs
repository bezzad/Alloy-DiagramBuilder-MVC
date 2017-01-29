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

        public ActionResult GetAlloyDiagramsTable()
        {
            var model = Connections.AlloyDb.SqlConn.Query<Diagram>("Select * From Diagrams");

            return PartialView("_AlloyDiagramsTable", model);
        }
    }
}