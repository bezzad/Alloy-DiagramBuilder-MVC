function DiagramDrower(containerId, builderId, nodes, connections, isReadonly, callBackDiagram) {
    YUI().use('aui-diagram-builder', function (y) {
        $.getJSON(window.location.origin + "/api/diagram/GetAvailableFields", null, function (data) {
            if (isReadonly === true) data = [];
            var diagram = new y.DiagramBuilder(
            {
                availableFields: data,
                boundingBox: '#' + containerId,
                fields: nodes,
                srcNode: '#' + builderId
            }).render();

            diagram.connectAll(connections);

            if (callBackDiagram !== undefined) callBackDiagram(diagram);

            if(isReadonly === true) ReadonlyDiagram(diagram);
        });
    });
}

/*
 * Readonly the diagram
 */
function ReadonlyDiagram(diagram) {
    function detachRecursively(node) {
        node.get('children').each(detachRecursively);

        // You may also want to set the cursor to the default since it will 
        // change based on which elements the mouse is over.
        node.setStyle('cursor', 'auto');

        // You may want to detach specific events such as 'click' or 
        // 'mousedown' if you do not want to disable all events.
        node.detach();
    };

    diagram.on('render', function (event) {
        detachRecursively(diagram.get('boundingBox'));
    });
}



function showAlert(message, title, type) {
    $('#alert_placeholder').html("<div id='messageBox' class='alert alert-" + type + " alert-dismissible fade in'>" +
        "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>" +
                "<strong>" + title + "</strong> Your diagram stored on server.</div>");
}


function SaveDiagram(diagram) {
    var x = diagram.toJSON();
    x.DiagramId = diagram.DiagramId;
    x.DiagramName = diagram.DiagramName;

    $.post(window.location.origin + "/api/diagram/SaveDiagram", x, function (d) {
        showAlert("Your diagram stored on server.", "Success!", "success");
    });
};





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