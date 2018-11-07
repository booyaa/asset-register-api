using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Documentation
{
    public static class ApiVersionExtensions
    {
        public static string GetFormattedApiVersion(this ApiVersion apiVersion)
        {
            return $"v{apiVersion.ToString()}";
        }
    }
}