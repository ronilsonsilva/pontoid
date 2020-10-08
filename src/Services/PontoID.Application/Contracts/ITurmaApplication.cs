using PontoID.Domain.Shared.Request;
using PontoID.Domain.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Application.Contracts
{
    public interface ITurmaApplication : IApplication<TurmaViewModel>
    {
        Task<ICollection<TurmaViewModel>> Listar(TurmaRequest request);
    }
}
