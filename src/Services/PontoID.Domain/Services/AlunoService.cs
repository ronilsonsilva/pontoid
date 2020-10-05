using PontoID.Domain.Contracts.Repository;
using PontoID.Domain.Contracts.Services;
using PontoID.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PontoID.Domain.Services
{
    public class AlunoService : Service<Aluno>, IAlunoService
    {
        protected readonly IRepository<AlunoTurma> _alunoTurmaRepository;
        public AlunoService(IRepository<Aluno> repository, IRepository<AlunoTurma> alunoTurmaRepository) : base(repository)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
        }

        public async Task<Turma> AdicionarTurma(Turma turma)
        {
            var ok = await this._alunoTurmaRepository.Add(turma);
        }

        public Task<Turma> ExcluirTurma(Turma turma)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Turma>> ListarTurmas(Guid alunoId)
        {
            throw new NotImplementedException();
        }
    }
}
