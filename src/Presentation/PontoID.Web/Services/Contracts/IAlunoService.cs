using PontoID.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Web.Services.Contracts
{
    public interface IAlunoService
    {
        Task<ResponseApi<AlunoViewModel>> Adicionar(AlunoViewModel model);
        Task<ResponseApi<bool>> Delete(Guid id);
        Task<AlunoViewModel> Detalhes(Guid id);
        Task<ResponseApi<AlunoViewModel>> Editar(AlunoViewModel model);
        Task<ResponseApi<TurmaViewModel>> AdicionarTurma(AdicionarAlunoTurmaCommand command);
        Task<ResponseApi<bool>> DeleteTurma(ExcluirAlunoTurmaCommand command);
        Task<ICollection<AlunoViewModel>> Listar(AlunoRequest request);
    }
}
