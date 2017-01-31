using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace AlloyUiDiagram
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Diagram(this HtmlHelper html, List<Shape> availableFields, Diagram diagram, string varName)
        {
            if (diagram == null) throw new ArgumentNullException(nameof(diagram));

            dynamic diagramData = diagram.GetDiagramDrawableData();

            var id = Guid.NewGuid();

            var containerDiv = new TagBuilder("div");
            containerDiv.Attributes.Add("id", $"diagramContainer_{id}");

            var builderDiv = new TagBuilder("div");
            builderDiv.Attributes.Add("id", $"diagramBuilder_{id}");

            containerDiv.InnerHtml = builderDiv.ToString();

            if (diagram.IsReadOnly)
                availableFields.Clear();

            var jsCode =
                $@"
            <script>
                var {varName}; 
                window.onload = function () {{ 
                YUI().use('aui-diagram-builder', function (y) {{
                {varName} = new y.DiagramBuilder(
                {{
                    availableFields: {JsonConvert.SerializeObject(availableFields)},
                    boundingBox: '#diagramContainer_{id}',
                    fields: {JsonConvert.SerializeObject(diagramData.nodes)},
                    srcNode: '#diagramBuilder_{id}',
                    render: true
                }});

                {varName}.connectAll({JsonConvert.SerializeObject(diagramData.connections)});";

            if (diagram.IsReadOnly) jsCode += $"ReadonlyDiagram({varName});";

            jsCode += @"}); 
            }
            </script>";
            
            return MvcHtmlString.Create(containerDiv + jsCode);
        }
    }
}
