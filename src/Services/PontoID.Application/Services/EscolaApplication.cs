using AutoMapper;
using PontoID.Application.Contracts;
using PontoID.Data.Repository.Reading.Contracts;
using PontoID.Domain.Contracts.Services;
using PontoID.Domain.Entities;
using PontoID.Domain.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Application.Services
{
    public class EscolaApplication : BaseApplication<EscolaViewModel, Escola>, IEscolaApplication
    {
        protected readonly IEscolaReadRepository _escolaReadRepository;
        public EscolaApplication(IEscolaService service, IMapper mapper, IEscolaReadRepository escolaReadRepository) : base(service, mapper)
        {
            this._escolaReadRepository = escolaReadRepository;
        }

        public async Task<ICollection<EscolaViewModel>> Listar()
        {
            return await this._escolaReadRepository.Listar();
        }
    }
}
