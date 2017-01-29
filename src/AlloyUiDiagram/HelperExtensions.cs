using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlloyUiDiagram
{
    public static class HelperExtensions
    {
        public static object GetDiagramDrawableData(this Diagram diagram)
        {
            var nodes =
               diagram?.Nodes.Select(n => new { name = n.Name, type = n.Type.ToString(), xy = n.XY.ToList() })?.ToList();


            var connections =
                diagram?.Nodes?.Where(x => x?.Transitions != null)?.SelectMany(x => x.Transitions)?
                    .Select(x => new { connector = new { name = x.Connector.Name }, source = x.Source, target = x.Target })?.ToList();


            return new { nodes, connections, isReadonly = diagram?.IsReadOnly ?? false };
        }
    }
}
