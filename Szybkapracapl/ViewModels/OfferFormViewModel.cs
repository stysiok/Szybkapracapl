using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Szybkapracapl.Models;

namespace Szybkapracapl.ViewModels
{
    public class OfferFormViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public double Sallary { get; set; }

        [Required]
        public int City { get; set; }

        public IEnumerable<City> Cities { get; set; }
        
        [Required]
        public string Description { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time)); 
        }
    }

}