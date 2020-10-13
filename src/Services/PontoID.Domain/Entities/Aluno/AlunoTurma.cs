using PontoID.Domain.Shared;
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

        public override bool IsValid()
        {
            var validator = new AlunoTurmaValidators();
            this.Validators = validator.Validate(this);
            return this.Validators.IsValid;
        }
    }
}
