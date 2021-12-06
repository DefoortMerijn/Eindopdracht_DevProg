using DevProg_EindOpdracht.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevProg_EindOpdracht.Repositories
{
    public static class AmiiboRepository
    {
        private const string _BASEURL = "https://www.amiiboapi.com/api/amiibo/";

        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json");
            return client;
        }

        public static async Task<List<Amiibo>> GetAmiibosAsync()
        {
            using (HttpClient client = GetClient())
            {

                try
                {
                    //check url om boards op te vragen en plak key en token op einde van url
                    string url = _BASEURL + "?type=figure";

                    //api callen en het resultaat bijhouden in een variabele
                    string json = await client.GetStringAsync(url);
                    JObject obj = JObject.Parse(json);
                    JToken res = obj["amiibo"];
                    string jsonResults = res.ToString();
                    if (json != null)
                    {
                        return JsonConvert.DeserializeObject<List<Amiibo>>(jsonResults);
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}

