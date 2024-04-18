using Application.Shared.Entities;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Models;

public record GetAddressModel
{
    public Guid Id { get; init; }
    public string? Street { get; init; }
    public string? Neighborhood { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string? Complement { get; init; }
    public string ZipCode { get; init; }
    public string? Number { get; init; }

    public GetAddressModel(Address address)
    {
        Id = address.Id;
        Street = address.Street;
        Neighborhood = address.Neighborhood;
        City = address.City;
        State = address.State;
        Complement = address.Complement;
        ZipCode = address.ZipCode;
        Number = address.Number;
    }
}