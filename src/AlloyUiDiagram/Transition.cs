using System.Collections.Generic;

namespace AlloyUiDiagram
{
    public class Transition
    {
        public string Source { get; set; }
        public string Target { get; set; }
        public string Uid { get; set; }
        public List<double> SourceXY { get; set; }
        public List<double> TargetXY { get; set; }
        public Connector Connector { get; set; }
    }
}