using PontoID.Domain.Contracts.Repositories;
using PontoID.Domain.Entities;
using PontoID.Infra.Data.Context;

namespace PontoID.Infra.Data.Repository.Repositories
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
