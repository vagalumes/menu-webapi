using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Validators;
using Bogus;
using FluentValidation.TestHelper;

namespace UnitTests.Application.Restaurants.v1.Validators;

public class CreateRestaurantAddressValidatorTests
{
    private readonly CreateRestaurantAddressValidator _validator = new();
    private readonly Faker _faker = new();

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public async Task ShouldHaveError_When_CityIsEmpty(string? value)
    {
        var request = new AddressRequest { City = value! };
        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(a => a.City)
            .WithErrorMessage("Cidade é um campo obrigatório.");
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public async Task ShouldHaveError_When_StateIsEmpty(string? value)
    {
        var request = new AddressRequest { State = value! };
        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(a => a.State)
            .WithErrorMessage("Estado é um campo obrigatório.");
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public async Task ShouldHaveError_When_ZipCodeIsEmpty(string? value)
    {
        var request = new AddressRequest { ZipCode = value! };
        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(a => a.ZipCode)
            .WithErrorMessage("CEP é um campo obrigatório.");
    }
    
    [Fact]
    public async Task ShouldHaveError_When_ZipCodeHaveLessThanEightDigits()
    {
        var request = new AddressRequest { ZipCode = _faker.Random.Number(9999999).ToString() };
        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(a => a.ZipCode)
            .WithErrorMessage("CEP deve conter no mínimo 8 dígitos.");
    }
    
    [Fact]
    public async Task ShouldHaveError_When_ZipCodeHaveMoreThanEightDigits()
    {
        var request = new AddressRequest { ZipCode = _faker.Random.Number(max: 999999999, min: 999999991).ToString() };
        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(a => a.ZipCode)
            .WithErrorMessage("CEP deve conter no máximo 8 dígitos.");
    }
}