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
        IOrderedEnumerable<Star> sortedList = null;

        public StarsPage()
        {
            InitializeComponent();
            
            starsView = new StarsViewModel();
            Title = Locales.Title_Stars;

            searchbar.TextChanged += SearchBar_TextChanged;
            StarsListView.ItemsSource = starsView.stars;
            StarsListView.ItemSelected += async (s, e) => { await ConstellationsListView_ItemSelected(s, e); };
            ToolbarItems.Add(new ToolbarItem("", "sort_icon.xml", async () => { await Sort_click(); }, priority: 2));
            ToolbarItems.Add(new ToolbarItem("", "search_icon.xml", () => { ToggleSearchbar(); }, priority: 1));
            StarsListView.ItemAppearing += (sender, e) =>
            {
                //hit bottom!
                if (e.Item == starsView.stars[starsView.stars.Count - 1])
                {

                    starsView.DownloadJson(50);
                    StarsListView.RefreshCommand = new Command(() =>
                    {
                        StarsListView.ItemsSource = starsView.stars;
                        StarsListView.IsRefreshing = false;
                    });
                }
            };
        }

        private void ToggleSearchbar()
        {
            searchbar.IsVisible = !searchbar.IsVisible;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                StarsListView.ItemsSource = starsView.stars;
            else
                StarsListView.ItemsSource = starsView.stars.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));
        }

        private async Task Sort_click()
        {
            var action = await DisplayActionSheet(Locales.Title_Sort, null, null, "A-Z", "Z-A");
            switch (action)
            {
                case "A-Z":
                    {
                        sortedList = starsView.stars.OrderBy((obj) => { return obj.Name; });
                        break;
                    }
                case "Z-A":
                    {
                        sortedList = starsView.stars.OrderByDescending((obj) => { return obj.Name; });
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

        private async Task ConstellationsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            InfoPage page = new InfoPage();
            await Navigation.PushModalAsync(page);
            page.SetStarInfo((Star)e.SelectedItem);
            StarsListView.SelectedItem = null;
        }
    }
}