using PontoID.Domain.Shared;
using PontoID.Domain.Shared.Command;
using PontoID.Domain.Shared.Request;
using PontoID.Domain.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Application.Contracts
{
    public interface IAlunoApplication : IApplication<AlunoViewModel>
    {
        Task<Response<TurmaViewModel>> AdicionarTurma(AdicionarAlunoTurmaCommand command);
        Task<Response<TurmaViewModel>> DeleteTurma(ExcluirAlunoTurmaCommand command);
        Task<ICollection<AlunoViewModel>> Listar(AlunoRequest request);
    }
}
