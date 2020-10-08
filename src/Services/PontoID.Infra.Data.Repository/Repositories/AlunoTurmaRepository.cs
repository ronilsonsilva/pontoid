using Microsoft.EntityFrameworkCore;
using PontoID.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PontoID.Infra.Data.Repository.Repositories
{
    public class AlunoTurmaRepository : Repository<AlunoTurma>
    {
        public AlunoTurmaRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<ICollection<AlunoTurma>> GetEntities()
        {
            return await this._context.Set<AlunoTurma>()
                .Include(x => x.Aluno)
                .Include(x => x.Turma)
                .ToListAsync();
        }

        public override async Task<ICollection<AlunoTurma>> GetEntities(Expression<Func<AlunoTurma, bool>> expression)
        {
            return await this._context.Set<AlunoTurma>()
                .Include(x => x.Aluno)
                .Include(x => x.Turma)
                .Where(expression)
                .ToListAsync();
        }
    }
}
