using PontoID.Data.Repository.Reading.Contracts;
using PontoID.Domain.Shared.Request;
using PontoID.Domain.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Data.Repository.Reading.Repositories
{
    public class TurmaReadRepository : ReadRepository, ITurmaReadRepository
    {
        public Task<ICollection<TurmaViewModel>> Listar(TurmaRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
