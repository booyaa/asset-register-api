using System;
using HomesEngland.Boundary;
using Infrastructure.Api.Middleware;
using Infrastructure.Documentation;
using Main;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HomesEngland.Gateway.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IApiVersionDescriptionProvider, DefaultApiVersionDescriptionProvider>();

            var assetRegister = new AssetRegister();
            assetRegister.ExportDependencies((type, provider) => services.AddTransient(type, _ => provider()));

            assetRegister.ExportTypeDependencies((type, provider) => services.AddTransient(type, provider));

            services.ConfigureApiVersioning();
            services.ConfigureDocumentation(_apiName);
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<AssetRegisterContext>();
            
            var serviceProvider = services.BuildServiceProvider();
            var assetRegisterContext = serviceProvider.GetService<AssetRegisterContext>();
            assetRegisterContext.Database.Migrate();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.ConfigureSwaggerUiPerApiVersion(_apiName);
            app.UseCors(builder => builder.WithOrigins("*"));

            app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}