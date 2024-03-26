using Application.Shared.Entities;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Models
{
    public class GetRestaurantModel(Restaurant restaurant)
    {
        public Guid Id { get; set; } = restaurant.Id;
        public string Name { get; set; } = restaurant.Name;
        public string Cnpj { get; set; } = restaurant.Cnpj;
        public Information? Information { get; set; } = restaurant.Information;
        public Address Address { get; set; } = restaurant.Address;
    }
}
