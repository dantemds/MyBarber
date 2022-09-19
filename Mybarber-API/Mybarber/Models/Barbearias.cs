using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mybarber.Models
{
    public class Barbearias
    {


       [Key()]
        public Guid IdBarbearia { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O nome deve ser informado")]
        public string NomeBarbearia { get; set; }

        [Required(ErrorMessage = "O CNPJ deve ser informado")]
        public string CNPJ { get; set; }
        public string Route { get; set; }
        public Temas Temas { get; set; }
        public Enderecos Enderecos { get; set; }
        public Contatos Contatos { get; set; }
        public bool LandingPage { get; set; }
        public bool Ativa { get; set; } = true;
        public HorarioFuncionamento HorarioFuncionamento { get; set; }
        public Banner Banner { get; set; }
        public ICollection<LandingPageImages> LandingPageImages { get; set; }
        public ICollection<Agendamentos> Agendamentos { get; set; }
        public ICollection<Servicos> Servicos { get; set; }
        public ICollection<Barbeiros> Barbeiros { get; set; }
        public  ICollection<ServicosBarbeiros> ServicosBarbeiros { get; set; }
        public  ICollection<Users> Users { get; set; }
        public Barbearias() { }





    }
}
