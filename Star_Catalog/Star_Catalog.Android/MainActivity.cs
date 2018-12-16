using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using System.IO;

namespace Star_Catalog.Droid
{

    [Activity(Label = "Star_Catalog", Icon = "@mipmap/app_icon", Theme = "@style/DarkTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static int theme = 0;

        private void CopyAsset(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string jsonPath = Path.Combine(path, filename);
            using (var br = new BinaryReader(Application.Context.Assets.Open(filename)))
            {
                using (var bw = new BinaryWriter(new FileStream(jsonPath, FileMode.Create)))
                {
                    byte[] buffer = new byte[2048];
                    int length = 0;
                    while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        bw.Write(buffer, 0, length);
                    }
                }
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            CopyAsset("constellations.json");
            CopyAsset("planets.json");
            CopyAsset("dso.json");
            var app = new App();
            LoadApplication(app);

            App.BatmanMode += () =>
            {
                theme = (theme + 1) % 2;
                System.Diagnostics.Debug.WriteLine($"Gone Batman, theme is {theme}");
                if (theme == 1)
                    SetTheme(Resource.Style.LightTheme);
                if (theme == 0)
                    SetTheme(Resource.Style.DarkTheme);
            };
        }
        
    }
}