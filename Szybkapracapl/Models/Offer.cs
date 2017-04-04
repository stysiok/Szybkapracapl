using System;
using System.ComponentModel.DataAnnotations;

namespace Szybkapracapl.Models
{
    public class Offer
    {
        public int Id { get; set; }

        public ApplicationUser Employer { get; set; }

        [Required]
        public string EmployerId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public double Sallary { get; set; }

        [Required]
        public int CityId { get; set; }

        public City City { get; set; }

        [Required]
        public string Description { get; set; }
    }
}