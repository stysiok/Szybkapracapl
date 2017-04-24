using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szybkapracapl.Models
{
    public class Work
    {
        public Offer Offer { get; set; }

        [Key]
        [Column(Order =  1)]
        public int OfferId { get; set; }

        public ApplicationUser Employer{ get; set; }

        [Key]
        [Column(Order = 2)]
        public string EmployerId { get; set; }

        public ApplicationUser Employee { get; set; }

        [Key]
        [Column(Order = 3)]
        public string EmployeeId { get; set; }


    }
}