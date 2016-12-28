using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.Core.Entities
{
    /// <summary>
    /// Grants within application
    /// </summary>
    public class Grant : Dictionary
    {
        public Grant()
        {
            UserGroups = new List<UserGroup>();
        }

        // a grant may be given to different groups of employees
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}