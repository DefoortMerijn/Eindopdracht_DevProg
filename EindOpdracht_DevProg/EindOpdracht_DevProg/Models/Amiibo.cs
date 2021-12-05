using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EindOpdracht_DevProg.Models
{
    class Amiibo
    {
        [JsonProperty(propertyName: "tail")]
        public string Id { get; set; }
        
        public string Name { get; set; }
        public string GameSeries { get; set; }
        public string AmiiboSeries { get; set; }
        public string Image { get; set; }

    }
}
