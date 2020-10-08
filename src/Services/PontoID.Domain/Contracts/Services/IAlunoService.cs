using PontoID.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Domain.Contracts.Services
{
    public interface IAlunoService : IService<Aluno>
    {
        Task<AlunoTurma> AdicionarTurma(AlunoTurma turma);
        Task<bool> ExcluirTurma(Guid id);
        Task<ICollection<AlunoTurma>> ListarTurmas(Guid alunoId);
    }
}
