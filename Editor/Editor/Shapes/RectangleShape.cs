﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Newtonsoft.Json;
using Editor.ShapeControls;

namespace Editor
{
    public class RectangleShape : Shape
    {
        [JsonProperty("points")]
        public Point[] EdgePoints { get; set; }

        public RectangleShape()
        {
            Control = RectangleControl.Instance;
            Type = Constants.TYPE_RECTANGLE;
            EdgePoints = new Point[Constants.RECTANGLE_EDGES];
        }

        public RectangleShape(RectangleShape shape)
        {
            Name = shape.Name;
            Control = shape.Control;
            Type = shape.Type;
            EdgePoints = new Point[Constants.RECTANGLE_EDGES];
            Array.Copy(shape.EdgePoints, EdgePoints, Constants.RECTANGLE_EDGES);
        }

        public override void Select()
        {
            Control.CurrentShape = this;
            Control.UpdateControlView();
        }
    }
}
