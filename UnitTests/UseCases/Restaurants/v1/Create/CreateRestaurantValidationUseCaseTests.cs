using Application.Shared.Notifications;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace UnitTests.UseCases.Restaurants.v1.Create;

public class CreateRestaurantValidationUseCaseTests
{
    private readonly Mock<ICreateRestaurantUseCase> _mockUseCase = new();
    private readonly Mock<IValidator<CreateRestaurantRequest>> _mockValidator = new();
    private readonly Notification _notification = new();
    private readonly Mock<IOutputPort> _mockOutputPort = new();
    private readonly Fixture _fixture = new();

    private readonly CreateRestaurantValidationUseCase _service;

    public CreateRestaurantValidationUseCaseTests()
    {
        _service = new CreateRestaurantValidationUseCase(_mockUseCase.Object, _mockValidator.Object,
            _notification);
        _service.SetOutputPort(_mockOutputPort.Object);
    }

    [Fact]
    public async Task ExecuteAsync_When_ValidatorReturnsErrors_ShouldCall_InvalidRequest()
    {
        var request = _fixture.Create<CreateRestaurantRequest>();

        _mockValidator.Setup(v => v.ValidateAsync(request, CancellationToken.None))
            .ReturnsAsync(_fixture.Create<ValidationResult>());

        await _service.ExecuteAsync(request, CancellationToken.None);

        _mockOutputPort.Verify(o => o.InvalidRequest(), Times.Once);
        _mockUseCase.Verify(m => m.ExecuteAsync(It.IsAny<CreateRestaurantRequest>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }
    
    [Fact]
    public async Task ExecuteAsync_When_ValidatorReturnsSuccess_ShouldCall_UseCase()
    {
        var request = _fixture.Create<CreateRestaurantRequest>();

        _mockValidator.Setup(v => v.ValidateAsync(request, CancellationToken.None))
            .ReturnsAsync(new ValidationResult() {Errors = [] });

        await _service.ExecuteAsync(request, CancellationToken.None);

        _mockOutputPort.Verify(o => o.InvalidRequest(), Times.Never);
        _mockUseCase.Verify(m => m.ExecuteAsync(request, CancellationToken.None),
            Times.Once);
    }
}