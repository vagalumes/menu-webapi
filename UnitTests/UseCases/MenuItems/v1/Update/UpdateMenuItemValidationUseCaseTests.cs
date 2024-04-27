using Application.Shared.Entities;
using Application.Shared.Notifications;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Models;
using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace UnitTests.UseCases.MenuItems.v1.Update;

public class UpdateMenuItemValidationUseCaseTests
{
    private readonly Mock<IUpdateMenuItemUseCase> _mockUseCase = new();
    private readonly Mock<IValidator<UpdateMenuItemRequest>> _mockValidator = new();
    private readonly Mock<IOutputPort> _mockOutputPort = new();
    private readonly Notification _notification = new();
    private readonly Fixture _fixture = new();


    private readonly UpdateMenuItemValidation _service;

    public UpdateMenuItemValidationUseCaseTests()
    {
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _service = new UpdateMenuItemValidation(_mockValidator.Object, _mockUseCase.Object, _notification);
        _service.SetOutputPort(_mockOutputPort.Object);
    }

    [Fact]
    public async Task ExecuteAsync_WhenRequestIsInvalid_MustCallInvalidRequest()
    {
        // Arrange
        var id = Guid.NewGuid();
        var menuItemId = Guid.NewGuid();
        var request = _fixture.Create<UpdateMenuItemRequest>();
        var validationResult = new ValidationResult(new List<ValidationFailure>
        {
            new("Name", "Name is required")
        });
        _mockValidator.Setup(x => x.ValidateAsync(request, It.IsAny<CancellationToken>()))
            .ReturnsAsync(validationResult);

        // Act
        await _service.ExecuteAsync(id, menuItemId, request, CancellationToken.None);

        // Assert
        _mockOutputPort.Verify(x => x.InvalidRequest(), Times.Once);
        _mockUseCase.Verify(
            x => x.ExecuteAsync(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<UpdateMenuItemRequest>(),
                It.IsAny<CancellationToken>()),
            Times.Never);
    }

    [Fact]
    public async Task ExecuteAsync_WhenRequestIsValid_MustCallUseCase()
    {
        // Arrange
        var restaurant = _fixture.Create<Restaurant>();
        var menuItem = _fixture.Create<MenuItem>();
        var request = _fixture.Create<UpdateMenuItemRequest>();
        var validationResult = new ValidationResult();
        _mockValidator.Setup(x => x.ValidateAsync(request, It.IsAny<CancellationToken>()))
            .ReturnsAsync(validationResult);

        // Act
        await _service.ExecuteAsync(restaurant.Id, menuItem.Id, request, CancellationToken.None);

        // Assert
        _mockOutputPort.Verify(x => x.InvalidRequest(), Times.Never);
        _mockUseCase.Verify(
            x => x.ExecuteAsync(restaurant.Id, menuItem.Id, request, It.IsAny<CancellationToken>()),
            Times.Once);
    }
}