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
            label_description.Text = 
                $" {Locales.Info_Name} {item.proper} \n " +
                $"{Locales.HIP} HIP {item.hip} \n " +
                $"{Locales.BF} {item.bf} \n " +
                $"{Locales.Bayer} {item.bayer} \n " +
                $"{Locales.HD} {item.hd} \n " +
                $"{Locales.HR} HR {item.hr} \n " +
                $"{Locales.Gliese} {item.gl} \n ";
            label_characteristics.Text = 
                $" {Locales.Info_Magnitude} {item.mag} ({item.var_min} - {item.var_max}) \n " +
                $"{Locales.Info_Distance} {item.dist} {Locales.Info_Parsec}\n " +
                $"{Locales.Info_Luminocity} {item.lum} L\n " +
                $"{Locales.Info_Temperature} {item.Temperature} K\n " +
                $"{Locales.Info_Velocity} {item.rv} {Locales.Info_VelocityDim}\n " +
                $"{Locales.Info_Spectral} {item.spect} \n " +
                $"{Locales.Info_CI} {item.ci} \n " +
                $"{Locales.Info_Constellation} {item.con}";
            background.BackgroundColor = item.Color;
    }

        public void SetConstellationInfo(Constellation item)
        {
            label_description.Text = $" {Locales.Info_Name} {item.Name} \n {item.Description}";
            label_characteristics.Text = $" {Locales.Info_Stars} {item.members}";
            imagee.Source = item.pic;
        }

        public void SetPlanetInfo(Planet item)
        {
            label_description.Text = $" {Locales.Info_Name} {item.Name} \n {item.Description}";
            label_characteristics.Text = 
                $" {Locales.Info_Aphelion} {item.aphelion} {Locales.Info_AU}\n " +
                $"{Locales.Info_Perihelion} {item.perihelion} {Locales.Info_AU}\n " +
                $"{Locales.Info_SemiMajor} {item.smaxis} {Locales.Info_AU}\n " +
                $"{Locales.Info_Eccentricity} {item.eccentricity} \n " +
                $"{Locales.Info_OrbitalP} {item.orbitalperiod} {Locales.Info_Days}\n " +
                $"{Locales.Info_Synodic} {item.synodicperiod} {Locales.Info_Days}\n " +
                $"{Locales.Info_OrbitalS} {item.orbitalspeed} {Locales.Info_VelocityDim}\n " +
                $"{Locales.Info_Radius} {item.radius} {Locales.Info_RadiusEarth} \n " +
                $"{Locales.Info_Mass} {item.mass} {Locales.Info_WeightEarth} \n " +
                $"{Locales.Info_Density} {item.density} \n " +
                $"{Locales.Info_Gravity} {item.gravity} \n " +
                $"{Locales.Info_Satellites} {item.satellites}";
            imagee.Source = item.pic;
        }

        public void SetDSOInfo(DSO item)
        {
            label_description.Text = 
                $" {Locales.Info_Name} {item.Name} \n " +
                $"{Locales.Info_Designations} {item.designations}";
            label_characteristics.Text = 
                $"{Locales.Info_Type} {item.type} \n " +
                $"{Locales.Info_Constellation} {item.Constellation} \n " +
                $"{Locales.Info_Magnitude} {item.mag} \n " +
                $"{Locales.Info_Diameter} {item.size} {Locales.Info_LY}";
            imagee.Source = item.pic;
        }
    }
}