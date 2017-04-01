using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Szybkapracapl.Models;

namespace Szybkapracapl.ViewModels
{
    public class OfferFormViewModel
    {
        public string Name { get; set; }

        public string Date { get; set; }
        public string Time { get; set; }

        public double Sallary { get; set; }

        public string City { get; set; }
        
        public string Description { get; set; }
    }

}