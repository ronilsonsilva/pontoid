using AutoMapper;
using PontoID.Application.Contracts;
using PontoID.Data.Repository.Reading.Contracts;
using PontoID.Domain.Contracts.Services;
using PontoID.Domain.Entities;
using PontoID.Domain.Shared.Request;
using PontoID.Domain.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Application.Services
{
    public class TurmaApplication : BaseApplication<TurmaViewModel, Turma>, ITurmaApplication
    {
        protected readonly ITurmaReadRepository _turmaReadRepository;
        public TurmaApplication(ITurmaService service, IMapper mapper, ITurmaReadRepository turmaReadRepository) : base(service, mapper)
        {
            this._turmaReadRepository = turmaReadRepository;
        }

        public async Task<ICollection<TurmaViewModel>> Listar(TurmaRequest request)
        {
            return await this._turmaReadRepository.Listar(request);
        }
    }
}
