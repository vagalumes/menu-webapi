using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using FluentValidation;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Validators
{
    public class CreateRestaurantRequestValidator : AbstractValidator<CreateRestaurantRequest>
    {
        public CreateRestaurantRequestValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("O Nome do estabelecimento é um campo obrigatório.");

            RuleFor(r => r.Cnpj)
                .MinimumLength(14)
                .WithMessage("O CNPJ deve conter no mínimo 14 dígitos.")
                .MaximumLength(14)
                .WithMessage("O CNPJ deve conter no máximo 14 dígitos. ")
                .NotEmpty()
                .WithMessage("O CNPJ do estabelecimento é um campo obrigatório.")
                .Matches("^[0-9]*$")
                .WithMessage("O CNPJ deve conter apenas números.");

            RuleFor(r => r.Address).SetValidator(new CreateRestaurantAddressValidator());

            RuleFor(r => r.Information).SetValidator(new CreateRestaurantInformationRequestValidator());
        }
    }
}
