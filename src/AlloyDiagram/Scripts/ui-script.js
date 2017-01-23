function DiagramDrower(containerId, builderId, nodes, connections, callBackDiagram) {
    YUI().use('aui-diagram-builder', function (y) {
        $.getJSON(window.location.origin + "/api/diagram/GetAvailableFields", null, function (data) {
            var diagram = new y.DiagramBuilder(
            {
                availableFields: data,
                boundingBox: '#' + containerId,
                fields: nodes,
                srcNode: '#' + builderId
            }).render();

            diagram.connectAll(connections);

            if (callBackDiagram !== undefined) callBackDiagram(diagram);
        });
    });
}

// tooltip loader
//YUI().ready(
//  'aui-tooltip',
//  function (Y) {
//    new Y.Tooltip(
//      {
//        trigger: '#myDiagramBuilder',
//        cssClass: 'tooltip-help',
//        opacity: 1,
//        position: 'bottom'
//      }
//    ).render();
//  }
//);