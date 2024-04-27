using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Validators;
using FluentValidation.TestHelper;

namespace UnitTests.UseCases.Restaurants.v1.Create.Validators;

public class CreateRestaurantInformationRequestValidatorTests
{
    private readonly CreateRestaurantInformationRequestValidator _validator = new();

    [Fact]
    public async Task ShouldHaveError_When_ScheduleIsEmpty()
    {
        
        var request = new InformationRequest { Schedules = Enumerable.Empty<ScheduleRequest>() };
        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(r => r.Schedules)
            .WithErrorMessage("É obrigatório definir um horário de funcionamento.");
    }
    
    [Fact]
    public async Task ShouldHaveError_When_ScheduleIsNull()
    {
        
        var request = new InformationRequest { Schedules = null! };
        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(r => r.Schedules)
            .WithErrorMessage("É obrigatório definir um horário de funcionamento.");
    }
}