using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Threading.Tasks;
using Android.Content;

namespace Star_Catalog.Droid
{

    [Activity(Label = "Star_Catalog", Icon = "@mipmap/app_icon", Theme = "@style/DarkTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static int theme = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            var app = new App();
            LoadApplication(app);
            
            App.BatmanMode += () =>
            {
                theme = (theme + 1) % 2;
                System.Diagnostics.Debug.WriteLine($"Gone Batman, theme is {theme}");
                SetTheme(theme);
                Recreate();
            };
        }
    }
}