using System;

namespace Szybkapracapl.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public ApplicationUser Employer { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Sallary { get; set; }
        public string City { get; set; }
    }
}