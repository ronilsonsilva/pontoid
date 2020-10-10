using PontoID.Domain.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Data.Repository.Reading.Contracts
{
    public interface IEscolaReadRepository : IReadRepository
    {
        Task<ICollection<EscolaViewModel>> Listar();
    }
}
