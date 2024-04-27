using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Abstractions;
using FluentAssertions;
using Menu_WebApi.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.UseCases.Restaurants.v1.Create;

public class CreateRestaurantDependencyInjectionTests
{
    [Fact]
    public void Should_Get_CreateRestaurantUseCase()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Test.json").Build();
        var services = new ServiceCollection();
        
        
        services
            .ConfigureDataBase(configuration)
            .AddCreateRestaurantUseCase();

        var provider = services.BuildServiceProvider();

        var useCase = provider.GetService<ICreateRestaurantUseCase>();

        useCase.Should().NotBeNull();
    }
}