using Editor.ShapeControls;
using Newtonsoft.Json;

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