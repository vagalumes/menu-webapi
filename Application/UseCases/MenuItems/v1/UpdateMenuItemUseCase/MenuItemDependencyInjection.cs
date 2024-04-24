using Application.Shared.Notifications;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Models;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Services;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase;

public static class MenuItemDependencyInjection
{
    public static IServiceCollection AddUpdateMenuItemUseCase(this IServiceCollection service)
    {
        return service.AddDependencies()
            .AddNotifications()
            .AddScoped<IValidator<UpdateMenuItemRequest>, UpdateMenuItemRequestValidator>()
            .AddScoped<IUpdateMenuItemUseCase, UpdateMenuItemUseCase>()
            .Decorate<IUpdateMenuItemUseCase, UpdateMenuItemValidation>();
    }
}