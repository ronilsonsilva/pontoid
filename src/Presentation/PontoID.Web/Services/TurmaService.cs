using PontoID.Web.Models;
using PontoID.Web.Services.Contracts;
using PontoID.Web.Services.IntegrationsConfig;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Web.Services
{
    public class TurmaService : IntegrationApi, ITurmaService
    {
        public TurmaService(IntegrationConfig integrationConfig) : base(integrationConfig)
        {
        }

        public async Task<ResponseApi<TurmaViewModel>> Adicionar(TurmaViewModel model)
        {
            var restRequest = new RestRequest("Turma", DataFormat.Json);
            restRequest.AddJsonBody(model); 
            return await this._client.PostAsync<ResponseApi<TurmaViewModel>>(restRequest);
        }

        public async Task<ResponseApi<bool>> Delete(Guid id)
        {
            var restRequest = new RestRequest("Turma", DataFormat.Json);
            restRequest.AddUrlSegment("id", id);
            return await this._client.DeleteAsync<ResponseApi<bool>>(restRequest);
        }

        public async Task<TurmaViewModel> Detalhes(Guid id)
        {
            var restRequest = new RestRequest("Turma", DataFormat.Json);
            restRequest.AddUrlSegment("id", id);
            return await this._client.GetAsync<TurmaViewModel>(restRequest);
        }

        public async Task<ResponseApi<TurmaViewModel>> Editar(TurmaViewModel model)
        {
            var restRequest = new RestRequest("Turma", DataFormat.Json);
            restRequest.AddJsonBody(model);
            return await this._client.PutAsync<ResponseApi<TurmaViewModel>>(restRequest);
        }

        public async Task<ICollection<TurmaViewModel>> Listar(TurmaRequest request)
        {
            var restRequest = new RestRequest("Turma/Listar", DataFormat.Json);
            restRequest.AddJsonBody(request);
            return await this._client.GetAsync<List<TurmaViewModel>>(restRequest);
        }
    }
}
