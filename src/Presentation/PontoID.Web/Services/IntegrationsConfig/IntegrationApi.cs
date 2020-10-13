using RestSharp;
using System;

namespace PontoID.Web.Services.IntegrationsConfig
{
    public class IntegrationApi
    {
        protected readonly RestClient _client;
        private readonly IntegrationConfig _integrationConfig;
        public IntegrationApi(IntegrationConfig integrationConfig)
        {
            _integrationConfig = integrationConfig;
            _client = new RestClient(_integrationConfig.UrlApi);
        }
    }
}
