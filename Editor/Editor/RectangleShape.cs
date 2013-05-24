using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Newtonsoft.Json;

namespace Editor
{
    class RectangleShape : Shape
    {
        [JsonProperty("points")]
        public Point[] EdgePoints { get; set; }

        public RectangleShape()
        {
            Type = Constants.TYPE_RECTANGLE;
            EdgePoints = new Point[Constants.RECTANGLE_EDGES];
        }
    }
}
