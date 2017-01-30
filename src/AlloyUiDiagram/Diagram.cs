using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AlloyUiDiagram
{
    public class Diagram
    {
        public Guid DiagramId { get; set; } = Guid.NewGuid();

        public string DiagramName { get; set; }

        public bool IsReadOnly { get; set; }

        public DateTime ModifyDate { get; set; }

        [ScaffoldColumn(false)]
        public List<Node> Nodes { get; set; }


        public object GetDiagramDrawableData()
        {
            var nodes = Nodes?.Select(n => new { name = n.Name, type = n.Type.ToString(), xy = n.XY.ToList() })?.ToList();


            var connections = Nodes?.Where(x => x?.Transitions != null)?.SelectMany(x => x.Transitions)?
                    .Select(x => new { connector = new { name = x.Connector.Name }, source = x.Source, target = x.Target })?.ToList();

            return new { nodes, connections, isReadonly = IsReadOnly };
        }
    }
}