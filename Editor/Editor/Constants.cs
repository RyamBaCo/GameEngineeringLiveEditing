using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Editor
{
    static class Constants
    {
        public const string TYPE_RECTANGLE = "rectangle";
        public const string TYPE_CIRCLE = "circle";
        public const ushort RECTANGLE_EDGES = 4;

        public const string HEADING_RECTANGLE = "Rectangle";
        public const string HEADING_CIRCLE = "Circle";

        public const string DISPLAY_MEMBER = "Name";
        public const string BINDING_TEXT = "Text";
        public const string BINDING_NAME = "Name";

        public const string ERROR_NO_SHAPE = "Selected item is not a rectangle or circle!";
        public const string ERROR_NO_CIRCLE = "Selected shape is not a circle!";
        public const string ERROR_NO_RECTANGLE = "Selected shape is not a rectangle!";
    }
}
