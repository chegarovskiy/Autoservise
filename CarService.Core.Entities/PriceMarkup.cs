using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Core.Entities
{
    public class PriceMarkup:ModelId
    {
        [Required]
        public int MarkupPercentage { get; set; }

        [Required]
        public double LowerBorder { get; set; }

        [Required]
        public double HigherBorder { get; set; }

    }
}