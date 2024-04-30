using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models;
using FluentValidation;
using FluentValidation.TestHelper;

namespace UnitTests.UseCases.MenuItems.v1.Create.Validators;

public class MenuItemResponseValidatorTests
{
    private readonly MenuItemResponseValidator _validator = new();

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void ShouldHaveError_When_NameIsEmpty(string name)
    {
        var response = new MenuItemResponse { Name = name };
        var result = _validator.TestValidate(response);

        result.ShouldHaveValidationErrorFor(mI => mI.Name)
            .WithErrorMessage("O Nome do prato não pode ser nulo ou vazio.");
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void ShouldHaveError_When_DescriptionIsEmpty(string description)
    {
        var response = new MenuItemResponse { Description = description };
        var result = _validator.TestValidate(response);

        result.ShouldHaveValidationErrorFor(mI => mI.Description)
            .WithErrorMessage("Descrição do prato não pode ser nulo ou vazio.");
    }

    [Theory]
    [InlineData(0)]
    public void ShouldHaveError_When_PriceIsInvalid(decimal price)
    {
        var response = new MenuItemResponse { Price = price };
        var result = _validator.TestValidate(response);

        result.ShouldHaveValidationErrorFor(mI => mI.Price)
            .WithErrorMessage($"O valor de um prato não pode ser {0:C}.");
    }
}

internal class MenuItemResponseValidator : AbstractValidator<MenuItemResponse>
{
    public MenuItemResponseValidator()
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