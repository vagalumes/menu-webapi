using Application.Shared.Entities;
using Application.Shared.Services.Abstractions;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Services.Repositories.Abstractions;
using AutoFixture;
using Moq;

namespace UnitTests.Application.Restaurants.v1;

public class CreateRestaurantUseCaseTests
{
    private readonly Mock<IRestaurantRepository> _mockRepository = new();
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
    private readonly Mock<IOutputPort> _mockOutputPort = new();
    private readonly Fixture _fixture = new();
    private readonly CreateRestaurantUseCase _service;

    public CreateRestaurantUseCaseTests()
    {
        _service = new CreateRestaurantUseCase(_mockRepository.Object, _mockUnitOfWork.Object);
        _service.SetOutputPort(_mockOutputPort.Object);
    }

    [Fact]
    public async Task CreateRestaurant_When_RestaurantExists_Should_CallRestaurantAlreadyExists()
    {
        var request = _fixture.Create<CreateRestaurantRequest>();
        _mockRepository.Setup(m => m.RestaurantExists(request.Cnpj)).ReturnsAsync(true);

        await _service.ExecuteAsync(request, CancellationToken.None);
        
        _mockOutputPort.Verify(o => o.RestaurantAlreadyExists(), Times.Once);
        _mockOutputPort.Verify(o => o.RestaurantCreated(), Times.Never);
        _mockRepository.Verify(r => r.CreateRestaurant(It.IsAny<Restaurant>(), It.IsAny<CancellationToken>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
    
    [Fact]
    public async Task CreateRestaurant_When_RestaurantDontExists_Should_CreateRestaurant()
    {
        var request = _fixture.Create<CreateRestaurantRequest>();
        _mockRepository.Setup(m => m.RestaurantExists(request.Cnpj)).ReturnsAsync(false);

        await _service.ExecuteAsync(request, CancellationToken.None);
        
        _mockOutputPort.Verify(o => o.RestaurantAlreadyExists(), Times.Never);
        _mockOutputPort.Verify(o => o.RestaurantCreated(), Times.Once);
        _mockRepository.Verify(r => r.CreateRestaurant(It.IsAny<Restaurant>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}