using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase;
using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Services.Repositories.Abstractions;
using AutoFixture;
using Moq;

namespace UnitTests.UseCases.Restaurants.v1.Delete;

public class DeleteRestaurantUseCaseTests
{
    private readonly Mock<IRestaurantRepository> _mockRepository = new();
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
    private readonly Mock<IOutputPort> _mockOutputPort = new();
    private readonly Fixture _fixture = new();
    private readonly DeleteRestaurantUseCase _service;

    public DeleteRestaurantUseCaseTests()
    {
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _service = new DeleteRestaurantUseCase(_mockRepository.Object, _mockUnitOfWork.Object);
        _service.SetOutputPort(_mockOutputPort.Object);
    }

    [Fact]
    public async Task ExecuteAsync_When_RestaurantDoesNotExists_Should_CallRestaurantNotFound()
    {
        var restaurantId = Guid.NewGuid();
        _mockRepository.Setup(m => m.GetRestaurant(restaurantId, CancellationToken.None))
            .ReturnsAsync((Restaurant?)default);

        await _service.ExecuteAsync(restaurantId, CancellationToken.None);
        
        _mockRepository.Verify(m => m.GetRestaurant(restaurantId, It.IsAny<CancellationToken>()), Times.Once);
        _mockOutputPort.Verify(m => m.RestaurantNotFound(), Times.Once);
        _mockRepository.Verify(m => m.DeletedRestaurant(It.IsAny<Restaurant>()), Times.Never);
        _mockUnitOfWork.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        _mockOutputPort.Verify(m => m.RestaurantDeleted(), Times.Never);
    }
    
    [Fact]
    public async Task ExecuteAsync_When_RestaurantExists_Should_RestaurantDeleted()
    {
        var restaurant = _fixture.Create<Restaurant>();
        _mockRepository.Setup(m => m.GetRestaurant(restaurant.Id, CancellationToken.None))
            .ReturnsAsync(restaurant);

        await _service.ExecuteAsync(restaurant.Id, CancellationToken.None);
        
        _mockRepository.Verify(m => m.GetRestaurant(restaurant.Id, It.IsAny<CancellationToken>()), Times.Once);
        _mockOutputPort.Verify(m => m.RestaurantNotFound(), Times.Never);
        _mockRepository.Verify(m => m.DeletedRestaurant(restaurant), Times.Once);
        _mockUnitOfWork.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        _mockOutputPort.Verify(m => m.RestaurantDeleted(), Times.Once);
    }
}