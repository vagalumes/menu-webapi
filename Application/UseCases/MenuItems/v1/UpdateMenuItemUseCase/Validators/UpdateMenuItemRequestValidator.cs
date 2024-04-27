using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Models;
using FluentValidation;

namespace Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Validators;

public class UpdateMenuItemRequestValidator : AbstractValidator<UpdateMenuItemRequest>
{
    public UpdateMenuItemRequestValidator()
    {
        When(mI => mI.Name is not null, () =>
        {
            RuleFor(mI => mI.Name)
                .NotEmpty()
                .WithMessage("O Nome do prato não pode ser nulo ou vazio.");
        });

        When(mI => mI.Description is not null, () =>
        {
            RuleFor(mI => mI.Description)
                .NotEmpty()
                .WithMessage("Descrição do pra não pode ser nulo ou vazio");
        });

        When(mI => mI.Price == 0, () =>
        {
            RuleFor(mI => mI.Price)
                .GreaterThan(0)
                .WithMessage($"O valor de um prato não pode ser {0:C}");
        });
    }
}