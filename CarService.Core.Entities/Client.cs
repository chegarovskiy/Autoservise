using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Core.Entities
{
    public class Client: ModelId
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Address { get; set; }

        public string PassportData { get; set; }

        public string Notes { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
