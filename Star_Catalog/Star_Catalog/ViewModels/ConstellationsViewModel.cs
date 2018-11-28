using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Star_Catalog.Models;
using Xamarin.Forms;

namespace Star_Catalog.ViewModels
{
    class ConstellationsViewModel
    {
        public List<string> Items { get; set; }

        public List<Constellation> constellations;

        public List<string> constellations_string;

        public ConstellationsViewModel()
        {
            int id = 0;

            Items = new List<string>
            {
            "Andromeda",
            "Antlia",
            "Apus",
            "Aquarius",
            "Aquila",
            "Ara",
            "Aries",
            "Auriga",
            "Boötes",
            "Caelum",
            "Camelopardalis",
            "Cancer",
            "Canes Venatici",
            "Canis Major",
            "Canis Minor",
            "Capricornus",
            "Carina",
            "Cassiopeia",
            "Centaurus",
            "Cepheus",
            "Cetus",
            "Chamaeleon",
            "Circinus",
            "Columba",
            "Coma Berenices",
            "Corona Austrina",
            "Corona Borealis",
            "Corvus",
            "Crater",
            "Crux",
            "Cygnus",
            "Delphinus",
            "Dorado",
            "Draco",
            "Equuleus",
            "Eridanus",
            "Fornax",
            "Gemini",
            "Grus",
            "Hercules",
            "Horologium",
            "Hydra",
            "Hydrus",
            "Indus",
            "Lacerta",
            "Leo",
            "Leo Minor",
            "Lepus",
            "Libra",
            "Lupus",
            "Lynx",
            "Lyra",
            "Mensa",
            "Microscopium",
            "Monoceros",
            "Musca",
            "Norma",
            "Octans",
            "Ophiuchus",
            "Orion",
            "Pavo",
            "Pegasus",
            "Perseus",
            "Phoenix",
            "Pictor",
            "Pisces",
            "Piscis Austrinus",
            "Puppis",
            "Pyxis",
            "Reticulum",
            "Sagitta",
            "Sagittarius",
            "Scorpius",
            "Sculptor",
            "Scutum",
            "Serpens",
            "Sextans",
            "Taurus",
            "Telescopium",
            "Triangulum",
            "Triangulum Australe",
            "Tucana",
            "Ursa Major",
            "Ursa Minor",
            "Vela",
            "Virgo",
            "Volans",
            "Vulpecula"
            };

            constellations = new List<Constellation>();
            foreach (var item in Items)
            {
                constellations.Add(new Constellation() { ID = id, Name = item, Description = "kek"});
                id++;
            }

            constellations_string = new List<string>();
            foreach (var item in constellations)
            {
                constellations_string.Add(constellations[item.ID].Name);
            }
        }
    }
}
