using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Star_Catalog.Resources;
using Star_Catalog.Models;
using Star_Catalog.ViewModels;

namespace Star_Catalog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
            Title = Locales.Title_Info;
            Section_Characteristics.Title = Locales.Info_Characteristics;
            Section_Description.Title = Locales.Info_Description;

        }

        public void SetStarInfo(Star item)
        {
            label_description.Text = $" {Locales.Info_Name} {item.ProperName} \n HIP: {item.HIP}";
            label_characteristics.Text = 
                $"{Locales.Info_Magnitude} {item.Magnitude} \n " +
                $"{Locales.Info_Distance} {item.Distance} {Locales.Info_Parsec}\n " +
                $"{Locales.Info_Luminocity} {item.Luminocity} L\n " +
                $"{Locales.Info_Velocity} {item.RadialVelocity} {Locales.Info_VelocityDim}\n " +
                $"{Locales.Info_Spectral} {item.Spectrum} \n " +
                $"{Locales.Info_CI} {item.ColorIndex} \n " +
                $"{Locales.Info_Constellation} {item.ConstellationName}";
    }

        public void SetConstellationInfo(Constellation item)
        {
            label_description.Text = $" {Locales.Info_Name} {item.Name} \n {item.Description}";
            label_characteristics.Text = $" {Locales.Info_Stars}";
            imagee.Source = $"https://en.wikipedia.org/wiki/{item.Name}#/media/File:{item.Name}_IAU.svg";
        }

        public void SetPlanetInfo(Planet item)
        {
            label_description.Text = $" {Locales.Info_Name} {item.Name}";
            label_characteristics.Text = $" {Locales.Info_Radius} {item.Radius} {Locales.Info_Meters} \n " +
                $"{Locales.Info_Mass} {item.Mass} {Locales.Info_Weight} ";
        }
    }
}