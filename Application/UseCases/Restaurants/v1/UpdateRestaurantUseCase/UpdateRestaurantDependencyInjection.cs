﻿using Application.Shared.Notifications;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Services;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase;

public static class UpdateRestaurantDependencyInjection
{
    public static IServiceCollection AddUpdateRestaurantUseCase(this IServiceCollection services)
    {
        return services
            .AddDependencies()
            .AddNotifications()
            .AddScoped<IValidator<UpdateRestaurantRequest>, UpdateRestaurantRequestValidator>()
            .AddScoped<IUpdateRestaurantUseCase, UpdateRestaurantUseCase>()
            .Decorate<IUpdateRestaurantUseCase, UpdateRestaurantValidationUseCase>();
    }
}