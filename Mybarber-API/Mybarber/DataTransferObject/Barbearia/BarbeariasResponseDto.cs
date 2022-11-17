
using Mybarber.DataTransferObject.Agendamento;
using Mybarber.DataTransferObject.Banner;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.DataTransferObject.Contatos;
using Mybarber.DataTransferObject.Enderecos;
using Mybarber.DataTransferObject.Horario;
using Mybarber.DataTransferObject.LadingPageImages;
using Mybarber.DataTransferObject.Servico;
using Mybarber.DataTransferObject.Temas;
using Mybarber.Models;
using Mybarber.Validations;
using System;
using System.Collections.Generic;

namespace Mybarber.DataTransferObject.Barbearia
{
/// <summary>
/// Este é um Data Transfer Object (DTO)
/// </summary>
    public class BarbeariasResponseDto 
    {
        public Guid IdBarbearia { get; set; }
        public string NomeBarbearia { get; set; }
        public string Route { get;set; }
        public bool Ativa { get; set; }
        public bool FuncaoAgendamento { get; set; }
        public virtual ICollection<ServicosResponseDto> Servicos { get; set; }
        //public virtual ICollection<AgendamentosResponseDto> Agendamentos { get; set; }
        public TemasResponseDto Temas { get; set; }
        public EnderecosResponseDto Enderecos { get; set; }
        public ContatosResponseDto Contatos { get; set; }
        public HorarioFuncionamentoResponseDto HorarioFuncionamento { get; set; }
        //public virtual ICollection<BarbeirosResponseDto> Barbeiros { get; set; }
        public ICollection<BannerResponseDto> Banner { get; set; }
        public ICollection<LandingPageImagesResponseDto> LandingPageImages { get; set; }



    }
}
