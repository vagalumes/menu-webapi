using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models;
using FluentValidation;

namespace Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Validators;

public class CreateMenuItemsRequestValidator : AbstractValidator<CreateMenuItemsRequest>
{
    public CreateMenuItemsRequestValidator()
    {
        RuleFor(mI => mI.Name)
            .NotEmpty()
            .WithMessage("O Nome do prato não pode ser nulo ou vazio.");

        RuleFor(mI => mI.Description)
            .NotEmpty()
            .WithMessage("Descrição do prato não pode ser nulo ou vazio.");

        RuleFor(mI => mI.Price)
            .GreaterThan(0)
            .WithMessage($"O valor de um prato não pode ser {0:C}.");
    }
}