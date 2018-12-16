using Newtonsoft.Json.Linq;
using Star_Catalog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Star_Catalog.ViewModels
{
    class DSOViewModel
    {
        public List<DSO> dso;



        public void OpenCollection()
        {
            string jsonPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "dso.json");
            var json = File.ReadAllText(jsonPath);
            var respParsed = JObject.Parse(json);
            dso = ((JArray)respParsed["dso"]).ToObject<List<DSO>>();
        }

        public DSOViewModel()
        {
            OpenCollection();
        }
    }
}
