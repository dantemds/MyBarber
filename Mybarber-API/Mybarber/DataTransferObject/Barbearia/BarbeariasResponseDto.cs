
using Mybarber.DataTransferObject.Agendamento;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.DataTransferObject.Contatos;
using Mybarber.DataTransferObject.Enderecos;
using Mybarber.DataTransferObject.Horario;
using Mybarber.DataTransferObject.Servico;
using Mybarber.DataTransferObject.Temas;
using Mybarber.Models;
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
        public TemasResponseDto Temas { get; set; }
        public EnderecosResponseDto Enderecos { get; set; }
        public ContatosResponseDto Contatos { get; set; }
        public HorarioFuncionamentoResponseDto HorarioFuncionamento { get; set; }
        //public virtual ICollection<BarbeirosResponseDto> Barbeiros { get; set; }



    }
}
