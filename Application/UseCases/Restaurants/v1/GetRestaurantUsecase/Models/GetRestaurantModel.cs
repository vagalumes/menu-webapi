using Application.Shared.Entities;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Models;

public record GetRestaurantModel
{
    public GetRestaurantModel(Restaurant restaurant)
    {
        Id = restaurant.Id;
        Name = restaurant.Name;
        Cnpj = restaurant.Cnpj;
        ProfileImage = restaurant.ProfileImage;
        Information = new GetInformationModel(restaurant.Information);
        Address = new GetAddressModel(restaurant.Address);
    }

    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Cnpj { get; init; }
    public string ProfileImage { get; init; }
    public GetInformationModel? Information { get; init; }
    public GetAddressModel Address { get; init; }
}