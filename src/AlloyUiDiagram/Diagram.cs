using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    }
}