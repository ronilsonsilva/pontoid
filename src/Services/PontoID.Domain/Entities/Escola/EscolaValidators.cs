using FluentValidation;

namespace PontoID.Domain.Entities
{
    public class EscolaValidators : AbstractValidator<Escola>
    {
        public EscolaValidators()
        {
            RuleFor(x => x.CodigoINEP)
                .NotNull().WithMessage("Código do INEP deve ser preenchido")
                .NotEqual(0).WithMessage("Código do INEP inválido");

            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Nome deve ser preenchido")
                .NotEmpty().WithMessage("Nome deve ser preenchido")
                .MaximumLength(256).WithMessage("Nome deve ter no máximo 256 caracteres")
                .MinimumLength(4).WithMessage("Nome deve ter no mínimo 4 caracteres");
        }
    }
}
