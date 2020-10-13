using PontoID.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Web.Services.Contracts
{
    public interface IEscolaService
    {
        Task<ResponseApi<EscolaViewModel>> Adicionar(EscolaViewModel model);
        Task<ResponseApi<bool>> Delete(Guid id);
        Task<AlunoViewModel> Detalhes(Guid id);
        Task<ResponseApi<EscolaViewModel>> Editar(EscolaViewModel model);
        Task<ICollection<EscolaViewModel>> Listar();
    }
}
