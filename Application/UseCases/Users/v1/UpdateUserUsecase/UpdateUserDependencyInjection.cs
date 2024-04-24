using Application.Shared.Notifications;
using Application.UseCases.Users.v1.UpdateUserUseCase.Abstraction;
using Application.UseCases.Users.v1.UpdateUserUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Users.v1.UpdateUserUseCase;

public static class UpdateUserDependencyInjection
{
    public static IServiceCollection AddUpdateUserUseCase(this IServiceCollection services)
    {
        return services.AddDependencies()
            .AddNotifications()
            .AddScoped<IUpdateUserUseCase, UpdateUserUseCase>()
            .Decorate<IUpdateUserUseCase, UpdateUserValidationUseCase>();
    }
}