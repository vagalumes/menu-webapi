using Application.Shared.Entities;
using Application.UseCases.MenuItems.v1.GetMenuItemUseCase;
using Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Models;
using Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Services.Repositories.Abstractions;
using AutoFixture;
using Moq;

namespace UnitTests.UseCases.MenuItems.v1.Get.GetMenuItem;

public class GetMenuItemUseCaseTests
{
    private readonly Mock<IMenuItemRepository> _repository = new();
    private readonly Mock<IOutputPort> _outputPort = new();
    private readonly Fixture _fixture = new();
    private readonly GetMenuItemUseCase _service;

    public GetMenuItemUseCaseTests()
    {
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _service = new GetMenuItemUseCase(_repository.Object);
        _service.SetOutputPort(_outputPort.Object);
    }

    [Fact]
    public async Task Should_Return_Restaurant_Not_Found()
    {
        // Arrange
        var restaurant = _fixture.Create<Restaurant>();
        var menuItem = _fixture.Create<MenuItem>();

        _repository.Setup(x => x.GetRestaurant(restaurant.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Restaurant?)null);

        // Act
        await _service.ExecuteAsync(restaurant.Id, menuItem.Id, CancellationToken.None);

        // Assert
        _outputPort.Verify(x => x.RestaurantNotFound(), Times.Once);
    }

    [Fact]
    public async Task Should_Return_MenuItem_Not_Found()
    {
        // Arrange
        var restaurant = _fixture.Create<Restaurant>();
        var menuItem = _fixture.Create<MenuItem>();

        _repository.Setup(x => x.GetRestaurant(restaurant.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(restaurant);
        _repository.Setup(x => x.GetMenuItem(menuItem.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync((MenuItem?)null);

        // Act
        await _service.ExecuteAsync(restaurant.Id, menuItem.Id, CancellationToken.None);

        // Assert
        _outputPort.Verify(x => x.MenuItemNotFound(), Times.Once);
    }

    [Fact]
    public async Task Should_Return_MenuItem_Found()
    {
        // Arrange
        var restaurant = _fixture.Create<Restaurant>();
        var menuItem = _fixture.Create<MenuItem>();

        _repository.Setup(x => x.GetRestaurant(restaurant.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(restaurant);
        _repository.Setup(x => x.GetMenuItem(menuItem.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(menuItem);

        // Act
        await _service.ExecuteAsync(restaurant.Id, menuItem.Id, CancellationToken.None);

        // Assert
        _outputPort.Verify(x => x.MenuItemFound(It.IsAny<MenuItemResponse>()), Times.Once);
    }
}