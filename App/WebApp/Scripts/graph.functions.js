var nodes, edges, network;
var nodesjson, edgesjson;
// create an array with nodes
nodes = new vis.DataSet();
nodes.on('*', function () {
    nodesjson = JSON.stringify(nodes.get(), null, 4);
});
nodes.add([
  { id: 'A', label: 'A' },
  { id: 'B', label: 'B' },
  { id: 'C', label: 'C' },
  { id: 'D', label: 'D' },
  { id: 'E', label: 'E' }
]);

// create an array with edges
edges = new vis.DataSet();
edges.on('*', function () {
    edgesjson = JSON.stringify(edges.get(), null, 4);
});
edges.add([
  { from: 'A', to: 'B', label: '5', arrows: 'to', font: { align: 'middle' }, id: 'AB' },
  { from: 'A', to: 'D', label: '5', arrows: 'to', font: { align: 'middle' }, id: 'AD' },
  { from: 'A', to: 'E', label: '7', arrows: 'to', font: { align: 'middle' }, id: 'AE' },
  { from: 'B', to: 'C', label: '4', arrows: 'to', font: { align: 'middle' }, id: 'BC' },
  { from: 'C', to: 'D', label: '8', arrows: 'to', font: { align: 'middle' }, id: 'CD' },
  { from: 'C', to: 'E', label: '6', arrows: 'to', font: { align: 'middle' }, id: 'CE' },
  { from: 'D', to: 'C', label: '8', arrows: 'to', font: { align: 'middle' }, id: 'DC' },
  { from: 'D', to: 'E', label: '6', arrows: 'to', font: { align: 'middle' }, id: 'DE' },
  { from: 'E', to: 'B', label: '3', arrows: 'to', font: { align: 'middle' }, id: 'EB' }
]);

// create a network
var container = document.getElementById('mynetwork');
var data = {
    nodes: nodes,
    edges: edges
};
var options = {};
network = new vis.Network(container, data, options);



// convenience method to stringify a JSON object
function toJSON(obj) {
    return JSON.stringify(obj, null, 4);
}

function addVertex() {

    try {
        nodes.add({
            id: document.getElementById('node-id').value.toUpperCase(),
            label: document.getElementById('node-id').value.toUpperCase()
        });
    }
    catch (err) {
        alert(err);
    }
}

function addEdge() {
    try {
        edges.add({
            label: document.getElementById('node-distance').value,
            from: document.getElementById('node-source').value.toUpperCase(),
            to: document.getElementById('node-target').value.toUpperCase(),
            id: document.getElementById('node-source').value.toUpperCase() + document.getElementById('node-target').value.toUpperCase(),
            arrows: 'to',
            font: { align: 'middle' }
        });
    }
    catch (err) {
        alert(err);
    }
}


