using Application.Shared.Entities;
using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase;
using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Models;
using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Services.Repositories.Abstractions;
using AutoFixture;
using Moq;

namespace UnitTests.UseCases.MenuItems.v1.Get.GetMenuItems;

public class GetMenuItemsUseCaseTests
{
    private readonly Mock<IMenuItemsRepository> _mockRepository = new();
    private readonly Mock<IOutputPort> _mockOutputPort = new();
    private readonly Fixture _fixture = new();
    private readonly GetMenuItemsUseCase _service;

    public GetMenuItemsUseCaseTests()
    {
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _service = new GetMenuItemsUseCase(_mockRepository.Object);
        _service.SetOutputPort(_mockOutputPort.Object);
    }

    [Fact]
    public async Task Should_Return_Restaurant_Not_Found()
    {
        // Arrange
        var restaurantId = Guid.NewGuid();
        _mockRepository.Setup(x => x.GetRestaurant(restaurantId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Restaurant?)null);

        // Act
        await _service.ExecuteAsync(restaurantId, CancellationToken.None);

        // Assert
        _mockOutputPort.Verify(x => x.RestaurantNotFound(), Times.Once);
    }

    [Fact]
    public async Task Should_Return_Restaurant_Found()
    {
        // Arrange
        var restaurantId = Guid.NewGuid();
        var restaurant = _fixture.Create<Restaurant>();
        _mockRepository.Setup(x => x.GetRestaurant(restaurantId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(restaurant);

        // Act
        await _service.ExecuteAsync(restaurantId, CancellationToken.None);

        // Assert
        _mockOutputPort.Verify(x => x.MenuItemsFound(It.IsAny<IEnumerable<MenuItemsResponse>>()), Times.Once);
    }

    [Fact]
    public async Task Should_Return_MenuItems()
    {
        // Arrange
        var restaurantId = Guid.NewGuid();
        var restaurant = _fixture.Create<Restaurant>();
        var menuItem = _fixture.CreateMany<MenuItem>().ToList();
        _mockRepository.Setup(x => x.GetRestaurant(restaurantId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(restaurant);
        _mockRepository.Setup(x => x.GetMenuItems(restaurantId))
            .Returns(menuItem);

        // Act
        await _service.ExecuteAsync(restaurantId, CancellationToken.None);

        // Assert
        _mockOutputPort.Verify(x => x.MenuItemsFound(It.IsAny<IEnumerable<MenuItemsResponse>>()), Times.Once);
    }
}