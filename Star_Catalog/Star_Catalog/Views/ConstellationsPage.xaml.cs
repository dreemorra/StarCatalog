using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Star_Catalog.Models;
using Star_Catalog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Star_Catalog.Resources;
using System.Collections.Generic;

namespace Star_Catalog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConstellationsPage : ContentPage
    {
        ConstellationsViewModel consView;
        IOrderedEnumerable<Constellation> sortedList = null;

        public ConstellationsPage()
        {
            InitializeComponent();
            consView = new ConstellationsViewModel();
            Title = Locales.Title_Constellations;

            searchbar.TextChanged += SearchBar_TextChanged;
            ConstellationsListView.ItemsSource = consView.constellations;
            ConstellationsListView.ItemSelected += async (s, e) => { await ConstellationsListView_ItemSelected(s, e); };
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
                ConstellationsListView.ItemsSource = consView.constellations;
            else
                ConstellationsListView.ItemsSource = consView.constellations.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));
        }

        private async Task Sort_click()
        {
            var action = await DisplayActionSheet(Locales.Title_Sort, null, null, "A-Z", "Z-A");
            switch (action)
            {
                case "A-Z":
                    {
                        sortedList = consView.constellations.OrderBy((obj) => { return obj.Name; });
                        break;
                    }
                case "Z-A":
                    {
                        sortedList = consView.constellations.OrderByDescending((obj) => { return obj.Name; });
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

        private async Task ConstellationsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            InfoPage page = new InfoPage();
            await Navigation.PushModalAsync(page);
            page.SetConstellationInfo((Constellation)e.SelectedItem);
            ConstellationsListView.SelectedItem = null;
        }
    }
}
