using AutoMapper;
using PontoID.Application.Contracts;
using PontoID.Domain.Contracts.Services;
using PontoID.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Application.Services
{
    public class BaseApplication<EntityViewModel, Entity> : IApplication<EntityViewModel> where EntityViewModel : ViewModelBase where Entity : EntityBase
    {
        protected readonly IService<Entity> _service;
        protected readonly IMapper _mapper;

        public BaseApplication(IService<Entity> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<Response<EntityViewModel>> Add(EntityViewModel entityViewModel)
        {
            var entity = this._mapper.Map<Entity>(entityViewModel);
            if (!entity.IsValid()) return new Response<EntityViewModel>(entity.Validators);
            var retornoDoinio = await this._service.Add(entity);
            if (retornoDoinio == null) return new Response<EntityViewModel>().AddError("Não foi possível salvar o registro");
            return new Response<EntityViewModel>(this._mapper.Map<EntityViewModel>(retornoDoinio));
        }

        public async Task<Response<bool>> Delete(Guid id)
        {
            var retorno = await this._service.Delete(id);
            if (!retorno) return new Response<bool>().AddError("Não foi possível excluir o registro");
            return new Response<bool>().AddMensagem("Excluído com sucesso");
        }

        public async Task<EntityViewModel> Get(Guid id)
        {
            return this._mapper.Map<EntityViewModel>(await this._service.GetEntity(id));
        }

        public async Task<Response<EntityViewModel>> Update(EntityViewModel entityViewModel)
        {
            var entity = this._mapper.Map<Entity>(entityViewModel);
            if (!entity.IsValid()) return new Response<EntityViewModel>(entity.Validators);
            var retornoDoinio = await this._service.Update(entity);
            if (retornoDoinio == null) return new Response<EntityViewModel>().AddError("Não foi possível alterar o registro");
            return new Response<EntityViewModel>(this._mapper.Map<EntityViewModel>(retornoDoinio));
        }
    }
}
