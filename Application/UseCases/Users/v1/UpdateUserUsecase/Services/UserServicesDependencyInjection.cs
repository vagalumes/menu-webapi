using Application.UseCases.Users.v1.UpdateUserUseCase.Services.Repositories;
using Application.UseCases.Users.v1.UpdateUserUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Users.v1.UpdateUserUseCase.Services;

public static class UserServicesDependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        return services.AddScoped<IUserRepository, UserRepository>();
    }
}