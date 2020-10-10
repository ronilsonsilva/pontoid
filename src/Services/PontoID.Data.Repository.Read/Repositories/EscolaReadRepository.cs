using PontoID.Data.Repository.Reading.Contracts;
using PontoID.Domain.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Data.Repository.Reading.Repositories
{
    public class EscolaReadRepository : ReadRepository, IEscolaReadRepository
    {
        public Task<ICollection<EscolaViewModel>> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
