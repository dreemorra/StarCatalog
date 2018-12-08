using Newtonsoft.Json;
using Star_Catalog.Resources;
using System;
using System.Globalization;
using System.IO;

namespace Star_Catalog.ViewModels
{
    public class SettingsViewModel
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Settings.json");


        private class Language
        {
            public int locale { get; set; }
        }

        public void Apply(int locale)
        {
            switch(locale)
            {
                case 0:
                    {
                        Locales.Culture = new CultureInfo("en-US");
                        break;
                    }
                case 1:
                    {
                        Locales.Culture = new CultureInfo("ru-RU");
                        break;
                    }
                case 2:
                    {
                        Locales.Culture = new CultureInfo("be-BY");
                        break;
                    }
            }
        }

        public void SaveSettings(int i)
        {
            
            var index = new Language() { locale = i };
            File.WriteAllText(path, JsonConvert.SerializeObject(index));
            Apply(i);
        }

        public void LoadSettings()
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                var localeIndex = JsonConvert.DeserializeObject<Language>(json);
                Apply(localeIndex.locale);
            }
        }
    }
}
