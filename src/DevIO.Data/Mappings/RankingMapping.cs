using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class RankingMapping : IEntityTypeConfiguration<Ranking>
    {
        public void Configure(EntityTypeBuilder<Ranking> builder)
        {
            builder.HasKey(p => p.Id);


            builder.Property(p => p.Id)
                .IsRequired();


            builder.ToTable("Rankings");
        }
    }
}