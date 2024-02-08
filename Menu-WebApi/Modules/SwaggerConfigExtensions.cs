using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace WebApi.Modules
{
    public static class SwaggerConfigExtensions
    {
        public static WebApplication ConfigureSwaggerUi(this WebApplication application, IApiVersionDescriptionProvider provider)
        {
            _ = application.UseSwagger();
            _ = application.UseSwaggerUI(o =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    o.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"Cardápio.Api - {description.GroupName.ToUpper()}");
                }
            });
            return application;
        }
    }
}
