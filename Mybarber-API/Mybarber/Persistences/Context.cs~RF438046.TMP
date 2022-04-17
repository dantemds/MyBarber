using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistences;

namespace Mybarber.Persistencia
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<BarbeiroImagens> BarbeiroImagens { get; set; }
        public DbSet<Barbearias> Barbearias { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Barbeiros> Barbeiros { get; set; }
        public DbSet<Agendamentos> Agendamentos { get; set; }
        public DbSet<Servicos> Servicos { get; set; }
        public DbSet<ServicosBarbeiros> ServicosBarbeiros { get; set; }
        public DbSet<ServicoImagens> ServicoImagens { get; set; }
        public DbSet<Agendas> Agendas { get; set;}
    
       
      
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ServicosBarbeirosConfiguration());
            modelBuilder.ApplyConfiguration(new BarbeirosConfiguration());
            
          





        }






    }
}
