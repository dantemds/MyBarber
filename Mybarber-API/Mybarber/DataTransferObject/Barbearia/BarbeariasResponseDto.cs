
using Mybarber.DataTransferObject.Agendamento;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.DataTransferObject.Servico;
using Mybarber.Validations;
using System.Collections.Generic;

namespace Mybarber.DataTransferObject.Barbearia
{
/// <summary>
/// Este é um Data Transfer Object (DTO)
/// </summary>
    public class BarbeariasResponseDto 
    {
        public int IdBarbearia { get; set; }
        public string NomeBarbearia { get; set; }
        public virtual ICollection<ServicosResponseDto> Servicos { get; set; }
        public virtual ICollection<AgendamentosResponseDto> Agendamentos { get; set; }
        public virtual ICollection<BarbeirosResponseDto> Barbeiros { get; set; }


        
    }
}
