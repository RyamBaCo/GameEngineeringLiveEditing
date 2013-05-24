using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Newtonsoft.Json;

namespace Editor
{
    class CircleShape : Shape
    {
        [JsonProperty("center")]
        public Point Center { get; set; }
        [JsonProperty("radius")]
        public uint Radius { get; set; }

        public CircleShape()
        {
            Type = Constants.TYPE_CIRCLE;
            Radius = 1;
        }
    }
}
