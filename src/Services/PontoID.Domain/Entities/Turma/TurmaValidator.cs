using FluentValidation;
using PontoID.Domain.Shared;
using System;

namespace PontoID.Domain.Entities
{
    public class TurmaValidator : EntityValidator<Turma>
    {
        public TurmaValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome deve se preenchido")
                .NotNull().WithMessage("Nome deve se preenchido")
                .MaximumLength(256).WithMessage("Nome deve ter no máximo 256 caracteres")
                .MinimumLength(4).WithMessage("Nome deve ter no mínimo 4 caracteres");
            
            RuleFor(x => x.Descricao)
                .MaximumLength(4096).WithMessage("Descrição deve ter no máximo 4096 caracteres");

            RuleFor(x => x.EscolaId)
                .NotNull().WithMessage("Escola inválida")
                .NotEqual(Guid.Empty).WithMessage("Escola inválida");
            
            RuleFor(x => x.Turno)
                .NotNull().WithMessage("Turno inválido");
        }
    }
}
