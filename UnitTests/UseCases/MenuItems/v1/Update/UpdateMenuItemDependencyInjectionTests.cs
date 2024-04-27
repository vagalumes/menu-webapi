using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Abstractions;
using FluentAssertions;
using Menu_WebApi.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.UseCases.MenuItems.v1.Update;

public class UpdateMenuItemDependencyInjectionTests
{
    [Fact]
    public void Should_Get_UpdateMenuItemUseCase()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Test.json").Build();
        var services = new ServiceCollection();

        services.ConfigureDataBase(configuration)
            .AddUpdateMenuItemUseCase();

        var provider = services.BuildServiceProvider();

        var useCase = provider.GetService<IUpdateMenuItemUseCase>();

        useCase.Should().NotBeNull();
    }
}