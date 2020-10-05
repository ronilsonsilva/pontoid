using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoID.Domain.Entities;

namespace PontoID.Infra.Data.Repository.Mappings
{
    public class AlunoTurmaMap : BaseMap<AlunoTurma>
    {
        public AlunoTurmaMap(string nomeTabela = "AlunoTurma") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<AlunoTurma> builder)
        {
            builder.Property(x => x.AlunoId)
                .IsRequired();
            
            builder.Property(x => x.TurmaId)
                .IsRequired();

            builder.HasOne(x => x.Aluno)
                .WithMany(x => x.Turmas)
                .HasForeignKey(x => x.AlunoId);

            builder.HasOne(x => x.Turma)
                .WithMany(x => x.Alunos)
                .HasForeignKey(x => x.TurmaId);

            base.Configure(builder);
        }
    }
}
