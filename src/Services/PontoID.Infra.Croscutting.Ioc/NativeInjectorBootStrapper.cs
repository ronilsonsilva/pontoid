using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PontoID.Application.Contracts;
using PontoID.Application.Services;
using PontoID.Data.Repository.Reading.Contracts;
using PontoID.Data.Repository.Reading.Repositories;
using PontoID.Domain.Contracts.Repositories;
using PontoID.Domain.Contracts.Services;
using PontoID.Domain.Services;
using PontoID.Infra.Data.Context;
using PontoID.Infra.Data.Repository.Repositories;

namespace PontoID.Infra.Croscutting.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            #region [Configurações]

            var connection = configuration["CONNECTION_STRING:Postgres"];
            services.AddDbContext<ApplicationContext>
                (options =>
                    options.UseNpgsql(connection)
                );
            services.AddScoped<ApplicationContext, ApplicationContext>();

            #endregion


            #region [Services Application]

            services.AddScoped<IEscolaApplication, EscolaApplication>();
            services.AddScoped<ITurmaApplication, TurmaApplication>();
            services.AddScoped<IAlunoApplication, AlunoApplication>();

            #endregion

            #region [Domain Services]

            services.AddScoped<IEscolaService, EscolaService>();
            services.AddScoped<ITurmaService, TurmaService>();
            services.AddScoped<IAlunoService, AlunoService>();

            #endregion

            #region [Persistence Repositories]
             
            services.AddScoped<IEscolaRepository, EscolaRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoTurmaRepository, AlunoTurmaRepository>();

            #endregion

            #region [Reading Repositories]

            services.AddScoped<IEscolaReadRepository, EscolaReadRepository>();
            services.AddScoped<ITurmaReadRepository, TurmaReadRepository>();
            services.AddScoped<IAlunoReadRepository, AlunoReadRepository>();

            #endregion

        }
    }
}
