using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mybarber.Models
{
    public class Barbeiros
    {
        [Key()]
        public Guid IdBarbeiro { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public string Password { get; set; }


        [Required(ErrorMessage = "O nome deve ser informado")]
        public string NameBarbeiro { get; set; }
       
        public virtual ICollection<ServicosBarbeiros> ServicosBarbeiros { get; set; }

        [ForeignKey("Barbearias")]
        public Guid BarbeariasId { get; set; }

        public virtual Barbearias Barbearias { get; set; }



        [ForeignKey("BarbeiroImagemId")]
        public Guid BarbeiroImagemId { get; set; }
        public virtual BarbeiroImagens BarbeiroImagem { get; set; }

        
        public virtual Agendas Agendas { get; set; }

        


        public Barbeiros()
        {

         
        }
        




    }
}
