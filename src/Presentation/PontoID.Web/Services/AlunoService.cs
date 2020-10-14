using PontoID.Web.Models;
using PontoID.Web.Services.Contracts;
using PontoID.Web.Services.IntegrationsConfig;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontoID.Web.Services
{
    public class AlunoService : IntegrationApi, IAlunoService
    {
        public AlunoService(IntegrationConfig integrationConfig) : base(integrationConfig)
        {
        }

        public async Task<ResponseApi<AlunoViewModel>> Adicionar(AlunoViewModel model)
        {
            var restRequest = new RestRequest("Aluno", DataFormat.Json);
            restRequest.AddJsonBody(model);
            return await this._client.PostAsync<ResponseApi<AlunoViewModel>>(restRequest);
        }

        public async Task<ResponseApi<TurmaViewModel>> AdicionarTurma(AdicionarAlunoTurmaCommand command)
        {
            var restRequest = new RestRequest("Aluno/AdicionarTurma", DataFormat.Json);
            restRequest.AddJsonBody(command);
            return await this._client.PostAsync<ResponseApi<TurmaViewModel>>(restRequest);
        }

        public async Task<ResponseApi<bool>> Delete(Guid id)
        {
            var restRequest = new RestRequest("Aluno/{id}", DataFormat.Json);
            restRequest.AddUrlSegment("id", id);
            return await this._client.DeleteAsync<ResponseApi<bool>>(restRequest);
        }

        public async Task<ResponseApi<bool>> DeleteTurma(ExcluirAlunoTurmaCommand command)
        {
            var restRequest = new RestRequest("Aluno/ExcluirTurma", DataFormat.Json);
            restRequest.AddJsonBody(command);
            return await this._client.DeleteAsync<ResponseApi<bool>>(restRequest);
        }

        public async Task<AlunoViewModel> Detalhes(Guid id)
        {
            var restRequest = new RestRequest("Aluno/{id}", DataFormat.Json);
            restRequest.AddUrlSegment("id", id);
            return await this._client.GetAsync<AlunoViewModel>(restRequest);
        }

        public async Task<ResponseApi<AlunoViewModel>> Editar(AlunoViewModel model)
        {
            var restRequest = new RestRequest("Aluno", DataFormat.Json);
            restRequest.AddJsonBody(model);
            return await this._client.PutAsync<ResponseApi<AlunoViewModel>>(restRequest);
        }

        public async Task<ICollection<AlunoViewModel>> Listar(AlunoRequest request)
        {
            var restRequest = new RestRequest("Aluno/Listar", DataFormat.Json);
            restRequest.AddJsonBody(request);
            return await this._client.PostAsync<List<AlunoViewModel>>(restRequest);
        }
    }
}
