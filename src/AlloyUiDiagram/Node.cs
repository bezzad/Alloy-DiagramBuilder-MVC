using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AlloyUiDiagram
{
    [Serializable]
    public class Node
    {
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonIgnore]
        public List<Transition> Transitions { get; set; }

        [JsonIgnore]
        public string Description { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public bool Required { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public FieldType Type { get; set; }

        [JsonIgnore]
        public int Width { get; set; }

        [JsonIgnore]
        public int Height { get; set; }

        [JsonIgnore]
        public int ZIndex { get; set; }

        public List<int> XY { get { return Position?.ToList(); } set { Position = value; } }

        [JsonIgnore]
        public int X
        {
            get { return Position.X; }
            set
            {
                Position = Position ?? new Point();
                Position.X = value;
            }
        }

        [JsonIgnore]
        public int Y
        {
            get { return Position.Y; }
            set
            {
                Position = Position ?? new Point();
                Position.Y = value;
            }
        }


        [JsonIgnore]
        public Point Position { get; set; }
    }
}