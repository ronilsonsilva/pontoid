using PontoID.Domain.Contracts.Repositories;
using PontoID.Domain.Contracts.Services;
using PontoID.Domain.Entities;

namespace PontoID.Domain.Services
{
    public class TurmaService : Service<Turma>, ITurmaService
    {
        public TurmaService(ITurmaRepository repository) : base(repository)
        {
        }
    }
}
