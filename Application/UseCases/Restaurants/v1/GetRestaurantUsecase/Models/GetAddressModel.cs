using Application.Shared.Entities;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Models;

public record GetAddressModel
{
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

    public Guid Id { get; init; }
    public string? Street { get; init; }
    public string? Neighborhood { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string? Complement { get; init; }
    public string ZipCode { get; init; }
    public string? Number { get; init; }
}