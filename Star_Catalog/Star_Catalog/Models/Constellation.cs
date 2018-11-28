using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Catalog.Models
{
    public class Constellation
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<Star> Stars { get; set; }

        
        public void AddStar(Star item)
        {
            Stars.Add(item);
        }
    }
}
