using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Core.Entities
{
    public class Car : ModelId
    {
        [MaxLength(17, ErrorMessage = "VIN should consist of 17 characters only")]
        [Index(IsUnique = true)]
        [Required]
        public string Vin { get; set; }

        //ToDO make it int
        [Required]
        public string ReleaseYear { get; set; }

        [Required]
        public string NumberCar { get; set; }

        [Required]
        public virtual Model Model { get; set; }

        [Required]
        public virtual Client Client { get; set; }
    }
}
