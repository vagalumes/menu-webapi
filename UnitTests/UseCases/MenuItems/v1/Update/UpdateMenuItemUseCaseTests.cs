using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Models;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Services.Repositories.Abstractions;
using AutoFixture;
using Moq;

namespace UnitTests.UseCases.MenuItems.v1.Update;

public class UpdateMenuItemUseCaseTests
{
    private readonly Mock<IMenuItemRepository> _mockRepository = new();
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
    private readonly Mock<IOutputPort> _mockOutputPort = new();
    private readonly Fixture _fixture = new();
    private readonly UpdateMenuItemUseCase _service;

    public UpdateMenuItemUseCaseTests()
    {
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _service = new UpdateMenuItemUseCase(_mockRepository.Object, _mockUnitOfWork.Object);
        _service.SetOutputPort(_mockOutputPort.Object);
    }

    [Fact]
    public async Task ExecuteAsync_WhenRestaurantDoesNotExist_MustCallRestaurantNotFound()
    {
        // Arrange
        var restaurant = _fixture.Create<Restaurant>();
        var menuItem = _fixture.Create<MenuItem>();
        var request = _fixture.Create<UpdateMenuItemRequest>();
        _mockRepository.Setup(x => x.GetMenuItem(restaurant.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync((MenuItem?)null);

        // Act
        await _service.ExecuteAsync(restaurant.Id, menuItem.Id, request, CancellationToken.None);

        // Assert
        _mockOutputPort.Verify(x => x.MenuItemNotFound(), Times.Once);
        _mockRepository.Verify(x => x.UpdateMenuItem(It.IsAny<MenuItem>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        _mockOutputPort.Verify(x => x.MenuitemUpdated(), Times.Never);
        
    }

    [Fact]
    public async Task ExecuteAsync_WhenMenuItemDoesNotExist_MustCallMenuItemNotFound()
    {
        // Arrange
        var restaurant = _fixture.Create<Restaurant>();
        var menuItem = _fixture.Create<MenuItem>();
        var request = _fixture.Create<UpdateMenuItemRequest>();
        _mockRepository.Setup(x => x.GetMenuItem(restaurant.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync((MenuItem?)null);

        // Act
        await _service.ExecuteAsync(restaurant.Id, menuItem.Id, request, CancellationToken.None);

        // Assert
        _mockOutputPort.Verify(x => x.MenuItemNotFound(), Times.Once);
        _mockRepository.Verify(x => x.UpdateMenuItem(It.IsAny<MenuItem>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        _mockOutputPort.Verify(x => x.MenuitemUpdated(), Times.Never);
    }

    [Fact]
    public async Task ExecuteAsync_WhenMenuItemExists_MustCallMenuItemUpdated()
    {
        // Arrange
        var restaurant = _fixture.Create<Restaurant>();
        var menuItem = _fixture.Create<MenuItem>();
        var request = _fixture.Create<UpdateMenuItemRequest>();
        _mockRepository.Setup(x => x.GetMenuItem(restaurant.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(menuItem);

        // Act
        await _service.ExecuteAsync(restaurant.Id, menuItem.Id, request, CancellationToken.None);

        // Assert
        _mockRepository.Verify(x => x.UpdateMenuItem(menuItem), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        _mockOutputPort.Verify(x => x.MenuitemUpdated(), Times.Never);
        
    }
}