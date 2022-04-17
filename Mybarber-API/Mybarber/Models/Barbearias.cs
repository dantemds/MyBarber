using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mybarber.Models
{
    public class Barbearias
    {


       [Key()]
        public int IdBarbearia { get; set; }

        [Required(ErrorMessage = "O nome deve ser informado")]
        public string NomeBarbearia { get; set; }

        [Required(ErrorMessage = "O CNPJ deve ser informado")]
        public string CNPJ { get; set; }

        
        public  virtual ICollection<Agendamentos> Agendamentos { get; set; }

        public virtual ICollection<Servicos> Servicos { get; set; }

        public virtual ICollection<Barbeiros> Barbeiros { get; set; }

        public virtual ICollection<ServicosBarbeiros> ServicosBarbeiros { get; set; }

        public virtual ICollection<Users> Users { get; set; }

       

        public Barbearias() { }





    }
}
