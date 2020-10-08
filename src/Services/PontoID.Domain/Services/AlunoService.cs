using PontoID.Domain.Contracts.Repositories;
using PontoID.Domain.Contracts.Services;
using PontoID.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Domain.Services
{
    public class AlunoService : Service<Aluno>, IAlunoService
    {
        protected readonly IAlunoTurmaRepository _alunoTurmaRepository;
        public AlunoService(IAlunoRepository repository, IAlunoTurmaRepository alunoTurmaRepository) : base(repository)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
        }

        public async Task<AlunoTurma> AdicionarTurma(AlunoTurma turma)
        {
            var ok = await this._alunoTurmaRepository.Add(turma);
            if(ok) return turma;
            return null;
        }

        public async Task<bool> ExcluirTurma(Guid id)
        {
            return await this._alunoTurmaRepository.Delete(id);
        }

        public async Task<ICollection<AlunoTurma>> ListarTurmas(Guid alunoId)
        {
            return await this._alunoTurmaRepository.GetEntities(x => x.AlunoId == alunoId);
        }
    }
}
