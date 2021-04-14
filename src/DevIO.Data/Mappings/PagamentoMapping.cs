using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class PagamentoMapping : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.HasKey(p => p.Id);


            //1 : 1 => Jogador: Pagamento
            builder.HasOne(f => f.Jogador)
                .WithMany(x => x.Pagamento).HasForeignKey(x => x.JogadorId);


            builder.ToTable("Pagamentos");
        }
    }
}