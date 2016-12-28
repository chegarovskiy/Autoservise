using System.ComponentModel.DataAnnotations;

namespace CarService.Core.Entities
{
    /// <summary>
    /// Base class with Name property
    /// Derived from ModelId class
    /// </summary>
    public abstract class ModelName : ModelId
    {
        // Name property
        [MinLength(1, ErrorMessage = "Too short name. Must be 1-30 chars")]
        [MaxLength(30, ErrorMessage = "Too long name. Must be 1-30 chars")]
        [Required]
        public string Name { get; set; }
    }
}
