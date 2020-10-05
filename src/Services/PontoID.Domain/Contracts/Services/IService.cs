using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Domain.Contracts.Services
{
    public interface IService<Entity>
    {
        Task<Entity> Add(Entity entity);
        Task<Entity> Update(Entity entity);
        Task<Entity> GetEntity(Guid id);
        Task<ICollection<Entity>> GetList();
        Task<bool> Delete(Guid id);
    }
}
