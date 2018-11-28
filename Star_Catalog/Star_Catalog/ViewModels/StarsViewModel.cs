using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Star_Catalog.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Xamarin.Forms.PlatformConfiguration;

namespace Star_Catalog.ViewModels
{
    class StarsViewModel
    {
        //public List<string> Items { get; set; }

        public List<Star> stars;

        public List<string> stars_string;

        private async Task LoadDB()
        {
            try
            {
                //var appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Resources), "");
                //var apppath = Path.GetDirectoryName(appdata);
                //Directory.Delete(apppath);
                //throw new Exception();
                stars = new List<Star>();
                DBManager db = new DBManager();
                //foreach (var file in Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)))
                //{
                //    System.Diagnostics.Debug.WriteLine(file);
                //    File.Delete(file);
                //}
                //if (!File.Exists(db.csvPath))
                //    db.DownloadCSV();
                //File.Copy(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Resources), "hygdata_v3.csv"), 
                //    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "hygdata_v3.csv"));
                
                await db.UpdateDatabaseFromCSV(db.csvPath);

                //File.Delete(db.csvPath);
                db.Database.QueryAsync<Star>("SELECT * FROM [Star] WHERE [ProperName] <> \"\"").Result.ForEach((obj) => { stars.Add(obj); });
                System.Diagnostics.Debug.WriteLine("Done!");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }

        }

        public StarsViewModel()
        {
            LoadDB().Wait();

            stars_string = new List<string>();
            foreach (var item in stars)
            {
                stars_string.Add(stars[item.ID].ProperName);
            }
        }
    }
}
