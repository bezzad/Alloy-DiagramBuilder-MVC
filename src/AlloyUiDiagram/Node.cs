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
        public Guid NodeId { get; set; } = Guid.NewGuid();

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

        public List<double> XY
        {
            get { return new List<double>() { X, Y }; }
            set
            {
                if (value == null) return;
                X = value[0];
                Y = value[1];
            }
        }

        [JsonIgnore]
        public double X { get; set; }

        [JsonIgnore]
        public double Y { get; set; }

    }
}