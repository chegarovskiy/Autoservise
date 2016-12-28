using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Core.Entities
{
    public class User : ModelId
    {

        public User()
        {
            TypeOfWorks = new List<WorkType>();
        }

        [MinLength(1, ErrorMessage = "Too short name (must be 1-30)")]
        [MaxLength(30, ErrorMessage = "Too long name (must be 1-30)")]
        [Required]
        public string FirstName { get; set; }

        // user's login
        [MinLength(1, ErrorMessage = "Login should be 1 to 20 symbols")]
        [MaxLength(20, ErrorMessage = "Login should be 1 to 20 symbols")]
        [Index(IsUnique = true)]
        [Required]
        public string Login { get; set; }

        // user's password
        [MinLength(1, ErrorMessage = "Password should be 1 to 200 symbols")]
        [MaxLength(200, ErrorMessage = "Password should be 1 to 200 symbols")]
        [Required]
        public string Password { get; set; }

        //base wage rate
        [Required]
        public double BaseSalary { get; set; }

        //One employee can do several types of work
        public virtual ICollection<WorkType> TypeOfWorks { get; set; }

        // user group
        [Required]
        public virtual UserGroup UserGroup { get; set; }
    }
}