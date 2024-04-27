using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Validators;
using Bogus;
using FluentValidation.TestHelper;

namespace UnitTests.Application.Restaurants.v1.Create.Validators;

public class CreateRestaurantRequestValidatorTests
{
    private readonly CreateRestaurantRequestValidator _validator = new();

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task ShouldHaveError_When_NameIsEmpty(string name)
    {
        var request = new CreateRestaurantRequest { Name = name };
        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(r => r.Name)
            .WithErrorMessage("O Nome do estabelecimento é um campo obrigatório.");
    }
    
    [Theory]
    [InlineData("123456789", "O CNPJ deve conter no mínimo 14 dígitos." )]
    [InlineData("123456789101234", "O CNPJ deve conter no máximo 14 dígitos.")]
    [InlineData(null, "O CNPJ do estabelecimento é um campo obrigatório.")]
    [InlineData("", "O CNPJ do estabelecimento é um campo obrigatório.")]
    [InlineData(" ", "O CNPJ do estabelecimento é um campo obrigatório." )]
    [InlineData("123abcd", "O CNPJ deve conter apenas números.")]
    public async Task ShouldHaveError_When_CnpjIsInvalid(string cnpj, string errorMessage)
    {
        var request = new CreateRestaurantRequest { Cnpj = cnpj };
        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(r => r.Cnpj)
            .WithErrorMessage(errorMessage);
    }
}