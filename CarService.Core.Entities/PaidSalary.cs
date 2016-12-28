using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Core.Entities
{
    public class PaidSalary : ModelId
    {
        //date salary paid
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime PaidDate { get; set; }

        [Required]
        public double Summ { get; set; }

        [MinLength(1, ErrorMessage = "Too short name (must be 1-100)")]
        [MaxLength(100, ErrorMessage = "Too long name (must be 1-100)")]
        public string Description { get; set; }

        public virtual User User { get; set; }
    }
}