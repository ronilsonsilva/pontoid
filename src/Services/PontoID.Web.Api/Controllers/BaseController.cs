using Microsoft.AspNetCore.Mvc;
using PontoID.Application.Contracts;
using PontoID.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoID.Web.Api.Controllers
{
    [ApiController]
    public class BaseController<EntityViewModel> : Controller where EntityViewModel : ViewModelBase
    {
        protected readonly IApplication<EntityViewModel> _application;

        public BaseController(IApplication<EntityViewModel> application)
        {
            _application = application;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] EntityViewModel viewModel)
        {
            var result = await this._application.Add(viewModel);
            return this.DefaultResponse(result);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] EntityViewModel viewModel)
        {
            var result = await this._application.Update(viewModel);
            return this.DefaultResponse(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            return this.DefaultResponse(await this._application.Get(id));
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            return this.DefaultResponse(await this._application.Delete(id));
        }

        protected IActionResult DefaultResponse(Response<object> response)
        {
            return Ok(response);
        }
        
        protected IActionResult DefaultResponse(object entity = null)
        {
            if (entity == null) return NoContent();
            return Ok(entity);
        }
        
        protected IActionResult DefaultResponse(ICollection<object> entities = null)
        {
            if (entities?.Count() == 0) return NoContent();
            return Ok(entities);
        }
    }
}
