using Microsoft.EntityFrameworkCore;
using PontoID.Data.Repository.Reading.Contracts;
using PontoID.Infra.Data.Repository;
using System.Data;

namespace PontoID.Data.Repository.Reading.Repositories
{
    public class ReadRepository : IReadRepository
    {
        private readonly ApplicationContext _context;
        protected readonly IDbConnection _conexao;
        public ReadRepository(ApplicationContext context)
        {
            _context = context;
            this._conexao = context.Database.GetDbConnection();       
        }
    }
}
