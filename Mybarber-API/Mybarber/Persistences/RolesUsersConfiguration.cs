using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mybarber.Models;

namespace Mybarber.Persistences
{
    public class RolesUsersConfiguration : IEntityTypeConfiguration<RolesUsers>
    {
        public void Configure(EntityTypeBuilder<RolesUsers> builder)
        {
            builder.HasKey(x => new { x.RolesId, x.UsersId });
        }
    }
}

