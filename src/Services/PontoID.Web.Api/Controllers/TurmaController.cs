using Microsoft.AspNetCore.Mvc;
using PontoID.Application.Contracts;
using PontoID.Domain.Shared.Request;
using PontoID.Domain.Shared.ViewModels;
using System.Threading.Tasks;

namespace PontoID.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class TurmaController : BaseController<TurmaViewModel>
    {
        protected readonly ITurmaApplication _turmaApplication;
        public TurmaController(ITurmaApplication application) : base(application)
        {
            this._turmaApplication = application;
        }

        [HttpPost("Listar")]
        public async Task<IActionResult> Listar([FromBody]TurmaRequest request)
        {
            return this.DefaultResponse(await this._turmaApplication.Listar(request));
        }
    }
}
