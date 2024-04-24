using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using FluentValidation;

namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Validators;

public class UpdateInformationRequestValidator : AbstractValidator<UpdateInformationRequest>
{
    public UpdateInformationRequestValidator()
    {
        When(i => i.Description is not null, () =>
        {
            RuleFor(i => i.Description)
                .NotEmpty()
                .WithMessage("A Descrição não pode ser vazia.");
        });

        When(i => i is not null && i.Schedule.Any(),
            () => { RuleForEach(i => i.Schedule).SetValidator(new UpdateScheduleRequestValidator()); });
    }
}