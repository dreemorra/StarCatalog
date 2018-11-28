using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Star_Catalog.ViewModels;
using System.Diagnostics;
using System.Linq;
using Star_Catalog.Models;
using Star_Catalog.Resources;

namespace Star_Catalog.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StarsPage : ContentPage
	{
        StarsViewModel starsView;
        IOrderedEnumerable<string> sortedList = null;

        public StarsPage()
        {
            InitializeComponent();
            
            starsView = new StarsViewModel();
            Title = Locales.Title_Stars;

            StarsListView.ItemsSource = starsView.stars_string;
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
                StarsListView.ItemsSource = starsView.stars_string;
            else
                StarsListView.ItemsSource = starsView.stars_string.Where(i => i.ToLower().Contains(e.NewTextValue.ToLower()));
        }

        private async Task Sort_click()
        {
            var action = await DisplayActionSheet(Locales.Title_Sort, null, null, "A-Z", "Z-A");
            switch (action)
            {
                case "A-Z":
                    {
                        sortedList = from element in starsView.stars_string
                                     orderby element ascending
                                     select element;
                        break;
                    }
                case "Z-A":
                    {
                        sortedList = from element in starsView.stars_string
                                     orderby element descending
                                     select element;
                        break;
                    }
                case null:
                    {
                        return;
                    }
            }
            StarsListView.ItemsSource = sortedList;
            Debug.WriteLine("Action: " + action);
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            Star clicked_item = starsView.stars.Find(item => item.ProperName.Contains(e.Item as string));

            InfoPage page = new InfoPage();
            await Navigation.PushModalAsync(page);
            page.SetStarInfo(clicked_item);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}