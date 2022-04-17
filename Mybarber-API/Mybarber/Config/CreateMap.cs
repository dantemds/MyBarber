using AutoMapper;
using Mybarber.DataTransferObject.Agendamento;
using Mybarber.DataTransferObject.Agenda;
using Mybarber.DataTransferObject.Barbearia;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.DataTransferObject.Images;
using Mybarber.DataTransferObject.Relacionamento;
using Mybarber.DataTransferObject.Servico;
using Mybarber.Models;
using Mybarber.DataTransferObject.Roles;

namespace Mybarber.Helpers
{
    public class CreateMap : Profile
    {
        public CreateMap()
        {
            CreateMap<Barbearias, BarbeariasResponseDto>();
            CreateMap<Barbearias, BarbeariasRequestDto>().ReverseMap();
            CreateMap<Barbearias, BarbeariasCompleteResponseDto>().ReverseMap();
            CreateMap<Servicos, ServicosCompleteResponseDto>().ReverseMap();
            CreateMap<Servicos, ServicosRequestDto>().ReverseMap();
            CreateMap<Servicos, ServicosResponseDto>();
            CreateMap<Barbeiros, BarbeirosResponseDto>();
            CreateMap<Barbeiros, BarbeirosResponseDto>().ReverseMap();
            CreateMap<Barbeiros, BarbeirosCompleteResponseDto>().ReverseMap();
            CreateMap<Barbeiros, BarbeirosRequestDto>().ReverseMap();
            CreateMap<Agendamentos, AgendamentosRequestDto>().ReverseMap();
            CreateMap<Agendamentos, AgendamentosCompleteResponseDto>().ReverseMap();
            CreateMap<Agendamentos, AgendamentosResponseDto>();
            CreateMap<ServicosBarbeiros, ServicosBarbeirosRequestDto>().ReverseMap();
            CreateMap<ServicosBarbeiros, ServicosBarbeirosResponseDto>();
            CreateMap<ServicoImagens, ServicoImagemResponseDto>();
            CreateMap<ServicoImagens, ServicoImagemRequestDto>().ReverseMap();
            CreateMap<Servicos, ServicosForAgendamentosDto>();
            CreateMap<BarbeiroImagens, BarbeiroImagemRequestDto>().ReverseMap();
            CreateMap<BarbeiroImagens, BarbeiroImagemResponseDto>().ReverseMap();
            CreateMap<Barbeiros, BarbeirosForAgendamentosDto>();
            CreateMap<Agendas, AgendasRequestDto>().ReverseMap();
            CreateMap<Agendas, AgendasResponseDto>();
          

        }
    }
}
