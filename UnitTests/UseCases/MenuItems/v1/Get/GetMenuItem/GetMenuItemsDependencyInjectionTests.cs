using Application.UseCases.MenuItems.v1.GetMenuItemUseCase;
using Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Abstractions;
using FluentAssertions;
using Menu_WebApi.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.UseCases.MenuItems.v1.Get.GetMenuItem;

public class GetMenuItemsDependencyInjectionTests
{
    [Fact]
    public void Should_Get_MenuItemUseCase()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Test.json").Build();
        var services = new ServiceCollection();

        services.ConfigureDataBase(configuration)
            .AddGetMenuItemUseCase();

        var provider = services.BuildServiceProvider();

        var useCase = provider.GetService<IGetMenuItemUseCase>();
        useCase.Should().NotBeNull();
    }
}