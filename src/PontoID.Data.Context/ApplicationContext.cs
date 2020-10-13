using Microsoft.EntityFrameworkCore;
using PontoID.Domain.Contracts.Repositories;
using PontoID.Infra.Data.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PontoID.Infra.Data.Repository
{
    public class ApplicationContext : DbContext, IUnitOfWork
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new EscolaMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new AlunoTurmaMap());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Cadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Cadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Cadastro").IsModified = false;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
