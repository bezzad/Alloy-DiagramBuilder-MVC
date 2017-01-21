using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AlloyUiDiagram
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    [DataContract]
    public class Node
    {
        [JsonIgnore]
        public List<Transition> Transitions { get; set; }
        
        [JsonIgnore]
        public string Description { get; set; }
        
        public string Name { get; set; }
        
        [JsonIgnore]
        public bool Required { get; set; }
        
        public FieldType NodeType { get; set; }
        
        [JsonIgnore]
        public int Width { get; set; }
        
        [JsonIgnore]
        public int Height { get; set; }
        
        [JsonIgnore]
        public int ZIndex { get; set; }
        
        public List<int> XY { get {return } set { Position = new Point(value); } }

        [JsonIgnore]
        public Point Position { get; set; }
    }

    [JsonConverter(typeof(Point))]
    public class Point : JsonConverter
    {
        #region Properties

        /// <devdoc> 
        ///    Creates a new instance of the <see cref='AlloyUiDiagram.Point'/> class 
        ///    with member data left uninitialized.
        /// </devdoc> 
        public static readonly Point Empty = new Point();

        public int X { get; set; }
        public int Y { get; set; }

        #endregion

        #region Constructors

        /// <devdoc> 
        ///    Initializes a new instance of the <see cref='AlloyUiDiagram.Point'/> class
        ///    with the [zero, zero] coordinates. 
        /// </devdoc>
        public Point()
        {
        }

        /// <devdoc> 
        ///    Initializes a new instance of the <see cref='AlloyUiDiagram.Point'/> class
        ///    with the specified coordinates. 
        /// </devdoc>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <devdoc> 
        ///    Initializes a new instance of the <see cref='AlloyUiDiagram.Point'/> class
        ///    with the specified coordinates. 
        /// </devdoc>
        public Point(IList<int> xy)
        {
            if (xy == null || xy.Count == 0)
                return;

            if (xy.Count != 2)
                throw new InvalidCastException("parameters is not correct for point[x, y]");

            X = xy[0];
            Y = xy[1];
        }

        #endregion

        #region Methods

        /// <devdoc>
        ///    <para> 
        ///       Translates a <see cref='AlloyUiDiagram.Point'/> by a given <see cref='AlloyUiDiagram.Point'/> .
        ///    </para> 
        /// </devdoc> 
        public static Point operator +(Point f, Point s)
        {
            return new Point(f.X + s.X, f.Y + f.X);
        }

        /// <devdoc> 
        ///    <para>
        ///       Translates a <see cref='AlloyUiDiagram.Point'/> by the negative of a given <see cref='AlloyUiDiagram.Point'/> . 
        ///    </para> 
        /// </devdoc>
        public static Point operator -(Point f, Point s)
        {
            return new Point(f.X - s.X, f.Y - f.X);
        }

        /// <devdoc>
        ///    <para> 
        ///       Compares two <see cref='AlloyUiDiagram.Point'/> objects. The result specifies 
        ///       whether the values of the <see cref='AlloyUiDiagram.Point.X'/> and <see cref='AlloyUiDiagram.Point.Y'/> properties of the two <see cref='AlloyUiDiagram.Point'/>
        ///       objects are equal. 
        ///    </para>
        /// </devdoc>
        public static bool operator ==(Point left, Point right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        /// <devdoc>
        ///    <para> 
        ///       Compares two <see cref='AlloyUiDiagram.Point'/> objects. The result specifies whether the values
        ///       of the <see cref='AlloyUiDiagram.Point.X'/> or <see cref='AlloyUiDiagram.Point.Y'/> properties of the two
        ///    <see cref='AlloyUiDiagram.Point'/>
        ///    objects are unequal. 
        /// </para>
        /// </devdoc> 
        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }

        /// <devdoc>
        ///    <para> 
        ///       Specifies whether this <see cref='AlloyUiDiagram.Point'/> contains 
        ///       the same coordinates as the specified <see cref='System.Object'/>.
        ///    </para> 
        /// </devdoc>
        public override bool Equals(object obj)
        {
            if (!(obj is Point)) return false;
            Point comp = (Point)obj;
            // Note value types can't have derived classes, so we don't need
            // to check the types of the objects here.  -- [....], 2/21/2001 
            return comp.X == this.X && comp.Y == this.Y;
        }

        /// <devdoc> 
        ///    <para> 
        ///       Converts this <see cref='AlloyUiDiagram.Point'/> to a human readable string.
        ///       Like: {X=123, Y=456}
        ///    </para>
        /// </devdoc>
        public override string ToString()
        {
            return "{X=" + X.ToString(CultureInfo.CurrentCulture) + ", Y=" + Y.ToString(CultureInfo.CurrentCulture) + "}";
        }

        /// <devdoc> 
        ///    <para> 
        ///       Converts this <see cref='AlloyUiDiagram.Point'/> to a JSON string.
        ///       Like: [123, 456]
        ///    </para>
        /// </devdoc>
        public string ToJson()
        {
            return "[" + X.ToString(CultureInfo.CurrentCulture) + ", " + Y.ToString(CultureInfo.CurrentCulture) + "]";
        }

        /// <devdoc>
        ///    <para>
        ///       Returns a hash code. 
        ///    </para>
        /// </devdoc> 
        public override int GetHashCode()
        {
            return X ^ Y;
        }

        #endregion

        #region Implement JsonConverter

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IList<int>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jA = JArray.Load(reader);
            return new Point(serializer.Deserialize<List<int>>(new JTokenReader(jA)));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var field = value.GetType().Name;
            writer.WriteStartObject();

            writer.WritePropertyName(field);
            writer.WriteValue((value as Point)?.ToJson());

            writer.WriteEndObject();
        }
        #endregion
    }


}