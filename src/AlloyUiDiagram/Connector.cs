using System.Collections.Generic;

namespace AlloyUiDiagram
{
    public class Connector
    {
        public string color { get; set; }
        public bool lazyDraw { get; set; }
        public string name { get; set; }
        public ShapeSelected shapeSelected { get; set; }
        public ShapeHover shapeHover { get; set; }
        public List<double> p1 { get; set; }
        public List<double> p2 { get; set; }
    }
}