using DevProg_EindOpdracht.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevProg_EindOpdracht.Repositories
{
    public static class AmiiboRepository
    {
        private const string _BASEURLAMIIBO = "https://www.amiiboapi.com/api/amiibo/";
        private const string _BASEURLREVIEW = "http://192.168.0.177:5000/api/v1/amiibo/review/";


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
                    string url = _BASEURLAMIIBO + "?type=figure";

                    //api callen en het resultaat bijhouden in een variabele
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        JObject obj = JObject.Parse(json);
                        JToken res = obj["amiibo"];
                        string jsonResults = res.ToString();
                        List<Amiibo> list = JsonConvert.DeserializeObject<List<Amiibo>>(jsonResults);
                        return list;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static async Task<List<Amiibo>> GetAmiibosBySerieAsync(string Serie)
        {
            using (HttpClient client = GetClient())
            {

                try
                {
                    //check url om boards op te vragen en plak key en token op einde van url
                    string url = _BASEURLAMIIBO + "?type=figure&amiiboSeries=" + Serie;

                    //api callen en het resultaat bijhouden in een variabele
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        JObject obj = JObject.Parse(json);
                        JToken res = obj["amiibo"];
                        string jsonResults = res.ToString();
                        List<Amiibo> list = JsonConvert.DeserializeObject<List<Amiibo>>(jsonResults);
                        return list;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static async Task<List<Amiibo>> GetAmiibosByNameAsync(string Name)
        {
            using (HttpClient client = GetClient())
            {

                try
                {
                    //check url om boards op te vragen en plak key en token op einde van url
                    string url = _BASEURLAMIIBO + "?type=figure&name=" + Name;

                    //api callen en het resultaat bijhouden in een variabele
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        JObject obj = JObject.Parse(json);
                        JToken res = obj["amiibo"];
                        string jsonResults = res.ToString();
                        List<Amiibo> list = JsonConvert.DeserializeObject<List<Amiibo>>(jsonResults);
                        return list;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static async Task<List<Amiibo>> GetAmiibosByIDAsync(string Tail)
        {
            using (HttpClient client = GetClient())
            {

                try
                {
                    //check url om boards op te vragen en plak key en token op einde van url
                    string url = _BASEURLAMIIBO + "?type=figure&tail=" + Tail;

                    //api callen en het resultaat bijhouden in een variabele
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        JObject obj = JObject.Parse(json);
                        JToken res = obj["amiibo"];
                        string jsonResults = res.ToString();
                        List<Amiibo> list = JsonConvert.DeserializeObject<List<Amiibo>>(jsonResults);
                        return list;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static async Task<List<Amiibo>> GetAmiibosUsageAsync(string Tail)
        {
            using (HttpClient client = GetClient())
            {

                try
                {
                    //check url om boards op te vragen en plak key en token op einde van url
                    string url = _BASEURLAMIIBO + "?type=figure&showusage&tail=" + Tail;

                    //api callen en het resultaat bijhouden in een variabele
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        JObject obj = JObject.Parse(json);
                        JToken res = obj["amiibo"];
                        string jsonResults = res.ToString();
                        List<Amiibo> list = JsonConvert.DeserializeObject<List<Amiibo>>(jsonResults);
                        return list;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static async Task<List<Review>> GetAmiiboReviewsAsync()
        {
            using (HttpClient client = GetClient())
            {

                try
                {
                    //check url om boards op te vragen en plak key en token op einde van url
                    string url = _BASEURLREVIEW;

                    //api callen en het resultaat bijhouden in een variabele
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        JArray array = JArray.Parse(json);
                        JToken res = array;
                        string jsonResults = res.ToString();
                        List<Review> list = JsonConvert.DeserializeObject<List<Review>>(jsonResults);
                        return list;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static async Task<List<Review>> GetAmiiboReviewsByIdAsync(string Id)
        {
            using (HttpClient client = GetClient())
            {

                try
                {
                    //check url om boards op te vragen en plak key en token op einde van url
                    string url = _BASEURLREVIEW + Id;

                    //api callen en het resultaat bijhouden in een variabele
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        JArray array = JArray.Parse(json);
                        JToken res = array;
                        string jsonResults = res.ToString();
                        List<Review> list = JsonConvert.DeserializeObject<List<Review>>(jsonResults);
                        return list;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static async Task AddReviewAsync(Review newReview)
        {

            try
            {//deze methode voegt een nieuwe trellocard toe aan de list(listId als parameter)
                using (HttpClient client = GetClient())
                {
                    String url = _BASEURLREVIEW ;
                    String json = JsonConvert.SerializeObject(newReview);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);
                    if (response.IsSuccessStatusCode == false)
                    {
                        throw new Exception("It no work");

                    }
                    else
                    {
                        Debug.WriteLine("review created");
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static async Task UpdatReviewAsync(Review UpdatedReview)
        {

            try
            {
                using (HttpClient client = GetClient())
                {
                    String url = _BASEURLREVIEW + UpdatedReview.ReviewId ;
                    String json = JsonConvert.SerializeObject(UpdatedReview);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(url, content);
                    if (response.IsSuccessStatusCode == false)
                    {
                        throw new Exception("It no work");

                    }
                    else
                    {
                        Debug.WriteLine("review created");
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}

