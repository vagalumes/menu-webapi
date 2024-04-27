using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase;
using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Abstractions;
using FluentAssertions;
using Menu_WebApi.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.UseCases.Restaurants.v1.Delete;

public class DeleteRestaurantDependencyInjectionTests
{
    [Fact]
    public void Should_Get_DeleteRestaurantUseCase()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Test.json").Build();
        var services = new ServiceCollection();
        
        
        services
            .ConfigureDataBase(configuration)
            .AddDeleteRestaurantUseCase();

        var provider = services.BuildServiceProvider();

        var useCase = provider.GetService<IDeleteRestaurantUseCase>();

        useCase.Should().NotBeNull();
    }
}