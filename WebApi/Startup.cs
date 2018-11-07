using HomesEngland.Boundary;
using Infrastructure.Documentation;
using Infrastructure.Versioning.Dependencies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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

            new AssetRegister().ExportDependencies((type, provider) =>
                services.AddTransient(type, _ => provider())
            );

            new ApiVersioningDependencyExporter().ExportTypeDependencies((type, typeDependency) =>
                services.AddSingleton(type,typeDependency)
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
