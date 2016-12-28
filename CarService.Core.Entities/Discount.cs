using System.ComponentModel.DataAnnotations;

namespace CarService.Core.Entities
{
    public class Discount : Dictionary
    {
        [Required]
        public int Percentage { get; set; }
     }
}
