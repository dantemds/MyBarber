using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mybarber.Models;

namespace Mybarber.Persistences
{
    public class ServicosBarbeirosConfiguration : IEntityTypeConfiguration<ServicosBarbeiros>
    {
        public void Configure(EntityTypeBuilder<ServicosBarbeiros> builder)
        {
            builder.HasKey(x => new { x.ServicosId, x.BarbeirosId });
        }
    }
}

//Ficava no Context
//modelBuilder.Entity<ServicosBarbeiros>()
//    .HasKey(x => new { x.ServicosId, x.BarbeirosId });