using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Core.Entities
{
    /// <summary>
    /// Company's services will be contained here
    /// </summary>
    public class Service : Dictionary
    {
        // service price
        [Required]
        public double BasePrice { get; set; }

        // employee's percent from completing a service
        [Required]
        [DefaultValue(0)]
        public int EmployeePercent { get; set; }

        // connect to a service type
        [Required]
        public virtual ServiceType ServiceType { get; set; }
    }
}