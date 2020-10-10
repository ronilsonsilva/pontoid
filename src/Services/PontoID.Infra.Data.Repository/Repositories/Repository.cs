using Microsoft.EntityFrameworkCore;
using PontoID.Domain.Contracts.Repositories;
using PontoID.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PontoID.Infra.Data.Repository.Repositories
{
    public class Repository<Entity> : IRepository<Entity> where Entity : EntityBase
    {
        protected readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> Add(Entity entity)
        {
            this._context.Set<Entity>().Add(entity);
            return await this._context.Commit();
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var entityRemover = await this.GetEntity(id);
            if (entityRemover == null) return false;
            this._context.Set<Entity>().Remove(entityRemover);
            return await this._context.Commit();
        }

        public virtual async Task<bool> Delete(Expression<Func<Entity, bool>> expression)
        {
            var entitiesRemover = await this.GetEntities(expression);
            if (entitiesRemover?.Count() == 0) return false;
            this._context.Set<Entity>().RemoveRange(entitiesRemover);
            return await this._context.Commit();
        }

        public virtual async Task<Entity> GetEntity(Guid id)
        {
            return await this._context.Set<Entity>().FindAsync(id);
        }

        public virtual async Task<Entity> GetEntity(Expression<Func<Entity, bool>> expression)
        {
            return await this._context.Set<Entity>().FirstOrDefaultAsync(expression);
        }

        public virtual async Task<ICollection<Entity>> GetEntities()
        {
            return await this._context.Set<Entity>()
                .ToListAsync();
        }

        public virtual async Task<ICollection<Entity>> GetEntities(Expression<Func<Entity, bool>> expression)
        {
            return await this._context.Set<Entity>()
                .Where(expression)
                .ToListAsync();
        }

        public virtual async Task<bool> Update(Entity entity)
        {
            this._context.Set<Entity>().Update(entity);
            return await this._context.Commit();
        }
    }
}
