using System.Threading.Tasks;

namespace PontoID.Domain.Contracts.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
