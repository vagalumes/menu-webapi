using Application.Shared.Notifications;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models;
using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace UnitTests.UseCases.MenuItems.v1.Create;

public class CreateMenuItemValidationUseCaseTests
{
    private readonly Mock<ICreateMenuItemsUseCase> _mockUseCase = new();
    private readonly Mock<IValidator<CreateMenuItemsRequest>> _mockValidator = new();
    private readonly Notification _notification = new();
    private readonly Mock<IOutputPort> _mockOutputPort = new();
    private readonly Fixture _fixture = new();

    private readonly CreateMenuItemValidation _service;

    public CreateMenuItemValidationUseCaseTests()
    {
        _service = new CreateMenuItemValidation(_mockUseCase.Object, _mockValidator.Object, _notification);
        _service.SetOutputPort(_mockOutputPort.Object);
    }

    [Fact]
    public async Task ExecuteAsync_When_ValidatorReturnsErrors_ShouldCall_InvalidRequest()
    {
        var guidId = _fixture.Create<Guid>();
        var request = _fixture.Create<CreateMenuItemsRequest>();

        _mockValidator.Setup(v => v.ValidateAsync(request, CancellationToken.None))
            .ReturnsAsync(_fixture.Create<ValidationResult>());

        await _service.ExecuteAsync(guidId, request, CancellationToken.None);

        _mockOutputPort.Verify(o => o.InvalidRequest(), Times.Once);
        _mockUseCase.Verify(
            m => m.ExecuteAsync(It.IsAny<Guid>(), It.IsAny<CreateMenuItemsRequest>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }

    [Fact]
    public async Task ExecuteAsync_When_ValidatorReturnSuccess_ShouldCall_UseCase()
    {
        var request = _fixture.Create<CreateMenuItemsRequest>();

        _mockValidator.Setup(v => v.ValidateAsync(request, CancellationToken.None))
            .ReturnsAsync(new ValidationResult() { Errors = [] });

        await _service.ExecuteAsync(new Guid(), request, CancellationToken.None);

        _mockOutputPort.Verify(o => o.InvalidRequest(), Times.Never);
        _mockUseCase.Verify(m => m.ExecuteAsync(new Guid(), request, CancellationToken.None), Times.Once);
    }
}