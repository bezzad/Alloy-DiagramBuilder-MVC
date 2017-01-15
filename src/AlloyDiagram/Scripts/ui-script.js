YUI().use(
  'aui-diagram-builder',
  function (Y) {
    var availableFields = [
      {
        iconClass: 'diagram-node-start-icon',
        label: 'Start',
        type: 'start'
      },
      {
        iconClass: 'diagram-node-task-icon',
        label: 'Task',
        type: 'task'
      },
      {
        iconClass: 'diagram-node-state-icon',
        label: 'State',
        type: 'state'
      },
      {
        iconClass: 'diagram-node-join-icon',
        label: 'Join',
        type: 'join'
      },
      {
        iconClass: 'diagram-node-fork-icon',
        label: 'Fork',
        type: 'fork'
      },
      {
        iconClass: 'diagram-node-condition-icon',
        label: 'Condition',
        type: 'condition'
      },
      {
        iconClass: 'diagram-node-end-icon',
        label: 'End',
        type: 'end'
      }
    ];

    var diagramBuilder = new Y.DiagramBuilder(
      {
        availableFields: availableFields,
        boundingBox: '#myDiagramContainer',
        srcNode: '#myDiagramBuilder',
        fields: [
          {
            name: 'StartNode',
            type: 'start',
            xy: [10, 10]
          },
          {
            name: 'EndNode',
            type: 'end',
            xy: [300, 400]
          }
        ],
        render: true
      }
    ).render();

    diagramBuilder.connectAll(
      [
        {
          connector: {
            name: 'connector name'
          },
          source: 'StartNode',
          target: 'EndNode'
        }
      ]
    );


  }
);


// tooltip loader
YUI().ready(
  'aui-tooltip',
  function (Y) {
    new Y.Tooltip(
      {
        trigger: '#myDiagramBuilder',
        cssClass: 'tooltip-help',
        opacity: 1,
        position: 'right'
      }
    ).render();
  }
);