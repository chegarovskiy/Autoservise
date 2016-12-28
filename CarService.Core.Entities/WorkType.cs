using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.Core.Entities
{
    public class WorkType : ModelId
    {

        public WorkType()
        {
            Users = new List<User>();
        }

        //unique name for unique type of work
        [MinLength(2, ErrorMessage = "Too short name (must be 2-150)")]
        [MaxLength(150, ErrorMessage = "Too long name (must be 2-150)")]
        [Required]
        public string WorkName { get; set; }

        //One type of work can do different employees
        public virtual ICollection<User> Users { get; set; }
    }
}