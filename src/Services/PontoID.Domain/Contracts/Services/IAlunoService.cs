using PontoID.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Domain.Contracts.Services
{
    public interface IAlunoService : IService<Aluno>
    {
        Task<Turma> AdicionarTurma(Turma turma);
        Task<Turma> ExcluirTurma(Turma turma);
        Task<ICollection<Turma>> ListarTurmas(Guid alunoId);
    }
}
