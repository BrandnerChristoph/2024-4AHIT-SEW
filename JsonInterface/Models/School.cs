using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JsonInterface.Models
{
    [JsonObject("attributes")]
    public class School
    {
        [JsonProperty("OBJECTID")]
        [JsonPropertyName("OBJECTID")]
        public int Id { get; set; }

        [JsonProperty("NAME")]
        [JsonPropertyName("NAME")]
        public string Name { get; set; }

    }
}
