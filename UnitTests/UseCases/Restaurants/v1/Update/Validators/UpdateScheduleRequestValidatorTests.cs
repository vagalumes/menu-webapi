using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Validators;
using FluentValidation.TestHelper;

namespace UnitTests.UseCases.Restaurants.v1.Update.Validators;

public class UpdateScheduleRequestValidatorTests
{
    private readonly UpdateScheduleRequestValidator _validator = new();
    
    [Fact]
    public async Task ShouldHaveError_WhenDayIsInvalid()
    {
        var model = new UpdateScheduleInformation
        {
            Day = (DayOfWeek) 7,
            Start = new TimeOnly(8, 0, 0),
            End = new TimeOnly(18, 0, 0)
        };

        var result = await _validator.TestValidateAsync(model);

        result.ShouldHaveValidationErrorFor(s => s.Day)
            .WithErrorMessage("O dia de trabalho deve ser um dia válido");
    }
    
    [Fact]
    public async Task ShouldHaveErrorWhen_StartIsGreaterThanEnd()
    {
        var model = new UpdateScheduleInformation
        {
            Day = DayOfWeek.Monday,
            Start = new TimeOnly(18, 0, 0),
            End = new TimeOnly(8, 0, 0)
        };

        var result = await _validator.TestValidateAsync(model);

        result.ShouldHaveValidationErrorFor(s => s.Start)
            .WithErrorMessage("A data de início deve ser menor que a data de fim.");
    }
}