using Application.Shared.Notifications;
using Application.UseCases.Users.v1.DeleteUserUseCase.Abstractions;
using Application.UseCases.Users.v1.DeleteUserUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Users.v1.DeleteUserUseCase;

public static class DeleteUserDependencyInjection
{
    public static IServiceCollection AddDeleteUserUseCase(this IServiceCollection services)
    {
        return services
            .AddDependencies()
            .AddNotifications()
            .AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
    }
}