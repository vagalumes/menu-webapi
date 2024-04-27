using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Abstractions;
using FluentAssertions;
using Menu_WebApi.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.UseCases.Restaurants.v1.Update;

public class UpdateRestaurantDependencyInjectionTests
{
    [Fact]
    public void UpdateRestaurantUseCase_ShouldBeRegistered()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Test.json").Build();
        var services = new ServiceCollection();
        
        
        services
            .ConfigureDataBase(configuration)
            .AddUpdateRestaurantUseCase();

        var provider = services.BuildServiceProvider();

        var useCase = provider.GetService<IUpdateRestaurantUseCase>();

        useCase.Should().NotBeNull();
    }
}