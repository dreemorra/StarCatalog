using System;
using System.Collections.Generic;
using Star_Catalog.Resources;
using System.Text;
using System.Threading;

namespace Star_Catalog.Models
{
    public class Constellation
    {
        public string Name
        {
            get
            {
                
                if (Locales.Culture.Name == "ru-RU")
                    return nameRU;
                else if (Locales.Culture.Name == "be-BY")
                    return nameBY;
                else return nameEN;
            }
        }
        public string Description
        {
            get
            {
                if (Locales.Culture.Name == "ru-RU")
                    return descriptionRU;
                else if (Locales.Culture.Name == "be-BY")
                    return descriptionBY;
                else return descriptionEN;
            }
        }
        public int id { get; set; }
        public string nameEN { get; set; }
        public string nameRU { get; set; }
        public string nameBY { get; set; }
        public string pic { get; set; }
        public string descriptionEN { get; set; }
        public string descriptionRU { get; set; }
        public string descriptionBY { get; set; }
        public string members { get; set; }
    }
}
