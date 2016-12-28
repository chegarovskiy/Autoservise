using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.Core.Entities
{
    //ToDO discuss car models and brands
    public class Brand : Dictionary
    {
        [Required]
        public virtual ICollection <Model> Models { get; set; }

        public virtual ICollection<Car> Car { get; set; }

    }
}
