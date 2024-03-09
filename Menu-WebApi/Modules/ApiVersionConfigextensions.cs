using Microsoft.AspNetCore.Mvc;

namespace Cardapio_webapi.Modules
{
    public static class ApiVersionConfigextensions
    {
        public static IServiceCollection AddApiVersion(this IServiceCollection services)
        {
            _ = services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            _ = services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
