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
        IOrderedEnumerable<Planet> sortedList = null;

        public PlanetsPage()
        {
            InitializeComponent();
            planetsView = new PlanetsViewModel();
            Title = Locales.Title_Constellations;

            searchbar.TextChanged += SearchBar_TextChanged;
            PlanetsListView.ItemsSource = planetsView.planets;
            PlanetsListView.ItemSelected += async (s, e) => { await PlanetsListView_ItemSelected(s, e); };
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
                PlanetsListView.ItemsSource = planetsView.planets;
            else
                PlanetsListView.ItemsSource = planetsView.planets.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));
        }

        private async Task Sort_click()
        {
            var action = await DisplayActionSheet(Locales.Title_Sort, null, null, "A-Z", "Z-A");
            switch (action)
            {
                case "A-Z":
                    {
                        sortedList = planetsView.planets.OrderBy((obj) => { return obj.Name; });
                        break;
                    }
                case "Z-A":
                    {
                        sortedList = planetsView.planets.OrderByDescending((obj) => { return obj.Name; });
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

        private async Task PlanetsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            InfoPage page = new InfoPage();
            await Navigation.PushModalAsync(page);
            page.SetPlanetInfo((Planet)e.SelectedItem);
            PlanetsListView.SelectedItem = null;
        }
    }
}