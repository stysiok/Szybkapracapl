using System.ComponentModel.DataAnnotations;

namespace Szybkapracapl.Models
{
    public class City
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}