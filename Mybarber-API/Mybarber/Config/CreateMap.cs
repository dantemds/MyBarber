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
using Mybarber.DataTransferObject.Temas;
using Mybarber.DataTransferObject.Enderecos;
using Mybarber.DataTransferObject.Horario;
using Mybarber.DataTransferObject.Contatos;
using Mybarber.DataTransferObject.Banner;
using Mybarber.DataTransferObject.LadingPageImages;
using Mybarber.DataTransferObject.EventoAgendado;

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
            CreateMap<Servicos, ServicosResponseDto>().ReverseMap();
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
            CreateMap<Agendas, AgendasResponseDto>().ReverseMap();
            CreateMap<Temas, TemasResponseDto>().ReverseMap();
            CreateMap<Temas, TemasResponseDto>();
            CreateMap<Temas, TemasRequestDto>().ReverseMap();
            CreateMap<Temas, TemasRequestDto>();
            CreateMap<Enderecos, EnderecosRequestDto>().ReverseMap();
            CreateMap<Enderecos, EnderecosRequestDto>();
            CreateMap<Enderecos, EnderecosResponseDto>();
            CreateMap<Enderecos, EnderecosResponseDto>().ReverseMap();
            CreateMap<HorarioFuncionamento, HorarioFuncionamentoResponseDto>().ReverseMap();
            CreateMap<HorarioFuncionamento, HorarioFuncionamentoResponseDto>();
            CreateMap<HorarioFuncionamento, HorarioFuncionamentoRequestDto>();
            CreateMap<HorarioFuncionamento, HorarioFuncionamentoRequestDto>().ReverseMap();
            CreateMap<Contatos, ContatosRequestDto>().ReverseMap();
            CreateMap<Contatos, ContatosRequestDto>();
            CreateMap<Contatos, ContatosResponseDto>().ReverseMap();
            CreateMap<Contatos, ContatosResponseDto>();
            CreateMap<Banner, BannerResponseDto>();
            CreateMap<Banner, BannerResponseDto>().ReverseMap();
            CreateMap<LandingPageImages, LandingPageImagesResponseDto>().ReverseMap();
            CreateMap<LandingPageImages, LandingPageImagesResponseDto>();
            CreateMap<RolesUsers, UsersRolesRequestDto>();
            CreateMap<RolesUsers, UsersRolesRequestDto>().ReverseMap();
            CreateMap<RolesUsers, UsersRolesResponseDto>();
            CreateMap<RolesUsers, UsersRolesResponseDto>().ReverseMap();
            CreateMap<UsersRolesResponseDto, UsersRolesRequestDto>().ReverseMap();
            CreateMap<UsersRolesResponseDto, UsersRolesRequestDto>();
            CreateMap<Role, RolesRequestDto>().ReverseMap();
            CreateMap<Role, RolesRequestDto>();
            CreateMap<Role, RolesResponseDto>();
            CreateMap<Role, RolesResponseDto>().ReverseMap();
            CreateMap<EventoAgendado, EventoAgendadoRequestDto>().ReverseMap();
            CreateMap<EventoAgendado, EventoAgendadoRequestDto>();
            CreateMap<EventoAgendado, EventoAgendadoResponseDto>().ReverseMap();
            CreateMap<EventoAgendado, EventoAgendadoResponseDto>();
        }
    }
}
