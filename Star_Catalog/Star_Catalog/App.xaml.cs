using System;
using Xamarin.Forms;
using Star_Catalog.Views;
using Xamarin.Forms.Xaml;
using Star_Catalog.ViewModels;
using Xamarin.Forms.PlatformConfiguration;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Star_Catalog
{
    public partial class App : Application
    {

        public static event Action BatmanMode;
        public static void GoBatman() => BatmanMode();
        //ConstellationsViewModel conscollection = new ConstellationsViewModel();

        public App()
        {
            var loader = new SettingsViewModel();
           
            InitializeComponent();

            //conscollection.OpenCollection();
            loader.LoadSettings();            
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
