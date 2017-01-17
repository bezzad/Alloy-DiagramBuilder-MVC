using System.Collections.Generic;

namespace AlloyUiDiagram
{
    public class Transition
    {
        public string source { get; set; }
        public string target { get; set; }
        public string uid { get; set; }
        public List<int> sourceXY { get; set; }
        public List<int> targetXY { get; set; }
        public Connector connector { get; set; }
    }
}