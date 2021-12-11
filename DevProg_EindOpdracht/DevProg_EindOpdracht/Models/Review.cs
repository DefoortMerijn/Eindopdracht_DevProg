using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevProg_EindOpdracht.Models
{
    public class Review
    {
        public string ReviewId{ get; set; }
        public string AmiiboId { get; set; }
        public string Name { get; set; }
        [JsonProperty("Review")]
        public string ReviewText { get; set; }
        public double Rating{ get; set; }
    }
}
