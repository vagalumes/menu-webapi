﻿using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Validators;
using FluentValidation.TestHelper;

namespace UnitTests.UseCases.MenuItems.v1.Create.Validators;

public class CreateMenuItemRequestValidatorTests
{
    private readonly CreateMenuItemsRequestValidator _validator = new();

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task ShouldHaveError_When_NameIsEmpty(string name)
    {
        var request = new CreateMenuItemsRequest { Name = name };
        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(mI => mI.Name)
            .WithErrorMessage("O Nome do prato não pode ser nulo ou vazio.");
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task ShouldHaveError_When_DescriptionIsEmpty(string description)
    {
        var request = new CreateMenuItemsRequest { Description = description };
        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(mI => mI.Description)
            .WithErrorMessage("Descrição do prato não pode ser nulo ou vazio.");
    }

    [Theory]
    [InlineData(0)]
    public async Task ShouldHaveError_When_PriceIsInvalid(decimal price)
    {
        var request = new CreateMenuItemsRequest { Price = price };
        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(mI => mI.Price)
            .WithErrorMessage($"O valor de um prato não pode ser {0:C}.");
    }
}