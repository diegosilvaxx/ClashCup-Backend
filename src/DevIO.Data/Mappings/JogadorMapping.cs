using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class JogadorMapping : IEntityTypeConfiguration<Jogador>
    {
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder.HasKey(p => p.Id);



            // 1 : 1 => Cliente : Endereco
            builder.HasMany(f => f.Pagamento)
                .WithOne(e => e.Jogador).HasForeignKey(x => x.JogadorId);

            builder.ToTable("Jogadores");
        }
    }
}