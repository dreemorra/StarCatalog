using Star_Catalog.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Catalog.Models
{
    public class Planet
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
		public int? issatellite { get; set; }
        public string mass { get; set; }
        public string radius { get; set; }
        public string density { get; set; }
        public double? gravity { get; set; }
        public double? aphelion { get; set; }
        public double? perihelion { get; set; }
        public double? smaxis { get; set; }
        public double? eccentricity { get; set; }
        public double? orbitalperiod { get; set; }
        public double? synodicperiod { get; set; }
        public double? orbitalspeed { get; set; }
        public string satellites { get; set; }

    }
}
