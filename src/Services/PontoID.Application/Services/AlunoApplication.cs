using AutoMapper;
using PontoID.Application.Contracts;
using PontoID.Data.Repository.Reading.Contracts;
using PontoID.Domain.Contracts.Services;
using PontoID.Domain.Entities;
using PontoID.Domain.Shared;
using PontoID.Domain.Shared.Command;
using PontoID.Domain.Shared.Request;
using PontoID.Domain.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Application.Services
{
    public class AlunoApplication : BaseApplication<AlunoViewModel, Aluno>, IAlunoApplication
    {
        protected readonly ITurmaApplication _turmaApplication;
        protected readonly IAlunoService _alunoService;
        protected readonly IAlunoReadRepository _alunoReadRepository;
        public AlunoApplication(IAlunoService service, IMapper mapper, ITurmaApplication turmaApplication, IAlunoReadRepository alunoReadRepository) : base(service, mapper)
        {
            this._alunoService = service;
            this._turmaApplication = turmaApplication;
            this._alunoReadRepository = alunoReadRepository;
        }

        public async Task<Response<TurmaViewModel>> AdicionarTurma(AdicionarAlunoTurmaCommand command)
        {
            var alunoTurma = new AlunoTurma(command.TurmaId, command.AlunoId);
            if (!alunoTurma.IsValid()) return new Response<TurmaViewModel>(alunoTurma.Validators);
            var retornoDominio = await this._alunoService.AdicionarTurma(alunoTurma);
            if (retornoDominio == null) return new Response<TurmaViewModel>().AddError("Não foi possível aidicionar aluno na turma");
            return new Response<TurmaViewModel>(await this._turmaApplication.Get(retornoDominio.TurmaId));
        }

        public async Task<Response<bool>> DeleteTurma(ExcluirAlunoTurmaCommand command)
        {
            return new Response<bool>(await this._alunoService.ExcluirTurma(command));
        }

        public async Task<ICollection<AlunoViewModel>> Listar(AlunoRequest request)
        {
            return await this._alunoReadRepository.Listar(request);
        }
    }
}
