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
    public class AlunoReadRepository : ReadRepository, IAlunoReadRepository
    {
        public AlunoReadRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<ICollection<AlunoViewModel>> Listar(AlunoRequest request)
        {
            var query = new StringBuilder();
            query.AppendLine(" SELECT ");
            query.AppendLine("     \"Aluno\".\"Nome\", \"Aluno\".\"DataNascimento\", \"Aluno\".\"Cpf\" ");
            query.AppendLine(" FROM \"Aluno\" ");
            query.AppendLine(" LEFT JOIN \"AlunoTurma\" ON \"AlunoTurma\".\"AlunoId\" = \"Aluno\".\"Id\" ");
            query.AppendLine(" LEFT JOIN \"Turma\" ON \"AlunoTurma\".\"TurmaId\" = \"Turma\".\"Id\" ");
            var parameters = new DynamicParameters();
            bool flagWhere = false;
            if (request.EscolaId.HasValue)
            {
                query.AppendLine(" WHERE \"Turma\".\"EscolaId\" = @escolaId ");
                parameters.Add("@escolaId", request.EscolaId, DbType.Guid);
                flagWhere = true;
            }
            if (request.TurmaId.HasValue)
            {
                if (flagWhere)
                    query.AppendLine(" AND \"Turma\".\"EscolaId\" = @escolaId ");
                else query.AppendLine(" WHERE \"Turma\".\"EscolaId\" = @escolaId ");
                parameters.Add("@escolaId", request.TurmaId, DbType.Guid);
            }
            var alunos = await this._conexao.QueryAsync<AlunoViewModel>(query.ToString(), parameters);
            return alunos?.ToList();
        }
    }
}
