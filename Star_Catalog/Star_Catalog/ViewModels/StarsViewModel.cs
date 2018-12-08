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

        public void DownloadJson()
        {
            try
            {
                var responseString = client.GetStringAsync("http://fpmi-sosat.tk/stars?condition=mag%20%3C%206%20ORDER%20BY%20lum%20DESC&count=50").Result;
                var respParsed = JObject.Parse(responseString);
                stars = ((JArray) respParsed["response"]).ToObject<List<Star>>();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public StarsViewModel()
        {
            DownloadJson();
        }
    }
}
