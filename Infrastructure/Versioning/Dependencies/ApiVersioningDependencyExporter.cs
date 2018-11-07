using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Utilities;

namespace Infrastructure.Versioning.Dependencies
{
    public class ApiVersioningDependencyExporter: DependencyExporter
    {
        protected override void ConstructHiddenDependencies()
        {
            
        }

        protected override void RegisterAllExportedDependencies()
        {
            RegisterExportedDependency<IApiVersionDescriptionProvider, DefaultApiVersionDescriptionProvider>();
        }
    }
}
