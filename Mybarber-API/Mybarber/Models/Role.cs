using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mybarber.Models
{
    public class Role
    {
        [Key()]
        public Guid IdRole { get; set; }
        public string Name { get; set; }
        public int LevelRole { get; set; }
        public virtual ICollection<RolesUsers> RolesUsers { get; set; }
    }
}