function draw(obj) {

    console.log(obj);
    console.log(nodesjson);

    if (obj == 1) {
        nodes = new vis.DataSet();
        nodes.on('*', function () {
            nodesjson = JSON.stringify(nodes.get(), null, 4);
        });
        nodes.add([
          { id: 'A', label: 'A' },
          { id: 'B', label: 'B' },
          { id: 'C', label: 'C' },
          { id: 'D', label: 'D' },
          { id: 'E', label: 'E' }
        ]);

        // create an array with edges
        edges = new vis.DataSet();
        edges.on('*', function () {
            edgesjson = JSON.stringify(edges.get(), null, 4);
        });
        edges.add([
          { from: 'A', to: 'B', label: '5', arrows: 'to', font: { align: 'middle' }, id: 'AB' },
          { from: 'A', to: 'D', label: '5', arrows: 'to', font: { align: 'middle' }, id: 'AD' },
          { from: 'A', to: 'E', label: '7', arrows: 'to', font: { align: 'middle' }, id: 'AE' },
          { from: 'B', to: 'C', label: '4', arrows: 'to', font: { align: 'middle' }, id: 'BC' },
          { from: 'C', to: 'D', label: '8', arrows: 'to', font: { align: 'middle' }, id: 'CD' },
          { from: 'C', to: 'E', label: '6', arrows: 'to', font: { align: 'middle' }, id: 'CE' },
          { from: 'D', to: 'C', label: '8', arrows: 'to', font: { align: 'middle' }, id: 'DC' },
          { from: 'D', to: 'E', label: '6', arrows: 'to', font: { align: 'middle' }, id: 'DE' },
          { from: 'E', to: 'B', label: '3', arrows: 'to', font: { align: 'middle' }, id: 'EB' }
        ]);

        // create a network
        var container = document.getElementById('mynetwork');
        var data = {
            nodes: nodes,
            edges: edges
        };
        var options = {};
        network = new vis.Network(container, data, options);
    }

    if (obj == 2) {
        nodes = new vis.DataSet();
        nodes.on('*', function () {
            nodesjson = JSON.stringify(nodes.get(), null, 4);
        });
        nodes.add([
          { id: 'A', label: 'A' },
          { id: 'B', label: 'B' }
          
        ]);

        // create an array with edges
        edges = new vis.DataSet();
        edges.on('*', function () {
            edgesjson = JSON.stringify(edges.get(), null, 4);
        });
        edges.add([
          { from: 'A', to: 'B', label: '5', arrows: 'to', font: { align: 'middle' }, id: 'AB' },
          
        ]);

        // create a network
        var container = document.getElementById('mynetwork');
        var data = {
            nodes: nodes,
            edges: edges
        };
        var options = {};
        network = new vis.Network(container, data, options);
    }

    if (obj == 3) {
        nodes = new vis.DataSet();
        nodes.on('*', function () {
            nodesjson = JSON.stringify(nodes.get(), null, 4);
        });
        nodes.add([
          { id: 'A', label: 'A' },
          { id: 'B', label: 'B' },
          { id: 'C', label: 'C' },
          { id: 'D', label: 'D' },
          { id: 'E', label: 'E' },
          { id: 'F', label: 'F' },
          { id: 'G', label: 'G' },
          { id: 'H', label: 'H' },
          { id: 'I', label: 'I' },
          { id: 'J', label: 'J' }
        ]);

        // create an array with edges
        edges = new vis.DataSet();
        edges.on('*', function () {
            edgesjson = JSON.stringify(edges.get(), null, 4);
        });
        edges.add([
          { from: 'A', to: 'B', label: '5', arrows: 'to', font: { align: 'middle' }, id: 'AB' },
          { from: 'A', to: 'D', label: '5', arrows: 'to', font: { align: 'middle' }, id: 'AD' },
          { from: 'A', to: 'E', label: '7', arrows: 'to', font: { align: 'middle' }, id: 'AE' },
          { from: 'B', to: 'C', label: '4', arrows: 'to', font: { align: 'middle' }, id: 'BC' },
          { from: 'C', to: 'D', label: '8', arrows: 'to', font: { align: 'middle' }, id: 'CD' },
          { from: 'C', to: 'E', label: '6', arrows: 'to', font: { align: 'middle' }, id: 'CE' },
          { from: 'D', to: 'G', label: '8', arrows: 'to', font: { align: 'middle' }, id: 'DG' },
          { from: 'F', to: 'E', label: '6', arrows: 'to', font: { align: 'middle' }, id: 'FE' },
          { from: 'E', to: 'B', label: '3', arrows: 'to', font: { align: 'middle' }, id: 'EB' },
          { from: 'J', to: 'E', label: '6', arrows: 'to', font: { align: 'middle' }, id: 'JE' },
          { from: 'D', to: 'C', label: '8', arrows: 'to', font: { align: 'middle' }, id: 'DC' },
          { from: 'D', to: 'J', label: '6', arrows: 'to', font: { align: 'middle' }, id: 'DJ' },
          { from: 'H', to: 'B', label: '3', arrows: 'to', font: { align: 'middle' }, id: 'HB' },
          { from: 'I', to: 'A', label: '3', arrows: 'to', font: { align: 'middle' }, id: 'IA' }
        ]);

        // create a network
        var container = document.getElementById('mynetwork');
        var data = {
            nodes: nodes,
            edges: edges
        };
        var options = {};
        network = new vis.Network(container, data, options);
    }
}
var valuetosend;
var valueCalculate;
function DistanceRoute() {
    $(function () {
        $("#dialog-confirm-path").dialog({
            resizable: false,
            height: "auto",
            width: 400,
            modal: true,
            buttons: {
                "Exit": function () {
                    $(this).dialog("close");
                },
                "Calculate": function () {
                    

                    $.ajax({
                        type: "POST",
                        //url: '@(Url.Action("EditFromList", "Inventory"))',
                        url: "Graph/CalculatePath",
                        content: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify({ GraphNodes: nodesjson, GraphVertices: edgesjson, Path: $('#path-to-send').val() }),
                        success: function (d) {
                            valueCalculate = JSON.parse(d);
                            if (d["error"] == true) {
                                alert("Error in the path");
                            } else {
                                var path = "Distance: " + valueCalculate["distant"] +"\n";
                                $('#results').val($('#results').val() + path);
                                $("result").append("Distance: " + valueCalculate["distant"]);
                                $("#dialog-confirm-path").dialog("close");
                            }
                        },
                        error: function (xhr, textStatus, errorThrown) {
                            alert("Error sending the POST");
                        }
                    });

                    
                }
            }
        });
    });

}

