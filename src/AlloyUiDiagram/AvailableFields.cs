namespace AlloyUiDiagram
{
    public static class AvailableFields
    {
        #region Properties

        public static Shape Start { get; } = new Shape()
        {
            IconClass = "diagram-node-start-icon",
            Label = "Start",
            Type = FieldType.start
        };

        public static Shape End { get; } = new Shape()
        {
            IconClass = "diagram-node-end-icon",
            Label = "End",
            Type = FieldType.end
        };

        public static Shape Condition { get; } = new Shape()
        {
            IconClass = "diagram-node-condition-icon",
            Label = "Condition",
            Type = FieldType.condition
        };

        public static Shape Fork { get; } = new Shape()
        {
            IconClass = "diagram-node-fork-icon",
            Label = "Fork",
            Type = FieldType.fork
        };

        public static Shape Join { get; } = new Shape()
        {
            IconClass = "diagram-node-join-icon",
            Label = "Join",
            Type = FieldType.join
        };

        public static Shape State { get; } = new Shape()
        {
            IconClass = "diagram-node-state-icon",
            Label = "State",
            Type = FieldType.state
        };

        public static Shape Task { get; } = new Shape()
        {
            IconClass = "diagram-node-task-icon",
            Label = "Task",
            Type = FieldType.task
        };

        #endregion

    }
}