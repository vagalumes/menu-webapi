using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Validators;
using FluentAssertions;
using FluentValidation.TestHelper;

namespace UnitTests.Application.Restaurants.v1.Create.Validators;

public class CreateRestaurantScheduleValidatorTests
{
    private readonly CreateRestaurantScheduleValidator _validator = new();
    
    [Fact]
    public async Task ShouldHaveError_When_EndLessThanStart()
    {
        var start = new TimeOnly(23, 0);
        var end = new TimeOnly(8, 0);
        var request = new ScheduleRequest { Start = start, End = end};
        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(r => r.Start)
            .WithErrorMessage("A data de início deve ser menor que a data de fim.");
    }
}