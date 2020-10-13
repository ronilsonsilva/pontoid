using PontoID.Domain.Contracts.Repositories;
using PontoID.Domain.Entities;
using PontoID.Infra.Data.Context;

namespace PontoID.Infra.Data.Repository.Repositories
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
