using System.Collections.Generic;

namespace AlloyUiDiagram
{
    public class Node
    {
        public List<Transition> transitions { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
        public string type { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int zIndex { get; set; }
        public List<int> xy { get; set; }
    }
}