namespace AlloyUiDiagram
{
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
}