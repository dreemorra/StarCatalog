using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Star_Catalog.Resources;
using Star_Catalog.ViewModels;

namespace Star_Catalog.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutPage : ContentPage
	{
		public AboutPage ()
		{
            var vm = new AboutViewModel();
            InitializeComponent ();
            Title = Locales.Title_About;
            AboutAppText.Text = Locales.AboutApp_Text;
            About_Xamarin.Text = Locales.About_XamarinText;
            XamarinFrame.GestureRecognizers.Add(new TapGestureRecognizer((obj) => vm.OpenXamarin()));
        }
	}
}