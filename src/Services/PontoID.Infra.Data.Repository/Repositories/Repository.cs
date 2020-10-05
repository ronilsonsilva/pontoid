using Microsoft.EntityFrameworkCore;
using PontoID.Domain.Contracts.Repository;
using PontoID.Domain.Entities;
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

        public async Task<bool> Add(Entity entity)
        {
            this._context.Set<Entity>().Add(entity);
            return await this._context.Commit();
        }

        public async Task<bool> Delete(Guid id)
        {
            var entityRemover = await this.GetEntity(id);
            if (entityRemover == null) return false;
            this._context.Set<Entity>().Remove(entityRemover);
            return await this._context.Commit();
        }

        public async Task<bool> Delete(Expression<Func<Entity, bool>> expression)
        {
            var entitiesRemover = await this.GetEntities(expression);
            if (entitiesRemover?.Count() == 0) return false;
            this._context.Set<Entity>().RemoveRange(entitiesRemover);
            return await this._context.Commit();
        }

        public async Task<Entity> GetEntity(Guid id)
        {
            return await this._context.Set<Entity>().FindAsync(id);
        }

        public async Task<Entity> GetEntity(Expression<Func<Entity, bool>> expression)
        {
            return await this._context.Set<Entity>().FirstOrDefaultAsync(expression);
        }

        public async Task<ICollection<Entity>> GetEntities()
        {
            return await this._context.Set<Entity>()
                .ToListAsync();
        }

        public async Task<ICollection<Entity>> GetEntities(Expression<Func<Entity, bool>> expression)
        {
            return await this._context.Set<Entity>()
                .Where(expression)
                .ToListAsync();
        }

        public async Task<bool> Update(Entity entity)
        {
            this._context.Set<Entity>().Update(entity);
            return await this._context.Commit();
        }
    }
}
