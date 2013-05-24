using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Editor
{
    class Shape
    {
        [JsonProperty("type")]
        public string Type { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        protected Shape()
        {
            Type = "";
            Name = "";
        }
    }
}
