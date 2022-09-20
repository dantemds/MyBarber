using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mybarber.Models
{
    public class BarbeiroImagens
    {
        [Key()]
        public Guid IdBarbeiroImagem { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public virtual ICollection<Barbeiros> Barbeiros { get; set; }

        

        public BarbeiroImagens(){ }








    }
}
