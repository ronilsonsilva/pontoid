using PontoID.Domain.Contracts.Repositories;
using PontoID.Domain.Entities;

namespace PontoID.Infra.Data.Repository.Repositories
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
