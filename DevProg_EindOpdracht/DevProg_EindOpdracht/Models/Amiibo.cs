using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevProg_EindOpdracht.Models
{
    public class Amiibo
    {
        public string Tail { get; set; }
        public string Head { get; set; }
        public string Id => $"{Head}{Tail}";
        public string Name { get; set; }
        public string GameSeries { get; set; }
        public string AmiiboSeries { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public Dictionary<string,string> Release{ get; set; }
    }
}
