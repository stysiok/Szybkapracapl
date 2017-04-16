using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Szybkapracapl.Models;

namespace Szybkapracapl.ViewModels
{
    public class ViewOffersViewModel
    {
        public List<Offer> Offers { get; set; }

        [Required]
        public int CityId  { get; set; }

        public List<City> Cities { get; set; }
    }
}