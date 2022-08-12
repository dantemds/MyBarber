﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
      
        
        public DbSet<BarbeiroImagens> BarbeiroImagens { get; set; }
        public DbSet<Barbearias> Barbearias { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Barbeiros> Barbeiros { get; set; }
        public DbSet<Agendamentos> Agendamentos { get; set; }
        public DbSet<Servicos> Servicos { get; set; }
        public DbSet<ServicosBarbeiros> ServicosBarbeiros { get; set; }
        public DbSet<ServicoImagens> ServicoImagens { get; set; }
        //public DbSet<Agendas> Agendas { get; set;}
        //public DbSet<Temas> Temas { get; set; }
        //public DbSet<Contatos> Contatos { get; set; }
        //public DbSet<Enderecos> Enderecos { get; set; }
        //public DbSet<HorarioFuncionamento> HorarioFuncionamento { get; set; }

        public IConfiguration _config { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ServicosBarbeirosConfiguration());
            modelBuilder.ApplyConfiguration(new BarbeirosConfiguration());
            
          





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
