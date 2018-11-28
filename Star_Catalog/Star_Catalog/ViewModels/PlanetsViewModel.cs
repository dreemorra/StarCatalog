using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Star_Catalog.Models;

namespace Star_Catalog.ViewModels
{
    class PlanetsViewModel
    {
        public List<string> Items { get; set; }

        public List<Planet> planets;

        public List<string> planets_string;

        public PlanetsViewModel()
        {
            int id = 0;

            Items = new List<string>
            {
                "Mercury",
                "Venus",
                "Earth",
                "Mars",
                "Jupiter",
                "Nibiru",
                "Saturn",
                "Uranus",
                "Neptune",
                "Pluto",
                "Erida",
                "Vulcan",
                "Raxacoricofallapatorius",
                "Omicron Persei 8",
                "Arrakis",
                "Gallifrey",
                "Skaro",
                "Tatooine",
                "Naboo"
            };

            planets = new List<Planet>();
            foreach (var item in Items)
            {
                planets.Add(new Planet() { ID = id, Name = item, Radius = 0, Mass = 0});
                id++;
            }

            planets_string = new List<string>();
            foreach (var item in planets)
            {
                planets_string.Add(planets[item.ID].Name);
            }
        }
    }
}
