using Microsoft.AspNetCore.Mvc;
using PontoID.Application.Contracts;
using PontoID.Domain.Shared.ViewModels;
using System.Collections.Generic;
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
            ICollection<EscolaViewModel> escolas = await this._escolaApplication.Listar();
            return this.DefaultResponse(escolas);
        }
    }
}
