using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Abstractions;
using FluentAssertions;
using Menu_WebApi.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.UseCases.MenuItems.v1.Create;

public class CreateMenuItemDependencyInjectionTests
{
    [Fact]
    public void Should_Get_CreateMenuItemUseCase()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Test.json").Build();
        var services = new ServiceCollection();

        services
            .ConfigureDataBase(configuration)
            .AddCreateMenuItemUseCase();

        var provider = services.BuildServiceProvider();

        var useCase = provider.GetService<ICreateMenuItemsUseCase>();
        useCase.Should().NotBeNull();
    }
}