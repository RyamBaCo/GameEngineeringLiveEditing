using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Editor.ShapeControls;

namespace Editor
{
    public abstract class Shape
    {
        [JsonProperty("type")]
        public string Type { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonIgnoreAttribute]
        public ShapeControl Control { get; protected set; }

        protected Shape()
        {
            Type = "";
            Name = "";
        }

        public abstract void Select();
    }
}
