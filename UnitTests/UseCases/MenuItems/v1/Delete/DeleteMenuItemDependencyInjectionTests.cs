using Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase;
using Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Abstractions;
using FluentAssertions;
using Menu_WebApi.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.UseCases.MenuItems.v1.Delete;

public class DeleteMenuItemDependencyInjectionTests
{
    [Fact]
    public void Should_Get_DeleteMenuItemUseCase()
    {
        //Arrange
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Test.json").Build();
        var services = new ServiceCollection();

        services.ConfigureDataBase(configuration)
            .AddDeleteMenuItemUseCase();

        var provider = services.BuildServiceProvider();

        // Act
        var useCase = provider.GetService<IDeleteMenuItemUseCase>();

        // Assert
        useCase.Should().NotBeNull();
    }
}