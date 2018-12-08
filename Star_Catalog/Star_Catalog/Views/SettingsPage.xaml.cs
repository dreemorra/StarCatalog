using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Star_Catalog.ViewModels;
using Star_Catalog.Resources;
using System.Diagnostics;

namespace Star_Catalog.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{

        public SettingsPage ()
		{
			InitializeComponent ();
            Title = Locales.Title_Settings;
            Lang_Label.Text = Locales.Settings_Lang;
            SwitchTheme.Toggled += Switcher_Toggled;

            var save = new SettingsViewModel();

            PickLang.Items.Add(Locales.Settings_LangEN);
            PickLang.Items.Add(Locales.Settings_LangRU);
            PickLang.Items.Add(Locales.Settings_LangBY);

            ApplyButton.Text = Locales.Settings_Apply;

            ApplyButton.Clicked += async (sender, e) =>
            {
                await DisplayAlert("", Locales.Settings_Restart, "OK");
               
                save.SaveSettings(PickLang.SelectedIndex);
            };
            
        }

        private void Switcher_Toggled(object sender, ToggledEventArgs e)
        {
            Debug.WriteLine("Going batman!");
            App.GoBatman();   
        }
    }
}