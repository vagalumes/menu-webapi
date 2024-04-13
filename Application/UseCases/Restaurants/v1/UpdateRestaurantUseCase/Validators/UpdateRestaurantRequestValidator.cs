using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using FluentValidation;

namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Validators
{
    public class UpdateRestaurantRequestValidator : AbstractValidator<UpdateRestaurantRequest>
    {
        public UpdateRestaurantRequestValidator()
        {
            When(r => r.Name is not null, () =>
            {
                RuleFor(r => r.Name)
                    .NotEmpty()
                    .WithMessage("O Nome do restaurante não pode ser nulo ou vazio.");
            });


            When(r => r.Address is not null, () =>
            {
                RuleFor(r => r.Address!).SetValidator(new UpdateAddressRequestValidator());
            });

            When(r => r.Information is not null, () =>
            {
                RuleFor(r => r.Information!).SetValidator(new UpdateInformationRequestValidator());
            });
        }
    }
}
