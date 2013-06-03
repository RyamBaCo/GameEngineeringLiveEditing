using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Newtonsoft.Json;
using Editor.ShapeControls;

namespace Editor
{
    public class CircleShape : Shape
    {
        [JsonProperty("center")]
        public Point Center { get; set; }
        [JsonProperty("radius")]
        public uint Radius { get; set; }

        public CircleShape()
        {
            Control = CircleControl.Instance;
            Type = Constants.TYPE_CIRCLE;
            Radius = 1;
        }

        public CircleShape(CircleShape shape)
        {
            Name = shape.Name;
            Control = shape.Control;
            Type = shape.Type;
            Center = new Point(shape.Center.X, shape.Center.Y);
            Radius = shape.Radius;
        }

        public override void Select()
        {
            Control.CurrentShape = this;
            Control.UpdateControlView();
        }
    }
}
