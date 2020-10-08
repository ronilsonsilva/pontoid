using FluentValidation;

namespace PontoID.Domain.Shared
{
    public class EntityValidator<Entity> : AbstractValidator<Entity> where Entity : EntityBase
    {
        public EntityValidator()
        {
            
        }
    }
}
