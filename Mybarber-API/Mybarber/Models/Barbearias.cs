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

        
        public   ICollection<Agendamentos> Agendamentos { get; set; }

        public ICollection<Servicos> Servicos { get; set; }

        public  ICollection<Barbeiros> Barbeiros { get; set; }

        public  ICollection<ServicosBarbeiros> ServicosBarbeiros { get; set; }

        public  ICollection<Users> Users { get; set; }

       

        public Barbearias() { }





    }
}
