using System;
using System.Collections.Generic;
using Szybkapracapl.Models;

namespace Szybkapracapl.ViewModels
{
    public class OfferFormViewModel
    {
        public string Name { get; set; }

        public string Date { get; set; }
        public string Time { get; set; }

        public double Sallary { get; set; }

        public int City { get; set; }

        public IEnumerable<City> Cities { get; set; }
        
        public string Description { get; set; }

        public DateTime DateTime
        {
            get { return DateTime.Parse(string.Format("{0} {1}", Date, Time)); }
        }
    }

}