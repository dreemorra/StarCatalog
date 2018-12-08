using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Star_Catalog.Models;
using Xamarin.Forms;

namespace Star_Catalog.ViewModels
{
    class ConstellationsViewModel
    {
        public List<Constellation> constellations;

        

        public void OpenCollection()
        {
            string jsonPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "constellations.json");
            var json = File.ReadAllText(jsonPath);
            var respParsed = JObject.Parse(json);
            constellations = ((JArray)respParsed["constellations"]).ToObject<List<Constellation>>();
        }

        public ConstellationsViewModel()
        {
            OpenCollection();
        }
    }
}
