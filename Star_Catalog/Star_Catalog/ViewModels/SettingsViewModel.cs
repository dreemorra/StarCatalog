using Newtonsoft.Json;
using Star_Catalog.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

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
            Locales.Culture = new CultureInfo(locale == 0 ? "en-US" : "ru-RU");
        }

        public void SaveSettings(int i)
        {
            
            var index = new Language() { locale = i };
            //File.SetAttributes(path, FileAttributes.Normal);
            File.WriteAllText(path, JsonConvert.SerializeObject(index));
            Apply(i);
        }

        public void LoadSettings()
        {
            if (File.Exists(path))
            {
                //File.SetAttributes(path, FileAttributes.Normal);
                var json = File.ReadAllText(path);
                var localeIndex = JsonConvert.DeserializeObject<Language>(json);
                Apply(localeIndex.locale);
            }
        }
    }
}
