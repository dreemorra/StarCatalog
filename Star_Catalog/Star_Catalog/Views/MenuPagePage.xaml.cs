using Star_Catalog.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Star_Catalog.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPagePage : ContentPage
	{
		public MenuPagePage ()
		{
			InitializeComponent ();
            Welcome_Text.Text = Locales.Welcome_Text;

        }
	}
}