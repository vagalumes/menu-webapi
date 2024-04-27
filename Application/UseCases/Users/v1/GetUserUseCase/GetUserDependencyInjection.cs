using Application.UseCases.Users.v1.GetUserUseCase.Abstractions;
using Application.UseCases.Users.v1.GetUserUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Users.v1.GetUserUseCase;

public static class GetUserDependencyInjection
{
    public static IServiceCollection AddGetUserUseCase(this IServiceCollection services)
    {
        return services.AddDependencies()
            .AddScoped<IGetUserUseCase, GetUserUseCase>();
    }
}