using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mybarber.Models;

namespace Mybarber.Persistences
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<Users>
    {



        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("user");
            builder.HasKey(x => x.IdUser);
        }
    }

    public class ClientJuridicalMap : IEntityTypeConfiguration<Barbeiros>
    {

        public void Configure(EntityTypeBuilder<Barbeiros> builder)
        {
            builder.ToTable("barbeiro");

        }
    }
}
