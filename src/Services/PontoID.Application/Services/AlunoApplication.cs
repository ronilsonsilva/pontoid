using AutoMapper;
using PontoID.Application.Contracts;
using PontoID.Domain.Contracts.Services;
using PontoID.Domain.Entities;
using PontoID.Domain.Shared;
using PontoID.Domain.Shared.Command;
using PontoID.Domain.Shared.Request;
using PontoID.Domain.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PontoID.Application.Services
{
    public class AlunoApplication : BaseApplication<AlunoViewModel, Aluno>, IAlunoApplication
    {
        public AlunoApplication(IService<Aluno> service, IMapper mapper) : base(service, mapper)
        {
        }

        public Task<Response<TurmaViewModel>> AdicionarTurma(AdicionarAlunoTurmaCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<Response<TurmaViewModel>> DeleteTurma(ExcluirAlunoTurmaCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AlunoViewModel>> Listar(AlunoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
