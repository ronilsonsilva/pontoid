using PontoID.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Application.Contracts
{
    public interface IApplication<EntityViewModel>
    {
        Task<Response<EntityViewModel>> Add(EntityViewModel entityViewModel);
        Task<Response<EntityViewModel>> Update(EntityViewModel entityViewModel);
        Task<Response<bool>> Delete(Guid id);
        Task<EntityViewModel> Get(Guid id);
        Task<ICollection<EntityViewModel>> GetEntities();
    }
}
