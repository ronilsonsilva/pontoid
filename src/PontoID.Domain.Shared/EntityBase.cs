using FluentValidation.Results;
using System;

namespace PontoID.Domain.Shared
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime Cadastro { get; set; }
        public DateTime Atualizado { get; set; }
        public ValidationResult Validators { get; set; }

        public abstract bool IsValid();
    }
}
