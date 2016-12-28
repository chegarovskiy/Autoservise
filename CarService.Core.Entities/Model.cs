using System.ComponentModel.DataAnnotations;

namespace CarService.Core.Entities
{
    //ToDO discuss car models and brands
    public class Model : ModelName
    {
        [Required]
        public string Engine { get; set; }
        [Required]
        public string ReleaseYear { get; set; }
        [Required]
        public string BodyType { get; set; }
        [Required]
        public virtual Brand Brand { get; set; }
             
    }
}
