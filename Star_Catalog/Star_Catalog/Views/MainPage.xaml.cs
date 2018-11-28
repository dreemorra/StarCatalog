using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Star_Catalog.Models;
using Star_Catalog;

namespace Star_Catalog.Views
{
    public partial class MainPage : MasterDetailPage
    {
       
        public MainPage()
        {
            Master = new MenuPage();
            Detail = new NavigationPage(new MenuPagePage());
            InitializeComponent();

        }

        public async Task GoToPage(int pageID)
        {
                switch ((MenuItemType)pageID)
                {
                case MenuItemType.Constellations:
                    await Detail.Navigation.PushAsync(new ConstellationsPage());
                    break;
                case MenuItemType.Stars:
                    await Detail.Navigation.PushAsync(new StarsPage());
                    break;
                case MenuItemType.Planets:
                    await Detail.Navigation.PushAsync(new PlanetsPage());
                    break;
                case MenuItemType.DSO:
                    await Detail.Navigation.PushAsync(new DSOPage());
                    break;
                case MenuItemType.Settings:
                    await Detail.Navigation.PushAsync(new SettingsPage());
                    break;
                case MenuItemType.About:
                    await Detail.Navigation.PushAsync(new AboutPage());
                    break;
                    
                }
            if (Device.RuntimePlatform == Device.Android)
            {
                await Task.Delay(100);
            }
            IsPresented = false;
        }
    }
}
