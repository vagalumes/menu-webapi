using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace Menu_WebApi.Modules
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
                    o.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"Menu.Api - {description.GroupName.ToUpper()}");
                }
            });
            return application;
        }

        public static IServiceCollection AddSwaggerGen(this IServiceCollection services)
        {
            return services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo {Title = "Menu WebApi", Version = "v1"});
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Entre com um token válido",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer",
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }
    }
}
