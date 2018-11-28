using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Star_Catalog.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Star_Catalog.Resources;

namespace Star_Catalog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage MainPage { get => (MainPage)Application.Current.MainPage; }
        class MenuItem
        {
            public int ID { get; set; }
            public string Title { get; set; }
            public string Icon { get; set; }
        }

        List<MenuItem> Items;

        public MenuPage()
        {
            InitializeComponent();

            Items = new List<MenuItem>
            {
                new MenuItem {ID = (int)MenuItemType.Constellations, Title = Locales.Title_Constellations, Icon = "constellations_icon.xml"},
                 new MenuItem {ID = (int)MenuItemType.Stars, Title = Locales.Title_Stars, Icon = "stars_icon.xml"},
                 new MenuItem {ID = (int)MenuItemType.Planets, Title = Locales.Title_Planets, Icon = "planets_icon.xml"},
                 new MenuItem {ID = (int)MenuItemType.DSO, Title = Locales.Title_DSO, Icon = "stars_icon.xml"},
                 new MenuItem {ID = (int)MenuItemType.Settings, Title = Locales.Title_Settings, Icon = "settings_icon.xml"},
                 new MenuItem {ID = (int)MenuItemType.About, Title = Locales.Title_About, Icon = "about_icon.xml"}
            };

            ListViewMenu.ItemsSource = Items;
            ListViewMenu.SelectedItem = Items[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                await MainPage.GoToPage(((MenuItem)((ListView)sender).SelectedItem).ID);
                
                
            };
        }
    }
}