using System.Threading.Tasks;

namespace PontoID.Domain.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
