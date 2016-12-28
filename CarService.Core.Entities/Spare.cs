using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Core.Entities
{
    public class Spare : Dictionary
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public double Price { get; set; }

        [Required]
        public virtual Currency Currency { get; set; }

        [Required]
        public int MarkupPercentage { get; set; }
    }
}