using PontoID.Domain.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Application.Contracts
{
    public interface IEscolaApplication : IApplication<EscolaViewModel>
    {
        Task<ICollection<EscolaViewModel>> Listar();
    }
}
