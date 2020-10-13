using PontoID.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Web.Services.Contracts
{
    public interface ITurmaService
    {
        Task<ResponseApi<TurmaViewModel>> Adicionar(TurmaViewModel model);
        Task<ResponseApi<bool>> Delete(Guid id);
        Task<TurmaViewModel> Detalhes(Guid id);
        Task<ResponseApi<TurmaViewModel>> Editar(TurmaViewModel model);
        Task<ICollection<TurmaViewModel>> Listar(TurmaRequest request);
    }
}
