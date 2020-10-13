using PontoID.Web.Models;
using PontoID.Web.Services.Contracts;
using PontoID.Web.Services.IntegrationsConfig;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Web.Services
{
    public class EscolaService : IntegrationApi, IEscolaService
    {
        public EscolaService(IntegrationConfig integrationConfig) : base(integrationConfig)
        {
        }

        public async Task<ResponseApi<EscolaViewModel>> Adicionar(EscolaViewModel model)
        {
            var restRequest = new RestRequest("Escola", DataFormat.Json);
            restRequest.AddJsonBody(model);
            return await this._client.PostAsync<ResponseApi<EscolaViewModel>>(restRequest);
        }

        public async Task<ResponseApi<bool>> Delete(Guid id)
        {
            var restRequest = new RestRequest("Escola", DataFormat.Json);
            restRequest.AddUrlSegment("id", id);
            return await this._client.DeleteAsync<ResponseApi<bool>>(restRequest);
        }

        public async Task<AlunoViewModel> Detalhes(Guid id)
        {
            var restRequest = new RestRequest("Escola", DataFormat.Json);
            restRequest.AddUrlSegment("id", id);
            return await this._client.GetAsync<AlunoViewModel>(restRequest);
        }

        public async Task<ResponseApi<EscolaViewModel>> Editar(EscolaViewModel model)
        {
            var restRequest = new RestRequest("Escola", DataFormat.Json);
            restRequest.AddJsonBody(model);
            return await this._client.PutAsync<ResponseApi<EscolaViewModel>>(restRequest);
        }

        public async Task<ICollection<EscolaViewModel>> Listar()
        {
            var restRequest = new RestRequest("Escola/Listar", DataFormat.Json);
            var escolas = await this._client.GetAsync<List<EscolaViewModel>>(restRequest);
            return escolas;
        }
    }
}
