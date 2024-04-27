using Application.UseCases.Users.v1.CreateUserUseCase.Services.Repositories;
using Application.UseCases.Users.v1.CreateUserUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Users.v1.CreateUserUseCase.Services;

public static class UserServicesDependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        return services.AddScoped<IUserRepository, UserRepository>();
    }
}