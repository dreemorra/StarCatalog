using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Star_Catalog.Models
{
    public class Star
    {
        [PrimaryKey, Indexed]
        public int ID { get; set; }                      //id
        public string ProperName { get; set; }           //proper
        public string HIP { get; set; }                  //hip
        public double Magnitude { get; set; }            //mag
        public double Distance { get; set; }             //dist   
        public double Luminocity { get; set; }           //lum
        public double RadialVelocity { get; set; }       //rv
        public string Spectrum { get; set; }            //spect
        public double ColorIndex { get; set; }            //ci
        public string ConstellationName { get; set; }    //con
    }
}
