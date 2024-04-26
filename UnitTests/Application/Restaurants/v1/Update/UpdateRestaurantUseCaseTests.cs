using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Services.Repositories.Abstractions;
using AutoFixture;
using Moq;

namespace UnitTests.Application.Restaurants.v1.Update;

public class UpdateRestaurantUseCaseTests
{
    private readonly Mock<IRestaurantRepository> _mockRepository = new();
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
    private readonly Mock<IOutputPort> _mockOutputPort = new();
    private readonly Fixture _fixture = new();
    private readonly UpdateRestaurantUseCase _service;
    
    public UpdateRestaurantUseCaseTests()
    {
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _service = new UpdateRestaurantUseCase(_mockRepository.Object, _mockUnitOfWork.Object);
        _service.SetOutputPort(_mockOutputPort.Object);
    }
    
    [Fact]
    public async Task ExecuteAsync_WhenRestaurantDoesNotExist_MustCallRestaurantNotFound()
    {
        // Arrange
        var id = Guid.NewGuid();
        var request = _fixture.Create<UpdateRestaurantRequest>();
        _mockRepository.Setup(x => x.GetRestaurant(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Restaurant?)null);
        
        // Act
        await _service.ExecuteAsync(id, request, CancellationToken.None);
        
        // Assert
        _mockOutputPort.Verify(x => x.RestaurantNotFound(), Times.Once);
        _mockRepository.Verify(x => x.UpdateRestaurant(It.IsAny<Restaurant>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        _mockOutputPort.Verify(x => x.RestaurantUpdated(), Times.Never);
    }
    
    [Fact]
    public async Task ExecuteAsync_WhenRestaurantExists_MustCallRestaurantUpdated()
    {
        // Arrange
        var id = Guid.NewGuid();
        var request = _fixture.Create<UpdateRestaurantRequest>();
        var restaurant = _fixture.Create<Restaurant>();
        _mockRepository.Setup(x => x.GetRestaurant(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(restaurant);
        
        // Act
        await _service.ExecuteAsync(id, request, CancellationToken.None);
        
        // Assert
        _mockOutputPort.Verify(x => x.RestaurantNotFound(), Times.Never);
        _mockRepository.Verify(x => x.UpdateRestaurant(restaurant), Times.Once);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        _mockOutputPort.Verify(x => x.RestaurantUpdated(), Times.Once);
    }
}