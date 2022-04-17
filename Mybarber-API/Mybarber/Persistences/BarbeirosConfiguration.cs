using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mybarber.Models;

namespace Mybarber.Persistences
{
    public class BarbeirosConfiguration : IEntityTypeConfiguration<Barbeiros>
    {
        public void Configure(EntityTypeBuilder<Barbeiros> builder)
        {
            builder.HasOne(p => p.Barbearias)
         .WithMany(b => b.Barbeiros)
         .HasForeignKey(p => p.BarbeariasId);
        }
    }
}

//Estava em context
//modelBuilder.Entity<Barbeiros>()
//         .HasOne(p => p.Barbearias)
//         .WithMany(b => b.Barbeiros)
//         .HasForeignKey(p => p.BarbeariasForeignKey);