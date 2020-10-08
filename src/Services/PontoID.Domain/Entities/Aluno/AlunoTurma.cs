using System;

namespace PontoID.Domain.Entities
{
    public class AlunoTurma : EntityBase
    {
        public AlunoTurma() { }

        public AlunoTurma(Guid turmaId, Guid alunoId)
        {
            TurmaId = turmaId;
            AlunoId = alunoId;
        }

        public Guid TurmaId { get; set; }
        public Guid AlunoId { get; set; }

        public Turma Turma { get; set; }
        public Aluno Aluno { get; set; }
    }
}
