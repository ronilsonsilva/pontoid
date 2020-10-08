using PontoID.Domain.Contracts.Repositories;
using PontoID.Domain.Entities;

namespace PontoID.Infra.Data.Repository.Repositories
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
