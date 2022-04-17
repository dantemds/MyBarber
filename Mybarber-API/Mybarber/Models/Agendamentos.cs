using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mybarber.Models
{
    public class Agendamentos
    {

        [Key]
        public int IdAgendamento { get; set; }

        [Required(ErrorMessage = "O nome deve ser informado"), MaxLength(80, ErrorMessage = "Nome não pode exceder 80 caracteres"), MinLength(3, ErrorMessage = "Nome deve conter 3 ou mais caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O E-mail deve ser informado")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Um contato deve ser informado")]
        public string Contato { get; set; }

        [Required(ErrorMessage = "Um Horário deve ser informado")]
        public DateTime Horario { get; set; }

        [ForeignKey("Servicos")]
        public int ServicosId { get; set; }

        public virtual Servicos Servicos { get; set; }

        [ForeignKey("Barbeiros")]
        public int BarbeirosId { get; set; }

        public  virtual Barbeiros Barbeiros { get; set; }

        [ForeignKey("Barbearias")]
        public int BarbeariasId { get; set; }

        public virtual Barbearias Barbearias { get; set; }

        public Agendamentos() { }
       





    }
}
