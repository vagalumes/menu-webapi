using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using FluentValidation;

namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Validators
{
    public class UpdateScheduleRequestValidator : AbstractValidator<UpdateScheduleInformation>
    {
        public UpdateScheduleRequestValidator()
        {
            RuleFor(s => s.Day)
                .IsInEnum()
                .WithMessage("O dia de trabalho deve ser um dia válido");

            RuleFor(s => s.Start)
                .LessThan(s => s.End)
                .WithMessage("A data de início deve ser menor que a data de fim.");

            RuleFor(s => s.End)
                .GreaterThan(s => s.Start)
                .WithMessage("A data de fim deve ser maior que a data de início.");
        }
    }
}
