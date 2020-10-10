using PontoID.Data.Repository.Reading.Contracts;
using PontoID.Domain.Shared.Request;
using PontoID.Domain.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Data.Repository.Reading.Repositories
{
    public class AlunoReadRepository : ReadRepository, IAlunoReadRepository
    {
        public Task<ICollection<AlunoViewModel>> Listar(AlunoRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
