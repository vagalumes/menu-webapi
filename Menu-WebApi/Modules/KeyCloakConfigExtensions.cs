using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Sdk.Admin;

namespace Menu_WebApi.Modules;

public static class KeyCloakConfigExtensions
{
    public static IServiceCollection ConfigureKeyCloak(this IServiceCollection services, IConfiguration configuration)
    {
        var authenticationOptions = configuration
            .GetSection(KeycloakAuthenticationOptions.Section)
            .Get<KeycloakAuthenticationOptions>();

        var authorizationOptions = configuration
            .GetSection(KeycloakProtectionClientOptions.Section)
            .Get<KeycloakProtectionClientOptions>();

        services.AddKeycloakAuthentication(authenticationOptions!);
        services.AddKeycloakAuthorization(authorizationOptions!);
        
        return services;
    }
}