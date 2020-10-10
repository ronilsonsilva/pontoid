using PontoID.Domain.Entities;
using PontoID.Domain.Shared.Command;
using System.Threading.Tasks;

namespace PontoID.Domain.Contracts.Services
{
    public interface IAlunoService : IService<Aluno>
    {
        Task<AlunoTurma> AdicionarTurma(AlunoTurma turma);
        Task<bool> ExcluirTurma(ExcluirAlunoTurmaCommand command);
    }
}
