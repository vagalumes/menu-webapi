using Application.Shared.Notifications;
using Application.UseCases.Users.v1.CreateUserUseCase.Abstractions;
using Application.UseCases.Users.v1.CreateUserUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Users.v1.CreateUserUseCase;

public static class CreateUserDependencyInjection
{
    public static IServiceCollection AddCreateUserUseCase(this IServiceCollection services)
    {
        return services
            .AddDependencies()
            .AddNotifications()
            .AddScoped<ICreateUsersUseCase, CreateUserUseCase>()
            .Decorate<ICreateUsersUseCase, CreateUserValidationUseCase>();
    }
}