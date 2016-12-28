using System.ComponentModel.DataAnnotations;

namespace CarService.Core.Entities
{
    /// <summary>
    /// Entity to contain
    /// ordered services by a client
    /// </summary>
    public class OrderedService : ModelId
    {
        // connect ordered service to a user's order
        [Required]
        public virtual Order Order { get; set; }

        // info about a user who is carrying out the service
        [Required]
        public virtual User User { get; set; }

        // service itself
        [Required]
        public virtual Service Service { get; set; }

        // service price for a user
        [Required]
        public double FinalPrice { get; set; }

        //ToDO think about discount field
    }
}