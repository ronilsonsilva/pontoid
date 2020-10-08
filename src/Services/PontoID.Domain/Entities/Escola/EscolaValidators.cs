using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PontoID.Domain.Entities
{
    public class EscolaValidators : AbstractValidator<Escola>
    {
        public EscolaValidators()
        {
            RuleFor(x => x.CodigoINEP)
                .NotNull().WithMessage("Código do INEP deve ser preenchido");
        }
    }
}
