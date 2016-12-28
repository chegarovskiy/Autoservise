using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Core.Entities
{
    public class Dictionary : ModelName
    {
        // string which optionally contains description of a service
        [MaxLength(100, ErrorMessage = "Too long description (must be less than 100 symbols)")]
        public string Description { get; set; }
        
        //show if concrete record in dictionary is used
        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}