using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlloyUiDiagram;
using Dapper;

namespace AlloyDiagram.Core
{
    public static class AlloyHelper
    {
        public static bool StoreOnDb(this Diagram diagram, int userId = 0)
        {
            try
            {
                if (diagram == null) throw new ArgumentNullException(nameof(diagram));
                if (diagram.DiagramName == null)
                    throw new NullReferenceException("The name of diagram must be none empty!");

                var nodes =
                    diagram.Nodes.Select(
                        n =>
                            new
                            {
                                n.NodeId,
                                n.Name,
                                n.Position.X,
                                n.Position.Y,
                                Type = (int)n.Type,
                                n.Description,
                                n.ZIndex,
                                n.Width,
                                n.Height
                            });


                var connections =
                    diagram.Nodes?.Where(x => x?.Transitions != null)?.SelectMany(x => x.Transitions)?
                        .Select(x => new
                        {
                            x.Connector.Name,
                            SourceId = nodes.FirstOrDefault(n => n.Name == x.Source)?.NodeId,
                            TargetId = nodes.FirstOrDefault(n => n.Name == x.Target)?.NodeId
                        });

                var res = Connections.AlloyDb.SqlConn.Query<Diagram>("sp_InsertDiagramData",
                    new
                    {
                        diagram.DiagramId,
                        diagram.DiagramName,
                        diagram.IsReadOnly,
                        CreatorUserId = userId,
                        Nodes = nodes.ToDataTable(),
                        Transitions = connections.ToDataTable()
                    },
                    commandType: System.Data.CommandType.StoredProcedure);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Diagram LoadFromDb(this Guid diagramId, int userId = 0, bool forceReadonly = false)
        {
            try
            {
                var diagram =
                    Connections.AlloyDb.SqlConn.Query<Diagram>("Select * From Diagrams Where DiagramId = @diagramId",
                        new {diagramId}).FirstOrDefault();

                if (diagram == null) return null;

                if (diagram?.IsReadOnly == false)
                    diagram.IsReadOnly = forceReadonly; // set force to readonly when from database is false

                diagram.Nodes =
                    Connections.AlloyDb.SqlConn.Query<Node>("Select * From Nodes Where DiagramId = @diagramId",
                        new {diagramId})?.ToList();

                var connectors =
                    Connections.AlloyDb.SqlConn.Query<dynamic>("Select * From Connectors Where DiagramId = @diagramId",
                        new {diagramId})?.ToList();

                foreach (var node in diagram.Nodes) // read any nodes, one by one to find source node
                {
                    node.Transitions = new List<Transition>();

                    var conns = connectors?.Where(c => c.SourceId == node.NodeId).ToList();
                    foreach (var conn in conns)
                    {
                        var targetNode = diagram.Nodes.FirstOrDefault(x => x.NodeId == conn.TargetId);

                        node.Transitions.Add(new Transition()
                        {
                            Uid = conn.ConnectId.ToString(),
                            Source = node.Name,
                            SourceXY = node.XY,
                            Target = targetNode?.Name,
                            TargetXY = targetNode?.XY,
                            Connector = new Connector() {Name = conn.Name}
                        });
                    }
                }

                return diagram;
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        public static List<Shape> GetAvailableFieldsByUserRole(int userId)
        {
            var shapes = Connections.AlloyDb.SqlConn.Query<Shape>("SELECT * FROM fn_GetAvailableFields(@UserId)",
                new { UserId = userId }).ToList();

            return shapes;
        }
    }
}