using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Cardapio_webapi.Modules
{
    public static class SwaggerConfigExtensions
    {
        public static WebApplication ConfigureSwaggerUI(this WebApplication application, IApiVersionDescriptionProvider provider)
        {
            _ = application.UseSwagger();
            _ = application.UseSwaggerUI(o =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    o.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"Cardapio.Api - {description.GroupName.ToUpper()}");
                }
            });
            return application;
        }
    }
}
