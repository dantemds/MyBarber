using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mybarber.Helpers;
using Mybarber.Persistences;
using Mybarber.Presenter;
using Mybarber.Presenters;
using Mybarber.Presenters.Interfaces;
using Mybarber.Repositories;
using Mybarber.Repositories.Interface;
using Mybarber.Repository;
using Mybarber.Services;
using Mybarber.Services.Interfaces;
using System.Security.Cryptography;

namespace Mybarber.Config
{
    public static class Scopeds
    {
        public static void GetScoped(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IBarbeariasRepository, BarbeariasRepository>();
            services.AddScoped<IBarbeirosRepository, BarbeirosRepository>();
            services.AddScoped<IAgendamentosRepository, AgendamentosRepository>();
            services.AddScoped<IServicosRepository, ServicosRepository>();
            services.AddScoped<IServicosServices, ServicosServices>();
            services.AddScoped<IBarbeariasServices, BarbeariasServices>();
            services.AddScoped<IBarbeirosServices, BarbeirosServices>();
            services.AddScoped<IAgendamentosServices, AgendamentosServices>();
            services.AddScoped<IAgendamentosPresenter, AgendamentosPresenter>();
            services.AddScoped<IBarbeariasPresenter, BarbeariasPresenter>();
            services.AddScoped<IServicosPresenter, ServicosPresenter>();
            services.AddScoped<IBarbeirosPresenter, BarbeirosPresenter>();
            services.AddScoped<IGenerallyRepository, GenerallyRepository>();
            services.AddScoped<IServicosBarbeirosPresenter, ServicosBarbeirosPresenter>();
            services.AddScoped<IServicoImagemServices, ServicoImagemServices>();
            services.AddScoped<IServicoImagemPresenter, ServicoImagemPresenter>();
            services.AddScoped<IBarbeiroImagemServices, BarbeiroImagemServices>();
            services.AddScoped<IBarbeiroImagemPresenter, BarbeiroImagemPresenter>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IAgendasServices, AgendasServices>();
            services.AddScoped<IAgendasPresenter, AgendasPresenter>();
            services.AddScoped<IHash,Hash>();
            services.AddScoped<IBarbeiroImagemRepository, BarbeiroImagemRepository>();
            services.AddScoped<IServicoImagemRepository, ServicoImagemRepository>();
            services.AddScoped<ILandingPageServices, LandingPageServices>();
            services.AddScoped<IBannerServices, BannerServices>();
            services.AddScoped<ITemasServices, TemasServices>();
            services.AddScoped<IEnderecosServices, EnderecosServices>();
            services.AddScoped<IContatosServices, ContatosServices>();
            services.AddScoped<IHorarioFuncionamentoServices, HorarioFuncionamentoServices>();
            services.AddScoped<IEmailServices, EmailServices>();
            services.AddScoped<IServicosBarbeirosServices, ServicosBarbeirosServices>();
            services.AddScoped<IBarbeiroUsuarioServices, BarbeiroUsuarioServices>();
            services.AddScoped<IUsersServices, UsersServices>();
            services.AddScoped<IRolesUsersPresenter, RolesUsersPresenter>();
            services.AddScoped<IRolesUsersServices, RolesUsersServices>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<ILandingPageRepository, LandingPageRepository>();
            services.AddScoped<IEventosAgendadosPresenter, EventosAgendadosPresenter>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISMSService, SMSService>();
        }
    }
}
