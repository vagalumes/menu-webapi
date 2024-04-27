using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Models;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Validators;
using Bogus;
using FluentValidation.TestHelper;

namespace UnitTests.UseCases.Restaurants.v1.Update.Validators;

public class UpdateAddressRequestValidatorTests
{
    private readonly UpdateAddressRequestValidator _validator = new();
    private readonly Faker _faker = new();
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public async Task ShouldError_WhenCityIsEmpty(string city)
    {
        var request = new UpdateAddressRequest
        {
            City = city,
            State = _faker.Address.State(),
            ZipCode = _faker.Address.ZipCode()
        };

        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(a => a.City)
            .WithErrorMessage("Nome da cidade não pode ser vazio ou nulo.");
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public async Task ShouldHaveError_WhenStateIsEmpty(string state)
    {
        var request = new UpdateAddressRequest
        {
            City = _faker.Address.City(),
            State = state,
            ZipCode = _faker.Address.ZipCode()
        };

        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(a => a.State)
            .WithErrorMessage("O estado é um campo obrigatório.");
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public async Task ShouldHaveError_WhenZipCodeIsEmpty(string zipCode)
    {
        var request = new UpdateAddressRequest
        {
            City = _faker.Address.City(),
            State = _faker.Address.State(),
            ZipCode = zipCode
        };

        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(a => a.ZipCode)
            .WithErrorMessage("O CEP é um campo obrigatório.");
    }
    
    [Fact]
    public async Task ShouldHaveError_WhenZipCodeLessThanEightDigits()
    {
        var request = new UpdateAddressRequest
        {
            City = _faker.Address.City(),
            State = _faker.Address.State(),
            ZipCode = _faker.Random.String(7)
        };

        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(a => a.ZipCode)
            .WithErrorMessage("O CEP deve conter no mínimo 8 dígitos.");
    }
    
    [Fact]
    public async Task ShouldHaveError_WhenZipCodeMoreThanEightDigits()
    {
        var request = new UpdateAddressRequest
        {
            City = _faker.Address.City(),
            State = _faker.Address.State(),
            ZipCode = _faker.Random.String(9)
        };

        var result = await _validator.TestValidateAsync(request);

        result.ShouldHaveValidationErrorFor(a => a.ZipCode)
            .WithErrorMessage("o CEP deve conter no máximo 8 dígitos.");
    }
}