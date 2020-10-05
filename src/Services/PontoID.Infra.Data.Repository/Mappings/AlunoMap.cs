using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoID.Domain.Entities;

namespace PontoID.Infra.Data.Repository.Mappings
{
    public class AlunoMap : BaseMap<Aluno>
    {
        public AlunoMap(string nomeTabela = "Aluno") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.Property(x => x.Cpf)
                .HasMaxLength(11)
                .IsRequired();
            
            builder.Property(x => x.Nome)
                .HasMaxLength(256)
                .IsRequired();
            
            builder.Property(x => x.DataNascimento)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
