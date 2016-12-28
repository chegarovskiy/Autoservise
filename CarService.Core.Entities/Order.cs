using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Core.Entities
{
    /// <summary>
    /// Class to contain
    /// all service and spare orders
    /// </summary>
    public class Order : ModelId
    {
        // Indicate date and time when client
        // got into work or bought a spare
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        // Indicate order completion date and time
        // in case it is a purchase, Start and End dates will be equal
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        // Total price of an order
        [Required]
        public double TotalPrice { get; set; }

        // Define a client whose order it is
        // make it nullable because we may sell spares for one-time customers
        public virtual Client Client { get; set; }

        // If true - order is paid, false - order is not paid
        [Required]
        [DefaultValue(false)]
        public bool IsPaid { get; set; }

        // True - order deleted
        // False - order is valid
        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        // info about ordered services and spares
        public virtual ICollection<OrderedSpare> OrderedSpares { get; set; }
        // ordered services
        public virtual ICollection<OrderedService> OrderedServices { get; set; }
        //payments by order
        public virtual ICollection<Payment> Payments { get; set; }
        // status of the order
        [Required]
        public virtual OrderStatus OrderStatus { get; set; }
    }
}