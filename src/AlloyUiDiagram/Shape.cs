using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlloyUiDiagram
{
    public class Shape
    {
        public string iconClass { get; set; }
        public string label { get; set; }
        public string type { get; set; }

        public static List<Shape> GetAvailableFields()
        {
            var result = new List<Shape>()
            {
                new Shape() {
                    iconClass= "diagram-node-start-icon",
                    label= "Start",
                    type= "start"
                },
                new Shape() {
                    iconClass= "diagram-node-task-icon",
                    label= "Task",
                    type= "task"
                },
                new Shape() {
                    iconClass= "diagram-node-state-icon",
                    label= "State",
                    type= "state"
                },
                new Shape() {
                    iconClass= "diagram-node-join-icon",
                    label= "Join",
                    type= "join"
                },
                new Shape() {
                    iconClass= "diagram-node-fork-icon",
                    label= "Fork",
                    type= "fork"
                },
                new Shape() {
                    iconClass= "diagram-node-condition-icon",
                    label= "Condition",
                    type= "condition"
                },
                new Shape() {
                    iconClass= "diagram-node-end-icon",
                    label= "End",
                    type= "end"
                }
            };

            return result;
        }
    }
}
