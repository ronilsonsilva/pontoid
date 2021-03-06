﻿using PontoID.Domain.Contracts.Repositories;
using PontoID.Domain.Contracts.Services;
using PontoID.Domain.Entities;

namespace PontoID.Domain.Services
{
    public class EscolaService : Service<Escola>, IEscolaService
    {
        public EscolaService(IEscolaRepository repository) : base(repository)
        {
        }
    }
}
