using Microsoft.AspNetCore.Mvc;
using PontoID.Application.Contracts;
using PontoID.Domain.Shared.Command;
using PontoID.Domain.Shared.Request;
using PontoID.Domain.Shared.ViewModels;
using System.Threading.Tasks;

namespace PontoID.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class AlunoController : BaseController<AlunoViewModel>
    {
        protected readonly IAlunoApplication _alunoApplication;
        public AlunoController(IAlunoApplication application, IAlunoApplication alunoApplication) : base(application)
        {
            _alunoApplication = alunoApplication;
        }

        [HttpPost("AdicionarTurma")]
        public async Task<IActionResult> AdicionarTurma([FromBody]AdicionarAlunoTurmaCommand command)
        {
            return this.DefaultResponse(await this._alunoApplication.AdicionarTurma(command));
        }

        [HttpDelete("ExcluirTurma")]
        public async Task<IActionResult> ExcluirTurma([FromBody] ExcluirAlunoTurmaCommand command)
        {
            return this.DefaultResponse(await this._alunoApplication.DeleteTurma(command));
        }

        [HttpPost("Listar")]
        public async Task<IActionResult> Listar([FromBody] AlunoRequest request)
        {
            return this.DefaultResponse(await this._alunoApplication.Listar(request));
        }
    }
}
