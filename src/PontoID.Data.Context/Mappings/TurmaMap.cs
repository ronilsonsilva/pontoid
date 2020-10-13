using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoID.Domain.Entities;

namespace PontoID.Infra.Data.Context
{
    public class TurmaMap : BaseMap<Turma>
    {
        public TurmaMap(string nomeTabela = "Turma") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.Property(x => x.Descricao)
                .HasMaxLength(4096);

            builder.Property(x => x.Nome)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.Turno)
                .IsRequired();

            builder.HasOne(x => x.Escola)
                .WithMany(x => x.Turmas)
                .HasForeignKey(x => x.EscolaId);

            base.Configure(builder);
        }
    }
}
