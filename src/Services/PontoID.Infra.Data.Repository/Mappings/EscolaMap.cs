using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoID.Domain.Entities;

namespace PontoID.Infra.Data.Repository.Mappings
{
    public class EscolaMap : BaseMap<Escola>
    {
        public EscolaMap(string nomeTabela = "Escola") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<Escola> builder)
        {
            builder.Property(x => x.CodigoINEP)
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasMaxLength(256)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
