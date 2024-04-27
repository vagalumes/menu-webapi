using Application.Shared.Notifications;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Services;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase
{
    public static class CreateMenuItemDependencyInjection
    {
        public static IServiceCollection AddCreateMenuItemUseCase(this IServiceCollection services)
        {
            return services
                .AddDependencies()
                .AddNotifications()
                .AddScoped<IValidator<CreateMenuItemsRequest>, CreateMenuItemsRequestValidator>()
                .AddScoped<ICreateMenuItemsUseCase, CreateMenuItemUseCase>()
                .Decorate<ICreateMenuItemsUseCase, CreateMenuItemValidation>();
        }
    }
}