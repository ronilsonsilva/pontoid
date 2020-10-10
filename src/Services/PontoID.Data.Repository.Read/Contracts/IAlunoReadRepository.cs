using PontoID.Domain.Shared.Request;
using PontoID.Domain.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Data.Repository.Reading.Contracts
{
    public interface IAlunoReadRepository : IReadRepository
    {
        Task<ICollection<AlunoViewModel>> Listar(AlunoRequest request);
    }
}
