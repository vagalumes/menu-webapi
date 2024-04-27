using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Validators;
using FluentValidation.TestHelper;

namespace UnitTests.Application.Restaurants.v1.Update.Validators;

public class UpdateRestaurantRequestValidatorTests
{
    private readonly UpdateRestaurantRequestValidator _validator = new();
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public async Task ShouldHaveError_WhenNameIsEmpty(string name)
    {
        // Arrange
        var request = new UpdateRestaurantRequest
        {
            Name = name
        };

        // Act
        var result = await _validator.TestValidateAsync(request);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Name)
            .WithErrorMessage("O Nome do restaurante não pode ser nulo ou vazio.");
    }
}