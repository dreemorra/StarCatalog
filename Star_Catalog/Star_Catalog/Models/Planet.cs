using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Catalog.Models
{
    public class Planet
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; }
        public float Radius { get; set; }
        public float Mass { get; set; }
    }
}
