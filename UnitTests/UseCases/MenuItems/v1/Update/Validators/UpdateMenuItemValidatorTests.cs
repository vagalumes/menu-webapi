using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Models;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Validators;
using FluentValidation.TestHelper;

namespace UnitTests.UseCases.MenuItems.v1.Update.Validators;

public class UpdateMenuItemValidatorTests
{
    private readonly UpdateMenuItemRequestValidator _validator = new();

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public async Task ShouldHaveError_WhenNameIsEmpty(string name)
    {
        // Arrange
        var request = new UpdateMenuItemRequest
        {
            Name = name
        };

        // Act
        var result = await _validator.TestValidateAsync(request);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Name)
            .WithErrorMessage("O Nome do prato não pode ser nulo ou vazio.");
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public async Task ShouldHaveError_WhenDescriptionIsEmpty(string description)
    {
        // Arrange
        var request = new UpdateMenuItemRequest
        {
            Description = description
        };

        // Act
        var result = await _validator.TestValidateAsync(request);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Description)
            .WithErrorMessage("Descrição do pra não pode ser nulo ou vazio");
    }

    [Theory]
    [InlineData(0)]
    public async Task ShouldHaveError_WhenPriceIsZeroOrLess(decimal price)
    {
        // Arrange
        var request = new UpdateMenuItemRequest
        {
            Price = price
        };

        // Act
        var result = await _validator.TestValidateAsync(request);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Price)
            .WithErrorMessage($"O valor de um prato não pode ser {0:C}");
    }
}