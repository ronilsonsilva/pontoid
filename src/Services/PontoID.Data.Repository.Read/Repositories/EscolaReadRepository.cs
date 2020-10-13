using Dapper;
using PontoID.Data.Repository.Reading.Contracts;
using PontoID.Domain.Shared.ViewModels;
using PontoID.Infra.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoID.Data.Repository.Reading.Repositories
{
    public class EscolaReadRepository : ReadRepository, IEscolaReadRepository
    {
        public EscolaReadRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<ICollection<EscolaViewModel>> Listar()
        {
            string query = "SELECT * FROM \"Escola\"";
            var escolas = await this._conexao.QueryAsync<EscolaViewModel>(query);
            return escolas?.ToList();
        }
    }
}
