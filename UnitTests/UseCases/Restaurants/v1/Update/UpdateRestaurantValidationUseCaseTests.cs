using Application.Shared.Notifications;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace UnitTests.UseCases.Restaurants.v1.Update;

public class UpdateRestaurantValidationUseCaseTests
{
    private readonly Mock<IUpdateRestaurantUseCase> _mockUseCase = new();
    private readonly Mock<IValidator<UpdateRestaurantRequest>> _mockValidator = new();
    private readonly Mock<IOutputPort> _mockOutputPort = new();
    private readonly Notification _notification = new();
    private readonly Fixture _fixture = new();

    private readonly UpdateRestaurantValidationUseCase _service;

    public UpdateRestaurantValidationUseCaseTests()
    {
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _service = new UpdateRestaurantValidationUseCase(_mockValidator.Object, _mockUseCase.Object, _notification);
        _service.SetOutputPort(_mockOutputPort.Object);
    }

    [Fact]
    public async Task ExecuteAsync_WhenRequestIsInvalid_MustCallInvalidRequest()
    {
        // Arrange
        var id = Guid.NewGuid();
        var request = _fixture.Create<UpdateRestaurantRequest>();
        var validationResult = new ValidationResult(new List<ValidationFailure>
        {
            new("Name", "Name is required")
        });
        _mockValidator.Setup(x => x.ValidateAsync(request, It.IsAny<CancellationToken>()))
            .ReturnsAsync(validationResult);

        // Act
        await _service.ExecuteAsync(id, request, CancellationToken.None);

        // Assert
        _mockOutputPort.Verify(x => x.InvalidRequest(), Times.Once);
        _mockUseCase.Verify(
            x => x.ExecuteAsync(It.IsAny<Guid>(), It.IsAny<UpdateRestaurantRequest>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }
    
    [Fact]
    public async Task ExecuteAsync_WhenRequestIsValid_MustCallUseCase()
    {
        // Arrange
        var id = Guid.NewGuid();
        var request = _fixture.Create<UpdateRestaurantRequest>();
        var validationResult = new ValidationResult();
        _mockValidator.Setup(x => x.ValidateAsync(request, It.IsAny<CancellationToken>()))
            .ReturnsAsync(validationResult);

        // Act
        await _service.ExecuteAsync(id, request, CancellationToken.None);

        // Assert
        _mockOutputPort.Verify(x => x.InvalidRequest(), Times.Never);
        _mockUseCase.Verify(x => x.ExecuteAsync(id, request, It.IsAny<CancellationToken>()), Times.Once);
    }
}