using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Services.Repositories.Abstractions;
using AutoFixture;
using Moq;

namespace UnitTests.UseCases.MenuItems.v1.Create;

public class CreateMenuItemUseCaseTests
{
    private readonly Mock<IMenuItemRepository> _mockRepository = new();
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
    private readonly Mock<IOutputPort> _mockIOutputPort = new();
    private readonly CreateMenuItemUseCase _service;
    private readonly Fixture _fixture = new();

    public CreateMenuItemUseCaseTests()
    {
        _service = new CreateMenuItemUseCase(_mockRepository.Object, _mockUnitOfWork.Object);
        _service.SetOutputPort(_mockIOutputPort.Object);
    }

    [Fact]
    public async Task CreateMenuItem_When_RestaurantDontExists_ShouldCall_RestaurantNotLocated()
    {
        var guidId = _fixture.Create<Guid>();
        var request = _fixture.Create<CreateMenuItemsRequest>();
        _mockRepository.Setup(m => m.GetRestaurant(guidId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Restaurant?)null);

        await _service.ExecuteAsync(guidId, request, CancellationToken.None);

        _mockIOutputPort.Verify(o => o.RestaurantNotFound("Restaurante não localizado!"), Times.Once);
        _mockRepository.Verify(r => r.GetRestaurant(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateMenuItem_When_RestaurantExists_ShouldCall_MenuItemCreated()
    {
        var guidId = _fixture.Create<Guid>();
        var request = _fixture.Create<CreateMenuItemsRequest>();
        _mockRepository.Setup(m => m.GetRestaurant(guidId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Restaurant?)new Restaurant());

        await _service.ExecuteAsync(guidId, request, CancellationToken.None);

        _mockIOutputPort.Verify(o => o.RestaurantNotFound("Restaurante não localizado!"), Times.Never);
        _mockIOutputPort.Verify(o => o.MenuItemsCreated(It.IsAny<MenuItemResponse>()), Times.Once);
        _mockRepository.Verify(r => r.CreateMenuItems(It.IsAny<MenuItem>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}