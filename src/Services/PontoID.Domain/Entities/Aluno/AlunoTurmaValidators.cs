using FluentValidation;
using PontoID.Domain.Shared;
using System;

namespace PontoID.Domain.Entities
{
    public class AlunoTurmaValidators : EntityValidator<AlunoTurma>
    {
        public AlunoTurmaValidators()
        {
            RuleFor(x => x.AlunoId)
                .NotNull().WithMessage("Aluno inválido")
                .NotEqual(Guid.Empty).WithMessage("Aluno inválido");
            
            
            RuleFor(x => x.TurmaId)
                .NotNull().WithMessage("Turma inválida")
                .NotEqual(Guid.Empty).WithMessage("Turma inválida");
        }
    }
}
