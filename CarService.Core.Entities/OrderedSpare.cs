using System.ComponentModel.DataAnnotations;

namespace CarService.Core.Entities
{
    public class OrderedSpare:ModelId
    {
        [Required]
        public virtual Order Order { get; set; }

        [Required]
        public virtual Spare Spare { get; set; }

        [Required]
        public virtual User User { get; set; }

        [Required]
        public int Count { get; set; }

        public double? ExchangeRate { get; set; }

        [Required]
        public double UsedMarkup { get; set; }

        [Required]
        public double PriceForAll { get; set; }

        //[Required]
        public Currency Currency { get; set; }
    }
}