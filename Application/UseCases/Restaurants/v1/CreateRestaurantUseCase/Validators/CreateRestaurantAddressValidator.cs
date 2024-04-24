using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using FluentValidation;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Validators;

public class CreateRestaurantAddressValidator : AbstractValidator<AddressRequest>
{
    public CreateRestaurantAddressValidator()
    {
        RuleFor(a => a.City)
            .NotEmpty()
            .WithMessage("Cidade é um campo obrigatório.");

        RuleFor(a => a.State)
            .NotEmpty()
            .WithMessage("Estado é um campo obrigatório.");

        RuleFor(a => a.ZipCode)
            .NotEmpty()
            .WithMessage("CEP é um campo obrigatório.")
            .MinimumLength(8)
            .WithMessage("CEP deve conter no mínimo 8 dígitos.")
            .MaximumLength(8)
            .WithMessage("CEP deve conter no máximo 8 dígitos");
    }
}