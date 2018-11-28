using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Star_Catalog.Models;
using Star_Catalog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Star_Catalog.Resources;

namespace Star_Catalog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConstellationsPage : ContentPage
    {
        ConstellationsViewModel constellationsView;
        IOrderedEnumerable<string> sortedList = null;
        List<string> tempList;
        
        public ConstellationsPage()
        {
            InitializeComponent();
            Title = Locales.Title_Constellations;

            constellationsView = new ConstellationsViewModel();

            tempList = constellationsView.constellations_string;
            ConstellationsListView.ItemsSource = tempList;

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
                ConstellationsListView.ItemsSource = constellationsView.constellations_string;
            else
                ConstellationsListView.ItemsSource = constellationsView.constellations_string.Where(i => i.ToLower().Contains(e.NewTextValue.ToLower()));
            
        }

        private async Task Sort_click()
        {
            var action = await DisplayActionSheet(Locales.Title_Sort, null, null, "A-Z", "Z-A");
            switch (action)
            {
                case "A-Z":
                    {
                        sortedList = from element in constellationsView.constellations_string
                                     orderby element ascending
                                     select element;                        
                        break;
                    }
                case "Z-A":
                    {
                        sortedList = from element in constellationsView.constellations_string
                                     orderby element descending
                                     select element;
                        break;
                    }
                case null:
                    {
                        return;
                    }
            }
            ConstellationsListView.ItemsSource = sortedList;
            Debug.WriteLine("Action: " + action);
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
           

            Constellation clicked_item = constellationsView.constellations.Find(item => item.Name.Contains(e.Item as string));

            InfoPage page = new InfoPage();
            await Navigation.PushModalAsync(page);

            page.SetConstellationInfo(clicked_item);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
