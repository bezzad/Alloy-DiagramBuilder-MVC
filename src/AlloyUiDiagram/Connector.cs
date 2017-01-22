using System.Collections.Generic;

namespace AlloyUiDiagram
{
    public class Connector
    {
        public string Color { get; set; }
        public bool LazyDraw { get; set; }
        public string Name { get; set; }
        public ShapeSetting ShapeSelected { get; set; }
        public ShapeSetting ShapeHover { get; set; }
        public List<double> P1 { get; set; }
        public List<double> P2 { get; set; }
    }
}