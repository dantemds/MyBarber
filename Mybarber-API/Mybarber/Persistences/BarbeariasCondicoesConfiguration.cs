using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mybarber.Models;

namespace Mybarber.Persistences
{
    public class BarbeariasCondicoesConfiguration : IEntityTypeConfiguration<BarbeariasCondicoes>
    {
        public void Configure(EntityTypeBuilder<BarbeariasCondicoes> builder)
        {
            builder.HasKey(x => new { x.CondicaoId, x.BarbeariasId });
        }
    }
}

