using Application.Shared.Notifications;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Services;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase;

public static class CreateRestaurantDependencyInjection
{
    public static IServiceCollection AddCreateRestaurantUseCase(this IServiceCollection services)
    {
        return services
            .AddDependencies()
            .AddNotifications()
            .AddScoped<IValidator<CreateRestaurantRequest>, CreateRestaurantRequestValidator>()
            .AddScoped<ICreateRestaurantUseCase, CreateRestaurantUseCase>()
            .Decorate<ICreateRestaurantUseCase, CreateRestaurantValidationUseCase>();
    }
}