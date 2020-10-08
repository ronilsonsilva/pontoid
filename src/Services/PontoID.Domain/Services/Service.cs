using PontoID.Domain.Contracts.Repositories;
using PontoID.Domain.Contracts.Services;
using PontoID.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Domain.Services
{
    public class Service<Entity> : IService<Entity> where Entity : EntityBase
    {
        protected readonly IRepository<Entity> _repository;

        public Service(IRepository<Entity> repository)
        {
            _repository = repository;
        }

        public async Task<Entity> Add(Entity entity)
        {
            if (!entity.Validators.IsValid) return null;
            var ok = await this._repository.Add(entity);
            if (!ok) return null;
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await this._repository.Delete(id);
        }

        public async Task<Entity> GetEntity(Guid id)
        {
            return await this._repository.GetEntity(id);
        }

        public async Task<ICollection<Entity>> GetEntities()
        {
            return await this._repository.GetEntities();
        }

        public async Task<Entity> Update(Entity entity)
        {
            if (!entity.Validators.IsValid) return null;
            var ok = await this._repository.Update(entity);
            if (!ok) return null;
            return entity;
        }
    }
}
