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
}
