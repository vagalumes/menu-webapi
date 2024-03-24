﻿using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase
{
    public static class CreateMenuItemDependencyInjection
    {
        public static IServiceCollection AddMenuItemUseCase(this IServiceCollection services)
        {
            return services.AddDependencies()
                           .AddScoped<ICreateMenuItemsUseCase, CreateMenuItemUseCase>()
                           .Decorate<ICreateMenuItemsUseCase, CreateMenuItemValidation>();
        }
    }
}