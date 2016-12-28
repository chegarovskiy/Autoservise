using System.Collections.Generic;

namespace CarService.Core.Entities
{
    /// <summary>
    /// All created user groups will be contained here
    /// </summary>
    public class UserGroup : Dictionary
    {
        public UserGroup()
        {
            Grants = new List<Grant>();
        }
        // connect to particular grants
        public virtual ICollection<Grant> Grants { get; set; }
    }
}