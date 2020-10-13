namespace PontoID.Web.Services.IntegrationsConfig
{
    public class IntegrationConfig
    {
        public IntegrationConfig(string urlApi)
        {
            UrlApi = urlApi;
        }

        public string UrlApi { get; set; }
    }
}
