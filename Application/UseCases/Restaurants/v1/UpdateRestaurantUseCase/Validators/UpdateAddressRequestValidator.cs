using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using FluentValidation;

namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Validators
{
    public class UpdateAddressRequestValidator : AbstractValidator<UpdateAddressRequest>
    {
        public UpdateAddressRequestValidator()
        {
            RuleFor(a => a.City)
                .NotEmpty()
                .WithMessage("Nome da cidade não pode ser vazio ou nulo.");
            
            RuleFor(a => a.State)
                .NotEmpty()
                .WithMessage("O estado é um campo obrigatório.");
            
            RuleFor(a => a.ZipCode)
                .NotEmpty()
                .WithMessage("O CEP é um campo obrigatório.")
                .MinimumLength(8)
                .WithMessage("O CEP deve conter no mínimo 8 dígitos.")
                .MaximumLength(8)
                .WithMessage("o CEP deve conter no máximo 8 dígitos.");
        }
    }
}
