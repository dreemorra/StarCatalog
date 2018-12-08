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
        public static Dictionary<int, NavigationPage> Pages = new Dictionary<int, NavigationPage>();

        public MainPage()
        {
            Master = new MenuPage();
            Detail = new NavigationPage(new MenuPagePage());
            InitializeComponent();

        }

        public async Task GoToPage(int pageID)
        {
            if (!Pages.ContainsKey(pageID))
            {
                switch ((MenuItemType)pageID)
                {
                    case MenuItemType.About:
                        Pages.Add(pageID, new NavigationPage(new AboutPage()));
                        break;
                    case MenuItemType.Constellations:
                        Pages.Add(pageID, new NavigationPage(new ConstellationsPage()));
                        break;
                    case MenuItemType.DSO:
                        Pages.Add(pageID, new NavigationPage(new DSOPage()));
                        break;
                    case MenuItemType.Planets:
                        Pages.Add(pageID, new NavigationPage(new PlanetsPage()));
                        break;
                    case MenuItemType.Settings:
                        Pages.Add(pageID, new NavigationPage(new SettingsPage()));
                        break;
                    case MenuItemType.Stars:
                        Pages.Add(pageID, new NavigationPage(new StarsPage()));
                        break;
                }
            }

            var newPage = Pages[pageID];
            if (newPage != null && Detail != newPage)
            {
                newPage.Parent = null;
                Detail = newPage;
                await Task.Delay(200);
                IsPresented = false;
            }
        }
    }
}
