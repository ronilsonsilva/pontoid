using PontoID.Domain.Contracts.Repository;
using PontoID.Domain.Contracts.Services;
using PontoID.Domain.Entities;

namespace PontoID.Domain.Services
{
    public class EscolaService : Service<Escola>, IEscolaService
    {
        public EscolaService(IRepository<Escola> repository) : base(repository)
        {
        }
    }
}
