using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AlloyUiDiagram
{
    public class Shape
    {
        [JsonProperty(PropertyName ="iconClass")]
        public string IconClass { get; set; }

        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type")]
        public FieldType Type { get; set; }


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
}
