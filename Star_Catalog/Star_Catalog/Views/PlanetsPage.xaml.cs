using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Star_Catalog.ViewModels;
using System.Diagnostics;
using Star_Catalog.Models;
using Star_Catalog.Resources;

namespace Star_Catalog.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlanetsPage : ContentPage
	{
        PlanetsViewModel planetsView;
        IOrderedEnumerable<string> sortedList = null;

        public PlanetsPage()
        {
            InitializeComponent();
            Title = Locales.Title_Planets;
            planetsView = new PlanetsViewModel();

            PlanetsListView.ItemsSource = planetsView.planets_string;

            ToolbarItems.Add(new ToolbarItem("", "sort_icon.xml", async () => { await Sort_click(); }, priority: 2));
            ToolbarItems.Add(new ToolbarItem("", "search_icon.xml", () => { ToggleSearchbar(); }, priority: 1));
        }

        private void ToggleSearchbar()
        {
            searchbar.IsVisible = !searchbar.IsVisible;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                PlanetsListView.ItemsSource = planetsView.planets_string;
            else
                PlanetsListView.ItemsSource = planetsView.planets_string.Where(i => i.ToLower().Contains(e.NewTextValue.ToLower()));

        }

        private async Task Sort_click()
        {
            var action = await DisplayActionSheet(Locales.Title_Sort, null, null, "A-Z", "Z-A");
            switch (action)
            {
                case "A-Z":
                    {
                        sortedList = from element in planetsView.planets_string
                                     orderby element ascending
                                     select element;
                        break;
                    }
                case "Z-A":
                    {
                        sortedList = from element in planetsView.planets_string
                                     orderby element descending
                                     select element;
                        break;
                    }
                case null:
                    {
                        return;
                    }
            }
            PlanetsListView.ItemsSource = sortedList;
            Debug.WriteLine("Action: " + action);
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            Planet clicked_item = planetsView.planets.Find(item => item.Name.Contains(e.Item as string));

            InfoPage page = new InfoPage();
            await Navigation.PushModalAsync(page);
            page.SetPlanetInfo(clicked_item);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}