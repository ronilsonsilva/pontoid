using FluentValidation.Results;
using System;

namespace PontoID.Domain.Shared
{
    public class EntityBase
    {
        public EntityBase()
        {
            var validator = new EntityValidator<EntityBase>();
            this.Validators = validator.Validate(this);
        }
        public Guid Id { get; set; }
        public DateTime Cadastro { get; set; }
        public DateTime Atualizado { get; set; }
        public ValidationResult Validators { get; set; }
    }
}
