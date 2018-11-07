using HomesEngland.Boundary;
using Infrastructure.Api.Middleware;
using Infrastructure.Documentation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
{
    public class Startup
    {
        private readonly string _apiName;

        public Startup(IConfiguration configuration)
        {
            _apiName = "Asset Register Api";
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IApiVersionDescriptionProvider, DefaultApiVersionDescriptionProvider>();

            new AssetRegister().ExportDependencies((type, provider) =>
                services.AddTransient(type, _ => provider())
            );

            services.ConfigureApiVersioning();
            services.ConfigureDocumentation(_apiName);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.ConfigureSwaggerUiPerApiVersion(_apiName);

            app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
