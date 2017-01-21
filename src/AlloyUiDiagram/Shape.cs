using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlloyUiDiagram
{
    public class Shape
    {
        public string iconClass { get; set; }
        public string label { get; set; }
        public FieldType type { get; set; }

        public static List<Shape> GetAvailableFields()
        {
            var allFields =
                typeof(AvailableFields).GetProperties(BindingFlags.DeclaredOnly |
                                                      BindingFlags.Public |
                                                      BindingFlags.Static);

            var shapes = allFields.Select(prop => prop.GetValue(null) as Shape).ToList();

            return shapes;
        }
    }

    public static class AvailableFields
    {
        #region Properties

        public static Shape Start { get; } = new Shape()
        {
            iconClass = "diagram-node-start-icon",
            label = "Start",
            type = FieldType.start
        };


        public static Shape End { get; } = new Shape()
        {
            iconClass = "diagram-node-end-icon",
            label = "End",
            type = FieldType.end
        };

        public static Shape Condition { get; } = new Shape()
        {
            iconClass = "diagram-node-condition-icon",
            label = "Condition",
            type = FieldType.condition
        };

        public static Shape Fork { get; } = new Shape()
        {
            iconClass = "diagram-node-fork-icon",
            label = "Fork",
            type = FieldType.fork
        };

        public static Shape Join { get; } = new Shape()
        {
            iconClass = "diagram-node-join-icon",
            label = "Join",
            type = FieldType.join
        };

        public static Shape State { get; } = new Shape()
        {
            iconClass = "diagram-node-state-icon",
            label = "State",
            type = FieldType.state
        };

        public static Shape Task { get; } = new Shape()
        {
            iconClass = "diagram-node-task-icon",
            label = "Task",
            type = FieldType.task
        };

        #endregion



    }


    public enum FieldType
    {
        start,
        end,
        state,
        condition,
        task,
        join,
        fork
    }
}
