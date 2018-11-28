using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Star_Catalog.Resources;

namespace Star_Catalog.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DSOPage : ContentPage
	{
		public DSOPage ()
		{
			InitializeComponent ();
            Title = Locales.Title_DSO;
            ToolbarItems.Add(new ToolbarItem("", "sort_icon.xml", async () => { await Sort_click(); }, priority: 2));
            ToolbarItems.Add(new ToolbarItem("", "search_icon.xml", async () => { await Sort_click(); }, priority: 1));
        }

        private async Task Sort_click()
        {
            var action = await DisplayActionSheet(Locales.Title_Sort, null, null, "A-Z", "Z-A");
            Debug.WriteLine("Action: " + action);
        }
    }
}