using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Star_Catalog.Models;

namespace Star_Catalog.ViewModels
{
    class PlanetsViewModel
    {
        public List<Planet> planets;

        public void OpenCollection()
        {
            string jsonPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "planets.json");
            var json = File.ReadAllText(jsonPath);
            var respParsed = JObject.Parse(json);
            planets = ((JArray)respParsed["planets"]).ToObject<List<Planet>>();
        }

        public PlanetsViewModel()
        {
            OpenCollection();
        }
    }
}
