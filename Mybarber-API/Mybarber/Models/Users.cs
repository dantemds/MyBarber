﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mybarber.Models
{
    
    public class Users
    {
        [Key()]
        public Guid IdUser { get; set; } = Guid.NewGuid();

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [ForeignKey("Barbearias")]
        public Guid BarbeariasId { get; set; }

        public virtual Barbearias Barbearias { get; set; }
        public virtual Barbeiros Barbeiros { get; set; }

        public virtual ICollection<RolesUsers> RolesUsers { get; set; }






    }
}
