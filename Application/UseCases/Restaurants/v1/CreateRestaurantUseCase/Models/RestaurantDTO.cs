using Application.Shared.Entities;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models
{
    public class RestaurantDto(Restaurant restaurant)
    {
        public Guid Id { get; set; } = restaurant.Id;
        public string Name { get; set; } = restaurant.Name;
        public long Cnpj { get; set; } = restaurant.Cnpj;
        public Information? Information { get; set; } = restaurant.Information;
        public Payments Payments { get; set; } = restaurant.Payments;
        public Address Address { get; set; } = restaurant.Address;
    }
}
