using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mybarber.Models
{
    public class Barbeiros
    {
        [Key()]
        public int IdBarbeiro { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        [Required(ErrorMessage = "O nome deve ser informado")]
        public string NameBarbeiro { get; set; }
       
        public virtual ICollection<ServicosBarbeiros> ServicosBarbeiros { get; set; }

        [ForeignKey("Barbearias")]
        public int BarbeariasId { get; set; }
        public virtual Barbearias Barbearias { get; set; }



        [ForeignKey("BarbeiroImagemId")]
        public int BarbeiroImagemId { get; set; }
        public virtual BarbeiroImagens BarbeiroImagem { get; set; }

        
        public virtual Agendas Agendas { get; set; }

        


        public Barbeiros()
        {

         
        }
        




    }
}