function ExactStrips() {
    $(function () {
        $("#dialog-confirm-stripsexactly").dialog({
            resizable: false,
            height: "auto",
            width: 400,
            modal: true,
            buttons: {
                "Exit": function () {
                    $(this).dialog("close");
                },
                "Calculate": function () {
                    $.ajax({
                        type: "POST",
                        //url: '@(Url.Action("EditFromList", "Inventory"))',
                        url: "Graph/CalculateStripsExactly",
                        content: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify({ GraphNodes: nodesjson, GraphVertices: edgesjson, Source: $('#source-vertex-exac').val(), Target: $('#target-vertex-exac').val(), Strips: $('#number-strips-exac').val() }),
                        success: function (d) {
                            valueCalculate = JSON.parse(d);
                            if (d["error"] == true) {
                                alert("Error in the path");
                            } else {
                                var path = "Strips: " + valueCalculate["result"] + "\n";
                                $('#results').val($('#results').val() + path);
                                $("result").append("Distance: " + valueCalculate["distant"]);
                                $("#dialog-confirm-stripsexactly").dialog("close");
                            }
                        },
                        error: function (xhr, textStatus, errorThrown) {
                            alert("Error sending the POST");
                        }
                    });


                }
            }
        });
    });
}

function MinimunStrips() {
    $(function () {
        $("#dialog-confirm-stripsminimun").dialog({
            resizable: false,
            height: "auto",
            width: 400,
            modal: true,
            buttons: {
                "Exit": function () {
                    $(this).dialog("close");
                },
                "Calculate": function () {
                    $.ajax({
                        type: "POST",
                        //url: '@(Url.Action("EditFromList", "Inventory"))',
                        url: "Graph/CalculateStripsMinimun",
                        content: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify({ GraphNodes: nodesjson, GraphVertices: edgesjson, Source: $('#source-vertex-min').val(), Target: $('#target-vertex-min').val(), Strips: $('#number-strips-min').val() }),
                        success: function (d) {
                            valueCalculate = JSON.parse(d);
                            if (d["error"] == true) {
                                alert("Error in the path");
                            } else {
                                var path = "Strips: " + valueCalculate["result"] + "\n";
                                $('#results').val($('#results').val() + path);
                                $("result").append("Distance: " + valueCalculate["distant"]);
                                $("#dialog-confirm-stripsminimun").dialog("close");
                            }
                        },
                        error: function (xhr, textStatus, errorThrown) {
                            alert("Error sending the POST");
                        }
                    });


                }
            }
        });
    });
}

function ShortestRoute() {
    $(function () {
        $("#dialog-confirm-shortestroute").dialog({
            resizable: false,
            height: "auto",
            width: 400,
            modal: true,
            buttons: {
                "Exit": function () {
                    $(this).dialog("close");
                },
                "Calculate": function () {

                    $.ajax({
                        type: "POST",
                        //url: '@(Url.Action("EditFromList", "Inventory"))',
                        url: "Graph/CalculateShortestRoute",
                        content: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify({ GraphNodes: nodesjson, GraphVertices: edgesjson, Source: $('#source-vertex-shortest').val(), Target: $('#source-vertex-shortest').val() }),
                        success: function (d) {
                            valueCalculate = JSON.parse(d);
                            if (d["error"] == true) {
                                alert("Error in the path");
                            } else {
                                var path = "Distance: " + valueCalculate["distant"] + "\n";
                                $('#results').val($('#results').val() + path);
                                $("result").append("Distance: " + valueCalculate["distant"]);
                                $("#dialog-confirm-shortestroute").dialog("close");
                            }
                        },
                        error: function (xhr, textStatus, errorThrown) {
                            alert("Error sending the POST");
                        }
                    });


                }
            }
        });
    });
}

function NumberRoutes() {
    $(function () {
        $("#dialog-confirm-numberroute").dialog({
            resizable: false,
            height: "auto",
            width: 400,
            modal: true,
            buttons: {
                "Exit": function () {
                    $(this).dialog("close");
                },
                "Calculate": function () {
                  
                    $.ajax({
                        type: "POST",
                        //url: '@(Url.Action("EditFromList", "Inventory"))',
                        url: "Graph/CalculateRoutes",
                        content: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify({ GraphNodes: nodesjson, GraphVertices: edgesjson, Source: $('#source-vertex-numberroute').val(), Target: $('#source-vertex-numberroute').val() }),
                        success: function (d) {
                            valueCalculate = JSON.parse(d);
                            if (d["error"] == true) {
                                alert("Error in the path");
                            } else {
                                var path = "Distance: " + valueCalculate["distant"] + "\n";
                                $('#results').val(path + $('#results').val());
                                $("result").append("Distance: " + valueCalculate["distant"]);
                                $("#dialog-confirm-numberroute").dialog("close");
                            }
                        },
                        error: function (xhr, textStatus, errorThrown) {
                            alert("Error sending the POST");
                        }
                    });
                }
            }
        });
    });
}