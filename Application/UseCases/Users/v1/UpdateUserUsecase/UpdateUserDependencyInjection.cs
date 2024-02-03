using Application.Shared.Notifications;
using Application.UseCases.Users.v1.UpdateUserUsecase.Abstraction;
using Application.UseCases.Users.v1.UpdateUserUsecase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Users.v1.UpdateUserUsecase
{
    public static class UpdateUserDependencyInjection
    {
        public static IServiceCollection AddUpdateUserUseCase(this IServiceCollection services) =>
                services.AddDependencies()
                        .AddNotifications()
                        .AddScoped<IUpdateUserUseCase, UpdateUserUseCase>()
                        .Decorate<IUpdateUserUseCase, UpdateUserValidationUseCase>();
    }
}
