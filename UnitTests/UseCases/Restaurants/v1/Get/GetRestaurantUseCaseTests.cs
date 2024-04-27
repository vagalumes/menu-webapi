using Application.Shared.Entities;
using Application.UseCases.Restaurants.v1.GetRestaurantUsecase;
using Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Abstractions;
using Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Models;
using Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Services.Repositories.Abstractions;
using AutoFixture;
using Moq;

namespace UnitTests.UseCases.Restaurants.v1.Get;

public class GetRestaurantUseCaseTests
{
    private readonly Mock<IRestaurantRepository> _mockRepository = new();
    private readonly Mock<IOutputPort> _mockOutputPort = new();
    private readonly Fixture _fixture = new();
    private readonly GetRestaurantUseCase _service;
    
    public GetRestaurantUseCaseTests()
    {
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _service = new GetRestaurantUseCase(_mockRepository.Object);
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
        _mockOutputPort.Verify(x => x.RestaurantFound(It.IsAny<GetRestaurantModel>()), Times.Once);
    }
}