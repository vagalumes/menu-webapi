using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase;
using Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Services.Repositories.Abstractions;
using AutoFixture;
using Moq;

namespace UnitTests.UseCases.MenuItems.v1.Delete;

public class DeleteMenuItemUseCaseTests
{
    private readonly Mock<IMenuItemRepository> _mockRepository = new();
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
    private readonly Mock<IOutputPort> _mockOutputPort = new();
    private readonly Fixture _fixture = new();
    private readonly DeleteMenuItemUseCase _service;

    public DeleteMenuItemUseCaseTests()
    {
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _service = new DeleteMenuItemUseCase(_mockRepository.Object, _mockUnitOfWork.Object);
        _service.SetOutputPort(_mockOutputPort.Object);
    }

    [Fact]
    public async Task ExecuteAsync_When_RestaurantDoesNotExists_Should_CallRestaurantNotFound()
    {
        var restaurant = _fixture.Create<Restaurant>();
        var menuItem = _fixture.Create<MenuItem>();
        _mockRepository.Setup(m => m.GetRestaurant(restaurant.Id, CancellationToken.None))
            .ReturnsAsync((Restaurant?)default);

        await _service.ExecuteAsync(restaurant.Id, menuItem.Id, CancellationToken.None);

        _mockRepository.Verify(m => m.GetRestaurant(restaurant.Id, It.IsAny<CancellationToken>()), Times.Once);
        _mockOutputPort.Verify(m => m.RestaurantNotFound(), Times.Once);
        _mockRepository.Verify(m => m.DeletedMenuItem(It.IsAny<MenuItem>()), Times.Never);
        _mockUnitOfWork.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        _mockOutputPort.Verify(m => m.MenuItemDeleted(), Times.Never);
    }
    
    
    [Fact]
    public async Task ExecuteAsync_When_MenuItemDoesNotExists_Should_CallMenuItemNotFound()
    {
        var restaurant = _fixture.Create<Restaurant>();
        var menuItem = _fixture.Create<MenuItem>();
        _mockRepository.Setup(m => m.GetRestaurant(restaurant.Id, CancellationToken.None))
            .ReturnsAsync(restaurant);
        _mockRepository.Setup(m => m.GetMenuItem(menuItem.Id, CancellationToken.None))
            .ReturnsAsync((MenuItem?)default);

        await _service.ExecuteAsync(restaurant.Id, menuItem.Id, CancellationToken.None);

        _mockRepository.Verify(m => m.GetRestaurant(restaurant.Id, It.IsAny<CancellationToken>()), Times.Once);
        _mockRepository.Verify(m => m.GetMenuItem(menuItem.Id, It.IsAny<CancellationToken>()), Times.Once);
        _mockOutputPort.Verify(m => m.MenuItemNotFound(), Times.Once);
        _mockRepository.Verify(m => m.DeletedMenuItem(It.IsAny<MenuItem>()), Times.Never);
        _mockUnitOfWork.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        _mockOutputPort.Verify(m => m.MenuItemDeleted(), Times.Never);
    }
    
    [Fact]
    public async Task ExecuteAsync_When_MenuItemExists_Should_DeleteMenuItem()
    {
        var restaurant = _fixture.Create<Restaurant>();
        var menuItem = _fixture.Create<MenuItem>();
        _mockRepository.Setup(m => m.GetRestaurant(restaurant.Id, CancellationToken.None))
            .ReturnsAsync(restaurant);
        _mockRepository.Setup(m => m.GetMenuItem(menuItem.Id, CancellationToken.None))
            .ReturnsAsync(menuItem);

        await _service.ExecuteAsync(restaurant.Id, menuItem.Id, CancellationToken.None);

        _mockRepository.Verify(m => m.GetRestaurant(restaurant.Id, It.IsAny<CancellationToken>()), Times.Once);
        _mockRepository.Verify(m => m.GetMenuItem(menuItem.Id, It.IsAny<CancellationToken>()), Times.Once);
        _mockRepository.Verify(m => m.DeletedMenuItem(menuItem), Times.Once);
        _mockUnitOfWork.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        _mockOutputPort.Verify(m => m.MenuItemDeleted(), Times.Once);
    }
}