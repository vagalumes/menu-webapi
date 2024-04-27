using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Validators;
using FluentValidation.TestHelper;

namespace UnitTests.UseCases.Restaurants.v1.Update.Validators;

public class UpdateInformationRequestValidatorTests
{
    private readonly UpdateInformationRequestValidator _validator = new();
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public async Task ShouldHaveError_WhenDescriptionIsEmpty(string description)
    {
        var request = new UpdateInformationRequest
        {
            Description = description
        };

        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(i => i.Description)
            .WithErrorMessage("A Descrição não pode ser vazia.");
    }
}