using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mybarber.Models;
using Mybarber.Persistences;
using Npgsql;

namespace Mybarber.Persistencia
{
    public class Context : DbContext
    {
        

      
        public Context(DbContextOptions<Context> options, IConfiguration config) : base(options) { this._config = config; }
      
        
        public DbSet<Aviso> Aviso { get; set; }
        public DbSet<BarbeiroImagens> BarbeiroImagens { get; set; }
        public DbSet<Barbearias> Barbearias { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Barbeiros> Barbeiros { get; set; }
        public DbSet<Agendamentos> Agendamentos { get; set; }
        public DbSet<Servicos> Servicos { get; set; }
        public DbSet<ServicosBarbeiros> ServicosBarbeiros { get; set; }
        public DbSet<ServicoImagens> ServicoImagens { get; set; }
        public DbSet<Agendas> Agendas { get; set;}
        public DbSet<Temas> Temas { get; set; }
        public DbSet<Contatos> Contatos { get; set; }
        public DbSet<RolesUsers> RolesUsers { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Enderecos> Enderecos { get; set; }
        public DbSet<HorarioFuncionamento> HorarioFuncionamento { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<LandingPageImages> LandingPageImages { get; set; } 
        public DbSet<EventoAgendado> EventoAgendado { get; set; }

        public IConfiguration _config { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.ApplyConfiguration(new ServicosBarbeirosConfiguration());
            modelBuilder.ApplyConfiguration(new BarbeirosConfiguration());
            modelBuilder.ApplyConfiguration(new RolesUsersConfiguration());
         






        }



        public string ObterCaminhoConexaoPostGreSQL()
        {
            
            return _config.GetConnectionString("ConnectionDatabase");
        }

        public NpgsqlConnection ConexaoPostGreSQL()
        {
            NpgsqlConnection conexaoContext = new NpgsqlConnection(ObterCaminhoConexaoPostGreSQL());
            return conexaoContext;

        }

    }
}
