using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Star_Catalog.ViewModels
{
    class AboutViewModel
    {
        public const string XamarinURL = "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/";

        public void OpenXamarin() => Device.OpenUri(new Uri(XamarinURL));
    }
}
