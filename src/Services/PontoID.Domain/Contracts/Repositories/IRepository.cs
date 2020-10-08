using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PontoID.Domain.Contracts.Repositories
{
    public interface IRepository<Entity>
    {
        Task<bool> Add(Entity entity);
        Task<bool> Update(Entity entity);
        Task<Entity> GetEntity(Guid id);
        Task<Entity> GetEntity(Expression<Func<Entity, bool>> expression);
        Task<ICollection<Entity>> GetEntities();
        Task<ICollection<Entity>> GetEntities(Expression<Func<Entity, bool>> expression);
        Task<bool> Delete(Guid id);
        Task<bool> Delete(Expression<Func<Entity, bool>> expression);
    }
}
