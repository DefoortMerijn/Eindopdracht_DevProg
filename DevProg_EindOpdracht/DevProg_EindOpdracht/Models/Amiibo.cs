using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevProg_EindOpdracht.Models
{
    public class Amiibo
    {
        [JsonProperty(propertyName: "tail")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string GameSeries { get; set; }
        public string AmiiboSeries { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public Dictionary<string,string> Release{ get; set; }
    }
}
