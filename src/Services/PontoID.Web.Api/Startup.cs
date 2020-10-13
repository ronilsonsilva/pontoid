using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PontoID.Application.AutoMapper;
using PontoID.Infra.Croscutting.Ioc;
using PontoID.Infra.Data.Repository;
using PontoID.Web.Api.Configurations;

namespace PontoID.Web.Api
{
    public class Startup
    {
        public Startup(IHostEnvironment hostEnvironment)
        {
            //Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            //if (hostEnvironment.IsDevelopment())
            //{
            //    builder.AddUserSecrets<Startup>();
            //}

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects);

            services.AddApiConfiguration();

            services.AddSwaggerConfiguration();

            // Configurar Automapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfiguration());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            RegisterServices(services, this.Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");

            app.UseSwaggerConfiguration();

            app.UseApiConfiguration(env);
        }

        private static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            NativeInjectorBootStrapper.RegisterServices(services, configuration);
        }
    }
}
