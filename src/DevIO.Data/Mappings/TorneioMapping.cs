using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class TorneioMapping : IEntityTypeConfiguration<Torneio>
    {
        public void Configure(EntityTypeBuilder<Torneio> builder)
        {
            builder.HasKey(p => p.Id);


            builder.Property(p => p.NomeTorneio)
                .IsRequired()
                .HasColumnType("varchar(1000)");


            builder.ToTable("Torneios");
        }
    }
}