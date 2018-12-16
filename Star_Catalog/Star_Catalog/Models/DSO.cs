using Star_Catalog.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Catalog.Models
{
    public class DSO
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
        public string Constellation
        {
            get
            {
                if (Locales.Culture.Name == "ru-RU")
                    return ConstellationRU;
                else if (Locales.Culture.Name == "be-BY")
                    return ConstellationBY;
                else return ConstellationEN;
            }
        }

        public int id { get; set; }
        public string pic { get; set; }
        public string nameEN { get; set; }
        public string nameRU { get; set; }
        public string nameBY{ get; set; }
        public string ConstellationEN{ get; set; }
        public string ConstellationRU{ get; set; }
        public string ConstellationBY{ get; set; }
        public string type{ get; set; }
        public string designations{ get; set; }
        public string mag{ get; set; }
        public string size{ get; set; }
    }
}
