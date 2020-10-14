using Dapper;
using PontoID.Data.Repository.Reading.Contracts;
using PontoID.Domain.Shared.Request;
using PontoID.Domain.Shared.ViewModels;
using PontoID.Infra.Data.Context;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoID.Data.Repository.Reading.Repositories
{
    public class TurmaReadRepository : ReadRepository, ITurmaReadRepository
    {
        public TurmaReadRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<ICollection<TurmaViewModel>> Listar(TurmaRequest request)
        {
            var query = new StringBuilder();
            query.AppendLine(" SELECT \"Escola\".\"Nome\" AS \"NomeEscola\", \"Turma\".* FROM \"Turma\" ");
            query.AppendLine(" INNER JOIN \"Escola\" ON \"Escola\".\"Id\" = \"Turma\".\"EscolaId\" ");
            query.AppendLine(" LEFT JOIN \"AlunoTurma\" ON \"AlunoTurma\".\"TurmaId\" = \"Turma\".\"Id\" ");
            bool flagWhere = false;
            var parameters = new DynamicParameters();
            if (request.AlunoId.HasValue)
            {
                query.AppendLine(" WHERE \"AlunoTurma\".\"AlunoId\" = @alunoId ");
                parameters.Add("@alunoId", request.AlunoId, DbType.Guid);
                flagWhere = true;
            }
            if (request.EscolaId.HasValue)
            {
                if (flagWhere)
                    query.AppendLine(" AND \"EscolaId\" = @escolaId ");
                else query.AppendLine(" WHERE \"EscolaId\" = @escolaId ");
                parameters.Add("@escolaId", request.EscolaId, DbType.Guid);
            }
            var turmas = await this._conexao.QueryAsync<TurmaViewModel>(query.ToString(), parameters);
            return turmas?.ToList();
        }
    }
}
