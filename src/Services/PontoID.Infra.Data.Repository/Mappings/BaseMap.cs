using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoID.Domain.Entities;
using System;

namespace PontoID.Infra.Data.Repository.Mappings
{
    public class BaseMap<Entity> : IEntityTypeConfiguration<Entity> where Entity : EntityBase
    {
        protected readonly string _nomeTabela;
        public BaseMap(string nomeTabela)
        {
            this._nomeTabela = nomeTabela;
        }
        public virtual void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.ToTable(this._nomeTabela);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cadastro)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.Atualizado)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);
        }
    }
}
