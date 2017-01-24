using System;
using System.Collections.Generic;

namespace AlloyUiDiagram
{
    public class Diagram
    {
        public int DiagramId { get; set; }

        public string DiagramName { get; set; }

        public bool IsReadOnly { get; set; }

        public DateTime ModifyDate { get; set; }

        public List<Node> Nodes { get; set; }
    }
}