using System.Collections.Generic;
using Star_Catalog.Models;
using System.Net.Http;
using System;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Star_Catalog.ViewModels
{
    class StarsViewModel
    {
        public List<Star> stars;

        private static readonly HttpClient client = new HttpClient();

        public int offset = 0;

        public void DownloadJson(int add)
        {
            try
            {
                offset += add;
                var uri = $"http://fpmi-sosat.tk/stars?condition=mag%20%3C%206%20ORDER%20BY%20lum%20DESC&count=50&offset=" + $"{offset}";
                var responseString = client.GetStringAsync(uri).Result;
                var respParsed = JObject.Parse(responseString);
                var starss = ((JArray) respParsed["response"]).ToObject<List<Star>>();
                if (stars == null)
                    stars = starss;
                else stars.AddRange(starss);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public StarsViewModel()
        {
            DownloadJson(0);
        }
    }
}
