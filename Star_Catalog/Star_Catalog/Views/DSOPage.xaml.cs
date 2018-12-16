using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Star_Catalog.Resources;
using Star_Catalog.ViewModels;
using Star_Catalog.Models;

namespace Star_Catalog.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DSOPage : ContentPage
	{
        DSOViewModel dsoView;
        IOrderedEnumerable<DSO> sortedList = null;

        public DSOPage()
        {
            InitializeComponent();

            dsoView = new DSOViewModel();
            Title = Locales.Title_DSO;

            searchbar.TextChanged += SearchBar_TextChanged;
            dsoListView.ItemsSource = dsoView.dso;
            dsoListView.ItemSelected += async (s, e) => { await DSOListView_ItemSelected(s, e); };
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
                dsoListView.ItemsSource = dsoView.dso;
            else
                dsoListView.ItemsSource = dsoView.dso.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));
        }

        private async Task Sort_click()
        {
            var action = await DisplayActionSheet(Locales.Title_Sort, null, null, "A-Z", "Z-A");
            switch (action)
            {
                case "A-Z":
                    {
                        sortedList = dsoView.dso.OrderBy((obj) => { return obj.Name; });
                        break;
                    }
                case "Z-A":
                    {
                        sortedList = dsoView.dso.OrderByDescending((obj) => { return obj.Name; });
                        break;
                    }
                case null:
                    {
                        return;
                    }
            }
            dsoListView.ItemsSource = sortedList;
            Debug.WriteLine("Action: " + action);
        }

        private async Task DSOListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            InfoPage page = new InfoPage();
            await Navigation.PushModalAsync(page);
            page.SetDSOInfo((DSO)e.SelectedItem);
            dsoListView.SelectedItem = null;
        }
    }
}