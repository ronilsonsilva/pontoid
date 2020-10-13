using PontoID.Domain.Contracts.Repositories;
using PontoID.Domain.Entities;
using PontoID.Infra.Data.Context;

namespace PontoID.Infra.Data.Repository.Repositories
{
    public class EscolaRepository : Repository<Escola>, IEscolaRepository
    {
        public EscolaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
