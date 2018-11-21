using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Infrastructure.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Infrastructure.Documentation
{
    public static class SwaggerApiDocumentation
    {
        /// <summary>
        /// Pre-Requisite Controllers must [ApiVersion("x")] on them
        /// </summary>
        /// <param name="services"></param>
        /// <param name="apiName"></param>
        public static void ConfigureDocumentation(this IServiceCollection services, string apiName)
        {
            services.AddSwaggerGen(c =>
            {
                //include the relevant controller version in the relevant versions of the documentation
                SeperatePerApiVersion(c);

                var apiVersions = services.BuildServiceProvider().GetApiVersionDescriptions();

                GenerateSwaggerVersionPerApiVersion(apiName, apiVersions, c);

                c.CustomSchemaIds(x => x.FullName);
                
                IncludeXmlCommentsIfPresent(c);
            });
        }

        private static void GenerateSwaggerVersionPerApiVersion(string apiName, List<ApiVersionDescription> apiVersions, SwaggerGenOptions c)
        {
            foreach (var apiVersion in apiVersions)
            {
                var version = $"v{apiVersion.ApiVersion.ToString()}";
                c.SwaggerDoc(version, new Info {Title = $"{apiName} {version}", Version = version});
            }
        }

        private static void IncludeXmlCommentsIfPresent(SwaggerGenOptions c)
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
                c.IncludeXmlComments(xmlPath);
        }

        private static void SeperatePerApiVersion(SwaggerGenOptions c)
        {
            c.DocInclusionPredicate((docName, apiDesc) =>
            {
                var versions = apiDesc.ControllerAttributes()
                    .OfType<ApiVersionAttribute>()
                    .SelectMany(attr => attr.Versions).ToList();

                var any = versions.Any(v => $"{v.GetFormattedApiVersion()}" == docName);
                return any;
            });
        }

        /// <summary>
        /// Pre-Requisite Controllers must [ApiVersion("x")] on them
        /// </summary>
        /// <param name="app"></param>
        /// <param name="apiName"></param>
        /// <returns></returns>
        public static List<ApiVersionDescription> ConfigureSwaggerUiPerApiVersion(this IApplicationBuilder app, string apiName)
        {
            var api = app.ApplicationServices.GetService<IApiVersionDescriptionProvider>(); 
            var apiVersions = api.ApiVersionDescriptions.Select(s => s).ToList();
            app.UseSwaggerUI(c =>
            {
                //Generate swagger docs per api version
                foreach (var apiVersionDescription in apiVersions)
                {
                    //Create a swagger endpoint for each swagger version
                    c.SwaggerEndpoint($"{apiVersionDescription.GetFormattedApiVersion()}/swagger.json",
                        $"{apiName} {apiVersionDescription.GetFormattedApiVersion()}");
                }
            });

            app.UseSwagger();

            return apiVersions;
        }
    }

    public static class ApiVersioningConfigurationExtension
    {
        public static List<ApiVersionDescription> GetApiVersionDescriptions(this IServiceProvider serviceProvider)
        {
            var api = serviceProvider.GetService<IApiVersionDescriptionProvider>();
            var apiVersions = api.ApiVersionDescriptions.Select(s => s).ToList();
            return apiVersions;
        }

        public static void ConfigureApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
                // {host}/api/v{apiVersion}/{controller}/*
                o.ApiVersionReader = new UrlSegmentApiVersionReader();
            });
        }
    }
}
