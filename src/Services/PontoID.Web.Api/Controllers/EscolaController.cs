using Microsoft.AspNetCore.Mvc;
using PontoID.Application.Contracts;
using PontoID.Domain.Shared.ViewModels;
using System.Threading.Tasks;

namespace PontoID.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class EscolaController : BaseController<EscolaViewModel>
    {
        protected readonly IEscolaApplication _escolaApplication;
        public EscolaController(IEscolaApplication application) : base(application)
        {
            this._escolaApplication = application;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            return this.DefaultResponse(await this._escolaApplication.Listar());
        }
    }
}
