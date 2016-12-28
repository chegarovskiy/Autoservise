using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Core.Entities
{
    public class Currency: Dictionary
    {
        // Unique currency code
        [Required]
        [Index(IsUnique = true)]
        public int Code { get; set; }

        // current currency exchange rate
        [Required]
        public double ExchangeRate { get; set; }
    }
}