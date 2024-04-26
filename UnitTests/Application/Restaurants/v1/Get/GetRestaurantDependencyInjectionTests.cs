﻿using Application.UseCases.Restaurants.v1.GetRestaurantUseCase;
using Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Abstractions;
using FluentAssertions;
using Menu_WebApi.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.Application.Restaurants.v1.Get;

public class GetRestaurantDependencyInjectionTests
{
    [Fact]
    public void Should_Get_GetRestaurantUseCase()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Test.json").Build();
        var services = new ServiceCollection();
        
        
        services
            .ConfigureDataBase(configuration)
            .AddGetRestaurantUseCase();

        var provider = services.BuildServiceProvider();

        var useCase = provider.GetService<IGetRestaurantUseCase>();

        useCase.Should().NotBeNull();
    }
}