using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Core.Entities
{
    public class Payment:ModelId
    {

        [Required]
        public double Summ { get; set; }

        [Required]
        public virtual Order Order { get; set; }

        [Required]
        public virtual PaymentType PaymentType { get; set; }

    }
}